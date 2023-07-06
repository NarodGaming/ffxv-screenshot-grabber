using Microsoft.Win32;
using System.ComponentModel;
using System.Diagnostics;

namespace FFXV6_Screenshot_Grabber
{
    public partial class mainWindow : Form
    {
        imageExpander previewWindow = new imageExpander(); // create reference of imageExpander (the resizeable preview window)
        Image? currentImage; // variable to store current preview image
        string folderLocation; // variable to store folder location of screenshots
        bool isUpdateAvailable; // variable to store if update is required or not

        RealtimeHandler? realtimeObject; // object to handle realtime screenshots

        bool isWindows = true; // holds if the system is running windows or linux, will be set to false in init if on linux

        public mainWindow()
        {
            InitializeComponent();

            foreach (string subValueKey in Registry.CurrentUser.OpenSubKey("Software")?.GetSubKeyNames() ?? Array.Empty<string>()) // a good way of checking if we're running on Linux
            {
                if (subValueKey == "Wine") // if wine key exists, then we're on Linux
                {
                    isWindows = false;
                }
            }

            authVerLabel.Text = $"by Narod (V{Application.ProductVersion})";

            if (isWindows) { folderLocation = FolderDetector.detectFolder(); } else { folderLocation = FolderDetector.detectFolderLinux(); }

            scanScreenshots(); // scan for screenshots

            updateChecker.RunWorkerAsync(); // run the update checker

            DarkMode.SetupDarkMode(this);
        }

        private string returnFullPath() // returns full path of listbox item selected
        {
            if (screenshotListBox.SelectedIndex == -1) { return ""; }; // if there is no selected listbox item, return a blank string
            return folderLocation + screenshotListBox.SelectedItem.ToString(); // otherwise, concat the folder location var with the listbox selected item string and return it
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
            if (previewPictureBox.BackgroundImage != null) { previewPictureBox.BackgroundImage = Properties.Resources._00001333; } // if the preview image is set, unset it
            previewWindow.Hide(); // if the preview window is open, this will hide it (as theres no image to display right now)
            updateListBoxCounter();
        }

        private void scanScreenshots() // scans for all screenshots in folder, runs at boot, or when screenshot folder has changed
        {
            resetWindow();

            IEnumerable<String> ssFiles = Directory.GetFiles(folderLocation, "*.ss", SearchOption.TopDirectoryOnly).Select(nm => Path.GetFileName(nm)); // get all files ending with ".ss" only in the current directory, linq used to get just filename, not full path
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

        private void saveOneBtn_Click(object sender, EventArgs e) // run when the user clicks 'Save One'
        {
            saveAllProgressbar.Value = 0; // reset the progressbar (not used for saving single file anyway)
            saveScreenshotDialog.FileName = ""; // reset any previous dialog prompts that may have shown before
            if (screenshotListBox.SelectedIndex == -1) // if the selected item is not set
            {
                return; // then theres nothing to save, return
            }
            saveScreenshotDialog.ShowDialog(); // show the dialog to select file name to save as
            if (saveScreenshotDialog.FileName == null || saveScreenshotDialog.FileName == "") // if file name was not set (aka user cancelled dialog)
            {
                return; // then the user has changed their mind, return
            }
            string newPath = saveScreenshotDialog.FileName; // set the path of the file to save to the users preference as chosen by the dialog prompt
            ScreenshotWriter.writeScreenshot(returnFullPath(), newPath); // write the file to disk
        }

        private void saveAllBtn_Click(object sender, EventArgs e) // run when the user clicks 'Save All'
        {
            saveAllProgressbar.Value = 0; // reset the progressbar (in case of previous 'Save All'
            folderDialog.SelectedPath = ""; // reset any previous dialog prompts that may have shown before
            if (screenshotListBox.Items.Count == 0) // if theres no items to save
            {
                return; // then we can't save any items, return
            }
            folderDialog.ShowDialog(); // show the dialog to select folder to save out to
            if (folderDialog.SelectedPath == null || folderDialog.SelectedPath == "") // if the folder name was not set (aka user cancelled dialog)
            {
                return; // then the user has changed their mind, return
            }
            if (Directory.Exists(folderDialog.SelectedPath) == false) // if the directory chosen does not exist
            {
                MessageBox.Show("Unable to save screenshots. Folder chosen does not exist."); // show user message
                return; // then return, as we can't save
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
            folderDialog.SelectedPath = "";
            if (screenshotListBox.Items.Count == 0)
            {
                return;
            }
            folderDialog.ShowDialog(); // show the dialog to select folder to save out to
            if (folderDialog.SelectedPath == null || folderDialog.SelectedPath == "") // if the folder name was not set (aka user cancelled dialog)
            {
                return; // then the user has changed their mind, return
            }
            if (Directory.Exists(folderDialog.SelectedPath) == false) // if the directory chosen does not exist
            {
                MessageBox.Show("Unable to save screenshots. Folder chosen does not exist."); // show user message
                return; // then return, as we can't save
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
            folderLocation = FolderDetector.detectFolder(); // runs function to detect folder
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
                helpTooltip.SetToolTip(selectFolderBtn, "You must disable Realtime mode to change the folder location.");
                helpTooltip.SetToolTip(detectFolderBtn, "You must disable Realtime mode to change the folder location.");
                selectFolderBtn.Enabled = false;
                detectFolderBtn.Enabled = false;
                resetWindow();
            }
            else // if checkbox is unchecked
            {
                if (realtimeObject is not null) { realtimeObject.safeStop(); } // safely stop the realtime watcher 
                helpTooltip.SetToolTip(selectFolderBtn, "This button allows you to change the current screenshot directory.");
                helpTooltip.SetToolTip(detectFolderBtn, "This button attempts to automatically locate your screenshot folder.\r\n\r\nTypically this is \"My Games/FINAL FANTASY XV/Steam/.../savestorage/snapshot\"");
                selectFolderBtn.Enabled = true;
                detectFolderBtn.Enabled = true;
                scanScreenshots(); // scan for screenshots in the folder directory again, as realtime folder may be different from current
            }
        }
    }
}