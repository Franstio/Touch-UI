namespace TestTCP1.Forms
{
    partial class DashboardControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            runningModel = new Label();
            groupBox2 = new GroupBox();
            panel7 = new Panel();
            labeld = new Label();
            panel5 = new Panel();
            decisionLabel = new Label();
            panel2 = new Panel();
            panel4 = new Panel();
            areaLabel = new Label();
            label4 = new Label();
            groupBox3 = new GroupBox();
            inspectionListGridView = new DataGridView();
            groupBox4 = new GroupBox();
            label6 = new Label();
            groupBox5 = new GroupBox();
            statusLabel = new Label();
            pictureBox1 = new PictureBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            zLabel = new Label();
            yLabel = new Label();
            xLabel = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            finalJudgeLabel = new Label();
            processTimeLabel = new Label();
            processTimer = new System.Windows.Forms.Timer(components);
            timeLabel = new Label();
            groupBox6 = new GroupBox();
            panel1 = new Panel();
            label1 = new Label();
            groupBox7 = new GroupBox();
            campointLabel = new Label();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            tableLayoutPanel2 = new TableLayoutPanel();
            parameterPictureBox = new PictureBox();
            actualPictureBox = new PictureBox();
            tableLayoutPanel3 = new TableLayoutPanel();
            button1 = new Button();
            tableLayoutPanel6 = new TableLayoutPanel();
            button2 = new Button();
            tableLayoutPanel4 = new TableLayoutPanel();
            tableLayoutPanel5 = new TableLayoutPanel();
            tableLayoutPanel7 = new TableLayoutPanel();
            label7 = new Label();
            label5 = new Label();
            groupBox8 = new GroupBox();
            tableLayoutPanel8 = new TableLayoutPanel();
            failCountLabel = new Label();
            quantityLabel = new Label();
            yieldLabel = new Label();
            groupBox9 = new GroupBox();
            inputSerialView = new DataGridView();
            Label = new DataGridViewTextBoxColumn();
            Serial = new DataGridViewTextBoxColumn();
            Decision = new DataGridViewTextBoxColumn();
            button3 = new Button();
            groupBox1 = new GroupBox();
            serialGridView = new DataGridView();
            No = new DataGridViewTextBoxColumn();
            SerialNumber = new DataGridViewTextBoxColumn();
            groupBox10 = new GroupBox();
            button4 = new Button();
            comboBox1 = new ComboBox();
            button5 = new Button();
            groupBox2.SuspendLayout();
            panel7.SuspendLayout();
            panel5.SuspendLayout();
            panel4.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)inspectionListGridView).BeginInit();
            groupBox4.SuspendLayout();
            groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            groupBox6.SuspendLayout();
            panel1.SuspendLayout();
            groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)parameterPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)actualPictureBox).BeginInit();
            tableLayoutPanel3.SuspendLayout();
            tableLayoutPanel6.SuspendLayout();
            tableLayoutPanel7.SuspendLayout();
            groupBox8.SuspendLayout();
            tableLayoutPanel8.SuspendLayout();
            groupBox9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)inputSerialView).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)serialGridView).BeginInit();
            groupBox10.SuspendLayout();
            SuspendLayout();
            // 
            // runningModel
            // 
            runningModel.BackColor = Color.MediumTurquoise;
            runningModel.Dock = DockStyle.Fill;
            runningModel.Font = new Font("Segoe UI", 10F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            runningModel.Location = new Point(3, 23);
            runningModel.Name = "runningModel";
            runningModel.Size = new Size(222, 38);
            runningModel.TabIndex = 0;
            runningModel.Text = "-";
            runningModel.TextAlign = ContentAlignment.MiddleCenter;
            runningModel.Click += runningModel_Click;
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupBox2.BackColor = SystemColors.Control;
            groupBox2.Controls.Add(panel7);
            groupBox2.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox2.Location = new Point(667, 238);
            groupBox2.Margin = new Padding(3, 2, 3, 2);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 2, 3, 2);
            groupBox2.Size = new Size(228, 125);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Inspection";
            groupBox2.Enter += groupBox2_Enter;
            // 
            // panel7
            // 
            panel7.BackColor = Color.MediumTurquoise;
            panel7.Controls.Add(labeld);
            panel7.Controls.Add(panel5);
            panel7.Controls.Add(panel4);
            panel7.Controls.Add(label4);
            panel7.Dock = DockStyle.Fill;
            panel7.Location = new Point(3, 22);
            panel7.Name = "panel7";
            panel7.Size = new Size(222, 101);
            panel7.TabIndex = 20;
            // 
            // labeld
            // 
            labeld.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            labeld.AutoSize = true;
            labeld.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            labeld.Location = new Point(74, 47);
            labeld.Name = "labeld";
            labeld.Size = new Size(69, 19);
            labeld.TabIndex = 6;
            labeld.Text = "Decision:";
            // 
            // panel5
            // 
            panel5.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel5.BackColor = Color.Transparent;
            panel5.Controls.Add(decisionLabel);
            panel5.Controls.Add(panel2);
            panel5.Location = new Point(3, 76);
            panel5.Name = "panel5";
            panel5.Size = new Size(219, 25);
            panel5.TabIndex = 9;
            // 
            // decisionLabel
            // 
            decisionLabel.BackColor = Color.MediumTurquoise;
            decisionLabel.Dock = DockStyle.Fill;
            decisionLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            decisionLabel.ForeColor = Color.Lime;
            decisionLabel.Location = new Point(0, 0);
            decisionLabel.Name = "decisionLabel";
            decisionLabel.Size = new Size(219, 25);
            decisionLabel.TabIndex = 7;
            decisionLabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // panel2
            // 
            panel2.Location = new Point(6, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(252, 31);
            panel2.TabIndex = 17;
            // 
            // panel4
            // 
            panel4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel4.Controls.Add(areaLabel);
            panel4.Location = new Point(3, 27);
            panel4.Name = "panel4";
            panel4.Size = new Size(220, 17);
            panel4.TabIndex = 8;
            // 
            // areaLabel
            // 
            areaLabel.BackColor = Color.MediumTurquoise;
            areaLabel.Dock = DockStyle.Fill;
            areaLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            areaLabel.Location = new Point(0, 0);
            areaLabel.Name = "areaLabel";
            areaLabel.Size = new Size(220, 17);
            areaLabel.TabIndex = 5;
            areaLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(62, 6);
            label4.Name = "label4";
            label4.Size = new Size(88, 19);
            label4.TabIndex = 4;
            label4.Text = "Checkpoint:";
            // 
            // groupBox3
            // 
            groupBox3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            groupBox3.Controls.Add(inspectionListGridView);
            groupBox3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox3.Location = new Point(902, 392);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(3, 2, 3, 2);
            groupBox3.Size = new Size(307, 177);
            groupBox3.TabIndex = 4;
            groupBox3.TabStop = false;
            groupBox3.Text = "Inspection List:";
            groupBox3.Enter += groupBox3_Enter;
            // 
            // inspectionListGridView
            // 
            inspectionListGridView.AllowUserToAddRows = false;
            inspectionListGridView.AllowUserToDeleteRows = false;
            inspectionListGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            inspectionListGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            inspectionListGridView.BackgroundColor = SystemColors.Control;
            inspectionListGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            inspectionListGridView.Dock = DockStyle.Fill;
            inspectionListGridView.Location = new Point(3, 24);
            inspectionListGridView.Margin = new Padding(3, 2, 3, 2);
            inspectionListGridView.Name = "inspectionListGridView";
            inspectionListGridView.ReadOnly = true;
            inspectionListGridView.RowHeadersWidth = 51;
            inspectionListGridView.RowTemplate.Height = 29;
            inspectionListGridView.Size = new Size(301, 151);
            inspectionListGridView.TabIndex = 0;
            inspectionListGridView.CellClick += inspectionListGridView_CellClick;
            inspectionListGridView.CellContentClick += inspectionListGridView_CellContentClick;
            inspectionListGridView.CellContentDoubleClick += inspectionListGridView_CellContentDoubleClick;
            // 
            // groupBox4
            // 
            groupBox4.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            groupBox4.Controls.Add(label6);
            groupBox4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox4.Location = new Point(905, 613);
            groupBox4.Margin = new Padding(3, 2, 3, 2);
            groupBox4.Name = "groupBox4";
            groupBox4.Padding = new Padding(3, 2, 3, 2);
            groupBox4.Size = new Size(304, 50);
            groupBox4.TabIndex = 5;
            groupBox4.TabStop = false;
            groupBox4.Text = "Log File:";
            groupBox4.Enter += groupBox4_Enter;
            // 
            // label6
            // 
            label6.BackColor = Color.LightGreen;
            label6.Dock = DockStyle.Fill;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label6.Location = new Point(3, 24);
            label6.Name = "label6";
            label6.Size = new Size(298, 24);
            label6.TabIndex = 8;
            label6.Text = "log1123445.txt";
            label6.TextAlign = ContentAlignment.MiddleLeft;
            label6.Click += label6_Click;
            // 
            // groupBox5
            // 
            groupBox5.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            groupBox5.Controls.Add(statusLabel);
            groupBox5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox5.Location = new Point(668, 645);
            groupBox5.Margin = new Padding(3, 2, 3, 2);
            groupBox5.Name = "groupBox5";
            groupBox5.Padding = new Padding(3, 2, 3, 2);
            groupBox5.Size = new Size(227, 55);
            groupBox5.TabIndex = 9;
            groupBox5.TabStop = false;
            groupBox5.Text = "Status:";
            groupBox5.Enter += groupBox5_Enter;
            // 
            // statusLabel
            // 
            statusLabel.BackColor = Color.LightGreen;
            statusLabel.Dock = DockStyle.Fill;
            statusLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            statusLabel.Location = new Point(3, 24);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(221, 29);
            statusLabel.TabIndex = 8;
            statusLabel.Text = "log1123445.txt";
            statusLabel.TextAlign = ContentAlignment.MiddleLeft;
            statusLabel.Click += statusLabel_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Location = new Point(11, 121);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(651, 285);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 10;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.Controls.Add(zLabel, 2, 0);
            tableLayoutPanel1.Controls.Add(yLabel, 1, 0);
            tableLayoutPanel1.Controls.Add(xLabel, 0, 0);
            tableLayoutPanel1.Location = new Point(11, 97);
            tableLayoutPanel1.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(621, 20);
            tableLayoutPanel1.TabIndex = 11;
            tableLayoutPanel1.Paint += tableLayoutPanel1_Paint;
            // 
            // zLabel
            // 
            zLabel.AutoSize = true;
            zLabel.Dock = DockStyle.Fill;
            zLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            zLabel.Location = new Point(417, 0);
            zLabel.Name = "zLabel";
            zLabel.Size = new Size(201, 20);
            zLabel.TabIndex = 2;
            zLabel.Text = "Z: 0.00 mm";
            zLabel.TextAlign = ContentAlignment.MiddleCenter;
            zLabel.Click += zLabel_Click;
            // 
            // yLabel
            // 
            yLabel.AutoSize = true;
            yLabel.Dock = DockStyle.Fill;
            yLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            yLabel.Location = new Point(210, 0);
            yLabel.Name = "yLabel";
            yLabel.Size = new Size(201, 20);
            yLabel.TabIndex = 1;
            yLabel.Text = "Y: 0.00 mm";
            yLabel.TextAlign = ContentAlignment.MiddleCenter;
            yLabel.Click += yLabel_Click;
            // 
            // xLabel
            // 
            xLabel.AutoSize = true;
            xLabel.Dock = DockStyle.Fill;
            xLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            xLabel.Location = new Point(3, 0);
            xLabel.Name = "xLabel";
            xLabel.Size = new Size(201, 20);
            xLabel.TabIndex = 0;
            xLabel.Text = "X: 0.00 mm";
            xLabel.TextAlign = ContentAlignment.MiddleCenter;
            xLabel.Click += xLabel_Click;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // finalJudgeLabel
            // 
            finalJudgeLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            finalJudgeLabel.AutoSize = true;
            finalJudgeLabel.Font = new Font("Segoe UI", 48F, FontStyle.Bold, GraphicsUnit.Point);
            finalJudgeLabel.Location = new Point(793, 7);
            finalJudgeLabel.Name = "finalJudgeLabel";
            finalJudgeLabel.Size = new Size(189, 86);
            finalJudgeLabel.TabIndex = 12;
            finalJudgeLabel.Text = "PASS";
            // 
            // processTimeLabel
            // 
            processTimeLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            processTimeLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            processTimeLabel.Location = new Point(670, 619);
            processTimeLabel.Name = "processTimeLabel";
            processTimeLabel.Size = new Size(222, 31);
            processTimeLabel.TabIndex = 13;
            processTimeLabel.Text = "Process Time: 00:00:00";
            processTimeLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // processTimer
            // 
            processTimer.Interval = 1000;
            processTimer.Tick += processTimer_Tick;
            // 
            // timeLabel
            // 
            timeLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            timeLabel.AutoSize = true;
            timeLabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            timeLabel.Location = new Point(905, 666);
            timeLabel.Name = "timeLabel";
            timeLabel.Size = new Size(41, 38);
            timeLabel.TabIndex = 14;
            timeLabel.Text = "Date:\r\nTime:";
            timeLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // groupBox6
            // 
            groupBox6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupBox6.BackColor = SystemColors.Control;
            groupBox6.Controls.Add(runningModel);
            groupBox6.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox6.Location = new Point(667, 97);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(228, 64);
            groupBox6.TabIndex = 15;
            groupBox6.TabStop = false;
            groupBox6.Text = "Model";
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Controls.Add(label1);
            panel1.Location = new Point(11, 7);
            panel1.Name = "panel1";
            panel1.Size = new Size(777, 85);
            panel1.TabIndex = 16;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 42F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(777, 85);
            label1.TabIndex = 2;
            label1.Text = "AUTO INSPECTION MACHINE";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // groupBox7
            // 
            groupBox7.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupBox7.BackColor = SystemColors.Control;
            groupBox7.Controls.Add(campointLabel);
            groupBox7.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox7.Location = new Point(667, 167);
            groupBox7.Name = "groupBox7";
            groupBox7.Size = new Size(229, 66);
            groupBox7.TabIndex = 16;
            groupBox7.TabStop = false;
            groupBox7.Text = "Camera";
            // 
            // campointLabel
            // 
            campointLabel.BackColor = Color.MediumTurquoise;
            campointLabel.Dock = DockStyle.Fill;
            campointLabel.Font = new Font("Segoe UI", 16F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            campointLabel.Location = new Point(3, 23);
            campointLabel.Name = "campointLabel";
            campointLabel.Size = new Size(223, 40);
            campointLabel.TabIndex = 0;
            campointLabel.Text = "-";
            campointLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox2
            // 
            pictureBox2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pictureBox2.Image = Properties.Resources.dharma;
            pictureBox2.Location = new Point(1147, 6);
            pictureBox2.Margin = new Padding(3, 2, 3, 2);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(78, 85);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 18;
            pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pictureBox3.Image = Properties.Resources.flex;
            pictureBox3.Location = new Point(1004, 7);
            pictureBox3.Margin = new Padding(3, 2, 3, 2);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(137, 85);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 19;
            pictureBox3.TabStop = false;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(parameterPictureBox, 0, 0);
            tableLayoutPanel2.Controls.Add(actualPictureBox, 1, 0);
            tableLayoutPanel2.Controls.Add(tableLayoutPanel3, 0, 1);
            tableLayoutPanel2.Controls.Add(tableLayoutPanel6, 1, 1);
            tableLayoutPanel2.Location = new Point(11, 440);
            tableLayoutPanel2.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 82.89963F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 17.1003723F));
            tableLayoutPanel2.Size = new Size(651, 260);
            tableLayoutPanel2.TabIndex = 20;
            // 
            // parameterPictureBox
            // 
            parameterPictureBox.BorderStyle = BorderStyle.FixedSingle;
            parameterPictureBox.Dock = DockStyle.Fill;
            parameterPictureBox.Location = new Point(3, 2);
            parameterPictureBox.Margin = new Padding(3, 2, 3, 2);
            parameterPictureBox.Name = "parameterPictureBox";
            parameterPictureBox.Size = new Size(319, 211);
            parameterPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            parameterPictureBox.TabIndex = 4;
            parameterPictureBox.TabStop = false;
            // 
            // actualPictureBox
            // 
            actualPictureBox.BorderStyle = BorderStyle.FixedSingle;
            actualPictureBox.Dock = DockStyle.Fill;
            actualPictureBox.Location = new Point(328, 2);
            actualPictureBox.Margin = new Padding(3, 2, 3, 2);
            actualPictureBox.Name = "actualPictureBox";
            actualPictureBox.Size = new Size(320, 211);
            actualPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            actualPictureBox.TabIndex = 5;
            actualPictureBox.TabStop = false;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 3;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel3.Controls.Add(button1, 1, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(3, 217);
            tableLayoutPanel3.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Size = new Size(319, 41);
            tableLayoutPanel3.TabIndex = 6;
            // 
            // button1
            // 
            button1.BackColor = Color.LimeGreen;
            button1.Dock = DockStyle.Fill;
            button1.Enabled = false;
            button1.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            button1.ForeColor = Color.WhiteSmoke;
            button1.Location = new Point(109, 2);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(100, 37);
            button1.TabIndex = 3;
            button1.Text = "PASS";
            button1.UseVisualStyleBackColor = false;
            button1.Visible = false;
            button1.Click += button1_Click_1;
            // 
            // tableLayoutPanel6
            // 
            tableLayoutPanel6.ColumnCount = 3;
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel6.Controls.Add(button2, 1, 0);
            tableLayoutPanel6.Dock = DockStyle.Fill;
            tableLayoutPanel6.Location = new Point(328, 217);
            tableLayoutPanel6.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanel6.Name = "tableLayoutPanel6";
            tableLayoutPanel6.RowCount = 1;
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel6.Size = new Size(320, 41);
            tableLayoutPanel6.TabIndex = 7;
            // 
            // button2
            // 
            button2.BackColor = Color.Red;
            button2.Dock = DockStyle.Fill;
            button2.Enabled = false;
            button2.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            button2.ForeColor = Color.WhiteSmoke;
            button2.Location = new Point(109, 2);
            button2.Margin = new Padding(3, 2, 3, 2);
            button2.Name = "button2";
            button2.Size = new Size(100, 37);
            button2.TabIndex = 4;
            button2.Text = "NG";
            button2.UseVisualStyleBackColor = false;
            button2.Visible = false;
            button2.Click += button2_Click;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 2;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 75F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(0, 0);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 1;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.Size = new Size(200, 100);
            tableLayoutPanel4.TabIndex = 0;
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.ColumnCount = 2;
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 75F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel5.Dock = DockStyle.Fill;
            tableLayoutPanel5.Location = new Point(0, 0);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 1;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel5.Size = new Size(200, 100);
            tableLayoutPanel5.TabIndex = 0;
            // 
            // tableLayoutPanel7
            // 
            tableLayoutPanel7.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel7.ColumnCount = 2;
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel7.Controls.Add(label7, 1, 0);
            tableLayoutPanel7.Controls.Add(label5, 0, 0);
            tableLayoutPanel7.Location = new Point(11, 411);
            tableLayoutPanel7.Name = "tableLayoutPanel7";
            tableLayoutPanel7.RowCount = 1;
            tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel7.Size = new Size(648, 26);
            tableLayoutPanel7.TabIndex = 21;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Dock = DockStyle.Fill;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label7.Location = new Point(327, 0);
            label7.Name = "label7";
            label7.Size = new Size(318, 26);
            label7.TabIndex = 1;
            label7.Text = "ACTUAL";
            label7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Dock = DockStyle.Fill;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(3, 0);
            label5.Name = "label5";
            label5.Size = new Size(318, 26);
            label5.TabIndex = 0;
            label5.Text = "PARAMETER";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // groupBox8
            // 
            groupBox8.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            groupBox8.Controls.Add(tableLayoutPanel8);
            groupBox8.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox8.Location = new Point(673, 530);
            groupBox8.Name = "groupBox8";
            groupBox8.Size = new Size(222, 77);
            groupBox8.TabIndex = 22;
            groupBox8.TabStop = false;
            groupBox8.Text = "Counter";
            // 
            // tableLayoutPanel8
            // 
            tableLayoutPanel8.ColumnCount = 3;
            tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel8.Controls.Add(failCountLabel, 0, 0);
            tableLayoutPanel8.Controls.Add(quantityLabel, 0, 0);
            tableLayoutPanel8.Controls.Add(yieldLabel, 2, 0);
            tableLayoutPanel8.Dock = DockStyle.Fill;
            tableLayoutPanel8.Location = new Point(3, 23);
            tableLayoutPanel8.Name = "tableLayoutPanel8";
            tableLayoutPanel8.RowCount = 1;
            tableLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel8.Size = new Size(216, 51);
            tableLayoutPanel8.TabIndex = 0;
            // 
            // failCountLabel
            // 
            failCountLabel.AutoSize = true;
            failCountLabel.BackColor = SystemColors.Control;
            failCountLabel.Dock = DockStyle.Fill;
            failCountLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            failCountLabel.Location = new Point(74, 0);
            failCountLabel.Name = "failCountLabel";
            failCountLabel.Size = new Size(65, 51);
            failCountLabel.TabIndex = 5;
            failCountLabel.Text = "Fail: 0";
            failCountLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // quantityLabel
            // 
            quantityLabel.AutoSize = true;
            quantityLabel.BackColor = SystemColors.Control;
            quantityLabel.Dock = DockStyle.Fill;
            quantityLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            quantityLabel.Location = new Point(3, 0);
            quantityLabel.Name = "quantityLabel";
            quantityLabel.Size = new Size(65, 51);
            quantityLabel.TabIndex = 4;
            quantityLabel.Text = "Count: 0";
            quantityLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // yieldLabel
            // 
            yieldLabel.AutoSize = true;
            yieldLabel.BackColor = SystemColors.Control;
            yieldLabel.Dock = DockStyle.Fill;
            yieldLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            yieldLabel.Location = new Point(145, 0);
            yieldLabel.Name = "yieldLabel";
            yieldLabel.Size = new Size(68, 51);
            yieldLabel.TabIndex = 2;
            yieldLabel.Text = "Yield: 0%";
            yieldLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // groupBox9
            // 
            groupBox9.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupBox9.Controls.Add(inputSerialView);
            groupBox9.Location = new Point(902, 180);
            groupBox9.Name = "groupBox9";
            groupBox9.Padding = new Padding(5);
            groupBox9.Size = new Size(307, 206);
            groupBox9.TabIndex = 23;
            groupBox9.TabStop = false;
            groupBox9.Text = "Serial No.";
            // 
            // inputSerialView
            // 
            inputSerialView.AllowUserToAddRows = false;
            inputSerialView.AllowUserToDeleteRows = false;
            inputSerialView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            inputSerialView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            inputSerialView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            inputSerialView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            inputSerialView.Columns.AddRange(new DataGridViewColumn[] { Label, Serial, Decision });
            inputSerialView.Location = new Point(8, 24);
            inputSerialView.MultiSelect = false;
            inputSerialView.Name = "inputSerialView";
            inputSerialView.ReadOnly = true;
            inputSerialView.RowTemplate.Height = 25;
            inputSerialView.Size = new Size(291, 172);
            inputSerialView.TabIndex = 2;
            inputSerialView.CellClick += inputSerialView_CellClick;
            // 
            // Label
            // 
            Label.HeaderText = "Label";
            Label.Name = "Label";
            Label.ReadOnly = true;
            // 
            // Serial
            // 
            Serial.HeaderText = "Serial Number";
            Serial.Name = "Serial";
            Serial.ReadOnly = true;
            // 
            // Decision
            // 
            Decision.HeaderText = "Decision";
            Decision.Name = "Decision";
            Decision.ReadOnly = true;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            button3.Location = new Point(6, 121);
            button3.Name = "button3";
            button3.Size = new Size(207, 29);
            button3.TabIndex = 1;
            button3.Text = "Submit";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            groupBox1.Controls.Add(serialGridView);
            groupBox1.Controls.Add(button3);
            groupBox1.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox1.Location = new Point(670, 368);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(222, 156);
            groupBox1.TabIndex = 24;
            groupBox1.TabStop = false;
            groupBox1.Text = "Serial Input";
            // 
            // serialGridView
            // 
            serialGridView.AllowUserToAddRows = false;
            serialGridView.AllowUserToDeleteRows = false;
            serialGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            serialGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            serialGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            serialGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            serialGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            serialGridView.Columns.AddRange(new DataGridViewColumn[] { No, SerialNumber });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            serialGridView.DefaultCellStyle = dataGridViewCellStyle2;
            serialGridView.Location = new Point(6, 25);
            serialGridView.Name = "serialGridView";
            serialGridView.RowTemplate.Height = 25;
            serialGridView.Size = new Size(207, 90);
            serialGridView.TabIndex = 2;
            // 
            // No
            // 
            No.HeaderText = "No";
            No.Name = "No";
            No.ReadOnly = true;
            No.Width = 48;
            // 
            // SerialNumber
            // 
            SerialNumber.HeaderText = "Serial Number";
            SerialNumber.Name = "SerialNumber";
            SerialNumber.Width = 112;
            // 
            // groupBox10
            // 
            groupBox10.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupBox10.Controls.Add(button4);
            groupBox10.Controls.Add(comboBox1);
            groupBox10.Location = new Point(905, 108);
            groupBox10.Name = "groupBox10";
            groupBox10.Size = new Size(304, 66);
            groupBox10.TabIndex = 3;
            groupBox10.TabStop = false;
            groupBox10.Text = "Cavity Setup";
            // 
            // button4
            // 
            button4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button4.Location = new Point(112, 22);
            button4.Name = "button4";
            button4.Size = new Size(186, 31);
            button4.TabIndex = 1;
            button4.Text = "Set";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // comboBox1
            // 
            comboBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6" });
            comboBox1.Location = new Point(6, 27);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(100, 23);
            comboBox1.TabIndex = 0;
            // 
            // button5
            // 
            button5.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button5.Location = new Point(905, 575);
            button5.Name = "button5";
            button5.Size = new Size(304, 29);
            button5.TabIndex = 25;
            button5.Text = "RESET";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // DashboardControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(button5);
            Controls.Add(groupBox10);
            Controls.Add(groupBox1);
            Controls.Add(groupBox9);
            Controls.Add(groupBox8);
            Controls.Add(tableLayoutPanel7);
            Controls.Add(tableLayoutPanel2);
            Controls.Add(processTimeLabel);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox2);
            Controls.Add(groupBox7);
            Controls.Add(groupBox6);
            Controls.Add(timeLabel);
            Controls.Add(finalJudgeLabel);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(pictureBox1);
            Controls.Add(groupBox5);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(panel1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "DashboardControl";
            Size = new Size(1231, 703);
            Load += DashboardControl_Load;
            groupBox2.ResumeLayout(false);
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel5.ResumeLayout(false);
            panel4.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)inspectionListGridView).EndInit();
            groupBox4.ResumeLayout(false);
            groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            groupBox6.ResumeLayout(false);
            panel1.ResumeLayout(false);
            groupBox7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)parameterPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)actualPictureBox).EndInit();
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel6.ResumeLayout(false);
            tableLayoutPanel7.ResumeLayout(false);
            tableLayoutPanel7.PerformLayout();
            groupBox8.ResumeLayout(false);
            tableLayoutPanel8.ResumeLayout(false);
            tableLayoutPanel8.PerformLayout();
            groupBox9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)inputSerialView).EndInit();
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)serialGridView).EndInit();
            groupBox10.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label runningModel;
        private GroupBox groupBox2;
        private Label decisionLabel;
        private Label labeld;
        private Label label4;
        private GroupBox groupBox3;
        private DataGridView inspectionListGridView;
        private GroupBox groupBox4;
        private Label label6;
        private GroupBox groupBox5;
        private Label statusLabel;
        private PictureBox pictureBox1;
        private TableLayoutPanel tableLayoutPanel1;
        private Label zLabel;
        private Label yLabel;
        private Label xLabel;
        private System.Windows.Forms.Timer timer1;
        private Label finalJudgeLabel;
        private Label processTimeLabel;
        private System.Windows.Forms.Timer processTimer;
        private Label timeLabel;
        private GroupBox groupBox6;
        private Panel panel1;
        private Label label1;
        private GroupBox groupBox7;
        private Label campointLabel;
        private Panel panel2;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private Panel panel5;
        private Panel panel4;
        private Label areaLabel;
        private Panel panel7;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel4;
        private TableLayoutPanel tableLayoutPanel5;
        private PictureBox parameterPictureBox;
        private PictureBox actualPictureBox;
        private TableLayoutPanel tableLayoutPanel3;
        private Button button1;
        private TableLayoutPanel tableLayoutPanel6;
        private Button button2;
        private TableLayoutPanel tableLayoutPanel7;
        private Label label7;
        private Label label5;
        private GroupBox groupBox8;
        private Label quantityLabel;
        private TableLayoutPanel tableLayoutPanel8;
        private Label failCountLabel;
        private Label yieldLabel;
        private GroupBox groupBox9;
        private Button button3;
        private DataGridView inputSerialView;
        private GroupBox groupBox1;
        private DataGridView serialGridView;
        private DataGridViewTextBoxColumn Label;
        private DataGridViewTextBoxColumn Serial;
        private DataGridViewTextBoxColumn Decision;
        private DataGridViewTextBoxColumn No;
        private DataGridViewTextBoxColumn SerialNumber;
        private GroupBox groupBox10;
        private Button button4;
        private ComboBox comboBox1;
        private Button button5;
    }
}
