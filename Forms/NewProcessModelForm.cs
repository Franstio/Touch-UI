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
    public partial class NewProcessModelForm : Form
    {

        public event EventHandler<ModelFoundEvent>? ModelFound;
        public DbConn dbCon = new DbConn();
        public NewProcessModelForm()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {

            if (ModelFound is null)
            {
                this.Dispose();
                return;
            }
            var pos = await dbCon.GetPositionByModel(textBox1.Text);
            if (pos.Count < 1)
            {
                MessageBox.Show("No Data Found", "Process Fail");
                this.Dispose();
                return;
            }
            ModelFound(this, new ModelFoundEvent() { Positions = pos });
            this.Dispose();
        }
    }
}
