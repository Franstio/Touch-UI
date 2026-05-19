using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestTCP1.Forms
{
    public partial class TaskViewer : Form
    {
        private List<Tuple<string,Task>> Tasks;
        public TaskViewer(List<Tuple<string, Task>> Tasks)
        {
            InitializeComponent();
            this.Tasks = Tasks;
        }

        private void TaskViewer_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns.Add("TaskName","Task Name");
            dataGridView1.Columns.Add("Status", "Status");
            for (int i=0;i<Tasks.Count;i++)
            {
                dataGridView1.Rows.Add(Tasks[i].Item1, Tasks[i].Item2.Status);
            }
            dataGridView1.Refresh();
        }
    }
}
