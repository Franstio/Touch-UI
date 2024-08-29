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
        private List<PositionModel> _posData = new List<PositionModel>();
        private TCPConn mainConn = TCPConn.newInstance();
        private readonly int CameraDelay = 0;
        private readonly int DelayTimer = 0;
        private string sourceImage = string.Empty;
        private string? areaName;
        public AreaImageForm(string model, string? areaName = null, bool _isDelete = false, bool _isView = false)
        {
            InitializeComponent();
            modelName = model;
            isView = _isView;
            isDelete = _isDelete;
            this.areaName = areaName;
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
            var check = await dbCon.GetPositionByModel(modelName);
            if (check is null || check.Count < 1)
            {
                MessageBox.Show($"Model Data {modelName} Position not exists");
                Close();
                return;
            }
            allAreas = await dbCon.GetAreaImageByModel(modelName);
            _posData = await dbCon.GetPositionByModel(modelName);
            positionBox.Items.AddRange(_posData.Select(x => (object)x.Pos).OrderBy(x => x).ToArray());
            positionBox.SelectedIndex = 0;
            if (isDelete || isView)
            {
                panelNewArea.Visible = false;
                if (isDelete)
                {
                    actionButton.Text = "Delete";
                    areaNameBox.DropDownStyle = ComboBoxStyle.DropDownList;
                    areaNameBox.Items.AddRange(allAreas.Select(x => x.AreaInspection).Distinct().ToArray());
                    areaNameBox.DisplayMember = "AreaInspection";
                    if (allAreas.Any())
                        areaNameBox.Text = allAreas.FirstOrDefault()!.AreaInspection;
                    positionBox.Items.Clear();
                    var availablePos = allAreas.Where(x => x.AreaInspection == areaNameBox.Items[0].ToString()).Select(x => x.Position).ToArray();
                    positionBox.Items.AddRange(availablePos.Select(x => (object)x).ToArray());
                    positionBox.SelectedIndex = 0;
                }
                else if (isView)
                {
                    var queryAreaData = allAreas.Where(x => x.Model == modelName && x.AreaInspection == areaName).First();
                    positionBox.Text = queryAreaData.Position.ToString();
                    position = queryAreaData.Position;
                    if (check is null || check.Count < 1 || !check.Any(x => x.Pos == position))
                    {
                        MessageBox.Show($"Model Data {modelName} in position {position} is not exists");
                        Close();
                        return;
                    }
                    areaNameBox.Text = queryAreaData.AreaInspection;
                    areaImage.Image = fileLib.ReadImage(queryAreaData.Image,true);
                    actionButton.Visible = false;
                    areaNameBox.Enabled = false;
                    positionBox.Enabled = false;
                }
            }

        }
        private async Task DeleteArea()
        {
            if (int.TryParse(positionBox.Text, out position))
            {
                var pinpoint = allAreas.Where(x => x.AreaInspection == areaNameBox.Text).First();
                await dbCon.DeleteAreaImage(modelName, position,pinpoint.No);
                DialogResult = DialogResult.OK;
                Close();
            }
        }
        private async void actionButton_Click(object sender, EventArgs e)
        {
            if (isDelete)
            {
                await DeleteArea();
                return;
            }
            if (!int.TryParse(positionBox.Text, out position))
            {
                MessageBox.Show("Issue Parsing Position Box");
                return;
            }
            int pinpointNo = allAreas.Where(x => x.Model==modelName&&x.Position==position).LastOrDefault()?.No ?? 0;
            string type = sourceImage.Split('.').Last();
            string fileName = $"{modelName}_{position}_{pinpointNo+1}.{type}";
            var areaData = new ImageAreaModel()
            {
                AreaInspection = areaNameBox.Text,
                Image = fileName,
                Model = modelName,
                Position = position,
                No = pinpointNo+1,
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
            areaImage.ImageLocation = uploadPhotoDialog.FileName;
            sourceImage = uploadPhotoDialog.FileName;
        }

        private async void button2_Click(object sender, EventArgs e)
        {

            this.button2.Invoke(new Action(() => { button2.Text = "Loading..."; button2.Enabled = false; }));
            await mainConn.SendCommand($"WR W0F2 {_posData.First().CameraCheckpoint}");
            await mainConn.SendCommand("WR MR400 1");
            await Task.Delay(CameraDelay);
            await mainConn.SendCommand("WR MR400 0");
            //            MessageBox.Show("Send Trigger Command Complete", "Send Trigger Command");
            await Task.Delay(DelayTimer);

            //            this.button2.Invoke(new Action(() => { button2.Enabled = true; }));
        }
        private void OnTriggerImageCreated(object sender, FileSystemEventArgs e)
        {
            if (button2.Enabled)
                return;
            sourceImage = e.FullPath;
            button2.Enabled = true;
            button2.Text = "Trigger";
        }
        private void triggerWatcher_Error(object sender, ErrorEventArgs e)
        {
            MessageBox.Show(e.GetException().Message);
        }

        private void areaNameBox_TextUpdate(object sender, EventArgs e)
        {
            if (!isDelete)
                return;
            positionBox.Items.Clear();
            var availablePos = allAreas.Where(x => x.AreaInspection == areaNameBox.Text).Select(x => x.Position).ToArray();
            positionBox.Items.AddRange(availablePos.Select(x => (object)x).ToArray());
            positionBox.SelectedIndex = 0;
        }

        private void positionBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            areaImage.Image = fileLib.ReadImage(allAreas.Where(x => x.AreaInspection == areaNameBox.Text && x.Position==int.Parse(positionBox.Text)).First().Image, true);
        }

        private void areaNameBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (!isDelete)
                return;
            positionBox.Items.Clear();
            var availablePos = allAreas.Where(x => x.AreaInspection == areaNameBox.Text).Select(x => x.Position).ToArray();
            positionBox.Items.AddRange(availablePos.Select(x => (object)x).ToArray());
            positionBox.SelectedIndex = 0;
            areaImage.Image = fileLib.ReadImage(allAreas.Where(x => x.AreaInspection == areaNameBox.Text).First().Image,true);
        }
    }
}
