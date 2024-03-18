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
using TestTCP1.Forms;
using TestTCP1.Lib;

namespace TestTCP1
{
    public partial class MainForm : Form
    {
        private DbConn conn = new DbConn();
        public MainForm()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }

        private async void changeModelToolStripMenuItem_Click(object sender, EventArgs e)
        {

            var data = await conn.GetPositions(true);
            this.Invoke(new Action(() =>
            {
                SelectModalForm frm = new SelectModalForm("Choose Model", data.Select(x => x.Model).Distinct().ToList());
                mainPanel.Controls.Clear();
                var res = frm.ShowDialog();
                if (res == DialogResult.OK)
                {

                    DashboardControl ctrl = new DashboardControl(frm.Result);
                    ctrl.Dock = DockStyle.Fill;
                    mainPanel.Controls.Add(ctrl);
                }
            }));
        }

        private void newModelParameterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainPanel.Controls.Clear();
            InputModalForm frm = new InputModalForm("New Parameter Setting");
            var res = frm.ShowDialog();
            if (res == DialogResult.OK)
            {

                SettingParameterControl ctrl = new SettingParameterControl(frm.Result);
                ctrl.Dock = DockStyle.Fill;
                mainPanel.Controls.Add(ctrl);
            }
        }

        private async void modifyParameterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InputModalForm passModal = new InputModalForm("Input Password");
            passModal.textBox1.PasswordChar = '*';
            var resDialog = passModal.ShowDialog();
            if (resDialog != DialogResult.OK)
                return;
            if (passModal.Result.Hmac512Hash() != Properties.Settings.Default["Password"].ToString())
            {
                MessageBox.Show("Incorrect Password", "Access Fail");
                return;
            }
            var data = await conn.GetPositions(true);
            this.Invoke(new Action(() =>
            {
                SelectModalForm frm = new SelectModalForm("Modify Parameter Setting", data.Select(x => x.Model).Distinct().ToList());
                mainPanel.Controls.Clear();
                var res = frm.ShowDialog();
                if (res == DialogResult.OK)
                {

                    SettingParameterControl ctrl = new SettingParameterControl(frm.Result);
                    ctrl.Dock = DockStyle.Fill;
                    mainPanel.Controls.Add(ctrl);
                }
            }));
        }

        private void configurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainPanel.Controls.Clear();
            ConfigForm ctrl = new ConfigForm();
            ctrl.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(ctrl);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
