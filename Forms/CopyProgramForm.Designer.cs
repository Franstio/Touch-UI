namespace TestTCP1.Forms
{
    partial class CopyProgramForm
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
            label1 = new Label();
            label2 = new Label();
            newModelNameBox = new TextBox();
            comboBox1 = new ComboBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(36, 29);
            label1.Name = "label1";
            label1.Size = new Size(115, 21);
            label1.TabIndex = 0;
            label1.Text = "Model to Copy:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(12, 76);
            label2.Name = "label2";
            label2.Size = new Size(139, 21);
            label2.TabIndex = 1;
            label2.Text = "New Model Name:";
            // 
            // newModelNameBox
            // 
            newModelNameBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            newModelNameBox.Location = new Point(157, 73);
            newModelNameBox.Name = "newModelNameBox";
            newModelNameBox.Size = new Size(195, 29);
            newModelNameBox.TabIndex = 2;
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(157, 26);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(195, 29);
            comboBox1.TabIndex = 3;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(157, 118);
            button1.Name = "button1";
            button1.Size = new Size(195, 33);
            button1.TabIndex = 4;
            button1.Text = "Submit";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // CopyProgramForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(364, 165);
            Controls.Add(button1);
            Controls.Add(comboBox1);
            Controls.Add(newModelNameBox);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "CopyProgramForm";
            Text = "Copy Program Form";
            Load += CopyProgramForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox newModelNameBox;
        private ComboBox comboBox1;
        private Button button1;
    }
}