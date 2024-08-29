namespace TestTCP1.Forms
{
    partial class SettingParameterControl
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
            parameterDatsGridView = new DataGridView();
            groupBox3 = new GroupBox();
            groupBox10 = new GroupBox();
            panel4 = new Panel();
            label4 = new Label();
            button22 = new Button();
            button21 = new Button();
            inspectionAreaList = new DataGridView();
            timeLabel = new Label();
            runningModel = new Label();
            groupBox1 = new GroupBox();
            zLabel = new Label();
            yLabel = new Label();
            xLabel = new Label();
            label2 = new Label();
            gotoValue = new NumericUpDown();
            insertAfter = new NumericUpDown();
            button2 = new Button();
            delPos = new NumericUpDown();
            button3 = new Button();
            groupBox2 = new GroupBox();
            groupBox7 = new GroupBox();
            button12 = new Button();
            pointLabel = new Label();
            label5 = new Label();
            cameraTriggerBox = new TextBox();
            groupBox9 = new GroupBox();
            tableLayoutPanel2 = new TableLayoutPanel();
            button20 = new Button();
            button19 = new Button();
            groupBox8 = new GroupBox();
            button18 = new Button();
            activeCavityBox = new NumericUpDown();
            groupBox6 = new GroupBox();
            button17 = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            label3 = new Label();
            label6 = new Label();
            panel1 = new Panel();
            cavityBox = new NumericUpDown();
            panel2 = new Panel();
            pitchingBox = new NumericUpDown();
            groupBox5 = new GroupBox();
            button14 = new Button();
            camPoint = new NumericUpDown();
            groupBox4 = new GroupBox();
            panel3 = new Panel();
            button10 = new Button();
            label1 = new Label();
            button16 = new Button();
            comboBox1 = new ComboBox();
            button4 = new Button();
            radioButton2 = new RadioButton();
            button9 = new Button();
            radioButton1 = new RadioButton();
            button7 = new Button();
            button15 = new Button();
            button8 = new Button();
            button13 = new Button();
            button6 = new Button();
            button5 = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)parameterDatsGridView).BeginInit();
            groupBox3.SuspendLayout();
            groupBox10.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)inspectionAreaList).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gotoValue).BeginInit();
            ((System.ComponentModel.ISupportInitialize)insertAfter).BeginInit();
            ((System.ComponentModel.ISupportInitialize)delPos).BeginInit();
            groupBox2.SuspendLayout();
            groupBox7.SuspendLayout();
            groupBox9.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)activeCavityBox).BeginInit();
            groupBox6.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)cavityBox).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pitchingBox).BeginInit();
            groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)camPoint).BeginInit();
            groupBox4.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // parameterDatsGridView
            // 
            parameterDatsGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            parameterDatsGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            parameterDatsGridView.BackgroundColor = SystemColors.Control;
            parameterDatsGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            parameterDatsGridView.Dock = DockStyle.Fill;
            parameterDatsGridView.Location = new Point(3, 18);
            parameterDatsGridView.Margin = new Padding(3, 2, 3, 2);
            parameterDatsGridView.Name = "parameterDatsGridView";
            parameterDatsGridView.ReadOnly = true;
            parameterDatsGridView.RowHeadersWidth = 51;
            parameterDatsGridView.RowTemplate.Height = 29;
            parameterDatsGridView.Size = new Size(446, 430);
            parameterDatsGridView.TabIndex = 0;
            parameterDatsGridView.CellContentClick += parameterDatsGridView_CellContentClick;
            // 
            // groupBox3
            // 
            groupBox3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox3.Controls.Add(parameterDatsGridView);
            groupBox3.Location = new Point(620, 43);
            groupBox3.Margin = new Padding(3, 2, 3, 2);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(3, 2, 3, 2);
            groupBox3.Size = new Size(452, 450);
            groupBox3.TabIndex = 15;
            groupBox3.TabStop = false;
            groupBox3.Text = "Parameter Data";
            // 
            // groupBox10
            // 
            groupBox10.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox10.Controls.Add(panel4);
            groupBox10.Location = new Point(620, 544);
            groupBox10.Name = "groupBox10";
            groupBox10.Size = new Size(452, 357);
            groupBox10.TabIndex = 7;
            groupBox10.TabStop = false;
            groupBox10.Text = "Registration";
            // 
            // panel4
            // 
            panel4.AutoScroll = true;
            panel4.Controls.Add(label4);
            panel4.Controls.Add(button22);
            panel4.Controls.Add(button21);
            panel4.Controls.Add(inspectionAreaList);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(3, 19);
            panel4.Name = "panel4";
            panel4.Size = new Size(446, 335);
            panel4.TabIndex = 6;
            panel4.Paint += panel4_Paint;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Georgia", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(26, 32);
            label4.Name = "label4";
            label4.Size = new Size(154, 18);
            label4.TabIndex = 8;
            label4.Text = "Area Registration";
            // 
            // button22
            // 
            button22.Location = new Point(152, 71);
            button22.Name = "button22";
            button22.Size = new Size(127, 29);
            button22.TabIndex = 7;
            button22.Text = "Delete";
            button22.UseVisualStyleBackColor = true;
            button22.Click += button22_Click;
            // 
            // button21
            // 
            button21.Location = new Point(12, 69);
            button21.Name = "button21";
            button21.Size = new Size(118, 29);
            button21.TabIndex = 6;
            button21.Text = "ADD";
            button21.UseVisualStyleBackColor = true;
            button21.Click += button21_Click;
            // 
            // inspectionAreaList
            // 
            inspectionAreaList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            inspectionAreaList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            inspectionAreaList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllHeaders;
            inspectionAreaList.BackgroundColor = SystemColors.Control;
            inspectionAreaList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            inspectionAreaList.Location = new Point(12, 107);
            inspectionAreaList.Name = "inspectionAreaList";
            inspectionAreaList.RowTemplate.Height = 25;
            inspectionAreaList.Size = new Size(426, 213);
            inspectionAreaList.TabIndex = 5;
            inspectionAreaList.CellContentClick += inspectionAreaList_CellContentClick;
            inspectionAreaList.DataBindingComplete += inspectionAreaList_DataBindingComplete;
            // 
            // timeLabel
            // 
            timeLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            timeLabel.AutoSize = true;
            timeLabel.Location = new Point(966, 11);
            timeLabel.Name = "timeLabel";
            timeLabel.Size = new Size(36, 30);
            timeLabel.TabIndex = 12;
            timeLabel.Text = "Date:\r\nTime:";
            timeLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // runningModel
            // 
            runningModel.AutoSize = true;
            runningModel.Font = new Font("Segoe UI", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            runningModel.Location = new Point(779, 11);
            runningModel.Name = "runningModel";
            runningModel.Size = new Size(97, 32);
            runningModel.TabIndex = 11;
            runningModel.Text = "Model: ";
            runningModel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(zLabel);
            groupBox1.Controls.Add(yLabel);
            groupBox1.Controls.Add(xLabel);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(8, 43);
            groupBox1.Margin = new Padding(3, 2, 3, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 2, 3, 2);
            groupBox1.Size = new Size(606, 94);
            groupBox1.TabIndex = 16;
            groupBox1.TabStop = false;
            // 
            // zLabel
            // 
            zLabel.AutoSize = true;
            zLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            zLabel.Location = new Point(494, 46);
            zLabel.Name = "zLabel";
            zLabel.Size = new Size(84, 21);
            zLabel.TabIndex = 3;
            zLabel.Text = "Z: 0.0 mm";
            // 
            // yLabel
            // 
            yLabel.AutoSize = true;
            yLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            yLabel.Location = new Point(234, 46);
            yLabel.Name = "yLabel";
            yLabel.Size = new Size(84, 21);
            yLabel.TabIndex = 2;
            yLabel.Text = "Y: 0.0 mm";
            // 
            // xLabel
            // 
            xLabel.AutoSize = true;
            xLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            xLabel.Location = new Point(15, 46);
            xLabel.Name = "xLabel";
            xLabel.Size = new Size(84, 21);
            xLabel.TabIndex = 1;
            xLabel.Text = "X: 0.0 mm";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point);
            label2.Location = new Point(222, 17);
            label2.Name = "label2";
            label2.Size = new Size(109, 21);
            label2.TabIndex = 0;
            label2.Text = "Axis Position";
            // 
            // gotoValue
            // 
            gotoValue.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            gotoValue.Location = new Point(149, 154);
            gotoValue.Margin = new Padding(3, 2, 3, 2);
            gotoValue.Name = "gotoValue";
            gotoValue.Size = new Size(59, 27);
            gotoValue.TabIndex = 18;
            gotoValue.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // insertAfter
            // 
            insertAfter.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            insertAfter.Location = new Point(326, 155);
            insertAfter.Margin = new Padding(3, 2, 3, 2);
            insertAfter.Name = "insertAfter";
            insertAfter.Size = new Size(85, 27);
            insertAfter.TabIndex = 20;
            // 
            // button2
            // 
            button2.Location = new Point(213, 150);
            button2.Margin = new Padding(3, 2, 3, 2);
            button2.Name = "button2";
            button2.Size = new Size(108, 32);
            button2.TabIndex = 19;
            button2.Text = "Insert After";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // delPos
            // 
            delPos.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            delPos.Location = new Point(518, 155);
            delPos.Margin = new Padding(3, 2, 3, 2);
            delPos.Name = "delPos";
            delPos.Size = new Size(92, 27);
            delPos.TabIndex = 22;
            // 
            // button3
            // 
            button3.Location = new Point(416, 150);
            button3.Margin = new Padding(3, 2, 3, 2);
            button3.Name = "button3";
            button3.Size = new Size(96, 32);
            button3.TabIndex = 21;
            button3.Text = "Delete";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            groupBox2.Controls.Add(groupBox7);
            groupBox2.Controls.Add(groupBox9);
            groupBox2.Controls.Add(groupBox8);
            groupBox2.Controls.Add(groupBox6);
            groupBox2.Controls.Add(groupBox5);
            groupBox2.Controls.Add(groupBox4);
            groupBox2.Location = new Point(16, 196);
            groupBox2.Margin = new Padding(3, 2, 3, 2);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 2, 3, 2);
            groupBox2.Size = new Size(593, 702);
            groupBox2.TabIndex = 23;
            groupBox2.TabStop = false;
            groupBox2.Text = "Setting Parameter";
            // 
            // groupBox7
            // 
            groupBox7.Controls.Add(button12);
            groupBox7.Controls.Add(pointLabel);
            groupBox7.Controls.Add(label5);
            groupBox7.Controls.Add(cameraTriggerBox);
            groupBox7.Location = new Point(16, 245);
            groupBox7.Name = "groupBox7";
            groupBox7.Size = new Size(539, 132);
            groupBox7.TabIndex = 39;
            groupBox7.TabStop = false;
            // 
            // button12
            // 
            button12.Location = new Point(144, 80);
            button12.Margin = new Padding(3, 2, 3, 2);
            button12.Name = "button12";
            button12.Size = new Size(122, 26);
            button12.TabIndex = 32;
            button12.Text = "Add";
            button12.UseVisualStyleBackColor = true;
            button12.Click += button12_Click;
            // 
            // pointLabel
            // 
            pointLabel.AutoSize = true;
            pointLabel.Location = new Point(16, 28);
            pointLabel.Name = "pointLabel";
            pointLabel.Size = new Size(38, 15);
            pointLabel.TabIndex = 0;
            pointLabel.Text = "Point:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(28, 66);
            label5.Name = "label5";
            label5.Size = new Size(103, 15);
            label5.TabIndex = 2;
            label5.Text = "Camera Execution";
            // 
            // cameraTriggerBox
            // 
            cameraTriggerBox.Location = new Point(28, 83);
            cameraTriggerBox.Margin = new Padding(3, 2, 3, 2);
            cameraTriggerBox.Name = "cameraTriggerBox";
            cameraTriggerBox.Size = new Size(110, 23);
            cameraTriggerBox.TabIndex = 4;
            cameraTriggerBox.TextChanged += cameraTriggerBox_TextChanged;
            // 
            // groupBox9
            // 
            groupBox9.Controls.Add(tableLayoutPanel2);
            groupBox9.Location = new Point(229, 157);
            groupBox9.Name = "groupBox9";
            groupBox9.Padding = new Padding(5);
            groupBox9.Size = new Size(358, 72);
            groupBox9.TabIndex = 38;
            groupBox9.TabStop = false;
            groupBox9.Text = "Cylinder Enable/Disable";
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(button20, 0, 0);
            tableLayoutPanel2.Controls.Add(button19, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(5, 21);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.Padding = new Padding(3);
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(348, 46);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // button20
            // 
            button20.Dock = DockStyle.Fill;
            button20.Location = new Point(177, 5);
            button20.Margin = new Padding(3, 2, 3, 2);
            button20.Name = "button20";
            button20.Size = new Size(165, 36);
            button20.TabIndex = 20;
            button20.Tag = "0";
            button20.Text = "Disable";
            button20.UseVisualStyleBackColor = true;
            button20.Click += CylinderTrigger;
            // 
            // button19
            // 
            button19.Dock = DockStyle.Fill;
            button19.Location = new Point(6, 5);
            button19.Margin = new Padding(3, 2, 3, 2);
            button19.Name = "button19";
            button19.Size = new Size(165, 36);
            button19.TabIndex = 19;
            button19.Tag = "1";
            button19.Text = "Enable";
            button19.UseVisualStyleBackColor = true;
            button19.Click += CylinderTrigger;
            // 
            // groupBox8
            // 
            groupBox8.Controls.Add(button18);
            groupBox8.Controls.Add(activeCavityBox);
            groupBox8.Location = new Point(6, 151);
            groupBox8.Name = "groupBox8";
            groupBox8.Size = new Size(216, 78);
            groupBox8.TabIndex = 37;
            groupBox8.TabStop = false;
            groupBox8.Text = "Active Cavity";
            // 
            // button18
            // 
            button18.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            button18.Location = new Point(6, 49);
            button18.Name = "button18";
            button18.Size = new Size(204, 23);
            button18.TabIndex = 37;
            button18.Text = "Set";
            button18.UseVisualStyleBackColor = true;
            button18.Click += button18_Click;
            // 
            // activeCavityBox
            // 
            activeCavityBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            activeCavityBox.Location = new Point(6, 22);
            activeCavityBox.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            activeCavityBox.Name = "activeCavityBox";
            activeCavityBox.Size = new Size(204, 23);
            activeCavityBox.TabIndex = 1;
            activeCavityBox.TextAlign = HorizontalAlignment.Right;
            activeCavityBox.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // groupBox6
            // 
            groupBox6.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox6.Controls.Add(button17);
            groupBox6.Controls.Add(tableLayoutPanel1);
            groupBox6.Location = new Point(12, 40);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(349, 104);
            groupBox6.TabIndex = 35;
            groupBox6.TabStop = false;
            groupBox6.Text = "Cavity & Pitching";
            // 
            // button17
            // 
            button17.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            button17.Location = new Point(6, 71);
            button17.Name = "button17";
            button17.Size = new Size(337, 23);
            button17.TabIndex = 2;
            button17.Text = "Set";
            button17.UseVisualStyleBackColor = true;
            button17.Click += button17_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.Controls.Add(label3, 0, 0);
            tableLayoutPanel1.Controls.Add(label6, 2, 0);
            tableLayoutPanel1.Controls.Add(panel1, 1, 0);
            tableLayoutPanel1.Controls.Add(panel2, 3, 0);
            tableLayoutPanel1.Location = new Point(6, 22);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(337, 43);
            tableLayoutPanel1.TabIndex = 36;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Fill;
            label3.Location = new Point(3, 0);
            label3.Name = "label3";
            label3.Size = new Size(61, 43);
            label3.TabIndex = 0;
            label3.Text = "Cavity:";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Dock = DockStyle.Fill;
            label6.Location = new Point(171, 0);
            label6.Name = "label6";
            label6.Size = new Size(95, 43);
            label6.TabIndex = 1;
            label6.Text = "Pitching (mm):";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.Controls.Add(cavityBox);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(70, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(95, 37);
            panel1.TabIndex = 2;
            // 
            // cavityBox
            // 
            cavityBox.Location = new Point(3, 9);
            cavityBox.Maximum = new decimal(new int[] { 99999, 0, 0, 0 });
            cavityBox.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            cavityBox.Name = "cavityBox";
            cavityBox.Size = new Size(90, 23);
            cavityBox.TabIndex = 0;
            cavityBox.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // panel2
            // 
            panel2.Controls.Add(pitchingBox);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(272, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(62, 37);
            panel2.TabIndex = 3;
            // 
            // pitchingBox
            // 
            pitchingBox.DecimalPlaces = 2;
            pitchingBox.Location = new Point(3, 9);
            pitchingBox.Maximum = new decimal(new int[] { 99999, 0, 0, 0 });
            pitchingBox.Name = "pitchingBox";
            pitchingBox.Size = new Size(54, 23);
            pitchingBox.TabIndex = 0;
            // 
            // groupBox5
            // 
            groupBox5.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox5.Controls.Add(button14);
            groupBox5.Controls.Add(camPoint);
            groupBox5.Location = new Point(367, 40);
            groupBox5.Margin = new Padding(3, 2, 3, 2);
            groupBox5.Name = "groupBox5";
            groupBox5.Padding = new Padding(3, 2, 3, 2);
            groupBox5.Size = new Size(226, 104);
            groupBox5.TabIndex = 34;
            groupBox5.TabStop = false;
            groupBox5.Text = "Camera Program";
            // 
            // button14
            // 
            button14.Location = new Point(6, 71);
            button14.Name = "button14";
            button14.Size = new Size(209, 23);
            button14.TabIndex = 1;
            button14.Text = "Set";
            button14.UseVisualStyleBackColor = true;
            button14.Click += button14_Click;
            // 
            // camPoint
            // 
            camPoint.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            camPoint.Location = new Point(6, 20);
            camPoint.Margin = new Padding(3, 2, 3, 2);
            camPoint.Name = "camPoint";
            camPoint.Size = new Size(209, 39);
            camPoint.TabIndex = 0;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(panel3);
            groupBox4.Location = new Point(0, 392);
            groupBox4.Margin = new Padding(3, 2, 3, 2);
            groupBox4.Name = "groupBox4";
            groupBox4.Padding = new Padding(3, 2, 3, 2);
            groupBox4.Size = new Size(585, 295);
            groupBox4.TabIndex = 33;
            groupBox4.TabStop = false;
            groupBox4.Text = "Axis Position";
            // 
            // panel3
            // 
            panel3.AutoScroll = true;
            panel3.Controls.Add(button10);
            panel3.Controls.Add(label1);
            panel3.Controls.Add(button16);
            panel3.Controls.Add(comboBox1);
            panel3.Controls.Add(button4);
            panel3.Controls.Add(radioButton2);
            panel3.Controls.Add(button9);
            panel3.Controls.Add(radioButton1);
            panel3.Controls.Add(button7);
            panel3.Controls.Add(button15);
            panel3.Controls.Add(button8);
            panel3.Controls.Add(button13);
            panel3.Controls.Add(button6);
            panel3.Controls.Add(button5);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(3, 18);
            panel3.Name = "panel3";
            panel3.Size = new Size(579, 275);
            panel3.TabIndex = 40;
            // 
            // button10
            // 
            button10.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button10.Location = new Point(223, 150);
            button10.Margin = new Padding(3, 2, 3, 2);
            button10.Name = "button10";
            button10.Size = new Size(100, 26);
            button10.TabIndex = 29;
            button10.Tag = "Z-";
            button10.Text = "<- -Z";
            button10.UseVisualStyleBackColor = true;
            button10.Click += moveCoordinate;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(181, 97);
            label1.Name = "label1";
            label1.Size = new Size(29, 15);
            label1.TabIndex = 38;
            label1.Text = "mm";
            // 
            // button16
            // 
            button16.Location = new Point(454, 150);
            button16.Name = "button16";
            button16.Size = new Size(121, 23);
            button16.TabIndex = 39;
            button16.Text = "Reset";
            button16.UseVisualStyleBackColor = true;
            button16.Click += button16_Click;
            // 
            // comboBox1
            // 
            comboBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "0.1", "0.5", "1", "1.5", "2" });
            comboBox1.Location = new Point(119, 99);
            comboBox1.Margin = new Padding(3, 2, 3, 2);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(56, 23);
            comboBox1.TabIndex = 37;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // button4
            // 
            button4.Location = new Point(29, 32);
            button4.Margin = new Padding(3, 2, 3, 2);
            button4.Name = "button4";
            button4.Size = new Size(122, 26);
            button4.TabIndex = 24;
            button4.Text = "Origin";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // radioButton2
            // 
            radioButton2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(115, 76);
            radioButton2.Margin = new Padding(3, 2, 3, 2);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(74, 19);
            radioButton2.TabIndex = 36;
            radioButton2.Text = "INCHING";
            radioButton2.UseVisualStyleBackColor = true;
            radioButton2.CheckedChanged += radioButton2_CheckedChanged;
            // 
            // button9
            // 
            button9.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button9.Location = new Point(329, 150);
            button9.Margin = new Padding(3, 2, 3, 2);
            button9.Name = "button9";
            button9.Size = new Size(100, 26);
            button9.TabIndex = 30;
            button9.Tag = "Z+";
            button9.Text = "+Z ->";
            button9.UseVisualStyleBackColor = true;
            button9.Click += moveCoordinate;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Checked = true;
            radioButton1.Location = new Point(13, 76);
            radioButton1.Margin = new Padding(3, 2, 3, 2);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(46, 19);
            radioButton1.TabIndex = 35;
            radioButton1.TabStop = true;
            radioButton1.Text = "JOG";
            radioButton1.UseVisualStyleBackColor = true;
            radioButton1.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // button7
            // 
            button7.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button7.Location = new Point(329, 110);
            button7.Margin = new Padding(3, 2, 3, 2);
            button7.Name = "button7";
            button7.Size = new Size(100, 26);
            button7.TabIndex = 28;
            button7.Tag = "Y+";
            button7.Text = "+Y ->";
            button7.UseVisualStyleBackColor = true;
            button7.Click += moveCoordinate;
            // 
            // button15
            // 
            button15.Location = new Point(454, 110);
            button15.Margin = new Padding(3, 2, 3, 2);
            button15.Name = "button15";
            button15.Size = new Size(122, 26);
            button15.TabIndex = 34;
            button15.Text = "Mark Point";
            button15.UseVisualStyleBackColor = true;
            button15.Click += button15_Click;
            // 
            // button8
            // 
            button8.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button8.Location = new Point(222, 107);
            button8.Margin = new Padding(3, 2, 3, 2);
            button8.Name = "button8";
            button8.Size = new Size(100, 26);
            button8.TabIndex = 27;
            button8.Tag = "Y-";
            button8.Text = "<- -Y";
            button8.UseVisualStyleBackColor = true;
            button8.Click += moveCoordinate;
            // 
            // button13
            // 
            button13.Location = new Point(454, 69);
            button13.Name = "button13";
            button13.Size = new Size(122, 23);
            button13.TabIndex = 33;
            button13.Text = "Zero";
            button13.UseVisualStyleBackColor = true;
            button13.Click += button13_Click;
            // 
            // button6
            // 
            button6.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button6.Location = new Point(329, 72);
            button6.Margin = new Padding(3, 2, 3, 2);
            button6.Name = "button6";
            button6.Size = new Size(100, 26);
            button6.TabIndex = 26;
            button6.Tag = "X+";
            button6.Text = "+X ->";
            button6.UseVisualStyleBackColor = true;
            button6.Click += moveCoordinate;
            // 
            // button5
            // 
            button5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button5.Location = new Point(222, 69);
            button5.Margin = new Padding(3, 2, 3, 2);
            button5.Name = "button5";
            button5.Size = new Size(100, 26);
            button5.TabIndex = 25;
            button5.Tag = "X-";
            button5.Text = "<- -X";
            button5.UseVisualStyleBackColor = true;
            button5.Click += moveCoordinate;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Tick += timer1_Tick;
            // 
            // button1
            // 
            button1.Location = new Point(23, 150);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(122, 32);
            button1.TabIndex = 17;
            button1.Text = "Go Point";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // SettingParameterControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Controls.Add(groupBox10);
            Controls.Add(groupBox2);
            Controls.Add(delPos);
            Controls.Add(button3);
            Controls.Add(insertAfter);
            Controls.Add(button2);
            Controls.Add(gotoValue);
            Controls.Add(button1);
            Controls.Add(groupBox1);
            Controls.Add(groupBox3);
            Controls.Add(timeLabel);
            Controls.Add(runningModel);
            Margin = new Padding(3, 2, 3, 2);
            Name = "SettingParameterControl";
            Size = new Size(1085, 978);
            Load += SettingParameterControl_Load;
            ((System.ComponentModel.ISupportInitialize)parameterDatsGridView).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox10.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)inspectionAreaList).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gotoValue).EndInit();
            ((System.ComponentModel.ISupportInitialize)insertAfter).EndInit();
            ((System.ComponentModel.ISupportInitialize)delPos).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox7.ResumeLayout(false);
            groupBox7.PerformLayout();
            groupBox9.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            groupBox8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)activeCavityBox).EndInit();
            groupBox6.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)cavityBox).EndInit();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pitchingBox).EndInit();
            groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)camPoint).EndInit();
            groupBox4.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView parameterDatsGridView;
        private GroupBox groupBox3;
        private Label timeLabel;
        private Label runningModel;
        private GroupBox groupBox1;
        private Label zLabel;
        private Label yLabel;
        private Label xLabel;
        private Label label2;
        private NumericUpDown gotoValue;
        private NumericUpDown insertAfter;
        private Button button2;
        private NumericUpDown delPos;
        private Button button3;
        private GroupBox groupBox2;
        private Button button9;
        private Button button10;
        private Button button7;
        private Button button8;
        private Button button6;
        private Button button5;
        private Button button4;
        private TextBox cameraTriggerBox;
        private Label label5;
        private Label pointLabel;
        private Button button12;
        private System.Windows.Forms.Timer timer1;
        private Button button1;
        private GroupBox groupBox5;
        private NumericUpDown camPoint;
        private GroupBox groupBox4;
        private Button button13;
        private Button button14;
        private Button button15;
        private Label label1;
        private ComboBox comboBox1;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private Button button16;
        private GroupBox groupBox6;
        private Button button17;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label3;
        private Label label6;
        private Panel panel1;
        private NumericUpDown cavityBox;
        private Panel panel2;
        private NumericUpDown pitchingBox;
        private GroupBox groupBox8;
        private Button button18;
        private NumericUpDown activeCavityBox;
        private GroupBox groupBox9;
        private TableLayoutPanel tableLayoutPanel2;
        private Button button20;
        private Button button19;
        private Panel panel3;
        private Panel panel4;
        private DataGridView inspectionAreaList;
        private Button button22;
        private Button button21;
        private GroupBox groupBox7;
        private Label label4;
        private GroupBox groupBox10;
    }
}
