using Microsoft.Win32;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;

namespace FFXV6_Screenshot_Grabber
{
    public partial class mainWindow : Form
    {
        imageExpander previewWindow = new imageExpander(); // create reference of imageExpander (the resizeable preview window)
        Image? currentImage; // variable to store current preview image
        string folderLocation; // variable to store folder location of screenshots
        bool isUpdateAvailable; // variable to store if update is required or not

        RealtimeHandler? realtimeObject; // object to handle realtime screenshots

        OperatingSystem platform = OperatingSystem.Unknown; // set to Unknown, main function will set this to the correct platform

        public mainWindow()
        {
            InitializeComponent();

            platform = OSDetector.detectOS(); // run the OS detector function, this will set the platform variable to the correct platform

            folderLocation = FolderDetector.detectFolder(platform); // look for the screenshot folder in the default location

            authVerLabel.Text = $"by Narod (V{Assembly.GetExecutingAssembly().GetName().Version})"; // set the version label text to show the current version of the program

            scanScreenshots(); // scan for screenshots

            updateChecker.RunWorkerAsync(); // run the update checker

            DarkMode.SetupDarkMode(this); // run darkmode configuration, passing this form as an object

            screenshotTakenLabel.Text = ""; // blank out this label, it will be set when selecting a screenshot

            helpTooltip.SetToolTip(authVerLabel, $"Update Available: {isUpdateAvailable}{Environment.NewLine}Platform: {platform}{Environment.NewLine}{Environment.NewLine}Narod's FFXV Screenshot Grabber (v{Assembly.GetExecutingAssembly().GetName().Version})");
        }

        private string returnFullPath() // returns full path of listbox item selected
        {
            if (screenshotListBox.SelectedIndex == -1) { return ""; }; // if there is no selected listbox item, return a blank string
            return folderLocation + screenshotListBox.SelectedItem.ToString() + ".ss"; // otherwise, concat the folder location var with the listbox selected item string and return it
        }

        public void addToListBox(string itemToAdd) // add a single item to the screenshot list box
        {
            screenshotListBox.Items.Add(itemToAdd);
            updateListBoxCounter();
        }

        public void addToListBox(IEnumerable<String> itemsToAdd) // add an enum of strings to the screenshot list box
        {
            foreach (string ssFile in itemsToAdd) // for each file found in above line
            {
                screenshotListBox.Items.Add(ssFile); // add the filename to the listbox
            }

            updateListBoxCounter();
        }

        public void removeFromListBox(string itemToRemove) // remove a specific string from the screenshot list box
        {
            if (screenshotListBox.Items.Contains(itemToRemove))
            {
                screenshotListBox.Items.Remove(itemToRemove);
                updateListBoxCounter();
            }
        }

        private void updateListBoxCounter() // update the counter with how many items are in the screenshot list box
        {
            screenshotLabel.Text = $"Screenshots: {screenshotListBox.Items.Count}"; // change the label to show the total amount of detected screenshot files
        }

        private void resetWindow()
        {
            screenshotListBox.Items.Clear(); // clear all items currently in the listbox
            if (currentImage != null) { currentImage.Dispose(); } // if there is a current image set, dispose of it
            if (previewPictureBox.BackgroundImage != null) { previewPictureBox.BackgroundImage = Properties.Resources.default_preview; } // if the preview image is set, unset it
            previewWindow.Hide(); // if the preview window is open, this will hide it (as theres no image to display right now)
            screenshotTakenLabel.Text = ""; // blank out this label, it will be set when selecting a screenshot
            updateListBoxCounter(); // updates the counter for how many screenshots are in the listbox
        }

        private void scanScreenshots() // scans for all screenshots in folder, runs at boot, or when screenshot folder has changed
        {
            resetWindow(); // reset the window (clears listbox, preview image, etc.)

            IEnumerable<String> ssFiles = Directory.GetFiles(folderLocation, "*.ss", SearchOption.TopDirectoryOnly).Select(nm => Path.GetFileNameWithoutExtension(nm)); // get all files ending with ".ss" only in the current directory, linq used to get just filename, not full path
            addToListBox(ssFiles);
        }

        private void screenshotListBox_SelectedIndexChanged(object sender, EventArgs e) // run when the user selects a new screenshot to preview (and then potentially save)
        {
            if (screenshotListBox.SelectedIndex == -1) // if the selected item has been unset
            {
                return; // then theres nothing to show, return
            }
            currentImage = ScreenshotWriter.returnImageScreenshot(returnFullPath()); // set current image to the image that was just selected
            previewPictureBox.BackgroundImage = currentImage; // set up the preview image to this new current image
            previewWindow.retrieveScreenshot(currentImage); // pass the new preview image to the preview window
            screenshotTakenLabel.Text = $"Snapshot Taken On {File.GetCreationTime(returnFullPath())}";
        }

        private void previewPictureBox_Click(object sender, EventArgs e) // run when the user clicks the preview image (to 'expand' it)
        {
            if (screenshotListBox.SelectedIndex == -1) // if the preview image is not set
            {
                MessageBox.Show("Please select a screenshot to preview first before trying to expand the preview!", "Please select a screenshot!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return; // then theres nothing to show, return
            }
            previewWindow.Show(); // show the preview window (screenshotListBox_SelectedIndexChanged always passes screenshot whether the preview window is visible or not anyway)
        }

        private bool showSaveDialog(bool isAllSave) // function which runs the shared code between save, save all and save all turbo
        {
            saveAllProgressbar.Value = 0; // reset the progressbar (not used for saving single file anyway)
            saveScreenshotDialog.FileName = ""; // reset any previous dialog prompts that may have shown before
            if (screenshotListBox.SelectedIndex == -1 && !isAllSave)
            {
                MessageBox.Show("Unable to save screenshot. Please select a screen to preview first.");
                return false; // if there's no selected image, and save one was chosen, return false
            }
            else if (screenshotListBox.Items.Count == 0 && isAllSave)
            {
                MessageBox.Show("Unable to save screenshots. Please select a folder with some screenshots in to save.");
                return false; // if save all was chosen, but there's no items to save, return false
            }
            if (isAllSave)
            {
                folderDialog.ShowDialog();
                if (folderDialog.SelectedPath == null || folderDialog.SelectedPath == "") // if the folder name was not set (aka user cancelled dialog)
                {
                    return false; // then the user has changed their mind, return
                }
            }
            else
            {
                saveScreenshotDialog.ShowDialog();
                if (Directory.Exists(folderDialog.SelectedPath) == false) // if the directory chosen does not exist
                {
                    MessageBox.Show("Unable to save screenshots. Folder chosen does not exist."); // show user message
                    return false; // then return, as we can't save
                }
            }
            return true; // return true, all checks succesful
        }

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

            foreach (string listBoxItem in screenshotListBox.Items) // for each listbox item (screenshot) in listbox (total screenshots)
            {
                string fileName = newPath + listBoxItem.Split(".ss")[0] + ".jpg"; // gets a full file path to save the new ss to. e.g. listbox may say '00001.ss', this would change it to 'C:\screenshotsaves\00001.jpg' (if folder specified was 'C:\screenshotsaves')
                currentImage = ScreenshotWriter.writeScreenshotFromAll(folderLocation + listBoxItem, fileName); // write the screenshot to disk, and also retrieve a preview copy of this image
                saveAllProgressbar.PerformStep(); // increment the progress bar by 1
                previewPictureBox.BackgroundImage = currentImage; // update the preview image
                Application.DoEvents(); // do events, this slightly slows down the saving operation, but it prevents the UI from locking up and allows us to update the progressbar and preview image
            }

            screenshotListBox.Enabled = true; // before finishing function, re-enable the listbox
        }

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

            TurboHandler turboObject = new();
            turboObject.configureTurbo(screenshotListBox.Items.Cast<String>().ToList(), folderLocation, newPath, this);

            screenshotListBox.Enabled = true;
        }

        public void turboReportProgress(object sender, ProgressChangedEventArgs e)
        {
            saveAllProgressbar.Value = e.ProgressPercentage;
        }

        private void selectFolderBtn_Click(object sender, EventArgs e) // opens a folder selector, runs when user clicks 'Select Folder'
        {
            folderDialog.Description = "Please select the folder containing your FFXV screenshots...";
            folderDialog.UseDescriptionForTitle = true;
            folderDialog.SelectedPath = ""; // reset any saved folder name, as could be set during set-up or previous folder search
            folderDialog.ShowDialog(); // show the folder selector dialog
            if (folderDialog.SelectedPath == null || folderDialog.SelectedPath == "") // if the folder name was not set (aka user cancelled dialog)
            {
                return; // user has changed their mind, return
            }
            if (Directory.Exists(folderDialog.SelectedPath) == false) // if the directory chosen does not exist
            {
                MessageBox.Show("FFXV screenshot folder given does not exist, or not enough permissions to access!"); // show user message
                return; // then return, as we can't change folder
            }
            folderLocation = folderDialog.SelectedPath + "\\"; // set folder location to new specified folder
            scanScreenshots(); // re-scan for screenshots
        }

        private void detectFolderBtn_Click(object sender, EventArgs e) // detects default screenshot folder, runs when user clicks 'Detect Folder'
        {
            folderLocation = FolderDetector.detectFolder(platform); // runs function to detect folder
            scanScreenshots(); // runs function to re-scan for screenshots
        }

        private void updateChecker_DoWork(object sender, DoWorkEventArgs e)
        {
            isUpdateAvailable = UpdateChecker.checkForUpdate(); // run the function to check if theres an update
        }

        private void updateChecker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (isUpdateAvailable) // if there is an update
            {
                DialogResult shouldGetUpdate = MessageBox.Show("An update to Narod's FFXV Screenshot Grabber is available, do you wish to download the update?", "Narod's FFXV Screenshot Grabber - Update Available", MessageBoxButtons.YesNo); // show dialog to user
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

        private void realtimeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (realtimeCheckBox.Checked == true) // if the box has been checked
            {
                folderDialog.Description = "Please select the folder you wish to watch for screenshots...";
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
                    MessageBox.Show("Folder given does not exist, or not enough permissions to access!"); // show user message
                    realtimeCheckBox.Checked = false; // disable the checkbox as it wasn't turned on
                    return; // then return, as we can't use that folder
                }
                realtimeObject = new(this, folderDialog.SelectedPath); // create the new realtime watcher object
                screenshotListBox.Items.Clear(); // clear the items in this listbox, as realtime folder may be different to current directory
                helpTooltip.SetToolTip(selectFolderBtn, "You must disable Realtime mode to change the folder location."); // tooltips don't actually work on disabled buttons
                helpTooltip.SetToolTip(detectFolderBtn, "You must disable Realtime mode to change the folder location."); // tooltips don't actually work on disabled buttons
                selectFolderBtn.Enabled = false;
                detectFolderBtn.Enabled = false;
                selectFolderBtn.Visible = false;
                detectFolderBtn.Visible = false;
                folderRealtimeWarning.Visible = true;
                resetWindow();
            }
            else // if checkbox is unchecked
            {
                if (realtimeObject is not null) { realtimeObject.safeStop(); } // safely stop the realtime watcher 
                helpTooltip.SetToolTip(selectFolderBtn, "This button allows you to change the current screenshot directory.");
                helpTooltip.SetToolTip(detectFolderBtn, "This button attempts to automatically locate your screenshot folder.\r\n\r\nTypically this is \"My Games/FINAL FANTASY XV/Steam/.../savestorage/snapshot\"");
                selectFolderBtn.Enabled = true;
                detectFolderBtn.Enabled = true;
                selectFolderBtn.Visible = true;
                detectFolderBtn.Visible = true;
                folderRealtimeWarning.Visible = false;
                scanScreenshots(); // scan for screenshots in the folder directory again, as realtime folder may be different from current
            }
        }

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
    }
}