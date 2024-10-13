namespace FFXV6_Screenshot_Grabber
{
    /// <summary>
    /// Class for detecting the screenshot folder location on a range of <see cref="OperatingSystem"/>s.
    /// </summary>
    internal static class FolderDetector
    {
        private static FolderBrowserDialog folderDialog = new();

        private static readonly string windowsFolderPath = Environment.GetEnvironmentVariable("USERPROFILE") + "\\Documents\\My Games\\FINAL FANTASY XV\\Steam"; // default location for Windows
        private static readonly string linuxFolderPath = "~/.local/share/Steam/steamapps/compatdata/637650/pfx/dosdevices/c:/users/steamuser/Documents/My Games/Final Fantasy XV/Steam"; // default location for Linux
        private static readonly string macFolderPath = Environment.GetEnvironmentVariable("USERPROFILE") + "\\Documents\\My Games\\FINAL FANTASY XV\\Steam"; // default location for Mac (we're expecting a Windows file path due to some differences in how Linux and Mac opening of the utility is expected)

        /// <summary>
        /// Runs when screenshot folder detection fails, prompts the user to select the folder manually.
        /// </summary>
        /// <param name="positionToBrowse">The closest directory we got to finding the screenshot folder automatically</param>
        /// <param name="platform">The users operating system (changes help dialog to help as best as possible)</param>
        /// <returns>The full path to the screenshot folder (or Exits, if user cancels)</returns>
        private static string failedAutoDirSearch(string positionToBrowse, OperatingSystem platform) // runs when the detectFolder function fails
        {
            folderDialog.SelectedPath = ""; // reset the selected path to nothing, as it might be set from 'Save All' prompt
            folderDialog.Description = "Please select the folder containing your FFXV screenshots...";
            folderDialog.UseDescriptionForTitle = true;
            folderDialog.InitialDirectory = positionToBrowse;
            if (platform == OperatingSystem.Windows || platform == OperatingSystem.Mac || platform == OperatingSystem.LegacyWindows)
            {
                MessageBox.Show("Unable to automatically detect FFXV folder! Please manually search for it! (usually Documents\\My Games\\FINAL FANTASY XV\\Steam\\(some numbers)\\savestorage\\snapshot)"); // message to user
            } else if (platform == OperatingSystem.Linux)
            {
                MessageBox.Show("Unable to automatically detect FFXV folder! Please manually search for it! (usually {steam-library-dir}/steamapps/compatdata/637650/pfx/dosdevices/c:/users/steamuser/Documents/My Games/Final Fantasy XV/Steam/(some numbers)/savestorage/snapshot"); // message to user
            }
            folderDialog.ShowDialog(); // show the dialog to prompt the user to select screenshot dir
            if (folderDialog.SelectedPath == null || folderDialog.SelectedPath == "") // if they click cancel or otherwise don't select a directory
            {
                MessageBox.Show("No FFXV screenshot folder provided. You must select a folder! Closing..."); // message to user
                Application.Exit(); // safely exit
                return ""; // prevent any extra checks running
            }
            if (Directory.Exists(folderDialog.SelectedPath) == false) // if the directory specified does not exist
            {
                MessageBox.Show("FFXV screenshot folder given does not exist, or not enough permissions to access! Closing..."); // message to user
                Application.Exit(); // safely exit
                return ""; // prevent any extra checks running
            }
            return folderDialog.SelectedPath + "\\"; // all checks passed, set folder location to one specified by user
        }

        /// <summary>
        /// Automatically detects the screenshot folder location on a range of <see cref="OperatingSystem"/>s.
        /// </summary>
        /// <param name="platform">The users operating system, as this determines where the program should look for the folder.</param>
        /// <returns>The full path of the screenshot folder</returns>
        public static string detectFolder(OperatingSystem platform) // detects screenshot folder, runs at boot or when user selects 'Detect Folder' designed for WINDOWS.
        {
            string folderLocation;

            switch (platform)
            {
                case OperatingSystem.Windows:
                    folderLocation = windowsFolderPath;
                    break;
                case OperatingSystem.LegacyWindows:
                    folderLocation = windowsFolderPath;
                    break;
                case OperatingSystem.Linux:
                    folderLocation = linuxFolderPath;
                    break;
                case OperatingSystem.Mac:
                    folderLocation = macFolderPath;
                    break;
                default:
                    return failedAutoDirSearch("", 0);
            }

            if (!Directory.Exists(folderLocation)) // if this base directory doesn't exist (it should on all Windows systems who have played the game)
            {
                return failedAutoDirSearch(folderLocation, platform); // run failed function (above)
            }
            string[] subdirs = Directory.GetDirectories(folderLocation); // get all sub directories.
            if (subdirs.Length != 1) // check how many subdirs were returned, there should only be 1 (unless user has multiple steam accounts they played this game with, in which case they need to specify for themselves). if there's none, then the user hasn't played the game.
            {
                return failedAutoDirSearch(folderLocation, platform); // run failed function (above)
            }
            string lastSuccessLocation = folderLocation;
            folderLocation = subdirs[0] + "\\savestorage\\snapshot\\"; // get the only sub dir and append on the location of the snapshot folder
            if (!Directory.Exists(folderLocation)) // if this folder doesn't exist (if all other checks have passed, the only way this could occur is user messing with folders)
            {
                return failedAutoDirSearch(lastSuccessLocation, platform); // run failed function (above)
            }
            return folderLocation;
        }
    }
}
