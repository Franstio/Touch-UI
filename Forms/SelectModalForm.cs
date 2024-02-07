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

namespace TestTCP1.Forms
{
    public partial class SelectModalForm : Form
    {
        public string Result { get; set; } = string.Empty;  
        public bool isDropDown { get; set; } = false;
        public List<string> Data { get; set; } = new List<string>();
        public SelectModalForm(string title, List<string> data)
        {
            InitializeComponent();
            this.groupBox1.Text = title;
            Text = title;
            this.Data = data;
            isDropDown = true;
            comboBox1.Items.AddRange(data.ToArray());
        }

        private void textBox1_FontChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void InputModalForm_Load(object sender, EventArgs e)
        {
            Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Result = comboBox1.Text;
            this.Close();

        }
    }
}
