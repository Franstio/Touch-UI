using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestTCP1.Lib;
using TestTCP1.Model;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace TestTCP1.Forms
{
    public partial class ProcessForm : UserControl
    {
        private Dictionary<string, decimal> positionMap = new Dictionary<string, decimal>()
        {
            {"X",0 },
            {"Y",0 },
            {"Z",0}
        };
        private List<JudgementView> Data = new List<JudgementView>();
        DataTable dt = new DataTable();
        private readonly TCPConn conn = TCPConn.newInstance();
        public ProcessForm(List<PositionModel> positions)
        {
            InitializeComponent();
            foreach (var pos in positions)
            {
                JudgementView? v = AutoMapConfig.GetMapper().Map<JudgementView>( pos) ;
                if (v is null)
                    continue;
                v.Judgement = "-";
                Data.Add(v);
            }

            dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[]{
                new DataColumn("Pos."),
                new DataColumn("Model"),
                new DataColumn("X"),
                new DataColumn("Y"),
                new DataColumn("Z"),
                new DataColumn("Camera Checkpoint"),
                new DataColumn("Judgement")
            });
            dataGridView1.DataSource = dt;
            LoadDataGridView();
        }
        private void LoadDataGridView()
        {
            dataGridView1.DataSource = Data;
            dataGridView1.Refresh();
        }
        private void setText()
        {
            textBox1.Text = $"X = {positionMap["X"]},Y = {positionMap["Y"]},Z = {positionMap["Z"]}";
        }
        private void updatePositionMap(string label, decimal newPos)
        {
            newPos = (newPos / 1600) * 20;
            positionMap[label] = newPos;
            setText();
        }

        private void ProcessForm_Load(object sender, EventArgs e)
        {
            Task.Run( AutoProcess);
        }
        private async Task AutoProcess()
        {
            if (conn.IsRunning())
                await conn.StartConnection();
            textBox1.Invoke(new Action(() =>
            {
                textBox1.Text += " (Processing)";
            }));
            for (int i = 0; i < Data.Count; i++)
            {
                positionMap["X"] = Data[i].X;
                positionMap["Y"] = Data[i].Y;
                positionMap["Z"] = Data[i].Z;
                textBox1.Invoke(new Action(() =>
                {
                    setText();
                    textBox1.Text += " (Processing)";
                }));
                var res = await StartJudgement(positionMap["X"], positionMap["Y"], positionMap["Z"]);
                res = await Trigger(Data[i].CameraCheckpoint);
                Data[i].Judgement = res ? "OK" : "NG";
                dataGridView1.Invoke(new Action(() => LoadDataGridView()));
            }
            await StartJudgement(0, 0, 0);
            textBox1.Invoke(new Action(() =>
            {
                setText();
                textBox1.Text += " (Complete)";
            }));
        }
        private async Task<bool> StartJudgement(decimal x, decimal y, decimal z)
        {
            await conn.SendCommand("WR MR300 0");
            string res = string.Empty;
            string xVal = String.Format("{0:0}", x * 1600 / 20);
            string yVal = String.Format("{0:0}",y * 1600 / 20);
            string zVal = String.Format("{0:0}", z * 1600 / 20);
            res = await conn.SendCommand($"WR CM8010 {xVal}");
            res = await conn.SendCommand($"WR CM8210 {yVal}");
            res = await conn.SendCommand($"WR CM8410 {zVal}");

            await conn.SendCommand("WR MR300 1");
            bool[] confirms = new bool[3];
            do
            {
                confirms[0] =  (await conn.SendCommand($"RD CR8401")).Contains("1");
                confirms[1] = (await  conn.SendCommand($"RD CR8501")).Contains("1");
                confirms[2] = (await conn.SendCommand($"RD CR8601")).Contains("1");
            }
            while (confirms.Any(x => x==false));

            return confirms.Any(x=>x==false);
        }
        private async Task<bool> Trigger(string checkPoint)
        {
            var res = await conn.SendCommand($"WR W0F2 {checkPoint}");
            res = await conn.SendCommand("WR MR400 1");
            await Task.Delay(1000);
            res = await conn.SendCommand("WR MR400 0");
            res = await conn.SendCommand("RD B063");
            return res.Contains("1");
        }
    }
}
