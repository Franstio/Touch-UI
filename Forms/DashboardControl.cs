using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestTCP1.Lib;
using TestTCP1.Lib.DbUtil;
using TestTCP1.Model;
using TestTCP1.Model.ViewModel;

namespace TestTCP1.Forms
{
    public partial class DashboardControl : UserControl
    {
        public string Model { get; private set; } = string.Empty;
        private readonly FileLib fileLib = new FileLib();
        private readonly DbConn dbCon = new DbConn();
        private readonly TCPConn mainConn = TCPConn.newInstance();
        private readonly TCPConn? livePositionConn = null;
        private List<PositionModel> Positions = new List<PositionModel>();
        private List<InspectionView> InspectionViews = new List<InspectionView>();
        private readonly IMarkPointDb markDb;
        private int? CamPoint = null;
        private readonly Mapper mapper = AutoMapConfig.GetMapper();
        private string oldScanCode = string.Empty;
        private List<MarkPointModel> markPoint = new List<MarkPointModel>();
        private DateTime startTime = DateTime.Now;
        private CancellationTokenSource cts = new CancellationTokenSource();
        private TimeSpan delayTimer = TimeSpan.FromSeconds(1);
        private Dictionary<string, Tuple<string, string>> ImageList = new Dictionary<string, Tuple<string, string>>();
        private PositionModel _curPos = new PositionModel();
        private InspectionView _curInspectionView = new InspectionView();
        private readonly int DelayTimer = 0;
        private readonly int CameraDelay = 0;
        private CountViewModel countView = new CountViewModel();
        private TouchUITemp touchUITemp = new TouchUITemp();
        public DashboardControl()
        {
            InitializeComponent();
            textBox1.Enabled = false;
            finalJudgeLabel.Text = string.Empty;
            markDb = dbCon;
            LoadCountView();
        }
        protected override void OnControlRemoved(ControlEventArgs e)
        {
            mainConn.StopConnection();
            livePositionConn?.StopConnection();
            base.OnControlRemoved(e);
        }
        private void LoadCountView()
        {
            quantityLabel.Text = $"Count: {countView.Count}";
            failCountLabel.Text = $"Fail: {countView.Fail}";
            yieldLabel.Text = $"Yield: {countView.Yield}%";
        }
        public DashboardControl(string _Model)
        {
            InitializeComponent();

            DelayTimer = int.Parse(Properties.Settings.Default["DelayDashboardProcess"].ToString() ?? "0");
            CameraDelay = int.Parse(Properties.Settings.Default["NgCameraDelay"].ToString() ?? "0");
            markDb = dbCon;
            finalJudgeLabel.Text = string.Empty;
            touchUITemp.Multiplier = 0;
            touchUITemp.TargetPos = "X";
            livePositionConn = TCPConn.newInstance();
            livePositionConn.setLog(false);
            Model = _Model;
            runningModel.Text = Model;
            DataTable dt = new DataTable();
            dt.Columns.Add("Area");
            dt.Columns.Add("Judgement");
            inspectionListGridView.DataSource = dt;
            Task.Run(GetLivePosition, cts.Token);
            LoadCountView();
        }
        private async Task GetLivePosition()
        {
            while (true)
            {

                string res = string.Empty;
                decimal val = 0;
                if (livePositionConn is null)
                    return;
                if (!livePositionConn.IsRunning())
                    await livePositionConn.StartConnection();
                val = await LoadValue("RD CM8830", 0);

                xLabel.Invoke(new Action(() =>
                xLabel.Text = $"X: {(val / 1600 * 20).ToString("0.00")} mm"));
                //Thread.Sleep(5);
                val = await LoadValue("RD CM8870", 0);
                yLabel.Invoke(new Action(() =>
                yLabel.Text = $"Y: {(val / 1600 * 20).ToString("0.00")} mm"));
                //Thread.Sleep(5);
                val = await LoadValue("RD CM8910", 0);
                zLabel.Invoke(new Action(() =>
                zLabel.Text = $"Z: {(val / 1600 * 20).ToString("0.00")} mm"));
                await Task.Delay(delayTimer);
            }
        }
        private async Task<decimal[]> GetCurrentPosition()
        {
            decimal[] values = new decimal[3];
            values[0] = await LoadValue("RD CM8830", 0);
            values[1] = await LoadValue("RD CM8870", 0);
            values[2] = await LoadValue("RD CM8910", 0);
            return values;
        }
        private async Task GetPos()
        {
            bool checkIfJudgementEmpty = InspectionViews.Any(x => x.Judgement == string.Empty);
            if (!checkIfJudgementEmpty)
            {
                List<RecordInspectionModel> records = new List<RecordInspectionModel>();
                for (int i = 0; i < Positions.Count; i++)
                {
                    RecordInspectionModel record = mapper.Map<RecordInspectionModel>(Positions[i]);
                    record.ScanCode = oldScanCode;
                    record.Judgement = InspectionViews[i].Judgement;
                    record.FileName = (record.Judgement == "PASS" ? fileLib._savePath : fileLib._ngSavePath) + InspectionViews[i].Image;
                    await dbCon.SavePosRecord(record);
                    records.Add(record);
                }
                string logname = await fileLib.GenerateLog(records, oldScanCode);
                label6.Invoke(delegate
                {
                    label6.Text = logname;
                });
            }
            Positions = await dbCon.GetPositionByModel(Model);
            InspectionViews = mapper.Map<List<InspectionView>>(Positions);
            CamPoint = await dbCon.GetCamPoint(Model);
            this.inspectionListGridView.Invoke(new Action(() =>
            {
                inspectionListGridView.DataSource = InspectionViews;
                inspectionListGridView.Refresh();
                inspectionListGridView.Columns[2].Visible = false;
            }));
            campointLabel.Invoke(new Action(() => campointLabel.Text = CamPoint?.ToString() ?? "-"));
        }
        private async Task TriggerCamPoint()
        {
            await mainConn.SendCommand($"WR W0F8 {CamPoint}");
            await mainConn.SendCommand($"WR MR401 1");
            Thread.Sleep(DelayTimer);
            await mainConn.SendCommand($"WR MR401 0");
            fileLib.FolderCode = CamPoint ?? 1;
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void SwitchControlState(string status)
        {
            switch (status)
            {
                case "waiting":
                    if (Positions.Count > 0)
                        LoadImage(Positions[0]);
                    //pictureBox1.Invoke(new Action(() => pictureBox1.Image = markPoint.Where(x => x.Position == 1).FirstOrDefault() is null ? null : fileLib.ReadImage(markPoint.Where(x=>x.Position==1).FirstOrDefault()!.ImageName,manualPath:fileLib._markSaveDir)));
                    scanLabel.Invoke(new Action(() => scanLabel.Text = textBox1.Text));
                    textBox1.Invoke(new Action(() => textBox1.Enabled = false));
                    statusLabel.Invoke(new Action(() => statusLabel.Text = "Waiting for start button (In-Progress)"));
                    break;
                case "running":
                    statusLabel.Invoke(new Action(() =>
                    {
                        statusLabel.Text = "Running...";
                    }));
                    break;
                case "complete":
                    oldScanCode = textBox1.Text;
                    scanLabel.Invoke(new Action(() => scanLabel.Text = string.Empty));
                    textBox1.Invoke(new Action(() => { textBox1.Enabled = true; textBox1.Text = string.Empty; })); ;
                    statusLabel.Invoke(new Action(() => statusLabel.Text = "Running Process Complete"));
                    break;
            }
        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;
            finalJudgeLabel.Text = string.Empty;
            areaLabel.Text = string.Empty;
            decisionLabel.Text = string.Empty;
            processTimeLabel.Invoke(new Action(() => processTimeLabel.Text = "Process Time: 00:00:00"));
            actualPictureBox.Image = null;
            parameterPictureBox.Image = null;
            startTime = DateTime.Now;
            processTimer.Enabled = true;
            processTimer.Start();
            Task.Run(ScanRun);
        }
        private void LoadInspectionToGrid()
        {

            inspectionListGridView.DataSource = InspectionViews;
            for (int i = 0; i < InspectionViews.Count; i++)
                inspectionListGridView[1, i].Style.ForeColor = InspectionViews[i].Judgement == "PASS" ? Color.LimeGreen : Color.Red;
            inspectionListGridView.Refresh();
        }
        private async Task ScanRun()
        {
            ImageList.Clear();
            await GetPos();
            SwitchControlState("waiting");
            string res = string.Empty;
            await mainConn.SendCommand("WR MR002 1");
            await mainConn.SendCommand("WR MR004 1");
            do
            {
                res = await mainConn.SendCommand($"RD MR8000");
            }
            while (!res.Contains("1") && !res.Contains("ok"));

            SwitchControlState("running");
            for (int i = 0; i < Positions.Count; i++)
            {
                var _pos = /*Model.ToLower()=="touch-ui" ? touchUITemp.Setup( Positions[i]) :*/ Positions[i];
                await StartProcess(_pos);
                Task.Run(() => LoadImage(Positions[i]));
                var isPassed = await Trigger(_pos.CameraCheckpoint);
                InspectionViews[i].Judgement = isPassed ? "PASS" : "NG";
                string localImage = await dbCon.GetLocalImage(_pos);

                int temp = Convert.ToInt32(i.ToString());
                InspectionViews[temp].Image = isPassed ? localImage : await GetTriggerImgPath();
                ImageList.Add(Positions[temp].AreaInspection, new Tuple<string, string>(localImage, InspectionViews[temp].Image));

#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed

#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
                RecordInspectionModel record = mapper.Map<RecordInspectionModel>(_pos);
                record.ScanCode = textBox1.Text;
                record.Judgement = InspectionViews[i].Judgement;
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
                Task.Run(new Action(() =>
                {
                    this.inspectionListGridView.Invoke(new Action(() =>
                    {
                        LoadInspectionToGrid();
                    }));

                    this.areaLabel.Invoke(new Action(() => areaLabel.Text = _pos.AreaInspection));
                    this.decisionLabel.Invoke(new Action(() =>
                    {
                        decisionLabel.Text = record.Judgement;
                        decisionLabel.ForeColor = isPassed ? Color.Lime : Color.DarkRed;
                    }));
                }));
#pragma warning restore CS4014 // Because t     his call is not awaited, execution of the current method continues before the call is completed
            }
            finalJudgeLabel.Invoke(new Action(() =>
            {
                bool finalJudge = InspectionViews.Select(x => x.Judgement).Any(x => x.Contains("NG"));
                finalJudgeLabel.ForeColor = finalJudge ? Color.DarkRed : Color.Lime;
                finalJudgeLabel.Text = finalJudge ? "FAIL" : "PASS";
                countView.Count++;
                if (finalJudge)
                    countView.Fail++;
                countView.Yield = (decimal)countView.Fail / countView.Count;
                LoadCountView();
            }));
            string res1, res2;
            do
            {
                await StartProcess(new PositionModel() { X = 0, Y = 0, Z = 0, CameraCheckpoint = "" });
                res1 = await mainConn.SendCommand("WR MR8000 0");
                res2 = await mainConn.SendCommand("WR DM0 0");
            }
            while (!(res1.ToLower().Contains("ok") || res1.ToLower().Contains("1")) || !(res2.ToLower().Contains("ok") || res2.ToLower().Contains("1")));
            SwitchControlState("complete");
            processTimer.Stop();
            processTimer.Enabled = false;
            this.Invoke(new Action(() =>
            {
                actualPictureBox.Image = null;
                parameterPictureBox.Image = null;

                touchUITemp.Multiplier = touchUITemp.Multiplier + 1;
            }));
        }
        private async Task LoadImage(PositionModel position, bool isPassed)
        {
            const int SPECIAL_DELAY_IMAGE = 5;
            await Task.Delay(SPECIAL_DELAY_IMAGE);
            string imgPath = isPassed ? await dbCon.GetLocalImage(position) : await GetTriggerImgPath();
            //                string imgPath = isPassed ? await dbCon.GetLocalImage(Positions[i]) : GetTriggerImgPath();
            pictureBox1.Invoke(new Action(() =>
            {
                var point = markPoint.Where(x => x.Position == position.Pos).FirstOrDefault();
                if (point is not null)
                    LoadMarking(point);
                else
                    pictureBox1.Image = fileLib.ReadImage(imgPath, isPassed);//isPassed ? fileLib.ReadImage(imgPath) : Image.FromFile(imgPath);
            }));
        }
        private async void LoadImage(PositionModel position, int msDelay = 5)
        {
            await Task.Delay(msDelay);
            //                string imgPath = isPassed ? await dbCon.GetLocalImage(Positions[i]) : GetTriggerImgPath();
            pictureBox1.Invoke(new Action(() =>
            {
                var point = markPoint.Where(x => x.Position == position.Pos).FirstOrDefault();
                if (point is not null)
                    LoadMarking(point);
                else
                    pictureBox1.Image = null;//isPassed ? fileLib.ReadImage(imgPath) : Image.FromFile(imgPath);
            }));
        }

        private async Task<string> GetTriggerImgPath()
        {
            await Task.Delay(CameraDelay);
            string foldername = $"{DateTime.Now.ToString("yyMMdd")}";
            string[] folders = fileLib.GetFolders(foldername);
            if (folders.Length < 1)
            {
                MessageBox.Show($"No Folder with prefix {foldername} Found", "Error");
                return string.Empty;
            }
            string latestDir = Path.Combine(folders[0], "CAM1");
            string[] img = await fileLib.GetFiles(latestDir);
            if (img.Length < 1)
                return string.Empty;
            FileInfo file = new FileInfo(img[0]);
            fileLib.SaveImage(file.FullName, file.Name, true);
            return file.Name;
        }

        private async Task StartProcess(PositionModel data)
        {
            if (!mainConn.IsRunning())
                await mainConn.StartConnection();
            var s = await mainConn.SendCommand("WR MR300 0");
            string res = string.Empty;
            string xVal = String.Format("{0:0}", data.X * 1600 / 20);
            string yVal = String.Format("{0:0}", data.Y * 1600 / 20);
            string zVal = String.Format("{0:0}", data.Z * 1600 / 20);
            res = await mainConn.SendCommand($"WR CM8010 {xVal}");
            res = await mainConn.SendCommand($"WR CM8210 {yVal}");
            res = await mainConn.SendCommand($"WR CM8410 {zVal}");
            if (data.CameraCheckpoint != "")
                res = await mainConn.SendCommand($"WR W0F2 {data.CameraCheckpoint}");
            if (data.X == 0 && data.Y == 0 && data.Z == 0)
            {
                await mainConn.SendCommand("WR MR002 0");
                await mainConn.SendCommand("WR MR004 0");

                s = await mainConn.SendCommand("WR MR300 1");
                decimal[] _curPos = await GetCurrentPosition();
                while (_curPos.Any(x => x != 0))
                    _curPos = await GetCurrentPosition();
                return;
            }
            s = await mainConn.SendCommand("WR MR300 1");
            bool[] confirms = new bool[3];
            do
            {
                confirms[0] = (await mainConn.SendCommand($"RD CR8401")).Contains("1");
                confirms[1] = (await mainConn.SendCommand($"RD CR8501")).Contains("1");
                confirms[2] = (await mainConn.SendCommand($"RD CR8601")).Contains("1");
            }
            while (confirms.Any(x => x == false));
        }
        private async Task<bool> Trigger(string checkPoint)
        {
            //res = await conn.SendCommand("WR MR400 1");
            //Thread.Sleep(10);
            //res = await conn.SendCommand("WR MR400 0");
            bool? result = null;
            string res = string.Empty;
            do
            {
                res = await mainConn.SendCommand("RD MR400");
            }
            while (!res.Contains("1"));
            do
            {
                res = await mainConn.SendCommand("RD MR1000");
                if (res.Contains("1"))
                    result = true;
                res = await mainConn.SendCommand("RD MR1001");
                if (res.Contains("1"))
                    result = false;
            }
            while (result is null);
            //this.Invoke(new Action(() =>
            //MessageBox.Show("Incorrect trigger output")));
            await mainConn.SendCommand("WR MR400 0");
            return result.Value;
        }

        private async void DashboardControl_Load(object sender, EventArgs e)
        {
            if (Model == null || Model == string.Empty)
                return;
            if (!mainConn.IsRunning())
                await mainConn.StartConnection();
            if (livePositionConn is not null && !livePositionConn.IsRunning())
                await livePositionConn.StartConnection();
            await GetPos();

            if (CamPoint is not null)
                await TriggerCamPoint();

            var data = await markDb.GetMarkPoint(Model);
            if (data is null)
                return;
            markPoint = data.ToList();
            if (markPoint.Count > 1 && markPoint[0].Position == 1)
                LoadMarking(markPoint[0]);

        }
        private async Task<decimal> LoadValue(string command, decimal defaultValue)
        {
            if (livePositionConn is null)
                return defaultValue;
            string res;
            decimal value;
            res = await livePositionConn.SendCommand(command);
            string[] spl = res.Split("\n");
            if (spl.Length > 1)
            {
                if (spl[1] != string.Empty)
                {
                    Debug.WriteLine($"{command} reading resulting multiline value\nvalue: {res}\nRestarting Connection");
                    livePositionConn.StopConnection();
                    await livePositionConn.StartConnection();
                    await Task.Delay(100);
                    return defaultValue;
                }
            }
            bool s = decimal.TryParse(res.Replace("+", "").Replace("\r", "").Replace("\n", ""), out value);
            return s ? value : defaultValue;
        }
        private void LoadMarking(MarkPointModel mark)
        {
            Image? img = fileLib.ReadImage(mark.ImageName, manualPath: fileLib._markSaveDir);
            if (img is null)
            {
                Debug.WriteLine($"{mark.ImageName} Could not be loaded");
                return;
            }
            pictureBox1.Image = img;
            pictureBox1.Refresh();
            markDb.DrawMark(markDb.CalibratePoint(mark, img, pictureBox1), Color.Orange, img, pictureBox1);
            pictureBox1.Refresh();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Task.Run(new Action(() =>
            {
                timeLabel.Invoke(new Action(() =>
                {
                    timeLabel.Text = $"Date: {DateTime.Now.ToString("dd MMM yyyy")}\nTime: {DateTime.Now.ToString("HH:mm:ss")}";
                }));


            }));
        }

        private void timeLabel_Click(object sender, EventArgs e)
        {

        }

        private void scanLabel_Click(object sender, EventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {
        }

        private void inspectionListGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {
        }

        private void label6_Click(object sender, EventArgs e)
        {
        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {
        }

        private void statusLabel_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void zLabel_Click(object sender, EventArgs e)
        {
        }

        private void yLabel_Click(object sender, EventArgs e)
        {
        }

        private void xLabel_Click(object sender, EventArgs e)
        {
        }

        private void runningModel_Click(object sender, EventArgs e)
        {
        }

        private void processTimer_Tick(object sender, EventArgs e)
        {
            var elapsed = DateTime.Now - startTime;
            processTimeLabel.Invoke(new Action(() =>
            {
                processTimeLabel.Text = $"Process Time: {elapsed.Hours.ToString("00")}:{elapsed.Minutes.ToString("00")}:{elapsed.Seconds.ToString("00")}";
            }));
        }

        private async void inspectionListGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            var pos = Positions[index];
            var ins = inspectionListGridView.Rows[index].Cells[1];
            var frm = new ProcessVerificationModalForm(pos, ins.Value.ToString() == "PASS", InspectionViews[index].Image);
            frm.WindowState = FormWindowState.Maximized;
            var res = frm.ShowDialog();
            if (res == DialogResult.OK)
            {
                InspectionViews[index].Judgement = frm.resultVerification ? "PASS" : "NG";
                //RecordInspectionModel record = mapper.Map<RecordInspectionModel>(pos);
                //record.Judgement = InspectionViews[index].Judgement;
                if (frm.resultVerification)
                {
                    await dbCon.SaveImage(pos.Model, pos.Pos, frm._image);
                    fileLib.SaveImage(frm._imageFull, frm._image);
                }
                await Task.Run(new Action(() =>
                {
                    this.inspectionListGridView.Invoke(new Action(() =>
                    {
                        inspectionListGridView.DataSource = InspectionViews;
                        inspectionListGridView.Refresh();
                    }));
                    finalJudgeLabel.Invoke(new Action(() =>
                    {
                        bool finalJudge = InspectionViews.Select(x => x.Judgement).Any(x => x.Contains("NG"));
                        finalJudgeLabel.ForeColor = finalJudge ? Color.DarkRed : Color.Lime;
                        finalJudgeLabel.Text = finalJudge ? "FAIL" : "PASS";
                    }));
                }));
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            int index = InspectionViews.FindIndex(x => x.Area == _curInspectionView.Area);
            if (index == -1)
                return;
            InspectionViews[index].Judgement = "PASS";
            LoadInspectionToGrid();
            actualPictureBox.Image = null;
            parameterPictureBox.Image = null;
            button1.Enabled = false;
            button2.Enabled = false;
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            var tup = ImageList[_curPos.AreaInspection];
            string name = Path.GetFileName(tup.Item2);
            await dbCon.SaveImage(_curPos.Model, _curPos.Pos, name);
            fileLib.SaveImage(tup.Item2, name);
            inspectionListGridView.Invoke(LoadInspectionToGrid);
            actualPictureBox.Image = null;
            parameterPictureBox.Image = null;
            button1.Enabled = false;
            button2.Enabled = false;
        }

        private void inspectionListGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            PositionModel pcur = Positions[e.RowIndex];
            MarkPointModel? mark = markPoint.Where(x => x.Position == pcur.Pos).FirstOrDefault();
            if (mark is not null)
                LoadImage(pcur, 0);
            var res = InspectionViews.Where(x => x.Area == pcur.AreaInspection).FirstOrDefault();
            var img = ImageList[pcur.AreaInspection];
            if (res is null)
                return;
            button1.Enabled = res.Judgement == "PASS";
            button2.Enabled = res.Judgement == "PASS";

            button1.Visible = res.Judgement != "PASS";
            button2.Visible = res.Judgement != "PASS";
            actualPictureBox.Image = fileLib.ReadImage(img.Item2, res.Judgement == "PASS"); //Image.FromFile(img.Item2);
            parameterPictureBox.Image = fileLib.ReadImage(img.Item1, true);
            _curPos = pcur;
            _curInspectionView = res;
        }
    }
}
