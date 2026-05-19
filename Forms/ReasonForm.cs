using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TouchUI.Forms
{
    public partial class ReasonForm : Form
    {
        public string Result { get; private set; } = string.Empty;
        public ReasonForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Result = richTextBox1.Text;
            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
