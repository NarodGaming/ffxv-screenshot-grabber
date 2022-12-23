namespace FFXV6_Screenshot_Grabber
{
    partial class mainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.screenshotListBox = new System.Windows.Forms.ListBox();
            this.previewPictureBox = new System.Windows.Forms.PictureBox();
            this.previewLabel = new System.Windows.Forms.Label();
            this.expandLabel = new System.Windows.Forms.Label();
            this.screenshotLabel = new System.Windows.Forms.Label();
            this.saveAllProgressbar = new System.Windows.Forms.ProgressBar();
            this.saveOneBtn = new System.Windows.Forms.Button();
            this.saveAllBtn = new System.Windows.Forms.Button();
            this.selectFolderBtn = new System.Windows.Forms.Button();
            this.detectFolderBtn = new System.Windows.Forms.Button();
            this.authVerLabel = new System.Windows.Forms.Label();
            this.saveScreenshotDialog = new System.Windows.Forms.SaveFileDialog();
            this.folderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.updateChecker = new System.ComponentModel.BackgroundWorker();
            this.realtimeCheckBox = new System.Windows.Forms.CheckBox();
            this.helpTooltip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.previewPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // screenshotListBox
            // 
            this.screenshotListBox.FormattingEnabled = true;
            this.screenshotListBox.ItemHeight = 15;
            this.screenshotListBox.Location = new System.Drawing.Point(648, 22);
            this.screenshotListBox.Name = "screenshotListBox";
            this.screenshotListBox.Size = new System.Drawing.Size(322, 364);
            this.screenshotListBox.TabIndex = 0;
            this.screenshotListBox.SelectedIndexChanged += new System.EventHandler(this.screenshotListBox_SelectedIndexChanged);
            // 
            // previewPictureBox
            // 
            this.previewPictureBox.BackgroundImage = global::FFXV6_Screenshot_Grabber.Properties.Resources._00001333;
            this.previewPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.previewPictureBox.Location = new System.Drawing.Point(2, 22);
            this.previewPictureBox.Name = "previewPictureBox";
            this.previewPictureBox.Size = new System.Drawing.Size(640, 360);
            this.previewPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.previewPictureBox.TabIndex = 1;
            this.previewPictureBox.TabStop = false;
            this.previewPictureBox.Click += new System.EventHandler(this.previewPictureBox_Click);
            // 
            // previewLabel
            // 
            this.previewLabel.AutoSize = true;
            this.previewLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.previewLabel.Location = new System.Drawing.Point(2, 4);
            this.previewLabel.Name = "previewLabel";
            this.previewLabel.Size = new System.Drawing.Size(48, 15);
            this.previewLabel.TabIndex = 2;
            this.previewLabel.Text = "Preview";
            // 
            // expandLabel
            // 
            this.expandLabel.AutoSize = true;
            this.expandLabel.BackColor = System.Drawing.SystemColors.Control;
            this.expandLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.expandLabel.Location = new System.Drawing.Point(511, 4);
            this.expandLabel.Name = "expandLabel";
            this.expandLabel.Size = new System.Drawing.Size(131, 15);
            this.expandLabel.TabIndex = 3;
            this.expandLabel.Text = "(click image to expand)";
            // 
            // screenshotLabel
            // 
            this.screenshotLabel.AutoSize = true;
            this.screenshotLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.screenshotLabel.Location = new System.Drawing.Point(648, 4);
            this.screenshotLabel.Name = "screenshotLabel";
            this.screenshotLabel.Size = new System.Drawing.Size(119, 15);
            this.screenshotLabel.TabIndex = 4;
            this.screenshotLabel.Text = "Screenshots: 000000";
            this.helpTooltip.SetToolTip(this.screenshotLabel, "This is the number of screenshots shown in the list below.");
            // 
            // saveAllProgressbar
            // 
            this.saveAllProgressbar.Location = new System.Drawing.Point(164, 386);
            this.saveAllProgressbar.Name = "saveAllProgressbar";
            this.saveAllProgressbar.Size = new System.Drawing.Size(478, 23);
            this.saveAllProgressbar.Step = 1;
            this.saveAllProgressbar.TabIndex = 5;
            this.helpTooltip.SetToolTip(this.saveAllProgressbar, "This progressbar shows the progress of the current \'Save All\' task.");
            // 
            // saveOneBtn
            // 
            this.saveOneBtn.Location = new System.Drawing.Point(2, 386);
            this.saveOneBtn.Name = "saveOneBtn";
            this.saveOneBtn.Size = new System.Drawing.Size(75, 23);
            this.saveOneBtn.TabIndex = 6;
            this.saveOneBtn.Text = "Save One";
            this.helpTooltip.SetToolTip(this.saveOneBtn, "This button saves the current screenshot to a location of your choosing.");
            this.saveOneBtn.UseVisualStyleBackColor = true;
            this.saveOneBtn.Click += new System.EventHandler(this.saveOneBtn_Click);
            // 
            // saveAllBtn
            // 
            this.saveAllBtn.Location = new System.Drawing.Point(83, 386);
            this.saveAllBtn.Name = "saveAllBtn";
            this.saveAllBtn.Size = new System.Drawing.Size(75, 23);
            this.saveAllBtn.TabIndex = 7;
            this.saveAllBtn.Text = "Save All";
            this.helpTooltip.SetToolTip(this.saveAllBtn, "This button saves all screenshots in the list to a chosen location.");
            this.saveAllBtn.UseVisualStyleBackColor = true;
            this.saveAllBtn.Click += new System.EventHandler(this.saveAllBtn_Click);
            // 
            // selectFolderBtn
            // 
            this.selectFolderBtn.Location = new System.Drawing.Point(648, 388);
            this.selectFolderBtn.Name = "selectFolderBtn";
            this.selectFolderBtn.Size = new System.Drawing.Size(106, 23);
            this.selectFolderBtn.TabIndex = 8;
            this.selectFolderBtn.Text = "Select Folder";
            this.helpTooltip.SetToolTip(this.selectFolderBtn, "This button allows you to change the current screenshot directory.");
            this.selectFolderBtn.UseVisualStyleBackColor = true;
            this.selectFolderBtn.Click += new System.EventHandler(this.selectFolderBtn_Click);
            // 
            // detectFolderBtn
            // 
            this.detectFolderBtn.Location = new System.Drawing.Point(760, 388);
            this.detectFolderBtn.Name = "detectFolderBtn";
            this.detectFolderBtn.Size = new System.Drawing.Size(106, 23);
            this.detectFolderBtn.TabIndex = 9;
            this.detectFolderBtn.Text = "Detect Folder";
            this.helpTooltip.SetToolTip(this.detectFolderBtn, "This button attempts to automatically locate your screenshot folder.\r\n\r\nTypically" +
        " this is \"My Games/FINAL FANTASY XV/Steam/.../savestorage/snapshot\"");
            this.detectFolderBtn.UseVisualStyleBackColor = true;
            this.detectFolderBtn.Click += new System.EventHandler(this.detectFolderBtn_Click);
            // 
            // authVerLabel
            // 
            this.authVerLabel.AutoSize = true;
            this.authVerLabel.Location = new System.Drawing.Point(872, 392);
            this.authVerLabel.Name = "authVerLabel";
            this.authVerLabel.Size = new System.Drawing.Size(98, 15);
            this.authVerLabel.TabIndex = 10;
            this.authVerLabel.Text = "by Narod (V1.1.0)";
            this.helpTooltip.SetToolTip(this.authVerLabel, "Narod\'s FFXV Screenshot Grabber.\r\n\r\nby Narod");
            // 
            // saveScreenshotDialog
            // 
            this.saveScreenshotDialog.DefaultExt = "jpg";
            this.saveScreenshotDialog.Filter = "JPG file|*.jpg";
            this.saveScreenshotDialog.RestoreDirectory = true;
            this.saveScreenshotDialog.Title = "Choose where to save this screenshot...";
            // 
            // folderDialog
            // 
            this.folderDialog.Description = "Please select a folder...";
            // 
            // updateChecker
            // 
            this.updateChecker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.updateChecker_DoWork);
            this.updateChecker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.updateChecker_RunWorkerCompleted);
            // 
            // realtimeCheckBox
            // 
            this.realtimeCheckBox.AutoSize = true;
            this.realtimeCheckBox.Cursor = System.Windows.Forms.Cursors.Help;
            this.realtimeCheckBox.Location = new System.Drawing.Point(864, 3);
            this.realtimeCheckBox.Name = "realtimeCheckBox";
            this.realtimeCheckBox.Size = new System.Drawing.Size(106, 19);
            this.realtimeCheckBox.TabIndex = 11;
            this.realtimeCheckBox.Text = "Realtime Mode";
            this.helpTooltip.SetToolTip(this.realtimeCheckBox, "Realtime mode allows the utility to automatically save screenshots as the game cr" +
        "eates them.");
            this.realtimeCheckBox.UseVisualStyleBackColor = true;
            this.realtimeCheckBox.CheckedChanged += new System.EventHandler(this.realtimeCheckBox_CheckedChanged);
            // 
            // helpTooltip
            // 
            this.helpTooltip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.helpTooltip.ToolTipTitle = "Help";
            // 
            // mainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 412);
            this.Controls.Add(this.realtimeCheckBox);
            this.Controls.Add(this.authVerLabel);
            this.Controls.Add(this.detectFolderBtn);
            this.Controls.Add(this.selectFolderBtn);
            this.Controls.Add(this.saveAllBtn);
            this.Controls.Add(this.saveOneBtn);
            this.Controls.Add(this.saveAllProgressbar);
            this.Controls.Add(this.screenshotLabel);
            this.Controls.Add(this.expandLabel);
            this.Controls.Add(this.previewLabel);
            this.Controls.Add(this.previewPictureBox);
            this.Controls.Add(this.screenshotListBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "mainWindow";
            this.Text = "Narod\'s FFXV Screenshot Grabber";
            ((System.ComponentModel.ISupportInitialize)(this.previewPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListBox screenshotListBox;
        private PictureBox previewPictureBox;
        private Label previewLabel;
        private Label expandLabel;
        private Label screenshotLabel;
        private ProgressBar saveAllProgressbar;
        private Button saveOneBtn;
        private Button saveAllBtn;
        private Button selectFolderBtn;
        private Button detectFolderBtn;
        private Label authVerLabel;
        private SaveFileDialog saveScreenshotDialog;
        private FolderBrowserDialog folderDialog;
        private System.ComponentModel.BackgroundWorker updateChecker;
        private CheckBox realtimeCheckBox;
        private ToolTip helpTooltip;
    }
}