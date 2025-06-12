using FFXV6_Screenshot_Grabber.Locale.Dialogs;

namespace FFXV6_Screenshot_Grabber
{
    /// <summary>
    /// Class for detecting the screenshot folder location on a range of <see cref="OperatingSystem"/>s.
    /// </summary>
    internal static class FolderDetector
    {
        private static FolderBrowserDialog folderDialog = new();

        private static readonly string windowsBaseFolderPath = Environment.GetEnvironmentVariable("USERPROFILE") + "\\Documents\\My Games\\FINAL FANTASY XV"; // default base location for Windows
        private static readonly string linuxBaseFolderPath = "~/.local/share/Steam/steamapps/compatdata/637650/pfx/dosdevices/c:/users/steamuser/Documents/My Games/Final Fantasy XV"; // default base location for Linux
        private static readonly string macBaseFolderPath = windowsBaseFolderPath; // default base location for Mac (we're expecting a Windows file path due to some differences in how Linux and Mac opening of the utility is expected)

        private static readonly string windowsMSFolderPath = Environment.GetEnvironmentVariable("LOCALAPPDATA") + "\\Packages\\39EA002F.FINALFANTASYXVforPC_n746a19ndrrjg\\LocalState"; // default location for Windows (MS Store)
        // there's no proper way to run the MS Store version on Linux or Mac, so we're not going to bother with those

        // both origin & steam instead will use the 'base' folder

        /// <summary>
        /// Runs when screenshot folder detection fails, prompts the user to select the folder manually.
        /// </summary>
        /// <param name="positionToBrowse">The closest directory we got to finding the screenshot folder automatically</param>
        /// <param name="platform">The users operating system (changes help dialog to help as best as possible)</param>
        /// <returns>The full path to the screenshot folder (or Exits, if user cancels)</returns>
        private static string failedAutoDirSearch(string positionToBrowse, OperatingSystem platform, bool isComrades) // runs when the detectFolder function fails
        {
            folderDialog.SelectedPath = ""; // reset the selected path to nothing, as it might be set from 'Save All' prompt
            folderDialog.Description = Dialogs.Body_Info_SelectFFXVScreenshotFolder;
            folderDialog.UseDescriptionForTitle = true;
            folderDialog.InitialDirectory = positionToBrowse;
            if (platform == OperatingSystem.Windows || platform == OperatingSystem.Mac || platform == OperatingSystem.LegacyWindows)
            {
                if (isComrades)
                {
                    MessageBox.Show($"{Dialogs.Body_Error_UnableDetectComrades} (Documents\\My Games\\FINAL FANTASY XV\\Steam\\(some numbers)\\savestorage\\multiplayer\\snapshot)", Dialogs.Title_Error_UnableDetectComrades); // message to user
                } else
                {
                    MessageBox.Show($"{Dialogs.Body_Error_UnableDetectBase} (Documents\\My Games\\FINAL FANTASY XV\\Steam\\(some numbers)\\savestorage\\snapshot)", Dialogs.Title_Error_UnableDetectBase); // message to user
                }
            } else if (platform == OperatingSystem.Linux)
            {
                if (isComrades)
                {
                    MessageBox.Show($"{Dialogs.Body_Error_UnableDetectComrades} ([steam-library-dir]/steamapps/compatdata/637650/pfx/dosdevices/c:/users/steamuser/Documents/My Games/Final Fantasy XV/Steam/(some numbers)/savestorage/multiplayer/snapshot", Dialogs.Title_Error_UnableDetectComrades); // message to user
                } else
                {
                    MessageBox.Show($"{Dialogs.Body_Error_UnableDetectBase} ([steam-library-dir]/steamapps/compatdata/637650/pfx/dosdevices/c:/users/steamuser/Documents/My Games/Final Fantasy XV/Steam/(some numbers)/savestorage/snapshot", Dialogs.Title_Error_UnableDetectBase); // message to user
                }
            }
            folderDialog.ShowDialog(); // show the dialog to prompt the user to select screenshot dir
            if (folderDialog.SelectedPath == null || folderDialog.SelectedPath == "") // if they click cancel or otherwise don't select a directory
            {
                MessageBox.Show(Dialogs.Body_Error_NoScreenshotFolder, Dialogs.Title_Error_InvalidScreenshotFolder); // message to user
                Application.Exit(); // safely exit
                return ""; // prevent any extra checks running
            }
            if (Directory.Exists(folderDialog.SelectedPath) == false) // if the directory specified does not exist
            {
                MessageBox.Show(Dialogs.Body_Error_InvalidScreenshotFolder, Dialogs.Title_Error_InvalidScreenshotFolder); // message to user
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
        public static string detectFolder(OperatingSystem platform, bool isComrades) // detects screenshot folder, runs at boot or when user selects 'Detect Folder' designed for WINDOWS.
        {
            string folderLocation;

            switch (platform)
            {
                case OperatingSystem.Windows:
                    folderLocation = windowsBaseFolderPath;
                    if (Directory.Exists(windowsMSFolderPath)) // if the MS Store folder exists, then we're running the MS Store version of the game
                    {
                        failedAutoDirSearch(windowsMSFolderPath, platform, isComrades); // don't currently support MS Store version (don't own it, can't test it) so just fail the search here
                    }
                    break;
                case OperatingSystem.LegacyWindows:
                    folderLocation = windowsBaseFolderPath;
                    break;
                case OperatingSystem.Linux:
                    folderLocation = linuxBaseFolderPath;
                    break;
                case OperatingSystem.Mac:
                    folderLocation = macBaseFolderPath;
                    break;
                default:
                    return failedAutoDirSearch("", 0, isComrades);
            }

            if (!Directory.Exists(folderLocation)) // if this base directory doesn't exist (it should on all Windows systems who have played the game)
            {
                return failedAutoDirSearch(folderLocation, platform, isComrades); // run failed function (above)
            }
            string[] platformnames = Directory.GetDirectories(folderLocation); // get all sub directories (expecting it to say either 'Steam' or 'Origin')
            if (platformnames.Length != 1) // check how many were returned - this could actually implement a screen to select between Steam/Origin here, but that's a very rare case
            {
                return failedAutoDirSearch(folderLocation, platform, isComrades); // run failed function (above)
            }
            folderLocation = platformnames[0]; // move down the sub folder structure
            string[] subdirs = Directory.GetDirectories(folderLocation); // get all sub directories.
            if (subdirs.Length != 1) // check how many subdirs were returned, there should only be 1 (unless user has multiple steam accounts they played this game with, in which case they need to specify for themselves). if there's none, then the user hasn't played the game.
            {
                return failedAutoDirSearch(folderLocation, platform, isComrades); // run failed function (above)
            }
            string lastSuccessLocation = folderLocation;
            if (isComrades) // not sure if this section here works on Linux or SteamOS - needs testing
            {
                folderLocation = subdirs[0] + "\\savestorage\\multiplayer\\snapshot\\"; // get the only sub dir and append on the location of the snapshot folder
            } else
            {
                folderLocation = subdirs[0] + "\\savestorage\\snapshot\\"; // get the only sub dir and append on the location of the snapshot folder
            }
            if (!Directory.Exists(folderLocation)) // if this folder doesn't exist (if all other checks have passed, the only way this could occur is user messing with folders)
            {
                return failedAutoDirSearch(lastSuccessLocation, platform, isComrades); // run failed function (above)
            }
            return folderLocation;
        }
    }
}
