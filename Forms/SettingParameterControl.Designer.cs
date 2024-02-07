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
            groupBox5 = new GroupBox();
            button14 = new Button();
            camPoint = new NumericUpDown();
            pictureBox1 = new PictureBox();
            cameraTriggerBox = new TextBox();
            inspectionAreaBox = new TextBox();
            label5 = new Label();
            label4 = new Label();
            pointLabel = new Label();
            groupBox4 = new GroupBox();
            button16 = new Button();
            label1 = new Label();
            comboBox1 = new ComboBox();
            radioButton2 = new RadioButton();
            radioButton1 = new RadioButton();
            button15 = new Button();
            button13 = new Button();
            button12 = new Button();
            button4 = new Button();
            button11 = new Button();
            button5 = new Button();
            button9 = new Button();
            button6 = new Button();
            button10 = new Button();
            button8 = new Button();
            button7 = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)parameterDatsGridView).BeginInit();
            groupBox3.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gotoValue).BeginInit();
            ((System.ComponentModel.ISupportInitialize)insertAfter).BeginInit();
            ((System.ComponentModel.ISupportInitialize)delPos).BeginInit();
            groupBox2.SuspendLayout();
            groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)camPoint).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // parameterDatsGridView
            // 
            parameterDatsGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            parameterDatsGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            parameterDatsGridView.BackgroundColor = SystemColors.Control;
            parameterDatsGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            parameterDatsGridView.Dock = DockStyle.Fill;
            parameterDatsGridView.Location = new Point(3, 23);
            parameterDatsGridView.Name = "parameterDatsGridView";
            parameterDatsGridView.ReadOnly = true;
            parameterDatsGridView.RowHeadersWidth = 51;
            parameterDatsGridView.RowTemplate.Height = 29;
            parameterDatsGridView.Size = new Size(216, 841);
            parameterDatsGridView.TabIndex = 0;
            parameterDatsGridView.CellContentClick += parameterDatsGridView_CellContentClick;
            // 
            // groupBox3
            // 
            groupBox3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox3.Controls.Add(parameterDatsGridView);
            groupBox3.Location = new Point(706, 57);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(222, 867);
            groupBox3.TabIndex = 15;
            groupBox3.TabStop = false;
            groupBox3.Text = "Parameter Data";
            // 
            // timeLabel
            // 
            timeLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            timeLabel.AutoSize = true;
            timeLabel.Location = new Point(472, 12);
            timeLabel.Name = "timeLabel";
            timeLabel.Size = new Size(45, 40);
            timeLabel.TabIndex = 12;
            timeLabel.Text = "Date:\r\nTime:";
            timeLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // runningModel
            // 
            runningModel.AutoSize = true;
            runningModel.Font = new Font("Segoe UI", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            runningModel.Location = new Point(275, 12);
            runningModel.Name = "runningModel";
            runningModel.Size = new Size(121, 41);
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
            groupBox1.Location = new Point(9, 57);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(693, 125);
            groupBox1.TabIndex = 16;
            groupBox1.TabStop = false;
            // 
            // zLabel
            // 
            zLabel.AutoSize = true;
            zLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            zLabel.Location = new Point(565, 61);
            zLabel.Name = "zLabel";
            zLabel.Size = new Size(106, 28);
            zLabel.TabIndex = 3;
            zLabel.Text = "Z: 0.0 mm";
            // 
            // yLabel
            // 
            yLabel.AutoSize = true;
            yLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            yLabel.Location = new Point(267, 61);
            yLabel.Name = "yLabel";
            yLabel.Size = new Size(106, 28);
            yLabel.TabIndex = 2;
            yLabel.Text = "Y: 0.0 mm";
            // 
            // xLabel
            // 
            xLabel.AutoSize = true;
            xLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            xLabel.Location = new Point(17, 61);
            xLabel.Name = "xLabel";
            xLabel.Size = new Size(107, 28);
            xLabel.TabIndex = 1;
            xLabel.Text = "X: 0.0 mm";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point);
            label2.Location = new Point(254, 23);
            label2.Name = "label2";
            label2.Size = new Size(134, 28);
            label2.TabIndex = 0;
            label2.Text = "Axis Position";
            // 
            // gotoValue
            // 
            gotoValue.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            gotoValue.Location = new Point(170, 205);
            gotoValue.Name = "gotoValue";
            gotoValue.Size = new Size(67, 31);
            gotoValue.TabIndex = 18;
            gotoValue.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // insertAfter
            // 
            insertAfter.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            insertAfter.Location = new Point(373, 207);
            insertAfter.Name = "insertAfter";
            insertAfter.Size = new Size(97, 31);
            insertAfter.TabIndex = 20;
            // 
            // button2
            // 
            button2.Location = new Point(243, 200);
            button2.Name = "button2";
            button2.Size = new Size(123, 43);
            button2.TabIndex = 19;
            button2.Text = "Insert After";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // delPos
            // 
            delPos.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            delPos.Location = new Point(592, 207);
            delPos.Name = "delPos";
            delPos.Size = new Size(105, 31);
            delPos.TabIndex = 22;
            // 
            // button3
            // 
            button3.Location = new Point(475, 200);
            button3.Name = "button3";
            button3.Size = new Size(110, 43);
            button3.TabIndex = 21;
            button3.Text = "Delete";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            groupBox2.Controls.Add(groupBox5);
            groupBox2.Controls.Add(pictureBox1);
            groupBox2.Controls.Add(cameraTriggerBox);
            groupBox2.Controls.Add(inspectionAreaBox);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(pointLabel);
            groupBox2.Controls.Add(groupBox4);
            groupBox2.Location = new Point(18, 261);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(678, 663);
            groupBox2.TabIndex = 23;
            groupBox2.TabStop = false;
            groupBox2.Text = "Setting Parameter";
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(button14);
            groupBox5.Controls.Add(camPoint);
            groupBox5.Location = new Point(414, 27);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(258, 105);
            groupBox5.TabIndex = 34;
            groupBox5.TabStop = false;
            groupBox5.Text = "Camera Program";
            // 
            // button14
            // 
            button14.Location = new Point(13, 64);
            button14.Margin = new Padding(3, 4, 3, 4);
            button14.Name = "button14";
            button14.Size = new Size(239, 31);
            button14.TabIndex = 1;
            button14.Text = "Set";
            button14.UseVisualStyleBackColor = true;
            button14.Click += button14_Click;
            // 
            // camPoint
            // 
            camPoint.Location = new Point(13, 27);
            camPoint.Name = "camPoint";
            camPoint.Size = new Size(239, 27);
            camPoint.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Location = new Point(13, 145);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(365, 263);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // cameraTriggerBox
            // 
            cameraTriggerBox.Location = new Point(131, 101);
            cameraTriggerBox.Name = "cameraTriggerBox";
            cameraTriggerBox.Size = new Size(125, 27);
            cameraTriggerBox.TabIndex = 4;
            // 
            // inspectionAreaBox
            // 
            inspectionAreaBox.Location = new Point(131, 63);
            inspectionAreaBox.Name = "inspectionAreaBox";
            inspectionAreaBox.Size = new Size(125, 27);
            inspectionAreaBox.TabIndex = 3;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(13, 105);
            label5.Name = "label5";
            label5.Size = new Size(128, 20);
            label5.TabIndex = 2;
            label5.Text = "Camera Execution";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(13, 67);
            label4.Name = "label4";
            label4.Size = new Size(112, 20);
            label4.TabIndex = 1;
            label4.Text = "Inspection Area";
            label4.TextAlign = ContentAlignment.MiddleRight;
            // 
            // pointLabel
            // 
            pointLabel.AutoSize = true;
            pointLabel.Location = new Point(13, 32);
            pointLabel.Name = "pointLabel";
            pointLabel.Size = new Size(45, 20);
            pointLabel.TabIndex = 0;
            pointLabel.Text = "Point:";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(button16);
            groupBox4.Controls.Add(label1);
            groupBox4.Controls.Add(comboBox1);
            groupBox4.Controls.Add(radioButton2);
            groupBox4.Controls.Add(radioButton1);
            groupBox4.Controls.Add(button15);
            groupBox4.Controls.Add(button13);
            groupBox4.Controls.Add(button12);
            groupBox4.Controls.Add(button4);
            groupBox4.Controls.Add(button11);
            groupBox4.Controls.Add(button5);
            groupBox4.Controls.Add(button9);
            groupBox4.Controls.Add(button6);
            groupBox4.Controls.Add(button10);
            groupBox4.Controls.Add(button8);
            groupBox4.Controls.Add(button7);
            groupBox4.Location = new Point(413, 145);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(258, 503);
            groupBox4.TabIndex = 33;
            groupBox4.TabStop = false;
            groupBox4.Text = "Axis Position";
            // 
            // button16
            // 
            button16.Location = new Point(59, 439);
            button16.Margin = new Padding(3, 4, 3, 4);
            button16.Name = "button16";
            button16.Size = new Size(138, 31);
            button16.TabIndex = 39;
            button16.Text = "Reset";
            button16.UseVisualStyleBackColor = true;
            button16.Click += button16_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(213, 107);
            label1.Name = "label1";
            label1.Size = new Size(35, 20);
            label1.TabIndex = 38;
            label1.Text = "mm";
            // 
            // comboBox1
            // 
            comboBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "0.1", "0.5", "1", "1.5", "2" });
            comboBox1.Location = new Point(143, 107);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(63, 28);
            comboBox1.TabIndex = 37;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // radioButton2
            // 
            radioButton2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(143, 77);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(90, 24);
            radioButton2.TabIndex = 36;
            radioButton2.Text = "INCHING";
            radioButton2.UseVisualStyleBackColor = true;
            radioButton2.CheckedChanged += radioButton2_CheckedChanged;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Checked = true;
            radioButton1.Location = new Point(14, 77);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(56, 24);
            radioButton1.TabIndex = 35;
            radioButton1.TabStop = true;
            radioButton1.Text = "JOG";
            radioButton1.UseVisualStyleBackColor = true;
            radioButton1.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // button15
            // 
            button15.Location = new Point(59, 397);
            button15.Name = "button15";
            button15.Size = new Size(139, 35);
            button15.TabIndex = 34;
            button15.Text = "Mark Point";
            button15.UseVisualStyleBackColor = true;
            button15.Click += button15_Click;
            // 
            // button13
            // 
            button13.Location = new Point(58, 359);
            button13.Margin = new Padding(3, 4, 3, 4);
            button13.Name = "button13";
            button13.Size = new Size(139, 31);
            button13.TabIndex = 33;
            button13.Text = "Zero";
            button13.UseVisualStyleBackColor = true;
            button13.Click += button13_Click;
            // 
            // button12
            // 
            button12.Location = new Point(58, 317);
            button12.Name = "button12";
            button12.Size = new Size(139, 35);
            button12.TabIndex = 32;
            button12.Text = "Add";
            button12.UseVisualStyleBackColor = true;
            button12.Click += button12_Click;
            // 
            // button4
            // 
            button4.Location = new Point(59, 27);
            button4.Name = "button4";
            button4.Size = new Size(139, 35);
            button4.TabIndex = 24;
            button4.Text = "Origin";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button11
            // 
            button11.Location = new Point(58, 277);
            button11.Name = "button11";
            button11.Size = new Size(139, 35);
            button11.TabIndex = 31;
            button11.Text = "Trigger";
            button11.UseVisualStyleBackColor = true;
            button11.Click += button11_Click;
            // 
            // button5
            // 
            button5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button5.Location = new Point(13, 147);
            button5.Name = "button5";
            button5.Size = new Size(114, 35);
            button5.TabIndex = 25;
            button5.Tag = "X-";
            button5.Text = "<- -X";
            button5.UseVisualStyleBackColor = true;
            button5.Click += moveCoordinate;
            // 
            // button9
            // 
            button9.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button9.Location = new Point(133, 229);
            button9.Name = "button9";
            button9.Size = new Size(114, 35);
            button9.TabIndex = 30;
            button9.Tag = "Z+";
            button9.Text = "+Z ->";
            button9.UseVisualStyleBackColor = true;
            button9.Click += moveCoordinate;
            // 
            // button6
            // 
            button6.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button6.Location = new Point(133, 145);
            button6.Name = "button6";
            button6.Size = new Size(114, 35);
            button6.TabIndex = 26;
            button6.Tag = "X+";
            button6.Text = "+X ->";
            button6.UseVisualStyleBackColor = true;
            button6.Click += moveCoordinate;
            // 
            // button10
            // 
            button10.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button10.Location = new Point(13, 229);
            button10.Name = "button10";
            button10.Size = new Size(114, 35);
            button10.TabIndex = 29;
            button10.Tag = "Z-";
            button10.Text = "<- -Z";
            button10.UseVisualStyleBackColor = true;
            button10.Click += moveCoordinate;
            // 
            // button8
            // 
            button8.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button8.Location = new Point(11, 187);
            button8.Name = "button8";
            button8.Size = new Size(114, 35);
            button8.TabIndex = 27;
            button8.Tag = "Y-";
            button8.Text = "<- -Y";
            button8.UseVisualStyleBackColor = true;
            button8.Click += moveCoordinate;
            // 
            // button7
            // 
            button7.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button7.Location = new Point(133, 187);
            button7.Name = "button7";
            button7.Size = new Size(114, 35);
            button7.TabIndex = 28;
            button7.Tag = "Y+";
            button7.Text = "+Y ->";
            button7.UseVisualStyleBackColor = true;
            button7.Click += moveCoordinate;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Tick += timer1_Tick;
            // 
            // button1
            // 
            button1.Location = new Point(26, 200);
            button1.Name = "button1";
            button1.Size = new Size(139, 43);
            button1.TabIndex = 17;
            button1.Text = "Go Point";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // SettingParameterControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
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
            Name = "SettingParameterControl";
            Size = new Size(1085, 927);
            Load += SettingParameterControl_Load;
            ((System.ComponentModel.ISupportInitialize)parameterDatsGridView).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gotoValue).EndInit();
            ((System.ComponentModel.ISupportInitialize)insertAfter).EndInit();
            ((System.ComponentModel.ISupportInitialize)delPos).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)camPoint).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
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
        private Button button11;
        private Button button9;
        private Button button10;
        private Button button7;
        private Button button8;
        private Button button6;
        private Button button5;
        private Button button4;
        private PictureBox pictureBox1;
        private TextBox cameraTriggerBox;
        private TextBox inspectionAreaBox;
        private Label label5;
        private Label label4;
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
    }
}
