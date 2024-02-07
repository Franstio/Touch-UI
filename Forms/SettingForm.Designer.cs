namespace TestTCP1.Forms
{
    partial class SettingForm
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
            bindingSource1 = new BindingSource(components);
            button17 = new Button();
            button16 = new Button();
            label5 = new Label();
            modelBox = new TextBox();
            textBox2 = new TextBox();
            dataGridView1 = new DataGridView();
            button14 = new Button();
            textBox1 = new TextBox();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            groupBox2 = new GroupBox();
            label2 = new Label();
            button1 = new Button();
            button6 = new Button();
            button2 = new Button();
            button4 = new Button();
            trackBar1 = new TrackBar();
            jogSpeedLabel = new Label();
            button3 = new Button();
            button12 = new Button();
            button5 = new Button();
            button13 = new Button();
            button7 = new Button();
            button11 = new Button();
            button9 = new Button();
            button10 = new Button();
            button8 = new Button();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            SuspendLayout();
            // 
            // button17
            // 
            button17.Location = new Point(237, 32);
            button17.Name = "button17";
            button17.Size = new Size(62, 23);
            button17.TabIndex = 48;
            button17.Text = "Set";
            button17.UseVisualStyleBackColor = true;
            button17.Click += button17_Click;
            // 
            // button16
            // 
            button16.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button16.Location = new Point(401, 331);
            button16.Name = "button16";
            button16.Size = new Size(75, 23);
            button16.TabIndex = 47;
            button16.Text = "Trigger";
            button16.UseVisualStyleBackColor = true;
            button16.Click += button16_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(21, 35);
            label5.Name = "label5";
            label5.Size = new Size(44, 15);
            label5.TabIndex = 46;
            label5.Text = "Model:";
            // 
            // modelBox
            // 
            modelBox.Location = new Point(66, 32);
            modelBox.Name = "modelBox";
            modelBox.Size = new Size(155, 23);
            modelBox.TabIndex = 45;
            // 
            // textBox2
            // 
            textBox2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            textBox2.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            textBox2.Location = new Point(317, 328);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(74, 27);
            textBox2.TabIndex = 43;
            textBox2.TextAlign = HorizontalAlignment.Center;
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(19, 394);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(467, 126);
            dataGridView1.TabIndex = 42;
            // 
            // button14
            // 
            button14.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button14.Location = new Point(401, 361);
            button14.Name = "button14";
            button14.Size = new Size(75, 23);
            button14.TabIndex = 41;
            button14.Text = "Save";
            button14.UseVisualStyleBackColor = true;
            button14.Click += button14_Click;
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBox1.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            textBox1.Location = new Point(19, 361);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(372, 27);
            textBox1.TabIndex = 40;
            textBox1.TextAlign = HorizontalAlignment.Center;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Location = new Point(21, 63);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(278, 292);
            pictureBox1.TabIndex = 39;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point);
            label1.Location = new Point(21, 8);
            label1.Name = "label1";
            label1.Size = new Size(132, 21);
            label1.TabIndex = 38;
            label1.Text = "Setting Position";
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(button1);
            groupBox2.Controls.Add(button6);
            groupBox2.Controls.Add(button2);
            groupBox2.Controls.Add(button4);
            groupBox2.Controls.Add(trackBar1);
            groupBox2.Controls.Add(jogSpeedLabel);
            groupBox2.Controls.Add(button3);
            groupBox2.Controls.Add(button12);
            groupBox2.Controls.Add(button5);
            groupBox2.Controls.Add(button13);
            groupBox2.Controls.Add(button7);
            groupBox2.Controls.Add(button11);
            groupBox2.Controls.Add(button9);
            groupBox2.Controls.Add(button10);
            groupBox2.Controls.Add(button8);
            groupBox2.Location = new Point(305, 20);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(183, 296);
            groupBox2.TabIndex = 44;
            groupBox2.TabStop = false;
            groupBox2.Text = "Control";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(0, 19);
            label2.Name = "label2";
            label2.Size = new Size(94, 21);
            label2.TabIndex = 2;
            label2.Text = "Position : 1";
            // 
            // button1
            // 
            button1.BackgroundImage = Properties.Resources.left_arrow;
            button1.BackgroundImageLayout = ImageLayout.Stretch;
            button1.Location = new Point(107, 18);
            button1.Name = "button1";
            button1.Size = new Size(29, 23);
            button1.TabIndex = 3;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button6
            // 
            button6.BackgroundImage = Properties.Resources.top_arrow;
            button6.BackgroundImageLayout = ImageLayout.Stretch;
            button6.Location = new Point(46, 58);
            button6.Name = "button6";
            button6.Size = new Size(29, 23);
            button6.TabIndex = 8;
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button2
            // 
            button2.BackgroundImage = Properties.Resources.right_arrow;
            button2.BackgroundImageLayout = ImageLayout.Stretch;
            button2.Location = new Point(142, 18);
            button2.Name = "button2";
            button2.Size = new Size(29, 23);
            button2.TabIndex = 4;
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button4
            // 
            button4.BackgroundImage = Properties.Resources.left_arrow;
            button4.BackgroundImageLayout = ImageLayout.Stretch;
            button4.Location = new Point(11, 87);
            button4.Name = "button4";
            button4.Size = new Size(29, 23);
            button4.TabIndex = 5;
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // trackBar1
            // 
            trackBar1.Location = new Point(11, 242);
            trackBar1.Maximum = 10000;
            trackBar1.Minimum = 200;
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(160, 45);
            trackBar1.TabIndex = 16;
            trackBar1.Value = 200;
            trackBar1.Scroll += trackBar1_Scroll;
            // 
            // jogSpeedLabel
            // 
            jogSpeedLabel.AutoSize = true;
            jogSpeedLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            jogSpeedLabel.Location = new Point(12, 214);
            jogSpeedLabel.Name = "jogSpeedLabel";
            jogSpeedLabel.Size = new Size(109, 21);
            jogSpeedLabel.TabIndex = 17;
            jogSpeedLabel.Text = "Jog Speed : 1";
            // 
            // button3
            // 
            button3.BackgroundImage = Properties.Resources.right_arrow;
            button3.BackgroundImageLayout = ImageLayout.Stretch;
            button3.Location = new Point(81, 87);
            button3.Name = "button3";
            button3.Size = new Size(29, 23);
            button3.TabIndex = 6;
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button12
            // 
            button12.Location = new Point(96, 188);
            button12.Name = "button12";
            button12.Size = new Size(75, 23);
            button12.TabIndex = 15;
            button12.Text = "Delete";
            button12.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.BackgroundImageLayout = ImageLayout.Stretch;
            button5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button5.Location = new Point(46, 87);
            button5.Name = "button5";
            button5.Size = new Size(29, 23);
            button5.TabIndex = 7;
            button5.Text = "X";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button13
            // 
            button13.Location = new Point(11, 188);
            button13.Name = "button13";
            button13.Size = new Size(75, 23);
            button13.TabIndex = 14;
            button13.Text = "Insert";
            button13.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            button7.BackgroundImage = Properties.Resources.bottom_arrow;
            button7.BackgroundImageLayout = ImageLayout.Stretch;
            button7.Location = new Point(46, 116);
            button7.Name = "button7";
            button7.Size = new Size(29, 23);
            button7.TabIndex = 9;
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // button11
            // 
            button11.Location = new Point(96, 159);
            button11.Name = "button11";
            button11.Size = new Size(75, 23);
            button11.TabIndex = 13;
            button11.Text = "Zero";
            button11.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            button9.BackgroundImage = Properties.Resources.top_arrow;
            button9.BackgroundImageLayout = ImageLayout.Stretch;
            button9.Location = new Point(131, 75);
            button9.Name = "button9";
            button9.Size = new Size(29, 23);
            button9.TabIndex = 10;
            button9.UseVisualStyleBackColor = true;
            button9.Click += button9_Click;
            // 
            // button10
            // 
            button10.Location = new Point(11, 159);
            button10.Name = "button10";
            button10.Size = new Size(75, 23);
            button10.TabIndex = 12;
            button10.Text = "Home";
            button10.UseVisualStyleBackColor = true;
            button10.Click += button10_Click;
            // 
            // button8
            // 
            button8.BackgroundImage = Properties.Resources.bottom_arrow;
            button8.BackgroundImageLayout = ImageLayout.Stretch;
            button8.Location = new Point(131, 104);
            button8.Name = "button8";
            button8.Size = new Size(29, 23);
            button8.TabIndex = 11;
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // SettingForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(button17);
            Controls.Add(button16);
            Controls.Add(label5);
            Controls.Add(modelBox);
            Controls.Add(textBox2);
            Controls.Add(dataGridView1);
            Controls.Add(button14);
            Controls.Add(textBox1);
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            Controls.Add(groupBox2);
            Name = "SettingForm";
            Size = new Size(514, 527);
            Load += SettingForm_Load;
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private BindingSource bindingSource1;
        private Button button17;
        private Button button16;
        private Label label5;
        private TextBox modelBox;
        private TextBox textBox2;
        private DataGridView dataGridView1;
        private Button button14;
        private TextBox textBox1;
        private PictureBox pictureBox1;
        private Label label1;
        private GroupBox groupBox2;
        private Label label2;
        private Button button1;
        private Button button6;
        private Button button2;
        private Button button4;
        private TrackBar trackBar1;
        private Label jogSpeedLabel;
        private Button button3;
        private Button button12;
        private Button button5;
        private Button button13;
        private Button button7;
        private Button button11;
        private Button button9;
        private Button button10;
        private Button button8;
    }
}
