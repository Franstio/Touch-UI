﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestTCP1.Lib;
using TestTCP1.Model;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Button = System.Windows.Forms.Button;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.ComponentModel.Design;

namespace TestTCP1.Forms
{
    public partial class SettingParameterControl : UserControl, IDisposable
    {
        private string _image = string.Empty;
        private string _imageFull = string.Empty;
        private readonly FileLib fileLib = new FileLib();
        public string Model { get; set; } = string.Empty;
        private PositionModel curModel = new PositionModel();
        private readonly TCPConn mainConn = TCPConn.newInstance();
        private readonly TCPConn livePositionConn = TCPConn.newInstance();
        private readonly DbConn dbCon = new DbConn();
        private readonly Mapper map = AutoMapConfig.GetMapper();
        private readonly Button[] minusButtons = new Button[3];
        private List<PositionModel> Positions = new List<PositionModel>();
        private string state = "JOG";
        private CancellationTokenSource tokenSource = new CancellationTokenSource();
        private TimeSpan delayTimer = TimeSpan.FromSeconds(1);
        private bool isPressed = false;
        private Button[] _buttons = new Button[0];
        private readonly int CameraDelay = 0;
        private Dictionary<string, Dictionary<string, string>> CommandDict = new Dictionary<string, Dictionary<string, string>>
        {
            ["JOG"] = new Dictionary<string, string>
            {
                ["X+"] = "MR310",
                ["X-"] = "MR311",
                ["Y+"] = "MR305",
                ["Y-"] = "MR306",
                ["Z+"] = "MR308",
                ["Z-"] = "MR309"
            },
            ["INCHING"] = new Dictionary<string, string>
            {

                ["X+"] = "MR14",
                ["X-"] = "MR15",
                ["Y+"] = "MR12",
                ["Y-"] = "MR13",
                ["Z+"] = "MR10",
                ["Z-"] = "MR11"
            }
        };
        private List<string> InchingCommand = new List<string>
        {
            "CM8180",
            "CM8380",
            "CM8580",
            "CM8190",
            "CM8390",
            "CM8590",
        };
        //        private bool debug = false;
        private Dictionary<string, string> selectedCommand;
        private readonly int DelayTimer = 0;
        public SettingParameterControl(string Model)
        {
            InitializeComponent();
            minusButtons = new Button[] { button5, button8, button10 };
            this.Model = Model;
            runningModel.Text = $"Model: {Model}";

            checkMinusButton();
            DataTable dt = new DataTable();
            dt.Columns.Add("Point");
            dt.Columns.Add("Area");
            dt.Columns.Add("Camera Set");
            dt.Columns.Add("Axis (X,Y,Z)");
            parameterDatsGridView.DataSource = dt; ;
            Task.Run(LoadLivePosition, tokenSource.Token);
            selectedCommand = CommandDict["JOG"];
            _buttons = this.groupBox4.Controls.Cast<Control>().Where(x => x.GetType() == typeof(Button)).Cast<Button>().ToArray();
            DelayTimer = int.Parse(Properties.Settings.Default["DelaySettingParameter"].ToString() ?? "0");
            CameraDelay = int.Parse(Properties.Settings.Default["CameraDelay"].ToString() ?? "0");
        }
        private async Task LoadLivePosition()
        {

            while (true)
            {
                if (!mainConn.IsRunning())
                    await mainConn.StartConnection();
                if (!livePositionConn.IsRunning())
                    await livePositionConn.StartConnection();
                await LoadPosition();
                this.Invoke(new Action(() =>
                {
                    updatePositionAll();
                    checkMinusButton();
                }));
                await Task.Delay(delayTimer);
            }
        }

        public async Task LoadInching()
        {
            if (comboBox1.SelectedItem is null || comboBox1.SelectedItem.ToString() is null || comboBox1.SelectedItem.ToString() == string.Empty)
                return;
            decimal mmVal = decimal.Parse(comboBox1.SelectedItem.ToString()!);
            decimal initVal = 80;
            initVal = initVal * mmVal;
            for (int i = 0; i < InchingCommand.Count; i++)
                await mainConn.SendCommand($"WR {InchingCommand[i]}{(i > 2 ? ".L" :string.Empty)} {(i > 2 ? "-" : "")}{initVal.ToString().Split(".").FirstOrDefault()}");
        }
        private async void SettingParameterControl_Load(object sender, EventArgs e)
        {
            await ReloadData();
            //await LoadPosition();
            this.Invoke(new Action(() => updatePositionAll()));
            this.runningModel.Invoke(new Action(() => runningModel.Text = "Model: " + Model));
            int? cPoint = await dbCon.GetCamPoint(this.Model);
            fileLib.FolderCode = cPoint ?? 1;
            camPoint.Invoke(new Action(() => camPoint.Value = cPoint ?? 1));
            await LoadJogState("JOG");
            var data = await dbCon.GetCAvity(Model);
            pitchingBox.Value = data?.Pitching ?? 0;
            cavityBox.Value = data?.CavityTotal ?? 1;
        }
        private void checkMinusButton()
        {
            minusButtons[0].Enabled = curModel.X > 0;
            minusButtons[1].Enabled = curModel.Y > 0;
            minusButtons[2].Enabled = curModel.Z > 0;
        }
        private async Task ReloadData()
        {
            curModel = new PositionModel();
            curModel.Model = this.Model;
            if (!mainConn.IsRunning())
                await mainConn.StartConnection();
            if (!livePositionConn.IsRunning())
                await livePositionConn.StartConnection();
            var res = await dbCon.GetPositionByModel(Model);
            if (res is null || res.Count < 1)
            {
                curModel.Pos = 1;
                pointLabel.Invoke(new Action(() =>
                {
                    pointLabel.Text = "Point: " + curModel.Pos;
                }));

                parameterDatsGridView.DataSource = new List<ModelPosView>();
                parameterDatsGridView.Refresh();
                return;
            }
            Positions = res;
            var v = map.Map<List<ModelPosView>>(res);
            parameterDatsGridView.DataSource = v;
            parameterDatsGridView.Columns[3].HeaderText = "Axis (X,Y,Z)";
            parameterDatsGridView.Refresh();
            curModel.Pos = v.Select(x => x.Pos).Max() + 1;
            pointLabel.Invoke(new Action(() =>
            {
                pointLabel.Text = "Point: " + curModel.Pos;
            }));
            inspectionAreaBox.Invoke(new Action(() =>
            {
                inspectionAreaBox.Text = "";
            }));
            cameraTriggerBox.Invoke(new Action(() =>
            {
                cameraTriggerBox.Text = "";
            }));
        }

        private async void moveCoordinate(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            string res = string.Empty, result = string.Empty;
            if (!selectedCommand.ContainsKey(b.Tag.ToString() ?? ""))
                return;
            bool check = isPressed && state == "JOG";
            int val = check ? 0 : 1;
            await mainConn.SendCommand($"WR {selectedCommand[b.Tag.ToString()!]} {val}");
            if (state == "JOG")
            {
                foreach (var btn in _buttons)
                    if (btn.Name != b.Name)
                        btn.Enabled = isPressed;
                isPressed = !isPressed;
                if (isPressed)
                    return;
            }
            switch (b.Tag.ToString())
            {
                case "X+":
                    //await mainConn.SendCommand($"WR MR14 1");
                    result = await mainConn.SendCommand("RD CM8830");
                    res = "X";
                    curModel.X = decimal.Parse(result);
                    break;
                case "X-":
                    //await mainConn.SendCommand("WR MR15 1");
                    result = await mainConn.SendCommand("RD CM8830");
                    res = "X";
                    curModel.X = decimal.Parse(result);
                    break;
                case "Y+":
                    //await mainConn.SendCommand("WR MR12.L 1");
                    result = await mainConn.SendCommand("RD CM8870");
                    res = "Y";
                    curModel.Y = decimal.Parse(result);
                    break;
                case "Y-":
                    //await mainConn.SendCommand("WR MR13.L 1");
                    result = await mainConn.SendCommand("RD CM8870");
                    res = "Y";
                    curModel.Y = decimal.Parse(result);
                    break;
                case "Z+":
                    //await mainConn.SendCommand("WR MR10 1");
                    result = await mainConn.SendCommand("RD CM8910");
                    res = "Z";
                    curModel.Z = decimal.Parse(result);
                    break;
                case "Z-":
                    //await mainConn.SendCommand("WR MR11 1");
                    result = await mainConn.SendCommand("RD CM8910");
                    res = "Z";
                    curModel.Z = decimal.Parse(result);
                    break;
            }
            this.Invoke(new Action(() => updatePosition(res)));
        }

        private void updatePosition(string label)
        {
            switch (label)
            {
                case "X":
                    xLabel.Text = $"X: {(curModel.X / 1600 * 20).ToString("0.00")} mm";
                    break;
                case "Y":
                    yLabel.Text = $"Y: {(curModel.Y / 1600 * 20).ToString("0.00")} mm";
                    break;
                case "Z":
                    zLabel.Text = $"Z: {(curModel.Z / 1600 * 20).ToString("0.00")} mm";
                    break;
            }
            checkMinusButton();
        }
        private void updatePositionAll()
        {
            xLabel.Text = $"X: {(curModel.X / 1600 * 20).ToString("0.00")} mm";
            yLabel.Text = $"Y: {(curModel.Y / 1600 * 20).ToString("0.00")} mm";
            zLabel.Text = $"Z: {(curModel.Z / 1600 * 20).ToString("0.00")} mm";
            checkMinusButton();
        }
        private async Task LoadPosition()
        {
            curModel.X = await LoadValue("RD CM8830", curModel.X);
            curModel.Y = await LoadValue("RD CM8870", curModel.Y);
            //            if (debug)
            //                debug = false;
            curModel.Z = await LoadValue("RD CM8910", curModel.Z);
        }
        private async Task<decimal> LoadValue(string command, decimal defaultValue)
        {
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
                    await Task.Delay(DelayTimer);
                    return defaultValue;
                }
            }
            bool s = decimal.TryParse(res.Replace("+", "").Replace("\r", "").Replace("\n", ""), out value);
            return s ? value : defaultValue;
        }

        private async void button12_Click(object sender, EventArgs e)
        {
            button12.Invoke(new Action(() => { button12.Enabled = false; }));
            curModel.CameraCheckpoint = cameraTriggerBox.Text;
            curModel.Model = Model;
            curModel.AreaInspection = inspectionAreaBox.Text;
            curModel.X = curModel.X / 1600 * 20;
            curModel.Y = curModel.Y / 1600 * 20;
            curModel.Z = curModel.Z / 1600 * 20;
            PosView v = map.Map<PosView>(curModel);
            v.CameraPoint = int.Parse(camPoint.Value.ToString());
            await dbCon.SavePosition(v);
            await dbCon.SaveImage(curModel.Model, curModel.Pos, _image);
            fileLib.SaveImage(_imageFull, _image);
            pictureBox1.Invoke(new Action(() => pictureBox1.Image = null));
            await ReloadData();
            button12.Invoke(new Action(() => { button12.Enabled = true; }));
        }

        private async Task TriggerCamPoint(int CamPoint)
        {
            var res = await mainConn.SendCommand($"WR W0F8 {CamPoint}");
            res = await mainConn.SendCommand($"WR MR401 1");
            Task.Delay(DelayTimer);
            await mainConn.SendCommand($"WR MR401 0");
            fileLib.FolderCode = CamPoint;
            var pv = map.Map<PosView>(curModel);
            await dbCon.SaveCamPoint(pv, int.Parse(camPoint.Value.ToString()));
        }
        private async void button11_Click(object sender, EventArgs e)
        {
            this.button11.Invoke(new Action(() => { button11.Enabled = false; }));
            curModel.AreaInspection = inspectionAreaBox.Text;
            curModel.CameraCheckpoint = cameraTriggerBox.Text;
            await mainConn.SendCommand($"WR W0F2 {cameraTriggerBox.Text}");
            await mainConn.SendCommand("WR MR400 1");
            await Task.Delay(CameraDelay);
            await mainConn.SendCommand("WR MR400 0");
            //            MessageBox.Show("Send Trigger Command Complete", "Send Trigger Command");
            await Task.Delay(DelayTimer);
            await GetTriggerImage(curModel);
            this.button11.Invoke(new Action(() => { button11.Enabled = true; }));
        }
        private async Task GetTriggerImage(PositionModel data)
        {
            string foldername = $"{DateTime.Now.ToString("yyMMdd")}";
            string[] folders = fileLib.GetFolders(foldername);
            if (folders.Length < 1)
            {
                MessageBox.Show($"No Folder with prefix {foldername} Found", "Error");
                return;
            }
            string latestDir = Path.Combine(folders[0], "CAM1");
            string[] img = await fileLib.GetFiles(latestDir);
            if (img.Length < 1)
                return;
            FileInfo file = new FileInfo(img[0]);
            _image = file.Name;
            _imageFull = img[0];
            pictureBox1.Invoke(new Action(() =>
            {
                try
                {
                    pictureBox1.Image = Image.FromFile(img[0]);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }));

        }
        private async void button2_Click(object sender, EventArgs e)
        {

            button2.Invoke(new Action(() => { button2.Enabled = false; }));
            int newPos = int.Parse(insertAfter.Value.ToString());
            curModel.Pos = newPos + 1;
            curModel.AreaInspection = inspectionAreaBox.Text;
            curModel.CameraCheckpoint = cameraTriggerBox.Text;
            PosView v = map.Map<PosView>(curModel);
            v.CameraPoint = int.Parse(camPoint.Value.ToString());
            await dbCon.InsertAter(newPos, v);
            await ReloadData();
            button2.Invoke(new Action(() => { button2.Enabled = true; }));
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            button3.Invoke(new Action(() => { button3.Enabled = false; }));
            curModel.Pos = int.Parse(delPos.Value.ToString());
            curModel.Model = Model;
            await dbCon.DeletePosition(curModel);
            await ReloadData();
            button3.Invoke(new Action(() => { button3.Enabled = true; }));
        }
        private void GotoPoint(PositionModel _data)
        {
            //string res = string.Empty;
            curModel = new PositionModel(_data);
            curModel.X = _data.X * 1600 / 20;
            curModel.Y = _data.Y * 1600 / 20;
            curModel.Z = _data.Z * 1600 / 20;
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            Task.Run(new Action(async () => await GoPoint()));
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed

        }
        private async Task GoPoint()
        {

            string xVal = String.Format("{0:0}", curModel.X);
            string yVal = String.Format("{0:0}", curModel.Y);
            string zVal = String.Format("{0:0}", curModel.Z);
            string res = string.Empty;
            res = await mainConn.SendCommand($"WR CM8010 {xVal}");
            res = await mainConn.SendCommand($"WR CM8210 {yVal}");
            //            debug = true;
            res = await mainConn.SendCommand($"WR CM8410 {zVal}");

            await mainConn.SendCommand($"WR MR800 1");
            await Task.Delay(DelayTimer);
            await mainConn.SendCommand($"WR MR800 0");

            string img = await dbCon.GetLocalImage(curModel);
            pictureBox1.Invoke(new Action(() => pictureBox1.Image = fileLib.ReadImage(img, true)));
            this.button1.Invoke(new Action(() => { button1.Enabled = true; }));
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            var res = await dbCon.GetPositionByModel(Model);
            if (res is null || res.Count < 1)
                return;
            Positions = res;
            this.button1.Invoke(new Action(() => { button1.Enabled = false; }));
            int go = int.Parse(gotoValue.Value.ToString());
            var find = Positions.Where(x => x.Pos == go).FirstOrDefault();
            if (find is null)
            {
                this.Invoke(new Action(() =>
                {
                    MessageBox.Show("Position Not  Found", "Error");
                    this.button1.Enabled = true;
                }));
                return;
            }
            GotoPoint(find);

            this.Invoke(new Action(() =>
            {
                pointLabel.Text = "Point: " + curModel.Pos;
                cameraTriggerBox.Text = curModel.CameraCheckpoint;
                inspectionAreaBox.Text = curModel.AreaInspection;
                xLabel.Text = $"X: {(curModel.X / 1600 * 20).ToString("0.00")} mm";
                yLabel.Text = $"Y: {(curModel.Y / 1600 * 20).ToString("0.00")} mm";
                zLabel.Text = $"Z: {(curModel.Z / 1600 * 20).ToString("0.00")} mm";
            }));
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timeLabel.Invoke(new Action(() =>
            {
                timeLabel.Text = $"Date: {DateTime.Now.ToString("dd MMM yyyy")}\nTime: {DateTime.Now.ToString("HH:mm:ss")}";
            }));
        }

        private async void button13_Click(object sender, EventArgs e)
        {
            button13.Invoke(new Action(() => { button13.Enabled = false; }));

            string res = string.Empty;

            res = await mainConn.SendCommand($"WR MR500 1");
            res = await mainConn.SendCommand($"WR MR501 1");
            res = await mainConn.SendCommand($"WR MR502 1");
            await Task.Delay(DelayTimer);
            res = await mainConn.SendCommand($"WR MR500 0");
            res = await mainConn.SendCommand($"WR MR501 0");
            res = await mainConn.SendCommand($"WR MR502 0");

            //            await LoadPosition();
            this.Invoke(new Action(() => updatePositionAll()));
            button13.Invoke(new Action(() => { button13.Enabled = true; }));
        }

        private async void button4_Click(object sender, EventArgs e)
        {

            button4.Invoke(new Action(() => { button4.Enabled = false; }));

            string res = string.Empty;

            res = await mainConn.SendCommand($"WR MR003 1");
            await Task.Delay(DelayTimer);
            res = await mainConn.SendCommand($"WR MR003 0");

            //await LoadPosition();
            this.Invoke(new Action(() => updatePositionAll()));
            button4.Invoke(new Action(() => { button4.Enabled = true; }));
        }

        private async void liveConnectionTimer_Tick(object sender, EventArgs e)
        {
            if (!mainConn.IsRunning())
                await mainConn.StartConnection();
            if (!livePositionConn.IsRunning())
                await livePositionConn.StartConnection();
            await LoadPosition();
            updatePositionAll();
            checkMinusButton();
        }

        private async void button14_Click(object sender, EventArgs e)
        {
            button14.Invoke(new Action(() => button14.Enabled = false));
            tokenSource.Cancel();
            await TriggerCamPoint(int.Parse(camPoint.Value.ToString()));
            await Task.Delay(DelayTimer);
            Task.Run(LoadLivePosition, tokenSource.Token);
            button14.Invoke(new Action(() => button14.Enabled = true));
        }

        private void button15_Click(object sender, EventArgs e)
        {
            MarkPointForm markForm = new MarkPointForm(Model);
            markForm.ShowDialog();
        }

        private async void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            await LoadJogState("JOG");
        }

        private async void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            await LoadJogState("INCHING");
        }
        private async Task LoadJogState(string _isJog)
        {
            state = _isJog;
            comboBox1.Invoke(new Action(() => comboBox1.Enabled = radioButton2.Checked));
            var buttons = this.Controls.Cast<Control>().Where(x => x.GetType() == typeof(Button)).ToArray();
            selectedCommand = CommandDict[state];
            if (state == "INCHING")
            {
                foreach (var button in buttons)
                    button.Enabled = false;
                await LoadInching();
                foreach (var button in buttons)
                    button.Enabled = true;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadJogState("INCHING");
        }

        private void parameterDatsGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void button16_Click(object sender, EventArgs e)
        {
            this.button16.Invoke(new Action(() => this.button16.Enabled = false));
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
            this.button16.Invoke(new Action(() => this.button16.Enabled = true));
        }

        private async void button17_Click(object sender, EventArgs e)
        {
            button17.Invoke(delegate
            {
                button17.Enabled = false;
            });
            await dbCon.SaveCavity(Model, new TestTCP1.Model.ViewModel.CavityModel() { CavityTotal = int.Parse(cavityBox.Value.ToString() ?? "0"), Pitching = pitchingBox.Value });
            button17.Invoke(delegate
            {
                button17.Enabled = true;
            });

        }
    }
}