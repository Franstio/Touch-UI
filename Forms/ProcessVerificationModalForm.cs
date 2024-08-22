using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestTCP1.Lib;
using TestTCP1.Model;

namespace TestTCP1.Forms
{
    public partial class ProcessVerificationModalForm : Form
    {
        private readonly DbConn dbCon = new DbConn();
        private readonly FileLib fileLib = new FileLib();
        private PositionModel positionModel = new PositionModel();
        public string _image { get; set; } = string.Empty;
        public string _imageFull { get; set; } = string.Empty;
        private bool isPassed = false;
        private string _img = string.Empty;
        private ImageAreaModel _area;
        public bool resultVerification { get; set; } = false;
        public ProcessVerificationModalForm(PositionModel pos,ImageAreaModel model, bool isPassed, string img)
        {
            InitializeComponent();
            positionModel = pos;
            _area = model;
            this.isPassed = isPassed;
            _img = img;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            resultVerification = true;
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private async Task LoadImage(ImageAreaModel position, bool isPassed)
        {
            if (_img is null || _img == string.Empty)
            {
                MessageBox.Show("Image Path is Empty");
                DialogResult = DialogResult.Cancel;
                this.Close();
                return;
            }
            string parameterImg = await dbCon.GetLocalImage(position);
            if (!isPassed)
                GetTriggerImgPath(_img);
            pictureBox1.Image = fileLib.ReadImage(_img, isPassed) ;
            pictureBox2.Image = fileLib.ReadImage(parameterImg, true);
            //Thread.Sleep(5);
            //string imgPath = isPassed ? await dbCon.GetLocalImage(position) : GetTriggerImgPath();
            //                string imgPath = isPassed ? await dbCon.GetLocalImage(Positions[i]) : GetTriggerImgPath();
            //pictureBox1.Invoke(new Action(() =>
            //{
            //    pictureBox1.Image = fileLib.ReadImage(_img, isPassed);//isPassed ? fileLib.ReadImage(imgPath) : Image.FromFile(imgPath);
            //}));
        }
        private string GetTriggerImgPath(string pathImg)
        {
            FileInfo file = new FileInfo(Path.Combine(fileLib._ngSavePath,pathImg));
            _image = file.Name;
            _imageFull = file.FullName;
            return pathImg;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            resultVerification = false;
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private async void ProcessVerificationModalForm_Load(object sender, EventArgs e)
        {

            var data = (await dbCon.GetAreaImageByModel(_area.Model, _area.Position, _area.No)).First();
            this.label1.Text = "Verification: " + data.AreaInspection;
            await LoadImage(this._area, isPassed);
        }
    }
}
