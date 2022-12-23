using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void safeStop()
        {
            realtimeWatcher.EnableRaisingEvents = false;
            realtimeWatcher.Dispose();
        }

        private void realtimeScreenshotDetected(object? sender, FileSystemEventArgs? e)
        {
            if (e.Name.Contains(".ss") == false)
            {
                return;
            }
            callingForm.addToListBox(e.Name);
            string newFileName = e.Name.Split(".ss")[0];
            newFileName = newFileName + ".jpg";
            ScreenshotWriter.writeScreenshot(e.FullPath, realTimeFolder + "\\" + newFileName);
        }

        private void realtimeScreenshotRemoved(object? sender, FileSystemEventArgs? e)
        {
            if (e.Name.Contains(".ss") == false)
            {
                return;
            }
            callingForm.removeFromListBox(e.Name);
        }
    }
}
