using FFXV6_Screenshot_Grabber.Locale.Dialogs;
using FFXV6_Screenshot_Grabber.Locale.DynamicLabels;
using Microsoft.VisualBasic;
using Microsoft.Win32;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;

namespace FFXV6_Screenshot_Grabber
{
    /// <summary>
    /// The Main GUI window of the utility
    /// </summary>
    public partial class mainWindow : Form
    {
        readonly imageExpander previewWindow = new(); // create reference of imageExpander (the resizeable preview window)
        Image? currentImage; // variable to store current preview image
        string folderLocation; // variable to store folder location of screenshots
        bool isUpdateAvailable; // variable to store if update is required or not
        bool isComrades = false; // variable to store if we're in comrades mode or not

        RealtimeHandler? realtimeObject; // object to handle realtime screenshots

        OperatingSystem platform = OperatingSystem.Unknown; // set to Unknown, main function will set this to the correct platform

        /// <summary>
        /// Handles the startup events associated with the utility (e.g. update checks, OS detection, etc.)
        /// </summary>
        public mainWindow()
        {

            InitializeComponent();

            platform = OSDetector.detectOS(); // run the OS detector function, this will set the platform variable to the correct platform

            folderLocation = FolderDetector.detectFolder(platform, isComrades); // look for the screenshot folder in the default location

            authVerLabel.Text = $"{DynamicLabels.Main_AuthorLabel} (V{Assembly.GetExecutingAssembly().GetName().Version})"; // set the version label text to show the current version of the program

            scanScreenshots(); // scan for screenshots

            updateChecker.RunWorkerAsync(); // run the update checker

            DarkMode.SetupDarkMode(this); // run darkmode configuration, passing this form as an object

            screenshotTakenLabel.Text = ""; // blank out this label, it will be set when selecting a screenshot

            helpTooltip.SetToolTip(authVerLabel, $"{DynamicLabels.Main_UpdateAvailable} {isUpdateAvailable}{Environment.NewLine}{DynamicLabels.Main_Platform} {platform}{Environment.NewLine}{DynamicLabels.Main_Commit} {Application.ProductVersion.Split("+")[1]}{Environment.NewLine}{Environment.NewLine}{DynamicLabels.Main_FFXVSG} (v{Assembly.GetExecutingAssembly().GetName().Version})");
        }

        /// <summary>
        /// Appends the full path to the selected screenshot in the listbox item
        /// </summary>
        /// <returns>Returns the full path of any .ss file selected in the listbox</returns>
        private string returnFullPath() // returns full path of listbox item selected
        {
            if (screenshotListBox.SelectedIndex == -1) { return ""; }; // if there is no selected listbox item, return a blank string
            return folderLocation + screenshotListBox.SelectedItem.ToString() + ".ss"; // otherwise, concat the folder location var with the listbox selected item string and return it
        }

        /// <summary>
        /// Called by the realtime handler when a new screenshot is detected
        /// </summary>
        /// <param name="itemToAdd">The name of the screenshot file (not full path) created</param>
        public void addToListBox(string itemToAdd) // add a single item to the screenshot list box
        {
            screenshotListBox.Items.Add(itemToAdd);
            updateListBoxCounter();
        }

        /// <summary>
        /// Used to add multiple items to the screenshot list box, such as when first scanning for screenshots
        /// </summary>
        /// <param name="itemsToAdd">Contains multiple items (not full path) to be added</param>
        public void addToListBox(IEnumerable<String> itemsToAdd) // add an enum of strings to the screenshot list box
        {
            foreach (string ssFile in itemsToAdd) // for each file found in above line
            {
                screenshotListBox.Items.Add(ssFile); // add the filename to the listbox
            }

            updateListBoxCounter();
        }

        /// <summary>
        /// Called by realtime handler when a screenshot is deleted
        /// </summary>
        /// <param name="itemToRemove">The name of the screenshot file (not full path) created</param>
        public void removeFromListBox(string itemToRemove) // remove a specific string from the screenshot list box
        {
            if (screenshotListBox.Items.Contains(itemToRemove))
            {
                screenshotListBox.Items.Remove(itemToRemove);
                updateListBoxCounter();
            }
        }

        /// <summary>
        /// Updates the number of screenshot counter above the listbox
        /// </summary>
        private void updateListBoxCounter() // update the counter with how many items are in the screenshot list box
        {
            screenshotLabel.Text = $"{DynamicLabels.Main_Screenshots} {screenshotListBox.Items.Count}"; // change the label to show the total amount of detected screenshot files
        }

        /// <summary>
        /// Resets the window, clearing the listbox, preview image, etc. - useful when switching screenshot folder
        /// </summary>
        private void resetWindow()
        {
            screenshotListBox.Items.Clear(); // clear all items currently in the listbox
            currentImage?.Dispose(); // if there is a current image set, dispose of it
            if (previewPictureBox.BackgroundImage != null) { previewPictureBox.BackgroundImage = Properties.Resources.default_preview; } // if the preview image is set, unset it
            previewWindow.Hide(); // if the preview window is open, this will hide it (as theres no image to display right now)
            screenshotTakenLabel.Text = ""; // blank out this label, it will be set when selecting a screenshot
            updateListBoxCounter(); // updates the counter for how many screenshots are in the listbox
        }

        /// <summary>
        /// Scans the screenshot folder for screenshots, and adds them to the listbox
        /// </summary>
        private void scanScreenshots() // scans for all screenshots in folder, runs at boot, or when screenshot folder has changed
        {
            resetWindow(); // reset the window (clears listbox, preview image, etc.)

            IEnumerable<String> ssFiles = Directory.GetFiles(folderLocation, "*.ss", SearchOption.TopDirectoryOnly).Select(nm => Path.GetFileNameWithoutExtension(nm)); // get all files ending with ".ss" only in the current directory, linq used to get just filename, not full path
            addToListBox(ssFiles);
        }

        /// <summary>
        /// Updates the UI with the new screenshot preview when the user selects a new screenshot
        /// </summary>
        private void screenshotListBox_SelectedIndexChanged(object sender, EventArgs e) // run when the user selects a new screenshot to preview (and then potentially save)
        {
            if (screenshotListBox.SelectedIndex == -1) // if the selected item has been unset
            {
                return; // then theres nothing to show, return
            }
            currentImage = ScreenshotWriter.returnImageScreenshot(returnFullPath()); // set current image to the image that was just selected
            previewPictureBox.BackgroundImage = currentImage; // set up the preview image to this new current image
            previewWindow.retrieveScreenshot(currentImage); // pass the new preview image to the preview window
            screenshotTakenLabel.Text = $"{DynamicLabels.Main_SnapshotTakenOn} {File.GetCreationTime(returnFullPath())}";
        }

        /// <summary>
        /// Opens a <see cref="imageExpander"/> window with the current preview image
        /// </summary>
        private void previewPictureBox_Click(object sender, EventArgs e) // run when the user clicks the preview image (to 'expand' it)
        {
            MouseEventArgs mouseEvent = (MouseEventArgs)e;
            if (screenshotListBox.SelectedIndex == -1) // if the preview image is not set
            {
                MessageBox.Show(Dialogs.Body_Warn_SelectPreviewScreenshot, Dialogs.Title_Warn_SelectPreviewScreenshot, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return; // then theres nothing to show, return
            }
            if (mouseEvent.Button == MouseButtons.Right)
            {
                Clipboard.SetImage(currentImage);
                return;
            }
            if (platform == OperatingSystem.Windows || platform == OperatingSystem.LegacyWindows) // if we're on Windows, open the default image viewer instead
            {
                // write the image to disk, then open it with the default image viewer
                string tempPath = Path.GetTempPath() + $"\\NFFXVSG_{DynamicLabels.Main_Temp}";
                Directory.CreateDirectory(tempPath);
                tempPath += $"\\{screenshotListBox.SelectedItem}_{DynamicLabels.Main_Temp}.jpg";
                ScreenshotWriter.writeScreenshot(returnFullPath(), tempPath);
                Process p = new Process();
                p.StartInfo = new ProcessStartInfo
                {
                    FileName = tempPath,
                    UseShellExecute = true,
                    CreateNoWindow = true
                };
                p.Start();
            }
            else
            {
                previewWindow.Show(); // show the preview window (screenshotListBox_SelectedIndexChanged always passes screenshot whether the preview window is visible or not anyway)
            }
        }

        /// <summary>
        /// Handles the save dialog for save, save all and save all turbo
        /// </summary>
        /// <param name="isAllSave"><c>True</c> if a directory save dialog should be used (Save All / Save All Turbo), <c>False</c> if a single save dialog should be used (Save One)</param>
        /// <returns><c>True</c> if a directory has been selected and exists, <c>False</c> if no folder was selected, or selected folder doesn't exist</returns>
        private bool showSaveDialog(bool isAllSave) // function which runs the shared code between save, save all and save all turbo
        {
            saveAllProgressbar.Value = 0; // reset the progressbar (not used for saving single file anyway)
            saveScreenshotDialog.FileName = ""; // reset any previous dialog prompts that may have shown before
            if (screenshotListBox.SelectedIndex == -1 && !isAllSave)
            {
                MessageBox.Show(Dialogs.Body_Error_UnableToSaveSingle, Dialogs.Title_Error_UnableToSaveSingle);
                return false; // if there's no selected image, and save one was chosen, return false
            }
            else if (screenshotListBox.Items.Count == 0 && isAllSave)
            {
                MessageBox.Show(Dialogs.Body_Error_UnableToSaveMulti, Dialogs.Title_Error_UnableToSaveMulti);
                return false; // if save all was chosen, but there's no items to save, return false
            }
            if (isAllSave)
            {
                folderDialog.ShowDialog();
                return string.IsNullOrEmpty(folderDialog.SelectedPath) == false; // if the folder name was not set (aka user cancelled dialog), return false
            }
            else
            {
                saveScreenshotDialog.ShowDialog();
                return saveScreenshotDialog.FileName != ""; // if the file name was not set (aka user cancelled dialog), return false
            }
        }

        /// <summary>
        /// Handles saving the screenshot selected in the listbox
        /// </summary>
        private void saveOneBtn_Click(object sender, EventArgs e) // run when the user clicks 'Save One'
        {
            bool wasSuccessful = showSaveDialog(false);

            if (!wasSuccessful)
            {
                return; // some error has occurred
            }

            string newPath = saveScreenshotDialog.FileName; // set the path of the file to save to the users preference as chosen by the dialog prompt
            ScreenshotWriter.writeScreenshot(returnFullPath(), newPath); // write the file to disk
        }

        /// <summary>
        /// Handles saving all screenshots in the listbox
        /// </summary>
        private void saveAllBtn_Click(object sender, EventArgs e) // run when the user clicks 'Save All'
        {
            bool wasSuccessful = showSaveDialog(true);

            if (!wasSuccessful)
            {
                return;
            }

            screenshotListBox.Enabled = false; // disable the listbox so no new images can be selected, as this could cause issues.

            string newPath = folderDialog.SelectedPath + "\\"; // set the path to save the files to, as per the users wishes
            saveAllProgressbar.Maximum = screenshotListBox.Items.Count; // set the maximum value of the progressbar to the number of screenshots to save. minimum is always 0 and step is 1.
            saveAllProgressbar.Visible = true; // show the progressbar, as it was hidden before

            foreach (string listBoxItem in screenshotListBox.Items) // for each listbox item (screenshot) in listbox (total screenshots)
            {
                string fileName = newPath + listBoxItem + ".jpg"; // gets a full file path to save the new ss to. e.g. listbox may say '00001.ss', this would change it to 'C:\screenshotsaves\00001.jpg' (if folder specified was 'C:\screenshotsaves')
                currentImage = ScreenshotWriter.writeScreenshotFromAll(folderLocation + listBoxItem + ".ss", fileName); // write the screenshot to disk, and also retrieve a preview copy of this image
                saveAllProgressbar.PerformStep(); // increment the progress bar by 1
                previewPictureBox.BackgroundImage = currentImage; // update the preview image
                Application.DoEvents(); // do events, this slightly slows down the saving operation, but it prevents the UI from locking up and allows us to update the progressbar and preview image
            }

            screenshotListBox.Enabled = true; // before finishing function, re-enable the listbox
        }

        /// <summary>
        /// Handles saving all screenshots in the listbox, but using multiple background workers to speed up the process
        /// </summary>
        private void saveAllTBtn_Click(object sender, EventArgs e)
        {
            bool wasSuccessful = showSaveDialog(true);

            if (!wasSuccessful)
            {
                return;
            }

            screenshotListBox.Enabled = false; // disable the listbox so no new images can be selected, as this could cause issues.
            string newPath = folderDialog.SelectedPath + "\\"; // set the path to save the files to, as per the users wishes

            saveAllProgressbar.Maximum = 100; // the workers will report percentages rather than the screenshot number they have completed
            saveAllProgressbar.Visible = true; // show the progressbar, as it was hidden before

            TurboHandler turboObject = new();
            turboObject.configureTurbo(screenshotListBox.Items.Cast<String>().ToList(), folderLocation, newPath, this);

            screenshotListBox.Enabled = true;
        }

        /// <summary>
        /// Handles the progressbar updates for the save all turbo function
        /// </summary>
        public void turboReportProgress(object? sender, ProgressChangedEventArgs e)
        {
            saveAllProgressbar.Value = e.ProgressPercentage;
        }

        /// <summary>
        /// Handles switching the screenshot folder
        /// </summary>
        private void selectFolderBtn_Click(object sender, EventArgs e) // opens a folder selector, runs when user clicks 'Select Folder'
        {
            folderDialog.Description = Dialogs.Body_Info_SelectFFXVScreenshotFolder;
            folderDialog.UseDescriptionForTitle = true;
            folderDialog.SelectedPath = ""; // reset any saved folder name, as could be set during set-up or previous folder search
            folderDialog.ShowDialog(); // show the folder selector dialog
            if (folderDialog.SelectedPath == null || folderDialog.SelectedPath == "") // if the folder name was not set (aka user cancelled dialog)
            {
                return; // user has changed their mind, return
            }
            if (Directory.Exists(folderDialog.SelectedPath) == false) // if the directory chosen does not exist
            {
                MessageBox.Show(Dialogs.Body_Error_InvalidScreenshotFolder, Dialogs.Title_Error_InvalidScreenshotFolder); // show user message
                return; // then return, as we can't change folder
            }
            folderLocation = folderDialog.SelectedPath + "\\"; // set folder location to new specified folder
            scanScreenshots(); // re-scan for screenshots
        }

        /// <summary>
        /// Handles detecting the screenshot folder
        /// </summary>
        private void detectFolderBtn_Click(object sender, EventArgs e) // detects default screenshot folder, runs when user clicks 'Detect Folder'
        {
            folderLocation = FolderDetector.detectFolder(platform, isComrades); // runs function to detect folder
            scanScreenshots(); // runs function to re-scan for screenshots
        }

        /// <summary>
        /// Handles the background worker for checking for updates
        /// </summary>
        private void updateChecker_DoWork(object sender, DoWorkEventArgs e)
        {
            isUpdateAvailable = UpdateChecker.checkForUpdate(); // run the function to check if theres an update
        }

        /// <summary>
        /// Handles the completion of the background worker for checking for updates
        /// </summary>
        private void updateChecker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            helpTooltip.SetToolTip(authVerLabel, $"{DynamicLabels.Main_UpdateAvailable} {isUpdateAvailable}{Environment.NewLine}{DynamicLabels.Main_Platform} {platform}{Environment.NewLine}{DynamicLabels.Main_Commit} {Application.ProductVersion.Split("+")[1]}{Environment.NewLine}{Environment.NewLine}{DynamicLabels.Main_FFXVSG} (v{Assembly.GetExecutingAssembly().GetName().Version})");
            if (isUpdateAvailable) // if there is an update
            {
                DialogResult shouldGetUpdate = MessageBox.Show(Dialogs.Body_Info_UpdateAvailable, Dialogs.Title_Info_UpdateAvailable, MessageBoxButtons.YesNo); // show dialog to user
                if (shouldGetUpdate == DialogResult.Yes) // if they want to upgrade
                {
                    Process.Start(new ProcessStartInfo() // open their default browser, with the URL to download the latest version
                    {
                        UseShellExecute = true,
                        FileName = "https://ngserve.games/cdn/ffxvsg/exec/Narod's-FFXV-Screenshot-Grabber.zip"
                    });
                    Application.Exit(); // exit the application
                }
            }
        }

        /// <summary>
        /// Handles configuring the realtime mode (enabling & disabling)
        /// </summary>
        private void realtimeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (realtimeCheckBox.Checked == true) // if the box has been checked
            {
                folderDialog.Description = Dialogs.Body_Info_SelectRealtimeFolder;
                folderDialog.UseDescriptionForTitle = true;
                folderDialog.SelectedPath = ""; // reset any saved folder name, as could be set during set-up or previous folder search
                folderDialog.ShowDialog(); // show the folder selector dialog
                if (folderDialog.SelectedPath == null || folderDialog.SelectedPath == "") // if the folder name was not set (aka user cancelled dialog)
                {
                    realtimeCheckBox.Checked = false; // disable the checkbox as it wasn't turned on
                    return; // user has changed their mind, return
                }
                if (Directory.Exists(folderDialog.SelectedPath) == false) // if the directory chosen does not exist
                {
                    MessageBox.Show(Dialogs.Body_Error_InvalidScreenshotFolder); // show user message
                    realtimeCheckBox.Checked = false; // disable the checkbox as it wasn't turned on
                    return; // then return, as we can't use that folder
                }
                realtimeObject = new(this, folderDialog.SelectedPath); // create the new realtime watcher object
                screenshotListBox.Items.Clear(); // clear the items in this listbox, as realtime folder may be different to current directory
                helpTooltip.SetToolTip(selectFolderBtn, DynamicLabels.Main_DisableRealtimeWarning); // tooltips don't actually work on disabled buttons
                helpTooltip.SetToolTip(detectFolderBtn, DynamicLabels.Main_DisableRealtimeWarning); // tooltips don't actually work on disabled buttons
                selectFolderBtn.Enabled = false;
                detectFolderBtn.Enabled = false;
                selectFolderBtn.Visible = false;
                detectFolderBtn.Visible = false;
                folderRealtimeWarning.Visible = true;
                resetWindow();
            }
            else // if checkbox is unchecked
            {
                realtimeObject?.safeStop(); // safely stop the realtime watcher 
                helpTooltip.SetToolTip(selectFolderBtn, DynamicLabels.Main_SelectFolderTooltip);
                helpTooltip.SetToolTip(detectFolderBtn, $"{DynamicLabels.Main_DetectFolderTooltip} \\r\\n\\r\\nTypically this is \"My Games/FINAL FANTASY XV/Steam/.../savestorage/snapshot\"");
                selectFolderBtn.Enabled = true;
                detectFolderBtn.Enabled = true;
                selectFolderBtn.Visible = true;
                detectFolderBtn.Visible = true;
                folderRealtimeWarning.Visible = false;
                scanScreenshots(); // scan for screenshots in the folder directory again, as realtime folder may be different from current
            }
        }

        /// <summary>
        /// Handles the toggling of tooltips
        /// </summary>
        private void tooltipsCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (tooltipsCheckbox.Checked)
            {
                helpTooltip.Active = true;
            }
            else
            {
                helpTooltip.Active = false;
            }
        }

        /// <summary>
        /// Handles DPI sizing on checkboxes (as WinForms doesn't handle DPI scaling well)
        /// </summary>
        private void checkboxPainter(object sender, PaintEventArgs e)
        {
            CheckBox checkbox = (CheckBox)sender;

            if (this.DeviceDpi != 96)
            {
                checkbox.Text = checkbox.Text.Replace(" ", "\n");
            }
        }

        /// <summary>
        /// Deletes temporary preview files & folder on closing the utility
        /// </summary>
        private void mainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (platform == OperatingSystem.Windows || platform == OperatingSystem.LegacyWindows)
            {
                if (Directory.Exists(Path.GetTempPath() + $"\\NFFXVSG_{DynamicLabels.Main_Temp}"))
                {
                    Directory.Delete(Path.GetTempPath() + $"\\NFFXVSG_{DynamicLabels.Main_Temp}", true);
                }
            }
        }

        private void comradesCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (comradesCheckbox.Checked)
            {
                // switch to comrades mode
                isComrades = true;
                this.Text = DynamicLabels.Main_ComradesTitle;
            }
            else
            {
                // switch out of comrades mode
                isComrades = false;
                this.Text = DynamicLabels.Main_Title;
            }

            folderLocation = FolderDetector.detectFolder(platform, isComrades);
            resetWindow();
        }
    }
}