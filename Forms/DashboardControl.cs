using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
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
        private CancellationTokenSource mainCts = new CancellationTokenSource();
        private CancellationTokenSource cts = new CancellationTokenSource();
        private CancellationTokenSource cTokenSource = new CancellationTokenSource();
        public string Model { get; private set; } = string.Empty;
        private string prevStatus = string.Empty;
        private List<string> ngImage = new List<string>();

        private int? CamPoint = null;

        private readonly FileLib fileLib = new FileLib();
        
        private readonly DbConn dbCon = new DbConn();
        
        private readonly TCPConn mainConn = TCPConn.newInstance();
        private readonly TCPConn? livePositionConn = null;
        
        private List<PositionModel> Positions = new List<PositionModel>();
        private PositionModel _curPos = new PositionModel();

        private readonly IMarkPointDb markDb;
        private readonly Mapper mapper = AutoMapConfig.GetMapper();

        private List<MarkPointModel> markPoint = new List<MarkPointModel>();

        private DateTime startTime = DateTime.Now;
        private TimeSpan delayTimer = TimeSpan.FromSeconds(1);

        private InspectionView _curInspectionView = new InspectionView();

        private readonly int DelayTimer = 0;
        private readonly int CameraDelay = 0;

        private CountViewModel countView = new CountViewModel();

        private DashboardCavityModel? cavities;

        private bool isRunning = false;
        private bool isSensorActive = false;
        private static Task ProcessTask = Task.CompletedTask;
        private string? snFile = null;

        private List<ImageAreaModel> areaData = new List<ImageAreaModel>();

        public DashboardControl()
        {
            InitializeComponent();
            //            textBox1.Enabled = false;
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
            ngWatcher.Path = fileLib._filePath;
            snWatcher.Path = Properties.Settings.Default.SNLocation;
            ngWatcher.IncludeSubdirectories = true;
            snWatcher.IncludeSubdirectories = true;
            ngWatcher.NotifyFilter = NotifyFilters.FileName;
            snWatcher.NotifyFilter = NotifyFilters.FileName;
        }
        private async Task GetLivePosition()
        {
            while (!cts.IsCancellationRequested)
            {
                string res = string.Empty;
                decimal val = 0;
                if (livePositionConn is null)
                    return;
                if (!livePositionConn.IsRunning())
                    await livePositionConn.StartConnection();
                res = await livePositionConn.SendCommand("RD MR1003");
                if (res.Contains("1") && !isSensorActive)
                {
                    prevStatus = statusLabel.Text;
                    isSensorActive = true;
                    statusLabel.Invoke(delegate
                    {
                        statusLabel.Text = "M/C Paused, Waiting Start Button";
                    });
                }
                else if (res.Contains("0") && isSensorActive)
                {
                    isSensorActive = false;
                    statusLabel.Invoke(delegate
                    {
                        statusLabel.Text = prevStatus;
                    });
                }
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
            values[1] = await LoadValue("RD CM8870.L", 0);
            values[2] = await LoadValue("RD CM8910", 0);
            return values;
        }
        private async Task LogWrite()
        {
            if (cavities is not null)
            {
                Dictionary<string, string> _msg = new Dictionary<string, string>();
                foreach (var _cavity in cavities.Cavities)
                {
                    bool checkIfJudgementEmpty = _cavity.InspectionViews.Any(x => x.Judgement == string.Empty || x.Judgement == "" || x.Judgement is null);
                    if (!checkIfJudgementEmpty && _cavity.InspectionViews.Count >= Positions.Count)
                    {
                        List<RecordInspectionModel> records = new List<RecordInspectionModel>();
                        for (int i = 0; i < areaData.Count; i++)
                        {
                            var curPos = Positions.Where(x => x.Pos == areaData[i].Position).First();
                            RecordInspectionModel record = mapper.Map<RecordInspectionModel>(curPos);
                            record.ScanCode = _cavity.SerialNumber;
                            record.Judgement = _cavity.InspectionViews[i].Judgement;
                            record.Reason = _cavity.InspectionViews[i].Reason;
                            record.AreaInspection = areaData[i].AreaInspection;
                            record.FileName = (record.Judgement == "PASS" ? fileLib._savePath : fileLib._ngSavePath) + _cavity.InspectionViews[i].Image;
                            await dbCon.DeleteRecord(record);
                            await dbCon.SavePosRecord(record);
                            records.Add(record);
                        }
                        string logname = await fileLib.GenerateLog(records, _cavity.SerialNumber);
                        bool isValid = await fileLib.ValidateLog(_cavity.SerialNumber);
                        if (!isValid)
                        {
                            MessageBox.Show("BOT tidak ditemukan", "Log Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            SwitchControlState("Error");
                            return;

                        }
                        label6.Invoke(delegate
                        {
                            label6.Text += ";" + logname;
                        });
                        var temp = await fileLib.ValidateLog();
                        if (temp is not null)
                        {
                            foreach (var item in temp)
                                if (!_msg.ContainsKey(item.Key))
                                    _msg.Add(item.Key, item.Value);
                        }
                    }
                }
                if (!_msg.Any())
                    return;
                StringBuilder sb = new StringBuilder();
                foreach (var item in _msg)
                {
                    var _cavity = cavities.Cavities.Where(x => x.SerialNumber == item.Key).FirstOrDefault();
                    if (_cavity == null)
                        continue;
                    sb = sb.AppendLine($"Cavity {_cavity.CavityNo+1}: ");
                    sb = sb.AppendLine($"{item.Value}\n");
                }
                if (string.IsNullOrEmpty(sb.ToString()))
                    return;
                Invoke(delegate
                {
                    DialogResult res = MessageBox.Show(sb.ToString(), "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (res == DialogResult.OK)
                        fileLib.ClearSN();
                });
            }
        }
        private async Task GetPos()
        {
            CavityModel? cavityModel = await dbCon.GetCavity(Model);

            if (cavityModel is null)
                return;
            await ReloadCavity(cavityModel);
            CamPoint = await dbCon.GetCamPoint(Model);
            this.inspectionListGridView.Invoke(new Action(() =>
            {
                inspectionListGridView.DataSource = null;
                inspectionListGridView.Refresh();
                inspectionListGridView.DataSource = cavities!.CurrentCavityItem.InspectionViews;
                for (int i = 0; i < cavities.CurrentCavityItem.InspectionViews.Count; i++)
                    inspectionListGridView[1, i].Style.ForeColor = cavities.CurrentCavityItem.InspectionViews[i].Judgement == "PASS" ? Color.LimeGreen : Color.Red;
                inspectionListGridView.Columns[2].Visible = false;
                inspectionListGridView.Columns[3].Visible = false;
                inspectionListGridView.Refresh();
            }));
            campointLabel.Invoke(new Action(() => campointLabel.Text = CamPoint?.ToString() ?? "-"));
        }
        private async Task ReloadCavity(CavityModel cavityModel)
        {

            Positions = await dbCon.GetPositionByModel(Model);
            areaData = await dbCon.GetAreaImageByModel(Model);
            cavities = new DashboardCavityModel(cavityModel, Positions);
            Positions = cavities.Cavities.First().Models;
            comboBox1.Invoke(delegate
            {
                comboBox1.SelectedIndex = comboBox1.Items.IndexOf(cavities.Cavity.CavityTotal.ToString());
            });
            cavities.CurrentCavityItem.InspectionViews = mapper.Map<List<InspectionView>>(areaData);

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
                        LoadImage(areaData[0]);
                    //pictureBox1.Invoke(new Action(() => pictureBox1.Image = markPoint.Where(x => x.Position == 1).FirstOrDefault() is null ? null : fileLib.ReadImage(markPoint.Where(x=>x.Position==1).FirstOrDefault()!.ImageName,manualPath:fileLib._markSaveDir)));
                    //scanLabel.Invoke(new Action(() => scanLabel.Text = textBox1.Text));
                    //textBox1.Invoke(new Action(() => textBox1.Enabled = false));
                    statusLabel.Invoke(new Action(() => statusLabel.Text = "Waiting for start button (In-Progress)"));
                    break;
                case "running":
                    statusLabel.Invoke(new Action(() =>
                    {
                        statusLabel.Text = "Running...";
                    }));
                    break;
                case "complete":
                    //oldScanCode = textBox1.Text;
                    //scanLabel.Invoke(new Action(() => scanLabel.Text = string.Empty));
                    //textBox1.Invoke(new Action(() => { textBox1.Enabled = true; textBox1.Text = string.Empty; })); ;
                    statusLabel.Invoke(new Action(() => statusLabel.Text = "Running Process Complete"));
                    break;
                default:
                    statusLabel.Invoke(new Action(() => statusLabel.Text = status));
                    break;
            }
        }
        private void LoadInspectionToGrid()
        {
            inspectionListGridView.DataSource = null;
            inspectionListGridView.Refresh();
            inspectionListGridView.DataSource = cavities!.CurrentCavityItem.InspectionViews;
            for (int i = 0; i < cavities.CurrentCavityItem.InspectionViews.Count; i++)
                inspectionListGridView[1, i].Style.ForeColor = cavities.CurrentCavityItem.InspectionViews[i].Judgement == "PASS" ? Color.LimeGreen : Color.Red;
            inspectionListGridView.Columns[2].Visible = false;
            inspectionListGridView.Columns[3].Visible = false;
            inspectionListGridView.Refresh();
        }
        private async Task ScanRun()
        {
            string res = string.Empty;
            await GetPos();
            for (int i = 0; i < cavities!.Cavity.CavityTotal && !cTokenSource.IsCancellationRequested; i++)
            {
                cavities!.CurrentCavity = i;

                this.Invoke(delegate
                {
                    groupBox3.Text = "Inspection List: " + inputSerialView[0, cavities!.CurrentCavity].Value;
                    cavities.CurrentCavityItem.InspectionViews = mapper.Map<List<InspectionView>>(areaData);
                    LoadInspectionToGrid();
                });

                await RunProcess(i);
            }
            string res1, res2;
            do
            {
                await StartProcess(new PositionModel() { X = 0, Y = 0, Z = 0, CameraCheckpoint = "" });
                res1 = await mainConn.SendCommand("WR MR8000 0");
                res2 = await mainConn.SendCommand("WR DM0 0");
            }
            while ((!(res1.ToLower().Contains("ok") || res1.ToLower().Contains("1")) || !(res2.ToLower().Contains("ok") || res2.ToLower().Contains("1"))) && !cTokenSource.IsCancellationRequested);
            if (cTokenSource.IsCancellationRequested)
                return;
            await ReadSN();
            SwitchControlState("complete");

            processTimer.Stop();
            processTimer.Enabled = false;
        }
        void updateStatusText(string text)
        {
            statusLabel.Invoke(delegate
            {
                statusLabel.Text = text;
            });
        }
        private async Task ReadSN()
        {
            if (snFile is null)
                throw new Exception("SN File not detected");
            if (!File.Exists(snFile))
                throw new Exception("SN File Path not found");
            await Task.Delay(3000);
            string[] text = File.ReadAllLines(snFile);
            var sortedArea = areaData.OrderBy(x => x.Position).ThenBy(x => x.No).ToArray();
            for (int i = 0; i < cavities!.Cavity.CavityTotal; i++)
            {
                cavities.CurrentCavity = i;
                string[] judgement = text[(i * 2)].Replace(",#", "").Split(',');
                string sn = text[(i * 2) + 1];
                string[] dataSn = sn.Split(',');
                sn = dataSn[dataSn.Length - 2];
                inputSerialView[1, i].Value = sn;
                inputSerialView[2, i].Value = judgement.Any(x => x != "0") ? "FAIL" : "PASS";
                inputSerialView[2, i].Style.ForeColor = judgement.Any(x => x != "0") ? Color.DarkRed : Color.LimeGreen;
                inputSerialView.Invoke(delegate
                {
                    inputSerialView.Refresh();
                });
                cavities!.Cavities[i].SerialNumber = sn;
                int ngCount = 0;
                if (judgement.Length != sortedArea.Length)
                {
                    updateStatusText( "Failing Reading output .txt,Stopping Process");
                    mainCts.Cancel();
                    isRunning = false;
                    cTokenSource.Cancel();
                    return;
                }
                for (int j = 0; j < judgement.Length; j++)
                {
                    bool isPassed = judgement[j] == "0";
                    cavities.Cavities[i].InspectionViews[j].Judgement = isPassed ? "PASS" : "NG";
                    string localImage = await dbCon.GetLocalImage(sortedArea[j]);
                    cavities.Cavities[i].InspectionViews[j].Image = isPassed ? localImage : ngImage[ngCount];
                    ngCount = isPassed ? ngCount : ngCount + 1;
                    cavities!.AddToImageList(i , sortedArea[j].AreaInspection, localImage, cavities.Cavities[i].InspectionViews[j].Image);
                    var pos = Positions.Where(x => x.Pos == sortedArea[j].Position).First();
                    RecordInspectionModel record = mapper.Map<RecordInspectionModel>(pos);
                    record.ScanCode = sn;//inputSerialView.Rows[j + 1].Cells[1].Value.ToString() ?? string.Empty;
                    record.AreaInspection = sortedArea[j].AreaInspection;
                    record.Judgement = cavities.Cavities[i].InspectionViews[j].Judgement;
                }
                cavities.CurrentCavity = 0;
                this.inspectionListGridView.Invoke(new Action(() =>
                {
                    LoadInspectionToGrid();
                }));
                this.Invoke(new Action(() =>
                {
                    bool finalJudge = cavities.CurrentCavityItem.InspectionViews.Select(x => x.Judgement).Any(x => x.Contains("NG"));
                    inputSerialView[2, cavities.CurrentCavity].Style.ForeColor = finalJudge ? Color.DarkRed : Color.Lime;
                    inputSerialView[2, cavities.CurrentCavity].Value = finalJudge ? "FAIL" : "PASS";
                    finalJudgeLabel.ForeColor = finalJudge ? Color.DarkRed : Color.Lime;
                    finalJudgeLabel.Text = finalJudge ? "FAIL" : "PASS";
                    countView.Count++;
                    if (finalJudge)
                        countView.Fail++;
                    else
                        countView.Pass++;
                    countView.Yield = ((decimal)((decimal)countView.Pass / (decimal)countView.Count) * 100);
                    LoadCountView();
                }));
                File.Delete(snFile);
                updateStatusText(".txt Output have been deleted");
            }
            this.Invoke(new Action(() =>
            {
                bool finalJudge = cavities.CurrentCavityItem.InspectionViews.Select(x => x.Judgement).Any(x => x.Contains("NG"));
                inputSerialView[2, cavities.CurrentCavity].Style.ForeColor = finalJudge ? Color.DarkRed : Color.Lime;
                inputSerialView[2, cavities.CurrentCavity].Value = finalJudge ? "FAIL" : "PASS";
                finalJudgeLabel.ForeColor = finalJudge ? Color.DarkRed : Color.Lime;
                finalJudgeLabel.Text = finalJudge ? "FAIL" : "PASS";
                countView.Count++;
                if (finalJudge)
                    countView.Fail++;
                else
                    countView.Pass++;
                countView.Yield = ((decimal)((decimal)countView.Pass / (decimal)countView.Count) * 100);
                LoadCountView();
            }));
            isRunning = false;
            Invoke(delegate
            {
                button4.Enabled = true;
                isRunning = false;
            });
        }
        private async Task ShowLogPopup()
        {
            DialogResult dialogResult = MessageBox.Show("Generete Log Data?", "Log Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
                await LogWrite();
        }
        private async Task RunProcess(int cavityNo)
        {
            cavities!.ClearImageList(cavityNo);

            Positions = cavities!.Cavities[cavityNo].Models;
            SwitchControlState("running");
            for (int i = 0; i < Positions.Count ; i++)
            {
                if (i >= Positions.Count || cTokenSource.IsCancellationRequested)
                    break;
                Console.WriteLine("Position " + Positions[i].Pos);
                var _pos = /*Model.ToLower()=="touch-ui" ? touchUITemp.Setup( Positions[i]) :*/ Positions[i];
                await StartProcess(_pos);
//                LoadImage(Positions[i]); [TODO]
                
                this.areaLabel.Invoke(new Action(() => areaLabel.Text = string.Join(",",areaData.Where(x => x.Position == Positions[i].Pos).Select(x=>x.AreaInspection).ToArray())));
                /*#pragma warning disable CS4014 //r Because this call is not awaited, execution of the current method continues before the call is completed
                                Task.Run(new Action(() =>
                                {
                                }));
                #pragma warning restore CS4014 // Because t     his call is not awaited, execution of the current method continues before the call is completed
                */
            }
        }
        private async Task LoadImage(ImageAreaModel model, bool isPassed)
        {
            const int SPECIAL_DELAY_IMAGE = 5;
            await Task.Delay(SPECIAL_DELAY_IMAGE);
            string imgPath = isPassed ? await dbCon.GetLocalImage(model) : await GetTriggerImgPath();
            //                string imgPath = isPassed ? await dbCon.GetLocalImage(Positions[i]) : GetTriggerImgPath();
            pictureBox1.Invoke(new Action(() =>
            {
                var point = markPoint.Where(x => x.Position == model.Position).FirstOrDefault();
                if (point is not null)
                    LoadMarking(point);
                else
                    pictureBox1.Image = fileLib.ReadImage(imgPath, isPassed);//isPassed ? fileLib.ReadImage(imgPath) : Image.FromFile(imgPath);
            }));
        }
        private async void LoadImage(ImageAreaModel position, int msDelay = 5)
        {
            await Task.Delay(msDelay);
            //                string imgPath = isPassed ? await dbCon.GetLocalImage(Positions[i]) : GetTriggerImgPath();
            pictureBox1.Invoke(new Action(() =>
            {
                var point = markPoint.Where(x => x.Position == position.Position).FirstOrDefault();
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
            Console.WriteLine($"Moving To {data.X},{data.Y},{data.Z}");
            string xVal = String.Format("{0:0}", data.X * 1600 / 20);
            string yVal = String.Format("{0:0}", data.Y * 1600 / 20);
            string zVal = String.Format("{0:0}", data.Z * 1600 / 20);
            res = await mainConn.SendCommand($"WR CM8010 {xVal}");
            res = await mainConn.SendCommand($"WR CM8210.L {yVal}");
            res = await mainConn.SendCommand($"WR CM8410 {zVal}");

            if (data.CameraCheckpoint != "")
                res = await mainConn.SendCommand($"WR W0F2 {data.CameraCheckpoint}");
            if (data.X == 0 && data.Y == 0 && data.Z == 0)
            {
                await mainConn.SendCommand("WR MR002 0");
                s = await mainConn.SendCommand("WR MR300 1");
                await Task.Delay(3000);
                decimal[] _curPos = await GetCurrentPosition();
                while (_curPos.Any(x => x != 0))
                {
                    if (cTokenSource.IsCancellationRequested)
                    {
                        isRunning = false;
                        return;
                    }
                    _curPos = await GetCurrentPosition();
                }
                await mainConn.SendCommand("WR MR004 0");
                return;
            }
            s = await mainConn.SendCommand("WR MR300 1");
            await Task.Delay(3000);
            bool[] confirms = new bool[3];
            do
            {
                if (cTokenSource.IsCancellationRequested)
                {
                    isRunning = false;
                    return;
                }
                confirms[0] = (await mainConn.SendCommand($"RD CR8401")).Contains("1");
                confirms[1] = (await mainConn.SendCommand($"RD CR8501")).Contains("1");
                confirms[2] = (await mainConn.SendCommand($"RD CR8601")).Contains("1");
            }
            while (confirms.Any(x => x == false));
            await Task.Delay(500);
        }
        private async Task<bool?> Trigger(string checkPoint)
        {
            //res = await conn.SendCommand("WR MR400 1");
            //Thread.Sleep(10);
            //res = await conn.SendCommand("WR MR400 0");
            bool? result = null;
            string res = string.Empty;
            do
            {

                if (cTokenSource.IsCancellationRequested)
                    return null;
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
            while (result is null && !cTokenSource.IsCancellationRequested);
            //this.Invoke(new Action(() =>
            //MessageBox.Show("Incorrect trigger output")));
            await mainConn.SendCommand("WR MR400 0");
            return result;
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
            if (data is not null)
            {
                markPoint = data.ToList();
                if (markPoint.Count > 1 && markPoint[0].Position == 1)
                    LoadMarking(markPoint[0]);
            }
            ngWatcher.Created += NGWatcherEvent;
            snWatcher.Created += SNWatcherEvent;
            LoadCavityGridTable();
            if (ProcessTask != null || ProcessTask != Task.CompletedTask)
                mainCts.Cancel();
            ProcessTask = Task.Run(LoopProcess);

        }
        private void LoadCavityGridTable(bool reset = true) => Invoke(delegate
        {
            if (reset) inputSerialView.Rows.Clear();

            if (cavities is null)
                return;
            for (int i = 0; i < cavities!.Cavity.CavityTotal; i++)
            {
                if (reset)
                    inputSerialView.Rows.Add(new object[] { $"Cavity {i + 1}", string.Empty, "-" });
                else
                {
                    if (cavities is not null)
                    {
                        for (int j = 0; j < cavities.Cavities.Count; j++)
                        {
                            if (inputSerialView.Rows.Count > j)
                            {
                                cavities.Cavities[j].SerialNumber = inputSerialView[1, j].Value.ToString() ?? string.Empty;
                            }
                        }

                    }
                }
            }
            inputSerialView.Refresh();

        });
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
            var ins = inspectionListGridView.Rows[index].Cells[1];
            var ar = areaData.Where(x => x.AreaInspection == inspectionListGridView[0, index].Value.ToString()).First();
            var pos = Positions.Where(x => x.Pos == ar.Position).First();
            var frm = new ProcessVerificationModalForm(pos,areaData.Where(x => x.AreaInspection == inspectionListGridView[0,e.RowIndex].Value.ToString()).First(), ins.Value.ToString() == "PASS", cavities!.CurrentCavityItem.InspectionViews[index].Image);
            frm.WindowState = FormWindowState.Maximized;
            var res = frm.ShowDialog();
            if (res == DialogResult.OK)
            {
                //RecordInspectionModel record = mapper.Map<RecordInspectionModel>(pos);
                //record.Judgement = InspectionViews[index].Judgement;


                ReasonForm reasonForm = new ReasonForm();
                var _res = reasonForm.ShowDialog();
                if (_res == DialogResult.OK)
                {
                    string reason = reasonForm.Result;
                    cavities.CurrentCavityItem.InspectionViews[index].Reason = reason;
                    cavities.CurrentCavityItem.InspectionViews[index].Judgement = frm.resultVerification ? "PASS" : "NG";
                }
                else
                    return;
                if (frm.resultVerification)
                {
                    var areaGet = areaData.Where(x => x.AreaInspection == inspectionListGridView[0, e.RowIndex].Value.ToString()).First();
                    var tup = cavities!.Cavities[cavities.CurrentCavity].ImageList[areaGet.AreaInspection];
                    cavities!.Cavities[cavities.CurrentCavity].ImageList[areaGet.AreaInspection] = new Tuple<string, string>(tup.Item1, tup.Item1);
                    //                    await dbCon.SaveImage(pos.Model, pos.Pos, frm._image);
                    //                    fileLib.SaveImage(frm._imageFull, frm._image);
                }
                await Task.Run(new Action(() =>
                {
                    this.inspectionListGridView.Invoke(new Action(() =>
                    {
                        inspectionListGridView.DataSource = null;
                        inspectionListGridView.Refresh();
                        inspectionListGridView.DataSource = cavities.CurrentCavityItem.InspectionViews;
                        inspectionListGridView[1, index].Style.ForeColor = frm.resultVerification ? Color.LimeGreen : Color.DarkRed;
                        inspectionListGridView.Columns[2].Visible = false;
                        inspectionListGridView.Columns[3].Visible = false;
                        inspectionListGridView.Refresh();
                    }));
                    bool finalJudge = cavities.CurrentCavityItem.InspectionViews.Select(x => x.Judgement).Any(x => x.Contains("NG"));
                    finalJudgeLabel.Invoke(new Action(() =>
                    {
                        finalJudgeLabel.ForeColor = finalJudge ? Color.DarkRed : Color.Lime;
                        finalJudgeLabel.Text = finalJudge ? "FAIL" : "PASS";
                    }));
                    inputSerialView.Invoke(new Action(() =>
                    {

                        inputSerialView[2, cavities.CurrentCavity].Style.ForeColor = finalJudge ? Color.DarkRed : Color.Lime;
                        inputSerialView[2, cavities.CurrentCavity].Value = finalJudge ? "FAIL" : "PASS";
                    }));
                }));
                //                LogWrite();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            Invoke(delegate
            {
                int index = cavities!.CurrentCavityItem.InspectionViews.FindIndex(x => x.Area == _curInspectionView.Area);
                if (index == -1)
                    return;
                string prevJudgement = inputSerialView[2, cavities.CurrentCavity].Value.ToString()!;

                var tup = cavities!.Cavities[cavities.CurrentCavity].ImageList[_curInspectionView.Area];
                cavities!.Cavities[cavities.CurrentCavity].ImageList[_curInspectionView.Area] = new Tuple<string, string>(tup.Item1, tup.Item1);

                cavities.CurrentCavityItem.InspectionViews[index].Judgement = "PASS";
                LoadInspectionToGrid();
                actualPictureBox.Image = null;
                parameterPictureBox.Image = null;
                button1.Enabled = false;
                button2.Enabled = false;
                if (cavities.CurrentCavityItem.InspectionViews.Count > 0 && cavities.CurrentCavityItem.InspectionViews.Any(x => x.Judgement != "PASS"))
                {
                    if (prevJudgement == "PASS")
                    {
                        finalJudgeLabel.Text = "FAIL";
                        finalJudgeLabel.ForeColor = Color.DarkRed;
                        inputSerialView[2, cavities.CurrentCavity].Value = "FAIL";
                        inputSerialView[2, cavities.CurrentCavity].Style.ForeColor = Color.DarkRed;
                        countView.Pass--;
                        countView.Fail++;
                    }
                }
                else
                {
                    if (prevJudgement == "FAIL")
                    {

                        finalJudgeLabel.Text = "PASS";
                        finalJudgeLabel.ForeColor = Color.LimeGreen;
                        inputSerialView[2, cavities.CurrentCavity].Value = "PASS";

                        inputSerialView[2, cavities.CurrentCavity].Style.ForeColor = Color.LimeGreen;
                        countView.Pass++;
                        countView.Fail--;
                    }
                }
                countView.Yield = ((decimal)((decimal)countView.Pass / (decimal)countView.Count) * 100);
                LoadCountView();
            });
            //            await LogWrite();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Invoke(delegate
            {
                int index = cavities!.CurrentCavityItem.InspectionViews.FindIndex(x => x.Area == _curInspectionView.Area);
                if (index == -1)
                    return;
                if (cavities.CurrentCavityItem.InspectionViews[index].Judgement == "NG")
                {

                    ReasonForm reasonForm = new ReasonForm();
                    var _res = reasonForm.ShowDialog();
                    if (_res == DialogResult.OK)
                    {
                        string reason = reasonForm.Result;
                        cavities.CurrentCavityItem.InspectionViews[index].Reason = reason;
                    }
                }
                var curArea = areaData.Where(x => x.AreaInspection == _curInspectionView.Area).First();
                var tup = cavities!.Cavities[cavities.CurrentCavity].ImageList[curArea.AreaInspection];
                string prevJudgement = inputSerialView[2, cavities.CurrentCavity].Value.ToString()!;
                //string name = Path.GetFileName(tup.Item2);
                //await dbCon.SaveImage(_curPos.Model, _curPos.Pos, name);
                //fileLib.SaveImage(tup.Item2, name);

                cavities.CurrentCavityItem.InspectionViews[index].Judgement = "NG";
                inspectionListGridView.Invoke(LoadInspectionToGrid);
                actualPictureBox.Image = null;
                parameterPictureBox.Image = null;
                button1.Enabled = false;
                button2.Enabled = false;
                if (cavities.CurrentCavityItem.InspectionViews.Count > 0 && cavities.CurrentCavityItem.InspectionViews.Any(x => x.Judgement != "PASS"))
                {
                    if (prevJudgement == "PASS")
                    {
                        inputSerialView.Invoke(delegate
                        {

                            finalJudgeLabel.Text = "FAIL";
                            finalJudgeLabel.ForeColor = Color.DarkRed;
                            inputSerialView[2, cavities.CurrentCavity].Style.ForeColor = Color.DarkRed;
                            inputSerialView[2, cavities.CurrentCavity].Value = "FAIL";
                        });
                        countView.Pass--;
                        countView.Fail++;
                    }
                }
                countView.Yield = ((decimal)((decimal)countView.Pass / (decimal)countView.Count) * 100);
                LoadCountView();
            });
            // await LogWrite();
        }

        private void inspectionListGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || isRunning)
                return;
            var curArea = areaData.Where(x => x.AreaInspection == inspectionListGridView[0, e.RowIndex].Value.ToString()).First();
            MarkPointModel? mark = markPoint.Where(x => x.Position == curArea.Position).FirstOrDefault();
            if (mark is not null)
                LoadImage(curArea, 0);
            var res = cavities!.CurrentCavityItem.InspectionViews.Where(x => x.Area == curArea.AreaInspection).FirstOrDefault();

            if (!cavities!.Cavities[cavities.CurrentCavity].ImageList.ContainsKey(curArea.AreaInspection))
                return;
            var img = cavities!.Cavities[cavities.CurrentCavity].ImageList[curArea.AreaInspection];
            if (res is null)
                return;
            button1.Enabled = res.Judgement != "PASS";
            button2.Enabled = true;
            //            button2.Enabled = res.Judgement == "PASS";

            button1.Visible = false;// res.Judgement != "PASS";
            button2.Visible = false;// res.Judgement != "PASS";
            actualPictureBox.Image = fileLib.ReadImage(img.Item2, res.Judgement == "PASS"); //Image.FromFile(img.Item2);
            parameterPictureBox.Image = fileLib.ReadImage(img.Item1, true);
            _curPos = Positions.Where(x=>x.Pos==curArea.Position).First();
            _curInspectionView = res;
        }
        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            mainCts.Cancel();
        }
        private async Task LoopProcess()
        {
            mainCts = new CancellationTokenSource();
            cTokenSource = new CancellationTokenSource();
            await GetPos();
            LoadCavityGridTable(false);
            try
            {
                while (!mainCts.IsCancellationRequested)
                {
                    cavities!.CurrentCavity = 0;
                    SwitchControlState("waiting");
                    string res = await mainConn.SendCommand("RD MR004");
                    while (res.Last() != '1')
                    {

                        if (mainCts.IsCancellationRequested )
                            return;
                        if (cTokenSource.IsCancellationRequested)
                            break;
                        res = await mainConn.SendCommand("RD MR004");
                    }
                    await mainConn.SendCommand("WR MR002 1");
                    do
                    {
                        if (mainCts.IsCancellationRequested)
                            return;
                        if (cTokenSource.IsCancellationRequested)
                            break;
                        res = await mainConn.SendCommand($"RD MR8000");
                    }
                    while (!res.Contains("1") && !res.Contains("ok"));
                    isRunning = true;
                    Invoke(delegate
                    {
                        cTokenSource.Dispose();
                        cTokenSource = new CancellationTokenSource();
                        finalJudgeLabel.Text = string.Empty;
                        areaLabel.Text = string.Empty;
                        decisionLabel.Text = string.Empty;
                        processTimeLabel.Invoke(new Action(() => processTimeLabel.Text = "Process Time: 00:00:00"));
                        actualPictureBox.Image = null;
                        parameterPictureBox.Image = null;
                        startTime = DateTime.Now;
                        processTimer.Enabled = true;
                        processTimer.Start();
                        button4.Enabled = false;
                        button6.Enabled = false;
                    });
                    await GetPos();
                    LoadCavityGridTable(false);
                    await ScanRun();
                    if (cavities!.isCavitiesPass())
                        await LogWrite();
                    else
                    {

                        Invoke(delegate
                        {
                            statusLabel.Text = "Complete (Need Verification)";
                            button6.Enabled = true;
                        });

                    }
                }
            }
            catch (Exception ex)
            {
                isRunning = false;
                Debug.WriteLine("ERROR: " + ex.Message + " " + ex.StackTrace);
                updateStatusText("ERROR: " +ex.Message);
                mainCts.Cancel();
                cTokenSource.Cancel();
                return;
            }
        }
        private async void NGWatcherEvent(object sender,FileSystemEventArgs e)
        {
            if (e.Name is null && !isRunning)
                return;
            await Task.Delay(Properties.Settings.Default.NgCameraDelay);
            ngImage.Add(e.FullPath);
        }
        private void SNWatcherEvent(object sender,FileSystemEventArgs e)
        {
            if (e.FullPath is null && !isRunning)
                return;
            snFile = e.FullPath;
            return;

        }
        
        
        private void inputSerialView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || isRunning)
                return;
            cavities!.CurrentCavity = e.RowIndex;
            groupBox3.Text = "Inspection List: " + inputSerialView[0, cavities!.CurrentCavity].Value.ToString();

            finalJudgeLabel.Text = inputSerialView[2, e.RowIndex].Value.ToString();
            finalJudgeLabel.ForeColor = finalJudgeLabel.Text == "PASS" ? Color.LimeGreen : Color.DarkRed;
            LoadInspectionToGrid();
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            DialogResult? res = null;
            Invoke(delegate
            {
                res = MessageBox.Show("Are you sure want to change total cavity of this model?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            });
            if (res == DialogResult.Yes)
            {
                var cModel = cavities!.Cavity;
                cModel.CavityTotal = int.Parse(comboBox1.Text);
                await dbCon.SaveCavity(Model, cModel);
                cModel = await dbCon.GetCavity(Model);
                if (cModel is null)
                    return;
                await ReloadCavity(cModel);
                LoadCavityGridTable();
            }
        }

        private async void button5_Click(object sender, EventArgs e)
        {

            this.button5.Invoke(new Action(() => this.button5.Enabled = false));

            LoadCavityGridTable(true);
            if (isRunning)
            {
                cTokenSource.Cancel();

                processTimer.Enabled = false;
                processTimer.Stop();
                await GetPos();
                Invoke(delegate
                {
                    button4.Enabled = true;
                    isRunning = false;
                    statusLabel.Text = "Cancelled...";
                });
            }
            await mainConn.SendCommand("WR MR3000 0");
            await mainConn.SendCommand("WR MR001 0");
            await mainConn.SendCommand("WR DM0 0");
            await mainConn.SendCommand("WR MR701 1");
            await Task.Delay(DelayTimer);
            await mainConn.SendCommand("WR MR701 0");
            await mainConn.SendCommand("WR M400 0");
            await mainConn.SendCommand("WR B068 0");
            await mainConn.SendCommand("WR MR006 1");
            await Task.Delay(DelayTimer);
            await mainConn.SendCommand("WR MR006 0");
            await mainConn.SendCommand("WR MR003 1");
            await Task.Delay(DelayTimer);
            await mainConn.SendCommand("WR MR003 0");
            this.button5.Invoke(new Action(() => this.button5.Enabled = true));
        }

        private async void button6_Click(object sender, EventArgs e)
        {
            await ShowLogPopup();
        }
    }
}
