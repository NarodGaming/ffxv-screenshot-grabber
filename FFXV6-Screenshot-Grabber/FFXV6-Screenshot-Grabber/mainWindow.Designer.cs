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
            components=new System.ComponentModel.Container();
            screenshotListBox=new ListBox();
            previewPictureBox=new PictureBox();
            previewLabel=new Label();
            expandLabel=new Label();
            screenshotLabel=new Label();
            saveAllProgressbar=new ProgressBar();
            saveOneBtn=new Button();
            saveAllBtn=new Button();
            selectFolderBtn=new Button();
            detectFolderBtn=new Button();
            authVerLabel=new Label();
            saveScreenshotDialog=new SaveFileDialog();
            folderDialog=new FolderBrowserDialog();
            updateChecker=new System.ComponentModel.BackgroundWorker();
            realtimeCheckBox=new CheckBox();
            helpTooltip=new ToolTip(components);
            saveAllTBtn=new Button();
            ((System.ComponentModel.ISupportInitialize)previewPictureBox).BeginInit();
            SuspendLayout();
            // 
            // screenshotListBox
            // 
            screenshotListBox.FormattingEnabled=true;
            screenshotListBox.ItemHeight=15;
            screenshotListBox.Location=new Point(648, 22);
            screenshotListBox.Name="screenshotListBox";
            screenshotListBox.Size=new Size(322, 364);
            screenshotListBox.TabIndex=0;
            screenshotListBox.SelectedIndexChanged+=screenshotListBox_SelectedIndexChanged;
            // 
            // previewPictureBox
            // 
            previewPictureBox.BackgroundImage=Properties.Resources._00001333;
            previewPictureBox.BackgroundImageLayout=ImageLayout.Zoom;
            previewPictureBox.Location=new Point(2, 22);
            previewPictureBox.Name="previewPictureBox";
            previewPictureBox.Size=new Size(640, 360);
            previewPictureBox.SizeMode=PictureBoxSizeMode.Zoom;
            previewPictureBox.TabIndex=1;
            previewPictureBox.TabStop=false;
            helpTooltip.SetToolTip(previewPictureBox, "Your image preview for the selected image will appear here.");
            previewPictureBox.Click+=previewPictureBox_Click;
            // 
            // previewLabel
            // 
            previewLabel.AutoSize=true;
            previewLabel.Font=new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            previewLabel.Location=new Point(2, 4);
            previewLabel.Name="previewLabel";
            previewLabel.Size=new Size(48, 15);
            previewLabel.TabIndex=2;
            previewLabel.Text="Preview";
            // 
            // expandLabel
            // 
            expandLabel.AutoSize=true;
            expandLabel.BackColor=SystemColors.Control;
            expandLabel.ForeColor=SystemColors.ControlDarkDark;
            expandLabel.Location=new Point(511, 4);
            expandLabel.Name="expandLabel";
            expandLabel.Size=new Size(131, 15);
            expandLabel.TabIndex=3;
            expandLabel.Text="(click image to expand)";
            helpTooltip.SetToolTip(expandLabel, "Click here to open a larger window with your screenshot.");
            // 
            // screenshotLabel
            // 
            screenshotLabel.AutoSize=true;
            screenshotLabel.Font=new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            screenshotLabel.Location=new Point(648, 4);
            screenshotLabel.Name="screenshotLabel";
            screenshotLabel.Size=new Size(119, 15);
            screenshotLabel.TabIndex=4;
            screenshotLabel.Text="Screenshots: 000000";
            helpTooltip.SetToolTip(screenshotLabel, "This is the number of screenshots shown in the list below.");
            // 
            // saveAllProgressbar
            // 
            saveAllProgressbar.BackColor=SystemColors.Control;
            saveAllProgressbar.Location=new Point(266, 386);
            saveAllProgressbar.Name="saveAllProgressbar";
            saveAllProgressbar.Size=new Size(376, 23);
            saveAllProgressbar.Step=1;
            saveAllProgressbar.TabIndex=5;
            helpTooltip.SetToolTip(saveAllProgressbar, "This progress bar shows the progress of the current 'Save All' task.");
            // 
            // saveOneBtn
            // 
            saveOneBtn.FlatStyle=FlatStyle.System;
            saveOneBtn.Location=new Point(2, 386);
            saveOneBtn.Name="saveOneBtn";
            saveOneBtn.Size=new Size(75, 23);
            saveOneBtn.TabIndex=1;
            saveOneBtn.Text="Save One";
            helpTooltip.SetToolTip(saveOneBtn, "This button saves the current screenshot to a location of your choosing.");
            saveOneBtn.UseVisualStyleBackColor=true;
            saveOneBtn.Click+=saveOneBtn_Click;
            // 
            // saveAllBtn
            // 
            saveAllBtn.FlatStyle=FlatStyle.System;
            saveAllBtn.Location=new Point(83, 386);
            saveAllBtn.Name="saveAllBtn";
            saveAllBtn.Size=new Size(75, 23);
            saveAllBtn.TabIndex=2;
            saveAllBtn.Text="Save All";
            helpTooltip.SetToolTip(saveAllBtn, "This button saves all screenshots in the list to a chosen location.");
            saveAllBtn.UseVisualStyleBackColor=true;
            saveAllBtn.Click+=saveAllBtn_Click;
            // 
            // selectFolderBtn
            // 
            selectFolderBtn.FlatStyle=FlatStyle.System;
            selectFolderBtn.Location=new Point(648, 388);
            selectFolderBtn.Name="selectFolderBtn";
            selectFolderBtn.Size=new Size(106, 23);
            selectFolderBtn.TabIndex=3;
            selectFolderBtn.Text="Select Folder";
            helpTooltip.SetToolTip(selectFolderBtn, "This button allows you to change the current screenshot directory.");
            selectFolderBtn.UseVisualStyleBackColor=true;
            selectFolderBtn.Click+=selectFolderBtn_Click;
            // 
            // detectFolderBtn
            // 
            detectFolderBtn.FlatStyle=FlatStyle.System;
            detectFolderBtn.Location=new Point(760, 388);
            detectFolderBtn.Name="detectFolderBtn";
            detectFolderBtn.Size=new Size(106, 23);
            detectFolderBtn.TabIndex=4;
            detectFolderBtn.Text="Detect Folder";
            helpTooltip.SetToolTip(detectFolderBtn, "This button attempts to automatically locate your screenshot folder.\r\n\r\nTypically this is \"My Games/FINAL FANTASY XV/Steam/.../savestorage/snapshot\"");
            detectFolderBtn.UseVisualStyleBackColor=true;
            detectFolderBtn.Click+=detectFolderBtn_Click;
            // 
            // authVerLabel
            // 
            authVerLabel.AutoSize=true;
            authVerLabel.Location=new Point(872, 392);
            authVerLabel.Name="authVerLabel";
            authVerLabel.Size=new Size(98, 15);
            authVerLabel.TabIndex=10;
            authVerLabel.Text="by Narod (V1.2.0)";
            helpTooltip.SetToolTip(authVerLabel, "Narod's FFXV Screenshot Grabber.\r\n\r\nby Narod");
            // 
            // saveScreenshotDialog
            // 
            saveScreenshotDialog.DefaultExt="jpg";
            saveScreenshotDialog.Filter="JPG file|*.jpg";
            saveScreenshotDialog.RestoreDirectory=true;
            saveScreenshotDialog.Title="Choose where to save this screenshot...";
            // 
            // folderDialog
            // 
            folderDialog.Description="Please select a folder...";
            // 
            // updateChecker
            // 
            updateChecker.DoWork+=updateChecker_DoWork;
            updateChecker.RunWorkerCompleted+=updateChecker_RunWorkerCompleted;
            // 
            // realtimeCheckBox
            // 
            realtimeCheckBox.AutoSize=true;
            realtimeCheckBox.Cursor=Cursors.Help;
            realtimeCheckBox.Location=new Point(864, 3);
            realtimeCheckBox.Name="realtimeCheckBox";
            realtimeCheckBox.Size=new Size(106, 19);
            realtimeCheckBox.TabIndex=11;
            realtimeCheckBox.Text="Realtime Mode";
            helpTooltip.SetToolTip(realtimeCheckBox, "Realtime mode allows the utility to automatically save screenshots as the game creates them.");
            realtimeCheckBox.UseVisualStyleBackColor=true;
            realtimeCheckBox.CheckedChanged+=realtimeCheckBox_CheckedChanged;
            // 
            // helpTooltip
            // 
            helpTooltip.ToolTipIcon=ToolTipIcon.Info;
            helpTooltip.ToolTipTitle="Help";
            // 
            // saveAllTBtn
            // 
            saveAllTBtn.FlatStyle=FlatStyle.System;
            saveAllTBtn.Location=new Point(164, 386);
            saveAllTBtn.Name="saveAllTBtn";
            saveAllTBtn.Size=new Size(96, 23);
            saveAllTBtn.TabIndex=12;
            saveAllTBtn.Text="Save All Turbo";
            helpTooltip.SetToolTip(saveAllTBtn, "This button saves all screenshots in the list to a chosen location.\r\n\r\nIt does this in \"Turbo\" mode, which speeds up the conversion\r\nsignificantly (depends on PC speed, can be up to ~100x).");
            saveAllTBtn.UseVisualStyleBackColor=true;
            saveAllTBtn.Click+=saveAllTBtn_Click;
            // 
            // mainWindow
            // 
            AutoScaleDimensions=new SizeF(7F, 15F);
            AutoScaleMode=AutoScaleMode.Font;
            ClientSize=new Size(972, 412);
            Controls.Add(saveAllTBtn);
            Controls.Add(realtimeCheckBox);
            Controls.Add(authVerLabel);
            Controls.Add(detectFolderBtn);
            Controls.Add(selectFolderBtn);
            Controls.Add(saveAllBtn);
            Controls.Add(saveOneBtn);
            Controls.Add(saveAllProgressbar);
            Controls.Add(screenshotLabel);
            Controls.Add(expandLabel);
            Controls.Add(previewLabel);
            Controls.Add(previewPictureBox);
            Controls.Add(screenshotListBox);
            FormBorderStyle=FormBorderStyle.FixedSingle;
            MaximizeBox=false;
            Name="mainWindow";
            Text="Narod's FFXV Screenshot Grabber";
            ((System.ComponentModel.ISupportInitialize)previewPictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
        private Button saveAllTBtn;
    }
}