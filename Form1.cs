using System.Configuration;
using System.Data;
using TouchUI.Forms;
using TouchUI.Lib;

namespace TouchUI
{
    public partial class CommandCenter : Form
    {
        public CommandCenter()
        {
            InitializeComponent();
        }
        private void tabPage1_Click(object sender, EventArgs e)
        {
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewProcessModelForm frm1 = new NewProcessModelForm();
            frm1.ModelFound += (s, data) =>
            {
                if (data.Positions is null)
                    return;
                ProcessForm frm = new ProcessForm(data.Positions);
                frm.Dock = DockStyle.Fill;
                mainPanel.Controls.Clear();
                mainPanel.Controls.Add(frm);
            };
            frm1.ShowDialog();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingForm setting = new SettingForm();
            setting.Dock = DockStyle.Fill;
            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(setting);
        }

        private void configToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigForm frm = new ConfigForm();
            frm.Dock = DockStyle.Fill;
            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(frm);
        }
    }
}