﻿namespace FFXV6_Screenshot_Grabber
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
            ((System.ComponentModel.ISupportInitialize)previewPictureBox).BeginInit();
            saveGroupBox.SuspendLayout();
            folderGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // screenshotListBox
            // 
            screenshotListBox.BorderStyle = BorderStyle.FixedSingle;
            screenshotListBox.FormattingEnabled = true;
            screenshotListBox.ItemHeight = 16;
            screenshotListBox.Location = new Point(773, 23);
            screenshotListBox.Margin = new Padding(4, 3, 4, 3);
            screenshotListBox.Name = "screenshotListBox";
            screenshotListBox.Size = new Size(119, 434);
            screenshotListBox.TabIndex = 0;
            screenshotListBox.SelectedIndexChanged += screenshotListBox_SelectedIndexChanged;
            // 
            // previewPictureBox
            // 
            previewPictureBox.BackgroundImage = Properties.Resources.default_preview;
            previewPictureBox.BackgroundImageLayout = ImageLayout.Zoom;
            previewPictureBox.Location = new Point(2, 23);
            previewPictureBox.Margin = new Padding(4, 3, 4, 3);
            previewPictureBox.Name = "previewPictureBox";
            previewPictureBox.Size = new Size(768, 432);
            previewPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            previewPictureBox.TabIndex = 1;
            previewPictureBox.TabStop = false;
            helpTooltip.SetToolTip(previewPictureBox, "Your image preview for the selected image will appear here.");
            previewPictureBox.Click += previewPictureBox_Click;
            // 
            // previewLabel
            // 
            previewLabel.AutoSize = true;
            previewLabel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            previewLabel.Location = new Point(2, 4);
            previewLabel.Margin = new Padding(4, 0, 4, 0);
            previewLabel.Name = "previewLabel";
            previewLabel.Size = new Size(175, 15);
            previewLabel.TabIndex = 2;
            previewLabel.Text = "Preview - click image to expand";
            // 
            // screenshotLabel
            // 
            screenshotLabel.AutoSize = true;
            screenshotLabel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            screenshotLabel.Location = new Point(776, 5);
            screenshotLabel.Margin = new Padding(4, 0, 4, 0);
            screenshotLabel.Name = "screenshotLabel";
            screenshotLabel.Size = new Size(119, 15);
            screenshotLabel.TabIndex = 4;
            screenshotLabel.Text = "Screenshots: 000000";
            helpTooltip.SetToolTip(screenshotLabel, "This is the number of screenshots shown in the list below.");
            // 
            // saveAllProgressbar
            // 
            saveAllProgressbar.BackColor = SystemColors.Control;
            saveAllProgressbar.Location = new Point(167, 456);
            saveAllProgressbar.Margin = new Padding(4, 3, 4, 3);
            saveAllProgressbar.Name = "saveAllProgressbar";
            saveAllProgressbar.Size = new Size(475, 42);
            saveAllProgressbar.Step = 1;
            saveAllProgressbar.TabIndex = 5;
            helpTooltip.SetToolTip(saveAllProgressbar, "This progress bar shows the progress of the current 'Save All' task.");
            // 
            // saveOneBtn
            // 
            saveOneBtn.FlatStyle = FlatStyle.System;
            saveOneBtn.Location = new Point(3, 17);
            saveOneBtn.Margin = new Padding(4, 3, 4, 3);
            saveOneBtn.Name = "saveOneBtn";
            saveOneBtn.Size = new Size(40, 25);
            saveOneBtn.TabIndex = 1;
            saveOneBtn.Text = "One";
            helpTooltip.SetToolTip(saveOneBtn, "This button saves the current screenshot to a location of your choosing.");
            saveOneBtn.UseVisualStyleBackColor = true;
            saveOneBtn.Click += saveOneBtn_Click;
            // 
            // saveAllBtn
            // 
            saveAllBtn.FlatStyle = FlatStyle.System;
            saveAllBtn.Location = new Point(42, 17);
            saveAllBtn.Margin = new Padding(4, 3, 4, 3);
            saveAllBtn.Name = "saveAllBtn";
            saveAllBtn.Size = new Size(40, 25);
            saveAllBtn.TabIndex = 2;
            saveAllBtn.Text = "All";
            helpTooltip.SetToolTip(saveAllBtn, "This button saves all screenshots in the list to a chosen location.\r\n\r\nCompared to 'Turbo' mode, it's slower but shows a preview\r\nof the images as they are saved.");
            saveAllBtn.UseVisualStyleBackColor = true;
            saveAllBtn.Click += saveAllBtn_Click;
            // 
            // selectFolderBtn
            // 
            selectFolderBtn.FlatStyle = FlatStyle.System;
            selectFolderBtn.Location = new Point(3, 17);
            selectFolderBtn.Margin = new Padding(4, 3, 4, 3);
            selectFolderBtn.Name = "selectFolderBtn";
            selectFolderBtn.Size = new Size(55, 25);
            selectFolderBtn.TabIndex = 3;
            selectFolderBtn.Text = "Select";
            helpTooltip.SetToolTip(selectFolderBtn, "This button allows you to change the current screenshot directory.");
            selectFolderBtn.UseVisualStyleBackColor = true;
            selectFolderBtn.Click += selectFolderBtn_Click;
            // 
            // detectFolderBtn
            // 
            detectFolderBtn.FlatStyle = FlatStyle.System;
            detectFolderBtn.Location = new Point(57, 17);
            detectFolderBtn.Margin = new Padding(4, 3, 4, 3);
            detectFolderBtn.Name = "detectFolderBtn";
            detectFolderBtn.Size = new Size(55, 25);
            detectFolderBtn.TabIndex = 4;
            detectFolderBtn.Text = "Detect";
            helpTooltip.SetToolTip(detectFolderBtn, "This button attempts to automatically locate your screenshot folder.\r\n\r\nTypically this is \"My Games/FINAL FANTASY XV/Steam/.../savestorage/snapshot\"");
            detectFolderBtn.UseVisualStyleBackColor = true;
            detectFolderBtn.Click += detectFolderBtn_Click;
            // 
            // authVerLabel
            // 
            authVerLabel.AutoSize = true;
            authVerLabel.Font = new Font("Segoe UI Variable Text", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            authVerLabel.Location = new Point(679, 0);
            authVerLabel.Margin = new Padding(4, 0, 4, 0);
            authVerLabel.Name = "authVerLabel";
            authVerLabel.Size = new Size(93, 15);
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
            realtimeCheckBox.Location = new Point(773, 480);
            realtimeCheckBox.Margin = new Padding(4, 3, 4, 3);
            realtimeCheckBox.Name = "realtimeCheckBox";
            realtimeCheckBox.Size = new Size(105, 20);
            realtimeCheckBox.TabIndex = 11;
            realtimeCheckBox.Text = "Realtime Mode";
            helpTooltip.SetToolTip(realtimeCheckBox, "Realtime mode allows the utility to automatically save screenshots as the game creates them.");
            realtimeCheckBox.UseVisualStyleBackColor = true;
            realtimeCheckBox.CheckedChanged += realtimeCheckBox_CheckedChanged;
            // 
            // helpTooltip
            // 
            helpTooltip.ToolTipIcon = ToolTipIcon.Info;
            helpTooltip.ToolTipTitle = "Help";
            // 
            // saveAllTBtn
            // 
            saveAllTBtn.FlatStyle = FlatStyle.System;
            saveAllTBtn.Location = new Point(81, 17);
            saveAllTBtn.Margin = new Padding(4, 3, 4, 3);
            saveAllTBtn.Name = "saveAllTBtn";
            saveAllTBtn.Size = new Size(73, 25);
            saveAllTBtn.TabIndex = 12;
            saveAllTBtn.Text = "All (Turbo)";
            helpTooltip.SetToolTip(saveAllTBtn, "This button saves all screenshots in the list to a chosen location.\r\n\r\nIt does this in \"Turbo\" mode, which is very fast but doesn't\r\nshow previews like the non-Turbo mode does.");
            saveAllTBtn.UseVisualStyleBackColor = true;
            saveAllTBtn.Click += saveAllTBtn_Click;
            // 
            // saveGroupBox
            // 
            saveGroupBox.Controls.Add(saveOneBtn);
            saveGroupBox.Controls.Add(saveAllTBtn);
            saveGroupBox.Controls.Add(saveAllBtn);
            saveGroupBox.Location = new Point(2, 452);
            saveGroupBox.Name = "saveGroupBox";
            saveGroupBox.Size = new Size(158, 46);
            saveGroupBox.TabIndex = 13;
            saveGroupBox.TabStop = false;
            saveGroupBox.Text = "Save";
            // 
            // folderGroupBox
            // 
            folderGroupBox.Controls.Add(selectFolderBtn);
            folderGroupBox.Controls.Add(detectFolderBtn);
            folderGroupBox.Controls.Add(folderRealtimeWarning);
            folderGroupBox.Location = new Point(649, 453);
            folderGroupBox.Name = "folderGroupBox";
            folderGroupBox.Size = new Size(117, 45);
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
            screenshotTakenLabel.Location = new Point(335, 3);
            screenshotTakenLabel.Name = "screenshotTakenLabel";
            screenshotTakenLabel.Size = new Size(212, 16);
            screenshotTakenLabel.TabIndex = 15;
            screenshotTakenLabel.Text = "Snapshot Taken on (locale date format)";
            // 
            // tooltipsCheckbox
            // 
            tooltipsCheckbox.AutoSize = true;
            tooltipsCheckbox.Checked = true;
            tooltipsCheckbox.CheckState = CheckState.Checked;
            tooltipsCheckbox.Location = new Point(773, 458);
            tooltipsCheckbox.Name = "tooltipsCheckbox";
            tooltipsCheckbox.Size = new Size(105, 20);
            tooltipsCheckbox.TabIndex = 16;
            tooltipsCheckbox.Text = "Enable Tooltips";
            tooltipsCheckbox.UseVisualStyleBackColor = true;
            tooltipsCheckbox.CheckedChanged += tooltipsCheckbox_CheckedChanged;
            // 
            // mainWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(898, 499);
            Controls.Add(tooltipsCheckbox);
            Controls.Add(screenshotTakenLabel);
            Controls.Add(previewPictureBox);
            Controls.Add(folderGroupBox);
            Controls.Add(saveGroupBox);
            Controls.Add(realtimeCheckBox);
            Controls.Add(authVerLabel);
            Controls.Add(saveAllProgressbar);
            Controls.Add(screenshotLabel);
            Controls.Add(previewLabel);
            Controls.Add(screenshotListBox);
            Font = new Font("Segoe UI Variable Text", 9F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "mainWindow";
            Text = "Narod's FFXV Screenshot Grabber";
            ((System.ComponentModel.ISupportInitialize)previewPictureBox).EndInit();
            saveGroupBox.ResumeLayout(false);
            folderGroupBox.ResumeLayout(false);
            folderGroupBox.PerformLayout();
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
    }
}