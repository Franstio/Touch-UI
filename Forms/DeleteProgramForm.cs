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
    public partial class DeleteProgramForm : Form
    {
        private readonly DbConn db;
        private List<PositionModel> Positions = new List<PositionModel>();
        public DeleteProgramForm()
        {
            InitializeComponent();
            db = new DbConn();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure want to delete this program?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
                return;
            await db.DeletePosition(((PositionModel)comboBox1.SelectedItem).Model);
            MessageBox.Show("Delete Success");
            Close();
        }

        private async void DeleteProgramForm_Load(object sender, EventArgs e)
        {

            Positions= await db.GetPositions(true);
            comboBox1.Items.AddRange(Positions.DistinctBy(x => x.Model).ToArray());
            comboBox1.ValueMember = "Model";
            comboBox1.SelectedIndex = 0;
        }
    }
}
