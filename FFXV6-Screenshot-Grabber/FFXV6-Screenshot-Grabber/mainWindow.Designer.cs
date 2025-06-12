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
            resources.ApplyResources(screenshotListBox, "screenshotListBox");
            screenshotListBox.FormattingEnabled = true;
            screenshotListBox.Name = "screenshotListBox";
            screenshotListBox.SelectedIndexChanged += screenshotListBox_SelectedIndexChanged;
            // 
            // previewPictureBox
            // 
            previewPictureBox.BackgroundImage = Properties.Resources.default_preview;
            resources.ApplyResources(previewPictureBox, "previewPictureBox");
            previewPictureBox.Name = "previewPictureBox";
            previewPictureBox.TabStop = false;
            helpTooltip.SetToolTip(previewPictureBox, resources.GetString("previewPictureBox.ToolTip"));
            previewPictureBox.Click += previewPictureBox_Click;
            // 
            // previewLabel
            // 
            resources.ApplyResources(previewLabel, "previewLabel");
            previewLabel.Name = "previewLabel";
            // 
            // screenshotLabel
            // 
            resources.ApplyResources(screenshotLabel, "screenshotLabel");
            screenshotLabel.Name = "screenshotLabel";
            helpTooltip.SetToolTip(screenshotLabel, resources.GetString("screenshotLabel.ToolTip"));
            // 
            // saveAllProgressbar
            // 
            saveAllProgressbar.BackColor = SystemColors.Control;
            resources.ApplyResources(saveAllProgressbar, "saveAllProgressbar");
            saveAllProgressbar.Name = "saveAllProgressbar";
            saveAllProgressbar.Step = 1;
            helpTooltip.SetToolTip(saveAllProgressbar, resources.GetString("saveAllProgressbar.ToolTip"));
            // 
            // saveOneBtn
            // 
            resources.ApplyResources(saveOneBtn, "saveOneBtn");
            saveOneBtn.Name = "saveOneBtn";
            helpTooltip.SetToolTip(saveOneBtn, resources.GetString("saveOneBtn.ToolTip"));
            saveOneBtn.UseVisualStyleBackColor = true;
            saveOneBtn.Click += saveOneBtn_Click;
            // 
            // saveAllBtn
            // 
            resources.ApplyResources(saveAllBtn, "saveAllBtn");
            saveAllBtn.Name = "saveAllBtn";
            helpTooltip.SetToolTip(saveAllBtn, resources.GetString("saveAllBtn.ToolTip"));
            saveAllBtn.UseVisualStyleBackColor = true;
            saveAllBtn.Click += saveAllBtn_Click;
            // 
            // selectFolderBtn
            // 
            resources.ApplyResources(selectFolderBtn, "selectFolderBtn");
            selectFolderBtn.Name = "selectFolderBtn";
            helpTooltip.SetToolTip(selectFolderBtn, resources.GetString("selectFolderBtn.ToolTip"));
            selectFolderBtn.UseVisualStyleBackColor = true;
            selectFolderBtn.Click += selectFolderBtn_Click;
            // 
            // detectFolderBtn
            // 
            resources.ApplyResources(detectFolderBtn, "detectFolderBtn");
            detectFolderBtn.Name = "detectFolderBtn";
            helpTooltip.SetToolTip(detectFolderBtn, resources.GetString("detectFolderBtn.ToolTip"));
            detectFolderBtn.UseVisualStyleBackColor = true;
            detectFolderBtn.Click += detectFolderBtn_Click;
            // 
            // authVerLabel
            // 
            resources.ApplyResources(authVerLabel, "authVerLabel");
            authVerLabel.Name = "authVerLabel";
            helpTooltip.SetToolTip(authVerLabel, resources.GetString("authVerLabel.ToolTip"));
            // 
            // saveScreenshotDialog
            // 
            saveScreenshotDialog.DefaultExt = "jpg";
            resources.ApplyResources(saveScreenshotDialog, "saveScreenshotDialog");
            saveScreenshotDialog.RestoreDirectory = true;
            // 
            // folderDialog
            // 
            resources.ApplyResources(folderDialog, "folderDialog");
            // 
            // updateChecker
            // 
            updateChecker.DoWork += updateChecker_DoWork;
            updateChecker.RunWorkerCompleted += updateChecker_RunWorkerCompleted;
            // 
            // realtimeCheckBox
            // 
            resources.ApplyResources(realtimeCheckBox, "realtimeCheckBox");
            realtimeCheckBox.Name = "realtimeCheckBox";
            helpTooltip.SetToolTip(realtimeCheckBox, resources.GetString("realtimeCheckBox.ToolTip"));
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
            resources.ApplyResources(saveAllTBtn, "saveAllTBtn");
            saveAllTBtn.Name = "saveAllTBtn";
            helpTooltip.SetToolTip(saveAllTBtn, resources.GetString("saveAllTBtn.ToolTip"));
            saveAllTBtn.UseVisualStyleBackColor = true;
            saveAllTBtn.Click += saveAllTBtn_Click;
            // 
            // comradesCheckbox
            // 
            resources.ApplyResources(comradesCheckbox, "comradesCheckbox");
            comradesCheckbox.Name = "comradesCheckbox";
            helpTooltip.SetToolTip(comradesCheckbox, resources.GetString("comradesCheckbox.ToolTip"));
            comradesCheckbox.UseVisualStyleBackColor = true;
            comradesCheckbox.CheckedChanged += comradesCheckbox_CheckedChanged;
            comradesCheckbox.Paint += checkboxPainter;
            // 
            // saveGroupBox
            // 
            resources.ApplyResources(saveGroupBox, "saveGroupBox");
            saveGroupBox.Controls.Add(saveAllTBtn);
            saveGroupBox.Controls.Add(saveAllBtn);
            saveGroupBox.Controls.Add(saveOneBtn);
            saveGroupBox.Name = "saveGroupBox";
            saveGroupBox.TabStop = false;
            // 
            // folderGroupBox
            // 
            resources.ApplyResources(folderGroupBox, "folderGroupBox");
            folderGroupBox.Controls.Add(selectFolderBtn);
            folderGroupBox.Controls.Add(detectFolderBtn);
            folderGroupBox.Controls.Add(folderRealtimeWarning);
            folderGroupBox.Name = "folderGroupBox";
            folderGroupBox.TabStop = false;
            // 
            // folderRealtimeWarning
            // 
            resources.ApplyResources(folderRealtimeWarning, "folderRealtimeWarning");
            folderRealtimeWarning.Name = "folderRealtimeWarning";
            // 
            // screenshotTakenLabel
            // 
            resources.ApplyResources(screenshotTakenLabel, "screenshotTakenLabel");
            screenshotTakenLabel.Name = "screenshotTakenLabel";
            // 
            // tooltipsCheckbox
            // 
            resources.ApplyResources(tooltipsCheckbox, "tooltipsCheckbox");
            tooltipsCheckbox.Checked = true;
            tooltipsCheckbox.CheckState = CheckState.Checked;
            tooltipsCheckbox.Name = "tooltipsCheckbox";
            tooltipsCheckbox.UseVisualStyleBackColor = true;
            tooltipsCheckbox.CheckedChanged += tooltipsCheckbox_CheckedChanged;
            tooltipsCheckbox.Paint += checkboxPainter;
            // 
            // upperTableLayoutPanel
            // 
            resources.ApplyResources(upperTableLayoutPanel, "upperTableLayoutPanel");
            upperTableLayoutPanel.Controls.Add(previewLabel, 0, 0);
            upperTableLayoutPanel.Controls.Add(screenshotTakenLabel, 1, 0);
            upperTableLayoutPanel.Controls.Add(authVerLabel, 2, 0);
            upperTableLayoutPanel.GrowStyle = TableLayoutPanelGrowStyle.AddColumns;
            upperTableLayoutPanel.Name = "upperTableLayoutPanel";
            // 
            // rightTableLayoutPanel
            // 
            resources.ApplyResources(rightTableLayoutPanel, "rightTableLayoutPanel");
            rightTableLayoutPanel.Controls.Add(tooltipsCheckbox, 0, 2);
            rightTableLayoutPanel.Controls.Add(realtimeCheckBox, 0, 3);
            rightTableLayoutPanel.Controls.Add(screenshotLabel, 0, 0);
            rightTableLayoutPanel.Controls.Add(screenshotListBox, 0, 1);
            rightTableLayoutPanel.Controls.Add(comradesCheckbox, 0, 4);
            rightTableLayoutPanel.Name = "rightTableLayoutPanel";
            // 
            // lowerTableLayoutPanel
            // 
            resources.ApplyResources(lowerTableLayoutPanel, "lowerTableLayoutPanel");
            lowerTableLayoutPanel.Controls.Add(saveGroupBox, 0, 0);
            lowerTableLayoutPanel.Controls.Add(folderGroupBox, 2, 0);
            lowerTableLayoutPanel.Controls.Add(saveAllProgressbar, 1, 0);
            lowerTableLayoutPanel.Name = "lowerTableLayoutPanel";
            // 
            // leftTableLayoutPanel
            // 
            resources.ApplyResources(leftTableLayoutPanel, "leftTableLayoutPanel");
            leftTableLayoutPanel.Controls.Add(upperTableLayoutPanel, 0, 0);
            leftTableLayoutPanel.Controls.Add(lowerTableLayoutPanel, 0, 2);
            leftTableLayoutPanel.Controls.Add(previewPictureBox, 0, 1);
            leftTableLayoutPanel.Name = "leftTableLayoutPanel";
            // 
            // outerTableLayoutPanel
            // 
            resources.ApplyResources(outerTableLayoutPanel, "outerTableLayoutPanel");
            outerTableLayoutPanel.Controls.Add(leftTableLayoutPanel, 0, 0);
            outerTableLayoutPanel.Controls.Add(rightTableLayoutPanel, 1, 0);
            outerTableLayoutPanel.Name = "outerTableLayoutPanel";
            // 
            // mainWindow
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(outerTableLayoutPanel);
            Name = "mainWindow";
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