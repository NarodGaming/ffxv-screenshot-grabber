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
            comradesCheckbox = new CheckBox();
            saveGroupBox = new GroupBox();
            folderGroupBox = new GroupBox();
            folderRealtimeWarning = new Label();
            screenshotTakenLabel = new Label();
            tooltipsCheckbox = new CheckBox();
            upperTableLayoutPanel = new TableLayoutPanel();
            rightTableLayoutPanel = new TableLayoutPanel();
            lowerTableLayoutPanel = new TableLayoutPanel();
            leftTableLayoutPanel = new TableLayoutPanel();
            outerTableLayoutPanel = new TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)previewPictureBox).BeginInit();
            saveGroupBox.SuspendLayout();
            folderGroupBox.SuspendLayout();
            upperTableLayoutPanel.SuspendLayout();
            rightTableLayoutPanel.SuspendLayout();
            lowerTableLayoutPanel.SuspendLayout();
            leftTableLayoutPanel.SuspendLayout();
            outerTableLayoutPanel.SuspendLayout();
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
            screenshotListBox.Size = new Size(122, 394);
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
            helpTooltip.SetToolTip(previewPictureBox, "Your image preview for the selected image will appear here.\r\n\r\nClick to open a preview window. On Windows, this will be your\r\ndefault photo viewer.\r\n\r\nRight-click to copy the image to your clipboard.");
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
            saveAllProgressbar.Visible = false;
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
            helpTooltip.SetToolTip(detectFolderBtn, "This button attempts to automatically locate your screenshot folder.\r\n\r\nTypically this is \"My Games/FINAL FANTASY XV/(Steam/Origin)/.../savestorage/snapshot\"");
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
            realtimeCheckBox.Location = new Point(4, 444);
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
            // comradesCheckbox
            // 
            comradesCheckbox.AutoSize = true;
            comradesCheckbox.Dock = DockStyle.Fill;
            comradesCheckbox.Location = new Point(3, 470);
            comradesCheckbox.Name = "comradesCheckbox";
            comradesCheckbox.Size = new Size(124, 20);
            comradesCheckbox.TabIndex = 17;
            comradesCheckbox.Text = "Comrades Photos";
            helpTooltip.SetToolTip(comradesCheckbox, "Quick switches you to Comrades photos (or base game photos)\r\n\r\nYou can also achieve this by using 'Select' in the folder options.");
            comradesCheckbox.UseVisualStyleBackColor = true;
            comradesCheckbox.CheckedChanged += comradesCheckbox_CheckedChanged;
            comradesCheckbox.Paint += checkboxPainter;
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
            tooltipsCheckbox.Location = new Point(3, 418);
            tooltipsCheckbox.Name = "tooltipsCheckbox";
            tooltipsCheckbox.Size = new Size(124, 20);
            tooltipsCheckbox.TabIndex = 16;
            tooltipsCheckbox.Text = "Enable Tooltips";
            tooltipsCheckbox.UseVisualStyleBackColor = true;
            tooltipsCheckbox.CheckedChanged += tooltipsCheckbox_CheckedChanged;
            tooltipsCheckbox.Paint += checkboxPainter;
            // 
            // upperTableLayoutPanel
            // 
            upperTableLayoutPanel.AutoSize = true;
            upperTableLayoutPanel.ColumnCount = 3;
            upperTableLayoutPanel.ColumnStyles.Add(new ColumnStyle());
            upperTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            upperTableLayoutPanel.ColumnStyles.Add(new ColumnStyle());
            upperTableLayoutPanel.Controls.Add(previewLabel, 0, 0);
            upperTableLayoutPanel.Controls.Add(screenshotTakenLabel, 1, 0);
            upperTableLayoutPanel.Controls.Add(authVerLabel, 2, 0);
            upperTableLayoutPanel.Dock = DockStyle.Fill;
            upperTableLayoutPanel.GrowStyle = TableLayoutPanelGrowStyle.AddColumns;
            upperTableLayoutPanel.Location = new Point(3, 3);
            upperTableLayoutPanel.Name = "upperTableLayoutPanel";
            upperTableLayoutPanel.RowCount = 1;
            upperTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            upperTableLayoutPanel.Size = new Size(750, 16);
            upperTableLayoutPanel.TabIndex = 18;
            // 
            // rightTableLayoutPanel
            // 
            rightTableLayoutPanel.AutoSize = true;
            rightTableLayoutPanel.ColumnCount = 1;
            rightTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            rightTableLayoutPanel.Controls.Add(tooltipsCheckbox, 0, 2);
            rightTableLayoutPanel.Controls.Add(realtimeCheckBox, 0, 3);
            rightTableLayoutPanel.Controls.Add(screenshotLabel, 0, 0);
            rightTableLayoutPanel.Controls.Add(screenshotListBox, 0, 1);
            rightTableLayoutPanel.Controls.Add(comradesCheckbox, 0, 4);
            rightTableLayoutPanel.Dock = DockStyle.Fill;
            rightTableLayoutPanel.Location = new Point(765, 3);
            rightTableLayoutPanel.MaximumSize = new Size(130, 0);
            rightTableLayoutPanel.Name = "rightTableLayoutPanel";
            rightTableLayoutPanel.RowCount = 5;
            rightTableLayoutPanel.RowStyles.Add(new RowStyle());
            rightTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            rightTableLayoutPanel.RowStyles.Add(new RowStyle());
            rightTableLayoutPanel.RowStyles.Add(new RowStyle());
            rightTableLayoutPanel.RowStyles.Add(new RowStyle());
            rightTableLayoutPanel.Size = new Size(130, 493);
            rightTableLayoutPanel.TabIndex = 19;
            // 
            // lowerTableLayoutPanel
            // 
            lowerTableLayoutPanel.ColumnCount = 3;
            lowerTableLayoutPanel.ColumnStyles.Add(new ColumnStyle());
            lowerTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            lowerTableLayoutPanel.ColumnStyles.Add(new ColumnStyle());
            lowerTableLayoutPanel.Controls.Add(saveGroupBox, 0, 0);
            lowerTableLayoutPanel.Controls.Add(folderGroupBox, 2, 0);
            lowerTableLayoutPanel.Controls.Add(saveAllProgressbar, 1, 0);
            lowerTableLayoutPanel.Dock = DockStyle.Fill;
            lowerTableLayoutPanel.Location = new Point(3, 440);
            lowerTableLayoutPanel.MaximumSize = new Size(0, 50);
            lowerTableLayoutPanel.Name = "lowerTableLayoutPanel";
            lowerTableLayoutPanel.RowCount = 1;
            lowerTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            lowerTableLayoutPanel.Size = new Size(750, 50);
            lowerTableLayoutPanel.TabIndex = 20;
            // 
            // leftTableLayoutPanel
            // 
            leftTableLayoutPanel.AutoSize = true;
            leftTableLayoutPanel.ColumnCount = 1;
            leftTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            leftTableLayoutPanel.Controls.Add(upperTableLayoutPanel, 0, 0);
            leftTableLayoutPanel.Controls.Add(lowerTableLayoutPanel, 0, 2);
            leftTableLayoutPanel.Controls.Add(previewPictureBox, 0, 1);
            leftTableLayoutPanel.Dock = DockStyle.Fill;
            leftTableLayoutPanel.Location = new Point(3, 3);
            leftTableLayoutPanel.Name = "leftTableLayoutPanel";
            leftTableLayoutPanel.RowCount = 3;
            leftTableLayoutPanel.RowStyles.Add(new RowStyle());
            leftTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            leftTableLayoutPanel.RowStyles.Add(new RowStyle());
            leftTableLayoutPanel.Size = new Size(756, 493);
            leftTableLayoutPanel.TabIndex = 21;
            // 
            // outerTableLayoutPanel
            // 
            outerTableLayoutPanel.AutoSize = true;
            outerTableLayoutPanel.ColumnCount = 2;
            outerTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            outerTableLayoutPanel.ColumnStyles.Add(new ColumnStyle());
            outerTableLayoutPanel.Controls.Add(leftTableLayoutPanel, 0, 0);
            outerTableLayoutPanel.Controls.Add(rightTableLayoutPanel, 1, 0);
            outerTableLayoutPanel.Dock = DockStyle.Fill;
            outerTableLayoutPanel.Location = new Point(0, 0);
            outerTableLayoutPanel.Name = "outerTableLayoutPanel";
            outerTableLayoutPanel.RowCount = 1;
            outerTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            outerTableLayoutPanel.Size = new Size(898, 499);
            outerTableLayoutPanel.TabIndex = 22;
            // 
            // mainWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(898, 499);
            Controls.Add(outerTableLayoutPanel);
            Font = new Font("Segoe UI Variable Text", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            MinimumSize = new Size(914, 538);
            Name = "mainWindow";
            Text = "Narod's FFXV Screenshot Grabber";
            FormClosing += mainWindow_FormClosing;
            ((System.ComponentModel.ISupportInitialize)previewPictureBox).EndInit();
            saveGroupBox.ResumeLayout(false);
            saveGroupBox.PerformLayout();
            folderGroupBox.ResumeLayout(false);
            folderGroupBox.PerformLayout();
            upperTableLayoutPanel.ResumeLayout(false);
            upperTableLayoutPanel.PerformLayout();
            rightTableLayoutPanel.ResumeLayout(false);
            rightTableLayoutPanel.PerformLayout();
            lowerTableLayoutPanel.ResumeLayout(false);
            lowerTableLayoutPanel.PerformLayout();
            leftTableLayoutPanel.ResumeLayout(false);
            leftTableLayoutPanel.PerformLayout();
            outerTableLayoutPanel.ResumeLayout(false);
            outerTableLayoutPanel.PerformLayout();
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
        private TableLayoutPanel upperTableLayoutPanel;
        private TableLayoutPanel rightTableLayoutPanel;
        private TableLayoutPanel lowerTableLayoutPanel;
        private TableLayoutPanel leftTableLayoutPanel;
        private TableLayoutPanel outerTableLayoutPanel;
        private CheckBox comradesCheckbox;
    }
}