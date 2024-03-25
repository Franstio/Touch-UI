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
    public partial class CopyProgramForm : Form
    {
        private DbConn db;
        private List<PositionModel> PositionModel = new List<PositionModel>();
        public CopyProgramForm()
        {
            InitializeComponent();
            db = new DbConn();
        }

        private async void CopyProgramForm_Load(object sender, EventArgs e)
        {
            PositionModel = await db.GetPositions(true);
            comboBox1.Items.AddRange(PositionModel.DistinctBy(x=>x.Model).ToArray());
            comboBox1.ValueMember = "Model";
            comboBox1.SelectedIndex = 0;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            await db.FullCopyPosition(((PositionModel)comboBox1.SelectedItem).Model, newModelNameBox.Text);
            MessageBox.Show("Copy Complete");
            this.Close();
        }
    }
}
