namespace TestTCP1
{
    partial class MainForm
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
            menuStrip1 = new MenuStrip();
            optionToolStripMenuItem = new ToolStripMenuItem();
            changeModelToolStripMenuItem = new ToolStripMenuItem();
            settingParameterToolStripMenuItem = new ToolStripMenuItem();
            newModelParameterToolStripMenuItem = new ToolStripMenuItem();
            modifyParameterToolStripMenuItem = new ToolStripMenuItem();
            copyProgramToolStripMenuItem = new ToolStripMenuItem();
            deleteProgramToolStripMenuItem = new ToolStripMenuItem();
            configurationToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            mainPanel = new Panel();
            dashboardControl1 = new Forms.DashboardControl();
            menuStrip1.SuspendLayout();
            mainPanel.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { optionToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(5, 2, 0, 2);
            menuStrip1.Size = new Size(1122, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // optionToolStripMenuItem
            // 
            optionToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { changeModelToolStripMenuItem, settingParameterToolStripMenuItem, configurationToolStripMenuItem, exitToolStripMenuItem });
            optionToolStripMenuItem.Font = new Font("Segoe UI", 9F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point);
            optionToolStripMenuItem.Name = "optionToolStripMenuItem";
            optionToolStripMenuItem.Size = new Size(57, 20);
            optionToolStripMenuItem.Text = "Option";
            // 
            // changeModelToolStripMenuItem
            // 
            changeModelToolStripMenuItem.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            changeModelToolStripMenuItem.Name = "changeModelToolStripMenuItem";
            changeModelToolStripMenuItem.Size = new Size(168, 22);
            changeModelToolStripMenuItem.Text = "Change Model";
            changeModelToolStripMenuItem.Click += changeModelToolStripMenuItem_Click;
            // 
            // settingParameterToolStripMenuItem
            // 
            settingParameterToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newModelParameterToolStripMenuItem, modifyParameterToolStripMenuItem, copyProgramToolStripMenuItem, deleteProgramToolStripMenuItem });
            settingParameterToolStripMenuItem.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            settingParameterToolStripMenuItem.Name = "settingParameterToolStripMenuItem";
            settingParameterToolStripMenuItem.Size = new Size(168, 22);
            settingParameterToolStripMenuItem.Text = "Setting Parameter";
            // 
            // newModelParameterToolStripMenuItem
            // 
            newModelParameterToolStripMenuItem.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            newModelParameterToolStripMenuItem.Name = "newModelParameterToolStripMenuItem";
            newModelParameterToolStripMenuItem.Size = new Size(192, 22);
            newModelParameterToolStripMenuItem.Text = "New Model Parameter";
            newModelParameterToolStripMenuItem.Click += newModelParameterToolStripMenuItem_Click;
            // 
            // modifyParameterToolStripMenuItem
            // 
            modifyParameterToolStripMenuItem.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            modifyParameterToolStripMenuItem.Name = "modifyParameterToolStripMenuItem";
            modifyParameterToolStripMenuItem.Size = new Size(192, 22);
            modifyParameterToolStripMenuItem.Text = "Modify Parameter";
            modifyParameterToolStripMenuItem.Click += modifyParameterToolStripMenuItem_Click;
            // 
            // copyProgramToolStripMenuItem
            // 
            copyProgramToolStripMenuItem.Name = "copyProgramToolStripMenuItem";
            copyProgramToolStripMenuItem.Size = new Size(192, 22);
            copyProgramToolStripMenuItem.Text = "Copy Program";
            copyProgramToolStripMenuItem.Click += copyProgramToolStripMenuItem_Click;
            // 
            // deleteProgramToolStripMenuItem
            // 
            deleteProgramToolStripMenuItem.Name = "deleteProgramToolStripMenuItem";
            deleteProgramToolStripMenuItem.Size = new Size(192, 22);
            deleteProgramToolStripMenuItem.Text = "Delete Program";
            deleteProgramToolStripMenuItem.Click += deleteProgramToolStripMenuItem_Click;
            // 
            // configurationToolStripMenuItem
            // 
            configurationToolStripMenuItem.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            configurationToolStripMenuItem.Name = "configurationToolStripMenuItem";
            configurationToolStripMenuItem.Size = new Size(168, 22);
            configurationToolStripMenuItem.Text = "Configuration";
            configurationToolStripMenuItem.Click += configurationToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(168, 22);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // mainPanel
            // 
            mainPanel.AutoScroll = true;
            mainPanel.AutoSize = true;
            mainPanel.Controls.Add(dashboardControl1);
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(0, 24);
            mainPanel.Margin = new Padding(3, 2, 3, 2);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(1122, 592);
            mainPanel.TabIndex = 1;
            // 
            // dashboardControl1
            // 
            dashboardControl1.Dock = DockStyle.Fill;
            dashboardControl1.Location = new Point(0, 0);
            dashboardControl1.Margin = new Padding(3, 2, 3, 2);
            dashboardControl1.Name = "dashboardControl1";
            dashboardControl1.Size = new Size(1122, 592);
            dashboardControl1.TabIndex = 0;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1122, 616);
            Controls.Add(mainPanel);
            Controls.Add(menuStrip1);
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            Name = "MainForm";
            Text = "MainForm";
            Load += MainForm_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            mainPanel.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem optionToolStripMenuItem;
        private ToolStripMenuItem changeModelToolStripMenuItem;
        private ToolStripMenuItem settingParameterToolStripMenuItem;
        private ToolStripMenuItem newModelParameterToolStripMenuItem;
        private ToolStripMenuItem modifyParameterToolStripMenuItem;
        private ToolStripMenuItem configurationToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private Panel mainPanel;
        private ToolStripMenuItem copyProgramToolStripMenuItem;
        private ToolStripMenuItem deleteProgramToolStripMenuItem;
        private Forms.DashboardControl dashboardControl1;
    }
}