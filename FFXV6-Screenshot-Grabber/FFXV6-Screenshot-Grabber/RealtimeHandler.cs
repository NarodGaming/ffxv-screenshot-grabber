namespace FFXV6_Screenshot_Grabber
{
    internal class RealtimeHandler
    {
        mainWindow callingForm;
        FileSystemWatcher realtimeWatcher; // used for "realtime" mode
        string realTimeFolder; // used to store the location realtime screenshots should be stored in

        public RealtimeHandler(mainWindow formCalled, string folderToWatch)
        {
            callingForm = formCalled;
            realTimeFolder = folderToWatch;
            realtimeWatcher = new FileSystemWatcher(); // create a new filesystemwatcher
            realtimeWatcher.SynchronizingObject = callingForm; // set the object to sync to, to be the calling form
            realtimeWatcher.Path = realTimeFolder; // set the folder to watch, to the folder with the screenshots in
            realtimeWatcher.Created += realtimeScreenshotDetected; // set the function to be called if a new screenshot is detected
            realtimeWatcher.Deleted += realtimeScreenshotRemoved; // set the function to be called if that screenshot is deleted (likely by the game)
            realtimeWatcher.EnableRaisingEvents = true; // enable the filesystemwatcher
        }

        public void safeStop() // called when checkbox is unticked
        {
            realtimeWatcher.EnableRaisingEvents = false; // stop the watcher from raising new events
            realtimeWatcher.Dispose(); // dispose of the watcher
        }

        private void realtimeScreenshotDetected(object? sender, FileSystemEventArgs? e) // called whenever a new file is created in the watcher directory
        {
            if (e.Name.Contains(".ss") == false) // if the file does not contain ".ss" (a snapshot file)
            {
                return; // return, not interested in that file
            } // else
            callingForm.addToListBox(e.Name); // add it to the listbox
            string newFileName = e.Name.Split(".ss")[0]; // get just the name of the file without extension
            newFileName = newFileName + ".jpg"; // add the .jpg extension to the name of the file
            ScreenshotWriter.writeScreenshot(e.FullPath, realTimeFolder + "\\" + newFileName); // write the screenshot with the file name as .jpg
        }

        private void realtimeScreenshotRemoved(object? sender, FileSystemEventArgs? e) // when a snapshot file is removed (happens when user deletes it in-game, or rejects it at end of day)
        {
            if (e.Name.Contains(".ss") == false) // if the file does not contain ".ss" (a snapshot file)
            {
                return; // return, not interested in that file
            }
            callingForm.removeFromListBox(e.Name); // attempt to remove it from the listbox, it should exist
        }
    }
}
