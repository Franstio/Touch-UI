using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestTCP1.Lib;
using TestTCP1.Model;

namespace TestTCP1.Forms
{
    public partial class SettingForm : UserControl
    {

        private readonly Mapper map = AutoMapConfig.GetMapper();
        public SettingForm()
        {
            InitializeComponent();
            setText();
            dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[]{
                new DataColumn("Pos."),
                new DataColumn("Model"),
                new DataColumn("X"),
                new DataColumn("Y"),
                new DataColumn("Z"),
                new DataColumn("Camera Checkpoint")
            });
            dataGridView1.DataSource = dt;
            preventNegativeValue();

        }
        public List<PosView> Positions = new List<PosView>();

        public int jogSpeed
        {
            set;
            get;
        }
        private int position
        {
            get; set;
        }

        private Dictionary<string, decimal> positionMap = new Dictionary<string, decimal>()
        {
            {"X",0 },
            {"Y",0 },
            {"Z",0}
        };

        private TCPConn conn = TCPConn.newInstance();
        private DbConn dbCon = new DbConn();
        private DataTable dt;


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            jogSpeed = trackBar1.Value;
            jogSpeedLabel.Text = $"Jog Speed: {jogSpeed}";
        }

        private async void button10_Click(object sender, EventArgs e)
        {
            string res = await conn.SendCommand("RD CM5014");
            string msg = $"Send RD CM8830.L -> Return: {res}";
            MessageBox.Show(msg, "Result");


        }

        private async void button6_Click(object sender, EventArgs e)
        {

            await conn.SendCommand("WR MR12 1");
            var res = await conn.SendCommand("RD CM8870");
            updatePositionMap("Y", decimal.Parse(res));

        }

        private async void button7_Click(object sender, EventArgs e)
        {

            await conn.SendCommand("WR MR13 1");
            var res = await conn.SendCommand("RD CM8870.L");
            updatePositionMap("Y", decimal.Parse(res));

        }

        private async void button4_Click(object sender, EventArgs e)
        {
            await conn.SendCommand("WR MR15 1");
            var res = await conn.SendCommand("RD CM8830.L");
            updatePositionMap("X", decimal.Parse(res));

        }

        private async void button3_Click(object sender, EventArgs e)
        {

            await conn.SendCommand("WR MR14 1");
            var res = await conn.SendCommand("RD CM8830.L");
            updatePositionMap("X", decimal.Parse(res));

        }

        private async void button9_Click(object sender, EventArgs e)
        {

            await conn.SendCommand("WR MR10 1");
            var res = await conn.SendCommand("RD CM8910.L");
            updatePositionMap("Z", decimal.Parse(res));
        }

        private async void button8_Click(object sender, EventArgs e)
        {

            await conn.SendCommand("WR MR11 1");
            var res = await conn.SendCommand("RD CM8910.L");
            updatePositionMap("Z", decimal.Parse(res));
        }
        private void setText()
        {
            textBox1.Text = $"X = {positionMap["X"].ToString("0.00")},Y = {positionMap["Y"].ToString("0.00")},Z = {positionMap["Z"].ToString("0.00")}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            position = position - 1;
            label2.Text = $"Position: {position}";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            position = position + 1;
            label2.Text = $"Position: {position}";

        }


        private async void button5_Click(object sender, EventArgs e)
        {
            //if (TCPConn.isRunning)
            //    await conn.StopConnection();
            //else
            //    await conn.StartConnection();
            button5.Invoke(new Action(() => { button5.Enabled = false; }));
            if (!conn.IsRunning())
            {
                await conn.StartConnection();
                MessageBox.Show($"Connection is {(conn.IsRunning()? "On" : "Off")} ");
                button5.Invoke(new Action(() => { button5.Enabled = true; }));
                return;
            }
            button5.Invoke(new Action(() => { button5.Enabled = true; }));
        }
        private void updatePositionMap(string label, decimal newPos)
        {
            newPos = (newPos / 1600) * 20;
            positionMap[label] = newPos;
            preventNegativeValue();
            setText();
        }
        private void preventNegativeValue()
        {

            button4.Enabled = positionMap["X"] >= 0.1m;

            button7.Enabled = positionMap["Y"] >= 0.1m;

            button8.Enabled = positionMap["Z"] >= 0.1m;
        }

        private async void button14_Click(object sender, EventArgs e)
        {
            PosView pos = new PosView()
            {
                Pos = position,
                X = positionMap["X"],
                Y = positionMap["Y"],
                Z = positionMap["Z"],
                CameraCheckpoint = textBox2.Text,
                Model = modelBox.Text
            };
            PosView? find = Positions.Where(x => x.Pos == pos.Pos).FirstOrDefault();
            if (find is not null)
            {
                int index = Positions.IndexOf(find);
                Positions[index].X = pos.X;
                Positions[index].Y = pos.Y;
                Positions[index].Z = pos.Z;
                Positions[index].CameraCheckpoint = pos.CameraCheckpoint;
            }
            else
                Positions.Add(pos);
            await dbCon.SavePosition(pos);
            await LoadDataGridView1();
        }

        private async void button17_Click(object sender, EventArgs e)
        {
            button17.Invoke(new Action(() => { button17.Enabled = false; }));
            if (!conn.IsRunning())
                await conn.StartConnection();
            var list = await dbCon.GetPositionByModel(modelBox.Text);
            foreach (var item in list)
                dt.Rows.Add(item.GetValues());
            button17.Invoke(new Action(() => { button17.Enabled = true; }));
            await LoadDataGridView1();
        }

        private async void button16_Click(object sender, EventArgs e)
        {
            this.button16.Enabled = false;
            await conn.SendCommand($"WR W0F2 {textBox2.Text}");
            await conn.SendCommand("WR MR400 1");
            await Task.Delay(1000);
            await conn.SendCommand("WR MR400 0");
            MessageBox.Show("Send Trigger Command Complete", "Send Trigger Command");
            this.button16.Enabled = true;
        }

        private async Task LoadDataGridView1()
        {
            Positions = map.Map<List<PosView>>( await dbCon.GetPositionByModel(modelBox.Text));
            if (Positions.Count < 1)
                return;
            dataGridView1.DataSource = Positions;
        }

        private void SettingForm_Load(object sender, EventArgs e)
        {
            label2.Text = "Position: " + position;
        }
    }
}
