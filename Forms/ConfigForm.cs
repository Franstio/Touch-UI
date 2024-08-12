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

namespace TestTCP1.Forms
{
    public partial class ConfigForm : UserControl
    {
        private TCPConn tcp = TCPConn.newInstance();
        public ConfigForm()
        {
            InitializeComponent();
            button15.Text = tcp.IsRunning() ? "Disconnect" : "Connect";
            ipBox.Enabled = !tcp.IsRunning();
            portBox.Enabled = !tcp.IsRunning();
            statusLabel.Text = "Status: " + (tcp.IsRunning() ? "Connected" : "Disconnected");
            currentPasswordBox.PasswordChar = '*';
            newPasswordBox.PasswordChar = '*';
            LoadDirBox();
        }

        private async void button15_Click(object sender, EventArgs e)
        {
            if (tcp.IsRunning())
            {
                tcp.StopConnection();
                ipBox.Enabled = true;
                portBox.Enabled = true;
                button15.Invoke(new Action(() => { button15.Text = "Connect"; }));
            }
            else
            {
                Properties.Settings.Default["ServerIpAddress"] = ipBox.Text;
                Properties.Settings.Default["ServerPort"] = int.Parse(portBox.Text);
                Properties.Settings.Default.Save();
                tcp.SetIpAddress(ipBox.Text);
                tcp.SetPort(int.Parse(portBox.Text));
                this.Invoke(new Action(() =>
                {
                    button15.Text = "Disconnect";
                    ipBox.Enabled = false;
                    portBox.Enabled = false;
                }));
                await tcp.StartConnection();
                MessageBox.Show("Save Complete");
            }
            statusLabel.Invoke(new Action(() =>
            {
                statusLabel.Text = "Status: " + (tcp.IsRunning() ? "Connected" : "Disconnected");
            }));
        }

        private void ConfigForm_Load(object sender, EventArgs e)
        {

            ipBox.Text = Properties.Settings.Default["ServerIpAddress"].ToString();
            portBox.Text = Properties.Settings.Default["ServerPort"].ToString();
            dashboardDelay.Value = Convert.ToDecimal(Properties.Settings.Default["DelayDashboardProcess"].ToString() ?? "0");
            settingParamDelay.Value = Convert.ToDecimal(Properties.Settings.Default["DelaySettingParameter"].ToString() ?? "0");
            cameraTriggerDelay.Value = Convert.ToDecimal(Properties.Settings.Default["CameraDelay"].ToString() ?? "0");
            ngCameraDelay.Value = Convert.ToDecimal(Properties.Settings.Default["NgCameraDelay"].ToString() ?? "0");
            snResultDelay.Value = Convert.ToDecimal(Properties.Settings.Default["SNResultDelay"].ToString() ?? "0");
        }
        private string GetConfig(string name)
        {
            return Properties.Settings.Default[name].ToString() ?? string.Empty;
        }
        private void LoadDirBox()
        {
            triggerImgSaveDir.Text = GetConfig("SaveImageDirName");
            ngImgSaveDir.Text = GetConfig("NgImageDirName");
            markedImgSaveDir.Text = GetConfig("MarkSaveDir");
            ftpCameraDir.Text = GetConfig("ImageDirName");
            reportLogPath.Text = GetConfig("LogPath");
            debugLogPath.Text = GetConfig("DebugLogPath");
            snResultPath.Text = GetConfig("SNResultPath");
            snLocation.Text = GetConfig("SNLocation");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default["DelayDashboardProcess"] = int.Parse(dashboardDelay.Value.ToString());
            Properties.Settings.Default["DelaySettingParameter"] = int.Parse(settingParamDelay.Value.ToString());
            Properties.Settings.Default["CameraDelay"] = int.Parse(cameraTriggerDelay.Value.ToString());
            Properties.Settings.Default["NgCameraDelay"] = int.Parse(ngCameraDelay.Value.ToString());
            Properties.Settings.Default["SNResultDelay"] = int.Parse(snResultDelay.Value.ToString());
            Properties.Settings.Default.Save();
        }

        private void openDialogFolder(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            var res = folderBrowserDialog1.ShowDialog();
            if (res != DialogResult.OK)
                return;
            Properties.Settings.Default[btn.Tag.ToString()] = folderBrowserDialog1.SelectedPath;
            Properties.Settings.Default.Save();
            LoadDirBox();
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string currentPassword = Properties.Settings.Default["Password"].ToString() ?? string.Empty;
            if (currentPassword != currentPasswordBox.Text.Hmac512Hash() || newPasswordBox.Text == string.Empty)
            {
                MessageBox.Show(newPasswordBox.Text == string.Empty ? "New Passwrod Can't be Empty" : "Incorrect Password");
                return;
            }
            Properties.Settings.Default["Password"] = newPasswordBox.Text.Hmac512Hash();
            Properties.Settings.Default.Save();
            MessageBox.Show("Password Successfully Updated");
        }
    }
}
