using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXV6_Screenshot_Grabber
{
    internal static class FolderDetector
    {
        private static FolderBrowserDialog folderDialog = new FolderBrowserDialog();
        private static string failedAutoDirSearch(string positionToBrowse, bool isWindows) // runs when the detectFolder function fails
        {
            folderDialog.SelectedPath = ""; // reset the selected path to nothing, as it might be set from 'Save All' prompt
            folderDialog.Description = "Please select the folder containing your FFXV screenshots...";
            folderDialog.UseDescriptionForTitle = true;
            folderDialog.InitialDirectory = positionToBrowse;
            if (isWindows)
            {
                MessageBox.Show("Unable to automatically detect FFXV folder! Please manually search for it! (usually Documents\\My Games\\FINAL FANTASY XV\\Steam\\(some numbers)\\savestorage\\snapshot)"); // message to user
            } else
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

        public static string detectFolder() // detects screenshot folder, runs at boot or when user selects 'Detect Folder'
        {
            string documentsFolder = Environment.GetEnvironmentVariable("USERPROFILE") + "\\Documents\\";
            string folderLocation = documentsFolder + "My Games\\FINAL FANTASY XV\\Steam"; // starting directory, as far as we can get without dynamic checks
            if (!Directory.Exists(folderLocation)) // if this base directory doesn't exist (it should on all Windows systems who have played the game)
            {
                return failedAutoDirSearch(documentsFolder, true); // run failed function (above)
            }
            string[] subdirs = Directory.GetDirectories(folderLocation); // get all sub directories.
            if (subdirs.Length == 0 || subdirs.Length >= 2) // check how many subdirs were returned, there should only be 1 (unless user has multiple steam accounts they played this game with, in which case they need to specify for themselves). if there's none, then the user hasn't played the game.
            {
                return failedAutoDirSearch(folderLocation, true); // run failed function (above)
            }
            string lastSuccessLocation = folderLocation;
            folderLocation = subdirs[0] + "\\savestorage\\snapshot\\"; // get the only sub dir and append on the location of the snapshot folder
            if (!Directory.Exists(folderLocation)) // if this folder doesn't exist (if all other checks have passed, the only way this could occur is user messing with folders)
            {
                return failedAutoDirSearch(lastSuccessLocation, true); // run failed function (above)
            }
            return folderLocation;
        }

        public static string detectFolderLinux()
        {
            string folderLocation = "/home/deck/.local/share/Steam/steamapps/compatdata/637650/pfx/dosdevices/c:/users/steamuser/Documents/My Games/Final Fantasy XV/Steam";
            if (!Directory.Exists(folderLocation)) // if this base directory doesn't exist (it should on all Windows systems who have played the game)
            {
                return failedAutoDirSearch("/", false); // run failed function (above)
            }
            string[] subdirs = Directory.GetDirectories(folderLocation); // get all sub directories.
            if (subdirs.Length == 0 || subdirs.Length >= 2) // check how many subdirs were returned, there should only be 1 (unless user has multiple steam accounts they played this game with, in which case they need to specify for themselves). if there's none, then the user hasn't played the game.
            {
                return failedAutoDirSearch(folderLocation, false); // run failed function (above)
            }
            string lastSuccessLocation = folderLocation;
            folderLocation = subdirs[0] + "/savestorage/snapshot/"; // get the only sub dir and append on the location of the snapshot folder
            if (!Directory.Exists(folderLocation)) // if this folder doesn't exist (if all other checks have passed, the only way this could occur is user messing with folders)
            {
                return failedAutoDirSearch(lastSuccessLocation, false); // run failed function (above)
            }
            return folderLocation;
        }
    }
}
