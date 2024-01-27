namespace FFXV6_Screenshot_Grabber
{
    /// <summary>
    /// Handles the realtime mode, where the program watches a folder for new screenshots and converts them to .jpg
    /// </summary>
    internal class RealtimeHandler
    {
        mainWindow callingForm; // used to store the form that called this class - provide updates to the UI
        FileSystemWatcher realtimeWatcher; // used for "realtime" mode
        string realTimeFolder; // used to store the location realtime screenshots should be stored in

        /// <summary>
        /// Constructor for the realtime handler
        /// </summary>
        /// <param name="formCalled">The <c>mainWindow</c> that created RealtimeMode, for providing UI updates</param>
        /// <param name="folderToWatch">The folder where the .ss files will be appearing</param>
        /// <exception cref="ArgumentNullException">Thrown if the folderToWatch is null</exception>
        /// <exception cref="DirectoryNotFoundException">Thrown if the folderToWatch does not exist</exception>
        public RealtimeHandler(mainWindow formCalled, string folderToWatch)
        {
            if (folderToWatch == null) { 
                throw new ArgumentNullException("Realtime Mode folder is null!");
            } else if (Directory.Exists(folderToWatch) == false)
            {
                throw new DirectoryNotFoundException("Realtime Mode folder does not exist!");
            }
            callingForm = formCalled;
            realTimeFolder = folderToWatch;
            realtimeWatcher = new FileSystemWatcher(); // create a new filesystemwatcher
            realtimeWatcher.SynchronizingObject = callingForm; // set the object to sync to, to be the calling form
            realtimeWatcher.Path = realTimeFolder; // set the folder to watch, to the folder with the screenshots in
            realtimeWatcher.Created += realtimeScreenshotDetected; // set the function to be called if a new screenshot is detected
            realtimeWatcher.Deleted += realtimeScreenshotRemoved; // set the function to be called if that screenshot is deleted (likely by the game)
            realtimeWatcher.EnableRaisingEvents = true; // enable the filesystemwatcher
        }

        /// <summary>
        /// Handles the stopping of the realtime mode
        /// </summary>
        public void safeStop() // called when checkbox is unticked
        {
            realtimeWatcher.EnableRaisingEvents = false; // stop the watcher from raising new events
            realtimeWatcher.Dispose(); // dispose of the watcher
        }

        /// <summary>
        /// Handles the creation of a new screenshot file (e.g. taken in-game)
        /// </summary>
        private void realtimeScreenshotDetected(object? sender, FileSystemEventArgs? e) // called whenever a new file is created in the watcher directory
        {
            if (e is null) { return; } // ensures e is not null
            if (e.Name.Contains(".ss") == false) // if the file does not contain ".ss" (a snapshot file)
            {
                return; // return, not interested in that file
            } // else
            callingForm.addToListBox(e.Name); // add it to the listbox
            string newFileName = e.Name.Split(".ss")[0]; // get just the name of the file without extension
            newFileName = newFileName + ".jpg"; // add the .jpg extension to the name of the file
            ScreenshotWriter.writeScreenshot(e.FullPath, realTimeFolder + "\\" + newFileName); // write the screenshot with the file name as .jpg
        }

        /// <summary>
        /// Handles the deletion of a screenshot file (e.g. deleted from in-game menu, or not saved at end of day)
        /// </summary>
        private void realtimeScreenshotRemoved(object? sender, FileSystemEventArgs? e) // when a snapshot file is removed (happens when user deletes it in-game, or rejects it at end of day)
        {
            if (e is null) { return; } // ensures e is not null
            if (e.Name.Contains(".ss") == false) // if the file does not contain ".ss" (a snapshot file)
            {
                return; // return, not interested in that file
            }
            callingForm.removeFromListBox(e.Name); // attempt to remove it from the listbox, it should exist
        }
    }
}
