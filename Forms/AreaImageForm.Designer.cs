namespace TestTCP1.Forms
{
    partial class AreaImageForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            positionBox = new ComboBox();
            label2 = new Label();
            areaNameBox = new ComboBox();
            actionButton = new Button();
            panelNewArea = new TableLayoutPanel();
            label3 = new Label();
            button1 = new Button();
            button2 = new Button();
            label1 = new Label();
            uploadPhotoDialog = new OpenFileDialog();
            triggerWatcher = new FileSystemWatcher();
            groupBox2 = new GroupBox();
            areaImage = new PictureBox();
            groupBox1.SuspendLayout();
            panelNewArea.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)triggerWatcher).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)areaImage).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(positionBox);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(areaNameBox);
            groupBox1.Controls.Add(actionButton);
            groupBox1.Controls.Add(panelNewArea);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(502, 149);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Area Inspection";
            // 
            // positionBox
            // 
            positionBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            positionBox.DropDownStyle = ComboBoxStyle.DropDownList;
            positionBox.FormattingEnabled = true;
            positionBox.Location = new Point(107, 48);
            positionBox.Name = "positionBox";
            positionBox.Size = new Size(386, 23);
            positionBox.TabIndex = 8;
            // 
            // label2
            // 
            label2.Location = new Point(6, 48);
            label2.Name = "label2";
            label2.Size = new Size(79, 23);
            label2.TabIndex = 7;
            label2.Text = "Position:";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // areaNameBox
            // 
            areaNameBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            areaNameBox.FormattingEnabled = true;
            areaNameBox.Location = new Point(107, 19);
            areaNameBox.Name = "areaNameBox";
            areaNameBox.Size = new Size(389, 23);
            areaNameBox.TabIndex = 6;
            areaNameBox.SelectedIndexChanged += areaNameBox_SelectedIndexChanged;
            areaNameBox.TextUpdate += areaNameBox_TextUpdate;
            // 
            // actionButton
            // 
            actionButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            actionButton.Location = new Point(303, 120);
            actionButton.Name = "actionButton";
            actionButton.Size = new Size(193, 23);
            actionButton.TabIndex = 5;
            actionButton.Text = "Submit";
            actionButton.UseVisualStyleBackColor = true;
            actionButton.Click += actionButton_Click;
            // 
            // panelNewArea
            // 
            panelNewArea.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelNewArea.ColumnCount = 3;
            panelNewArea.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            panelNewArea.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            panelNewArea.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            panelNewArea.Controls.Add(label3, 0, 0);
            panelNewArea.Controls.Add(button1, 1, 0);
            panelNewArea.Controls.Add(button2, 2, 0);
            panelNewArea.Location = new Point(6, 81);
            panelNewArea.Name = "panelNewArea";
            panelNewArea.RowCount = 1;
            panelNewArea.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            panelNewArea.Size = new Size(490, 33);
            panelNewArea.TabIndex = 4;
            // 
            // label3
            // 
            label3.Dock = DockStyle.Fill;
            label3.Location = new Point(3, 0);
            label3.Name = "label3";
            label3.Size = new Size(92, 33);
            label3.TabIndex = 2;
            label3.Text = "Photo";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // button1
            // 
            button1.Dock = DockStyle.Fill;
            button1.Location = new Point(101, 3);
            button1.Name = "button1";
            button1.Size = new Size(190, 27);
            button1.TabIndex = 3;
            button1.Text = "Upload";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Dock = DockStyle.Fill;
            button2.Location = new Point(297, 3);
            button2.Name = "button2";
            button2.Size = new Size(190, 27);
            button2.TabIndex = 4;
            button2.Text = "Trigger";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label1
            // 
            label1.Location = new Point(6, 19);
            label1.Name = "label1";
            label1.Size = new Size(79, 23);
            label1.TabIndex = 0;
            label1.Text = "Name Area:";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // uploadPhotoDialog
            // 
            uploadPhotoDialog.FileName = "area.jpg";
            // 
            // triggerWatcher
            // 
            triggerWatcher.EnableRaisingEvents = true;
            triggerWatcher.NotifyFilter = NotifyFilters.FileName;
            triggerWatcher.SynchronizingObject = this;
            triggerWatcher.Error += triggerWatcher_Error;
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox2.Controls.Add(areaImage);
            groupBox2.Location = new Point(12, 167);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(502, 308);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Area Image";
            // 
            // areaImage
            // 
            areaImage.Dock = DockStyle.Fill;
            areaImage.Location = new Point(3, 19);
            areaImage.Name = "areaImage";
            areaImage.Size = new Size(496, 286);
            areaImage.SizeMode = PictureBoxSizeMode.Zoom;
            areaImage.TabIndex = 0;
            areaImage.TabStop = false;
            // 
            // AreaImageForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(526, 487);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "AreaImageForm";
            Text = "AreaImageForm";
            Load += AreaImageForm_Load;
            groupBox1.ResumeLayout(false);
            panelNewArea.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)triggerWatcher).EndInit();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)areaImage).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label1;
        private TableLayoutPanel panelNewArea;
        private Label label3;
        private Button button1;
        private OpenFileDialog uploadPhotoDialog;
        private ComboBox areaNameBox;
        private Button actionButton;
        private Button button2;
        private FileSystemWatcher triggerWatcher;
        private GroupBox groupBox2;
        private PictureBox areaImage;
        private ComboBox positionBox;
        private Label label2;
    }
}