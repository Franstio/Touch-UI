using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestTCP1.Lib;
using TestTCP1.Model;

namespace TestTCP1.Forms
{
    public partial class AreaImageForm : Form
    {
        private bool isDelete = false;
        private bool isView = false;
        private int position = -1;
        private DbConn dbCon = new DbConn();
        private FileLib fileLib = new FileLib();
        private readonly string modelName;
        private List<ImageAreaModel> allAreas = new List<ImageAreaModel>();
        private ImageAreaModel _areaData = new ImageAreaModel();
        private PositionModel _posData = new PositionModel();
        private TCPConn mainConn = TCPConn.newInstance();
        private readonly int CameraDelay = 0;
        private readonly int DelayTimer = 0;
        private string sourceImage = string.Empty;
        private ImageAreaModel areaData
        {
            get => _areaData;
            set
            {
                if (areaNameBox.IsHandleCreated)
                    areaNameBox.Text = value.AreaInspection;
                _areaData = value;
            }
        }
        public AreaImageForm(string model, bool _isDelete = false, bool _isView = false, int _position = -1)
        {
            InitializeComponent();
            modelName = model;
            isView = _isView;
            isDelete = _isDelete;
            position = _position;
            CameraDelay = Properties.Settings.Default.CameraDelay;
            DelayTimer = Properties.Settings.Default.DelaySettingParameter;
            triggerWatcher.Path = fileLib._filePath;
            triggerWatcher.Created += OnTriggerImageCreated;
        }

        private async void AreaImageForm_Load(object sender, EventArgs e)
        {
            actionButton.Text = "Submit";
            actionButton.Visible = true;
            areaNameBox.Enabled = true;
            allAreas = await dbCon.GetAreaImageByModel(modelName);
            _posData = (await dbCon.GetPositionByModel(modelName)).First();
            if (isDelete || isView)
            {
                panelNewArea.Visible = false;
                if (isDelete)
                {
                    actionButton.Text = "Delete";
                    areaNameBox.Items.AddRange(allAreas.ToArray());
                    areaNameBox.DisplayMember = "AreaInspection";
                    if (allAreas.Any())
                        areaData = allAreas.FirstOrDefault()!;
                }
                else if (isView)
                {
                    var queryAreaData = await dbCon.GetAreaImageByModel(modelName, position);
                    if (position == -1 || queryAreaData is null || queryAreaData.Count < 1)
                    {
                        MessageBox.Show("Position Is Not Provided");
                        Close();
                        return;
                    }
                    areaData = queryAreaData.First();
                    actionButton.Visible = false;
                    areaNameBox.Enabled = false;
                }
            }
            else
                position = allAreas.Count + 1;

        }
        private async Task DeleteArea()
        {
            areaData = (ImageAreaModel)areaNameBox.SelectedItem;
            await dbCon.DeleteAreaImage(modelName, areaData.Position);
            DialogResult = DialogResult.OK;
            Close();
        }
        private async void actionButton_Click(object sender, EventArgs e)
        {
            if (isDelete)
            {
                await DeleteArea();
                return;
            }
            string type = sourceImage.Split('.').Last();
            string fileName = $"{modelName}_{position}.{type}";
            areaData = new ImageAreaModel()
            {
                AreaInspection = areaNameBox.Text,
                Image = fileName,
                Model = modelName,
                Position = position
            };
            await dbCon.SaveImage(areaData);
            fileLib.SaveImage(sourceImage, areaData.Image);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var dialog = uploadPhotoDialog.ShowDialog();
            if (dialog != DialogResult.OK)
                return;
            sourceImage = uploadPhotoDialog.FileName;
            areaImage.ImageLocation = uploadPhotoDialog.FileName;
        }

        private async void button2_Click(object sender, EventArgs e)
        {

            this.button2.Invoke(new Action(() => {button2.Text  = "Loading..."; button2.Enabled = false; }));
            /*await mainConn.SendCommand($"WR W0F2 {_posData.CameraCheckpoint}");
            await mainConn.SendCommand("WR MR400 1");
            await Task.Delay(CameraDelay);
            await mainConn.SendCommand("WR MR400 0");*/
            //            MessageBox.Show("Send Trigger Command Complete", "Send Trigger Command");
            await Task.Delay(DelayTimer);

//            this.button2.Invoke(new Action(() => { button2.Enabled = true; }));
        }
        private void OnTriggerImageCreated(object sender,FileSystemEventArgs e)
        {
            if (button2.Enabled)
                return;
            areaImage.ImageLocation = e.FullPath;
            sourceImage = e.FullPath;
            button2.Enabled = true;
            button2.Text = "Trigger";
        }
        private void triggerWatcher_Error(object sender, ErrorEventArgs e)
        {
            MessageBox.Show(e.GetException().Message);
        }
    }
}
