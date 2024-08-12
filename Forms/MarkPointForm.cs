using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestTCP1.Lib;
using TestTCP1.Lib.DbUtil;
using TestTCP1.Model;

namespace TestTCP1.Forms
{
    public partial class MarkPointForm : Form
    {
        private readonly string model;
        private bool controlState = false;
        private readonly IMarkPointDb conn = new DbConn();
        private string originalPathImage = string.Empty;
        private string originalFileName = string.Empty;
        private List<ImageAreaModel> posModels = new List<ImageAreaModel>();
        private List<MarkPointModel> markModels = new List<MarkPointModel>();
        private MarkPointModel newModel = new MarkPointModel();
        private FileLib fileLib = new FileLib();
        public MarkPointForm(string _model)
        {
            InitializeComponent();
            model = _model;
            dataGridView1.Columns.Add("AreaInspection", "Area Inspection");
            DataGridViewButtonColumn col = new DataGridViewButtonColumn()
            {
                HeaderText = "*",
                Text = "Remove",
                Name = "action",
                UseColumnTextForButtonValue = true
            };
            dataGridView1.Columns.Add(col);
        }
        private void LoadDataGridView()
        {
            this.dataGridView1.Rows.Clear();
            for (int i = 0; i < markModels.Count; i++)
                this.dataGridView1.Rows.Add(new object[] { markModels[i].AreaInspection });
            dataGridView1.Refresh();
        }
        private async Task RemoveMarkPoint(MarkPointModel model)
        {
            await conn.RemoveMarkPoint(model);
            var list = await conn.GetMarkPoint(this.model);
            if (list is null)
                return;
            markModels = list.ToList();
            this.dataGridView1.Invoke(LoadDataGridView);
            this.Invoke(new Action(LoadComboBox));
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var resultDialog = uploadImageDialog.ShowDialog();
            if (resultDialog != DialogResult.OK)
                return;
            originalFileName = uploadImageDialog.SafeFileName;
            try
            {
                fileLib.SaveImage(uploadImageDialog.FileName, originalFileName, manualPath: fileLib._markSaveDir);
                Image img = fileLib.ReadImage(originalFileName, manualPath: fileLib._markSaveDir)!;
                pictureBox1.Image = img;
                SetControlState(false);
                originalPathImage = Path.Combine(fileLib._markSaveDir, originalFileName);
                var data = await conn.GetMarkPoint(model);
                if (data is null) return;
                markModels = data.ToList();
                this.Invoke(LoadDataGridView);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                MessageBox.Show("Upload Failed");
            }
        }
        private void SetControlState(bool enable)
        {
            button2.Enabled = enable;
            comboBox1.Enabled = enable;
            controlState = enable;
            button3.Enabled = enable;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (controlState)
                return;
            MouseEventArgs m = (MouseEventArgs)e;
            PointF curLoc = DrawMark(m.Location, Color.Red);
            SetControlState(true);
            newModel = new MarkPointModel()
            {
                X = curLoc.X,
                Y = curLoc.Y,
                Model = model,
                ImageName = originalFileName
            };
        }
        private void clearMarkPoint()
        {
            pictureBox1.Image = Image.FromFile(originalPathImage);
        }
        private PointF DrawMark(PointF p, Color color,Image? img = null,PictureBox? frame = null)
        {
            const float sizeDot = 0.01f;
            Image originalImage = img ?? pictureBox1.Image;
            frame = frame ?? pictureBox1;
            Graphics graph = Graphics.FromImage(originalImage);
            float factorX = (float)frame.Width / originalImage.Width;
            float factorY = (float)frame.Height / originalImage.Height;
            Pen pen = new Pen(color, frame.Width * sizeDot);
            graph.DrawEllipse(pen, new RectangleF(p.X / factorX, p.Y / factorY, frame.Width * sizeDot, frame.Height * sizeDot));
            frame.Refresh();
            return new PointF(p.X / factorX, p.Y / factorY);
        }
        
        private async void MarkPointForm_Load(object sender, EventArgs e)
        {
            var ret = await conn.GetMarkPoint(model);
            if (ret is null)
            {
                MessageBox.Show("Model Data is Empty");
                this.Close();
                return;
            }
            if (ret.Count() > 0)
            {
                var first = ret.First();
                originalPathImage = Path.Combine(fileLib._markSaveDir, first.ImageName);
                originalFileName = first.ImageName;
                pictureBox1.Image = fileLib.ReadImage(originalPathImage, manualPath: fileLib._markSaveDir);
                pictureBox1.Refresh();
            }
            posModels = await ((DbConn)conn).GetAreaImageByModel(model);
            markModels = ret.ToList();
            this.Invoke(new Action(LoadDataGridView));
            this.Invoke(new Action(LoadComboBox));
            for (int i = 0; i < markModels.Count; i++)
                if (pictureBox1.Image is not null)
                    DrawMark(conn.CalibratePoint(markModels[i],pictureBox1.Image,pictureBox1), Color.Gray);
            SetControlState(false);
        }
        private void LoadComboBox()
        {
            comboBox1.SelectedItem = null;
            comboBox1.Text = string.Empty;
            comboBox1.Items.Clear();
            var d = posModels.Where(x => !markModels.Any(z => z.AreaInspection == x.AreaInspection)).ToArray();
            comboBox1.Items.AddRange(d);
            comboBox1.DisplayMember = "AreaInspection";
            comboBox1.ValueMember = "Pos";
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            var item = (ImageAreaModel)comboBox1.SelectedItem;
            newModel.AreaInspection = item.AreaInspection;
            newModel.Position = item.Position;
            await conn.SaveMarkPoint(newModel);
            var data = await conn.GetMarkPoint(model);
            if (data is null)
                return;
            markModels = data.ToList();
            clearMarkPoint();
            LoadDataGridView();
            for (int i = 0; i < markModels.Count; i++)
                if (pictureBox1.Image is not null)
                    DrawMark(conn.CalibratePoint(markModels[i],pictureBox1.Image!,pictureBox1), Color.Gray);
            SetControlState(false);
            this.Invoke(LoadComboBox);
        }



        private async void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Invoke(new Action(() => SetControlState(false)));
            var _data = markModels[e.RowIndex];
            if (dataGridView1[e.ColumnIndex, e.RowIndex] is DataGridViewButtonCell)
            {
                await RemoveMarkPoint(_data);
                var data = await conn.GetMarkPoint(model);
                if (data is null)
                    return;
                markModels = data.ToList();
                this.Invoke(new Action(() =>
                {
                    clearMarkPoint();
                    LoadDataGridView();
                    for (int i = 0; i < markModels.Count; i++)
                        if (pictureBox1.Image is not null)
                            DrawMark(conn.CalibratePoint(markModels[i],pictureBox1.Image,pictureBox1), Color.Gray);
                }));
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            this.Invoke(new Action(() => SetControlState(false)));
            var _data = markModels[e.RowIndex];
            this.Invoke(new Action(() =>
            {
                comboBox1.Text = _data.AreaInspection;
                clearMarkPoint();
                LoadDataGridView();
                dataGridView1.Rows[0].Selected = false;
                dataGridView1.Rows[e.RowIndex].Selected = true;
                dataGridView1.CurrentCell = dataGridView1[0, e.RowIndex];
                pictureBox1.Image = fileLib.ReadImage(_data.ImageName, manualPath: fileLib._markSaveDir);
                //for (int i = 0; i < markModels.Count; i++)
                //    DrawMark(new PointF(markModels[i].X, markModels[i].Y), Color.Gray);
                if (pictureBox1.Image is not null)
                    DrawMark(conn.CalibratePoint(_data,pictureBox1.Image!,pictureBox1), Color.Navy);
            }));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SetControlState(false);
            clearMarkPoint();
            for (int i = 0; i < markModels.Count; i++)
                if (pictureBox1.Image is not null)
                DrawMark(conn.CalibratePoint(markModels[i],pictureBox1.Image,pictureBox1), Color.Gray);
        }
    }
}
