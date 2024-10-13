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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainWindow));
            screenshotListBox = new ListBox();
            previewPictureBox = new PictureBox();
            previewLabel = new Label();
            screenshotLabel = new Label();
            saveAllProgressbar = new ProgressBar();
            saveOneBtn = new Button();
            saveAllBtn = new Button();
            selectFolderBtn = new Button();
            detectFolderBtn = new Button();
            authVerLabel = new Label();
            saveScreenshotDialog = new SaveFileDialog();
            folderDialog = new FolderBrowserDialog();
            updateChecker = new System.ComponentModel.BackgroundWorker();
            realtimeCheckBox = new CheckBox();
            helpTooltip = new ToolTip(components);
            saveAllTBtn = new Button();
            saveGroupBox = new GroupBox();
            folderGroupBox = new GroupBox();
            folderRealtimeWarning = new Label();
            screenshotTakenLabel = new Label();
            tooltipsCheckbox = new CheckBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            tableLayoutPanel3 = new TableLayoutPanel();
            tableLayoutPanel4 = new TableLayoutPanel();
            tableLayoutPanel5 = new TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)previewPictureBox).BeginInit();
            saveGroupBox.SuspendLayout();
            folderGroupBox.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            tableLayoutPanel5.SuspendLayout();
            SuspendLayout();
            // 
            // screenshotListBox
            // 
            screenshotListBox.BorderStyle = BorderStyle.FixedSingle;
            screenshotListBox.Dock = DockStyle.Fill;
            screenshotListBox.FormattingEnabled = true;
            screenshotListBox.ItemHeight = 16;
            screenshotListBox.Location = new Point(4, 18);
            screenshotListBox.Margin = new Padding(4, 3, 4, 3);
            screenshotListBox.Name = "screenshotListBox";
            screenshotListBox.Size = new Size(122, 420);
            screenshotListBox.TabIndex = 0;
            screenshotListBox.SelectedIndexChanged += screenshotListBox_SelectedIndexChanged;
            // 
            // previewPictureBox
            // 
            previewPictureBox.BackgroundImage = Properties.Resources.default_preview;
            previewPictureBox.BackgroundImageLayout = ImageLayout.Zoom;
            previewPictureBox.Dock = DockStyle.Fill;
            previewPictureBox.Location = new Point(4, 25);
            previewPictureBox.Margin = new Padding(4, 3, 4, 3);
            previewPictureBox.Name = "previewPictureBox";
            previewPictureBox.Size = new Size(748, 409);
            previewPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            previewPictureBox.TabIndex = 1;
            previewPictureBox.TabStop = false;
            helpTooltip.SetToolTip(previewPictureBox, "Your image preview for the selected image will appear here.");
            previewPictureBox.Click += previewPictureBox_Click;
            // 
            // previewLabel
            // 
            previewLabel.AutoSize = true;
            previewLabel.Dock = DockStyle.Fill;
            previewLabel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            previewLabel.Location = new Point(4, 0);
            previewLabel.Margin = new Padding(4, 0, 4, 0);
            previewLabel.Name = "previewLabel";
            previewLabel.Size = new Size(175, 16);
            previewLabel.TabIndex = 2;
            previewLabel.Text = "Preview - click image to expand";
            // 
            // screenshotLabel
            // 
            screenshotLabel.AutoSize = true;
            screenshotLabel.Dock = DockStyle.Fill;
            screenshotLabel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            screenshotLabel.Location = new Point(4, 0);
            screenshotLabel.Margin = new Padding(4, 0, 4, 0);
            screenshotLabel.Name = "screenshotLabel";
            screenshotLabel.Size = new Size(122, 15);
            screenshotLabel.TabIndex = 4;
            screenshotLabel.Text = "Screenshots: 000000";
            helpTooltip.SetToolTip(screenshotLabel, "This is the number of screenshots shown in the list below.");
            // 
            // saveAllProgressbar
            // 
            saveAllProgressbar.BackColor = SystemColors.Control;
            saveAllProgressbar.Dock = DockStyle.Fill;
            saveAllProgressbar.Location = new Point(203, 3);
            saveAllProgressbar.Margin = new Padding(4, 3, 4, 3);
            saveAllProgressbar.Name = "saveAllProgressbar";
            saveAllProgressbar.Size = new Size(427, 44);
            saveAllProgressbar.Step = 1;
            saveAllProgressbar.TabIndex = 5;
            helpTooltip.SetToolTip(saveAllProgressbar, "This progress bar shows the progress of the current 'Save All' task.");
            // 
            // saveOneBtn
            // 
            saveOneBtn.AutoSize = true;
            saveOneBtn.Dock = DockStyle.Left;
            saveOneBtn.FlatStyle = FlatStyle.System;
            saveOneBtn.Location = new Point(3, 19);
            saveOneBtn.Margin = new Padding(1);
            saveOneBtn.Name = "saveOneBtn";
            saveOneBtn.Size = new Size(54, 28);
            saveOneBtn.TabIndex = 1;
            saveOneBtn.Text = "One";
            helpTooltip.SetToolTip(saveOneBtn, "This button saves the current screenshot to a location of your choosing.");
            saveOneBtn.UseVisualStyleBackColor = true;
            saveOneBtn.Click += saveOneBtn_Click;
            // 
            // saveAllBtn
            // 
            saveAllBtn.AutoSize = true;
            saveAllBtn.Dock = DockStyle.Left;
            saveAllBtn.FlatStyle = FlatStyle.System;
            saveAllBtn.Location = new Point(57, 19);
            saveAllBtn.Margin = new Padding(1);
            saveAllBtn.Name = "saveAllBtn";
            saveAllBtn.Size = new Size(51, 28);
            saveAllBtn.TabIndex = 2;
            saveAllBtn.Text = "All";
            helpTooltip.SetToolTip(saveAllBtn, "This button saves all screenshots in the list to a chosen location.\r\n\r\nCompared to 'Turbo' mode, it's slower but shows a preview\r\nof the images as they are saved.");
            saveAllBtn.UseVisualStyleBackColor = true;
            saveAllBtn.Click += saveAllBtn_Click;
            // 
            // selectFolderBtn
            // 
            selectFolderBtn.AutoSize = true;
            selectFolderBtn.Dock = DockStyle.Left;
            selectFolderBtn.FlatStyle = FlatStyle.System;
            selectFolderBtn.Location = new Point(3, 19);
            selectFolderBtn.Margin = new Padding(1);
            selectFolderBtn.Name = "selectFolderBtn";
            selectFolderBtn.Size = new Size(55, 28);
            selectFolderBtn.TabIndex = 3;
            selectFolderBtn.Text = "Select";
            helpTooltip.SetToolTip(selectFolderBtn, "This button allows you to change the current screenshot directory.");
            selectFolderBtn.UseVisualStyleBackColor = true;
            selectFolderBtn.Click += selectFolderBtn_Click;
            // 
            // detectFolderBtn
            // 
            detectFolderBtn.AutoSize = true;
            detectFolderBtn.Dock = DockStyle.Right;
            detectFolderBtn.FlatStyle = FlatStyle.System;
            detectFolderBtn.Location = new Point(58, 19);
            detectFolderBtn.Margin = new Padding(1);
            detectFolderBtn.Name = "detectFolderBtn";
            detectFolderBtn.Size = new Size(55, 28);
            detectFolderBtn.TabIndex = 4;
            detectFolderBtn.Text = "Detect";
            helpTooltip.SetToolTip(detectFolderBtn, "This button attempts to automatically locate your screenshot folder.\r\n\r\nTypically this is \"My Games/FINAL FANTASY XV/Steam/.../savestorage/snapshot\"");
            detectFolderBtn.UseVisualStyleBackColor = true;
            detectFolderBtn.Click += detectFolderBtn_Click;
            // 
            // authVerLabel
            // 
            authVerLabel.AutoSize = true;
            authVerLabel.Dock = DockStyle.Fill;
            authVerLabel.Font = new Font("Segoe UI Variable Text", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            authVerLabel.Location = new Point(653, 0);
            authVerLabel.Margin = new Padding(4, 0, 4, 0);
            authVerLabel.Name = "authVerLabel";
            authVerLabel.Size = new Size(93, 16);
            authVerLabel.TabIndex = 10;
            authVerLabel.Text = "by Narod (Vx.x.x.x)";
            helpTooltip.SetToolTip(authVerLabel, "Narod's FFXV Screenshot Grabber.\r\n\r\nby Narod");
            // 
            // saveScreenshotDialog
            // 
            saveScreenshotDialog.DefaultExt = "jpg";
            saveScreenshotDialog.Filter = "JPG file|*.jpg";
            saveScreenshotDialog.RestoreDirectory = true;
            saveScreenshotDialog.Title = "Choose where to save this screenshot...";
            // 
            // folderDialog
            // 
            folderDialog.Description = "Please select a folder...";
            // 
            // updateChecker
            // 
            updateChecker.DoWork += updateChecker_DoWork;
            updateChecker.RunWorkerCompleted += updateChecker_RunWorkerCompleted;
            // 
            // realtimeCheckBox
            // 
            realtimeCheckBox.AutoSize = true;
            realtimeCheckBox.Dock = DockStyle.Fill;
            realtimeCheckBox.Location = new Point(4, 470);
            realtimeCheckBox.Margin = new Padding(4, 3, 4, 3);
            realtimeCheckBox.Name = "realtimeCheckBox";
            realtimeCheckBox.Size = new Size(122, 20);
            realtimeCheckBox.TabIndex = 11;
            realtimeCheckBox.Text = "Realtime Mode";
            helpTooltip.SetToolTip(realtimeCheckBox, "Realtime mode allows the utility to automatically save screenshots as the game creates them.");
            realtimeCheckBox.UseVisualStyleBackColor = true;
            realtimeCheckBox.CheckedChanged += realtimeCheckBox_CheckedChanged;
            realtimeCheckBox.Paint += checkboxPainter;
            // 
            // helpTooltip
            // 
            helpTooltip.ToolTipIcon = ToolTipIcon.Info;
            helpTooltip.ToolTipTitle = "Help";
            // 
            // saveAllTBtn
            // 
            saveAllTBtn.AutoSize = true;
            saveAllTBtn.Dock = DockStyle.Right;
            saveAllTBtn.FlatStyle = FlatStyle.System;
            saveAllTBtn.Location = new Point(108, 19);
            saveAllTBtn.Margin = new Padding(1);
            saveAllTBtn.Name = "saveAllTBtn";
            saveAllTBtn.Size = new Size(88, 28);
            saveAllTBtn.TabIndex = 12;
            saveAllTBtn.Text = "All (Turbo)";
            helpTooltip.SetToolTip(saveAllTBtn, "This button saves all screenshots in the list to a chosen location.\r\n\r\nIt does this in \"Turbo\" mode, which is very fast but doesn't\r\nshow previews like the non-Turbo mode does.");
            saveAllTBtn.UseVisualStyleBackColor = true;
            saveAllTBtn.Click += saveAllTBtn_Click;
            // 
            // saveGroupBox
            // 
            saveGroupBox.AutoSize = true;
            saveGroupBox.Controls.Add(saveAllTBtn);
            saveGroupBox.Controls.Add(saveAllBtn);
            saveGroupBox.Controls.Add(saveOneBtn);
            saveGroupBox.Dock = DockStyle.Fill;
            saveGroupBox.Location = new Point(0, 0);
            saveGroupBox.Margin = new Padding(0);
            saveGroupBox.Name = "saveGroupBox";
            saveGroupBox.Size = new Size(199, 50);
            saveGroupBox.TabIndex = 13;
            saveGroupBox.TabStop = false;
            saveGroupBox.Text = "Save";
            // 
            // folderGroupBox
            // 
            folderGroupBox.AutoSize = true;
            folderGroupBox.Controls.Add(selectFolderBtn);
            folderGroupBox.Controls.Add(detectFolderBtn);
            folderGroupBox.Controls.Add(folderRealtimeWarning);
            folderGroupBox.Dock = DockStyle.Fill;
            folderGroupBox.Location = new Point(634, 0);
            folderGroupBox.Margin = new Padding(0);
            folderGroupBox.Name = "folderGroupBox";
            folderGroupBox.Size = new Size(116, 50);
            folderGroupBox.TabIndex = 14;
            folderGroupBox.TabStop = false;
            folderGroupBox.Text = "Folder";
            // 
            // folderRealtimeWarning
            // 
            folderRealtimeWarning.AutoSize = true;
            folderRealtimeWarning.Font = new Font("Segoe UI Variable Text", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            folderRealtimeWarning.Location = new Point(12, 14);
            folderRealtimeWarning.Name = "folderRealtimeWarning";
            folderRealtimeWarning.Size = new Size(91, 30);
            folderRealtimeWarning.TabIndex = 5;
            folderRealtimeWarning.Text = "Disable Realtime\r\n to change folder";
            folderRealtimeWarning.Visible = false;
            // 
            // screenshotTakenLabel
            // 
            screenshotTakenLabel.AutoSize = true;
            screenshotTakenLabel.Dock = DockStyle.Fill;
            screenshotTakenLabel.Location = new Point(186, 0);
            screenshotTakenLabel.Name = "screenshotTakenLabel";
            screenshotTakenLabel.Size = new Size(460, 16);
            screenshotTakenLabel.TabIndex = 15;
            screenshotTakenLabel.Text = "Snapshot Taken on (locale date format)";
            screenshotTakenLabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // tooltipsCheckbox
            // 
            tooltipsCheckbox.AutoSize = true;
            tooltipsCheckbox.Checked = true;
            tooltipsCheckbox.CheckState = CheckState.Checked;
            tooltipsCheckbox.Dock = DockStyle.Fill;
            tooltipsCheckbox.Location = new Point(3, 444);
            tooltipsCheckbox.Name = "tooltipsCheckbox";
            tooltipsCheckbox.Size = new Size(124, 20);
            tooltipsCheckbox.TabIndex = 16;
            tooltipsCheckbox.Text = "Enable Tooltips";
            tooltipsCheckbox.UseVisualStyleBackColor = true;
            tooltipsCheckbox.CheckedChanged += tooltipsCheckbox_CheckedChanged;
            tooltipsCheckbox.Paint += checkboxPainter;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.Controls.Add(previewLabel, 0, 0);
            tableLayoutPanel1.Controls.Add(screenshotTakenLabel, 1, 0);
            tableLayoutPanel1.Controls.Add(authVerLabel, 2, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.GrowStyle = TableLayoutPanelGrowStyle.AddColumns;
            tableLayoutPanel1.Location = new Point(3, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(750, 16);
            tableLayoutPanel1.TabIndex = 18;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.AutoSize = true;
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(tooltipsCheckbox, 0, 2);
            tableLayoutPanel2.Controls.Add(realtimeCheckBox, 0, 3);
            tableLayoutPanel2.Controls.Add(screenshotLabel, 0, 0);
            tableLayoutPanel2.Controls.Add(screenshotListBox, 0, 1);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(765, 3);
            tableLayoutPanel2.MaximumSize = new Size(130, 0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 4;
            tableLayoutPanel2.RowStyles.Add(new RowStyle());
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle());
            tableLayoutPanel2.RowStyles.Add(new RowStyle());
            tableLayoutPanel2.Size = new Size(130, 493);
            tableLayoutPanel2.TabIndex = 19;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 3;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel3.Controls.Add(saveGroupBox, 0, 0);
            tableLayoutPanel3.Controls.Add(folderGroupBox, 2, 0);
            tableLayoutPanel3.Controls.Add(saveAllProgressbar, 1, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(3, 440);
            tableLayoutPanel3.MaximumSize = new Size(0, 50);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Size = new Size(750, 50);
            tableLayoutPanel3.TabIndex = 20;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.AutoSize = true;
            tableLayoutPanel4.ColumnCount = 1;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.Controls.Add(tableLayoutPanel1, 0, 0);
            tableLayoutPanel4.Controls.Add(tableLayoutPanel3, 0, 2);
            tableLayoutPanel4.Controls.Add(previewPictureBox, 0, 1);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(3, 3);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 3;
            tableLayoutPanel4.RowStyles.Add(new RowStyle());
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle());
            tableLayoutPanel4.Size = new Size(756, 493);
            tableLayoutPanel4.TabIndex = 21;
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.AutoSize = true;
            tableLayoutPanel5.ColumnCount = 2;
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel5.Controls.Add(tableLayoutPanel4, 0, 0);
            tableLayoutPanel5.Controls.Add(tableLayoutPanel2, 1, 0);
            tableLayoutPanel5.Dock = DockStyle.Fill;
            tableLayoutPanel5.Location = new Point(0, 0);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 1;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel5.Size = new Size(898, 499);
            tableLayoutPanel5.TabIndex = 22;
            // 
            // mainWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(898, 499);
            Controls.Add(tableLayoutPanel5);
            Font = new Font("Segoe UI Variable Text", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimumSize = new Size(914, 538);
            Name = "mainWindow";
            Text = "Narod's FFXV Screenshot Grabber";
            ((System.ComponentModel.ISupportInitialize)previewPictureBox).EndInit();
            saveGroupBox.ResumeLayout(false);
            saveGroupBox.PerformLayout();
            folderGroupBox.ResumeLayout(false);
            folderGroupBox.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel4.PerformLayout();
            tableLayoutPanel5.ResumeLayout(false);
            tableLayoutPanel5.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox screenshotListBox;
        private PictureBox previewPictureBox;
        private Label previewLabel;
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
        private Button saveAllTBtn;
        private GroupBox saveGroupBox;
        private GroupBox folderGroupBox;
        private Label folderRealtimeWarning;
        private Label screenshotTakenLabel;
        private CheckBox tooltipsCheckbox;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel3;
        private TableLayoutPanel tableLayoutPanel4;
        private TableLayoutPanel tableLayoutPanel5;
    }
}