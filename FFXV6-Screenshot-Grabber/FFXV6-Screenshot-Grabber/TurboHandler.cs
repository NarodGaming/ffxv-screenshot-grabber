using System.ComponentModel; // import needed for backgroundworker

namespace FFXV6_Screenshot_Grabber
{
    internal class TurboHandler // turbo will split up the writing of all screenshot files in to the number of threads the PC has, in order to dramatically speed up screenshot retrieval
    {
        public void configureTurbo(List<String> screenshotNames, string currPath, string newPath, mainWindow mainForm) { // called when you click the 'save all turbo' button
            foreach(var chunk in screenshotNames.Chunk(Environment.ProcessorCount)) { // splits the total amount of screenshots in to chunks to the amount of your CPU core count (not logical cores), and runs for each on this
                TurboWorker newWorker = new(chunk.ToList(), currPath, newPath, mainForm); // create a new worker with it's specific chunk
                newWorker.Start(); // tell the new worker to start
            }
        }
    }

    internal class TurboWorker // class which defines the worker itself
    {
        private BackgroundWorker worker; // worker has a background worker which handles the processing
        private List<String> screenshotList; // worker has a chunk of the total screenshot list
        private string currentPath; // link to the current path the screenshots are in
        private string newPath; // link to the new path the screenshots are in

        public TurboWorker(List<string> screenshotList, string currentPath, string newPath, mainWindow mainForm) // constructor
        {
            worker=new(); // create new background worker
            worker.DoWork += threadProcess; // assign relevant functions to their processing
            worker.RunWorkerCompleted += threadDone;
            worker.ProgressChanged += mainForm.turboReportProgress;
            worker.WorkerReportsProgress = true;
            this.screenshotList=screenshotList; // set up object variables from passed variables
            this.currentPath=currentPath;
            this.newPath=newPath;
        }

        public void Start() // simple function, simply starts the background worker
        {
            worker.RunWorkerAsync();
        }

        private void threadProcess(object sender, DoWorkEventArgs e) // this is the main processing of the worker
        {
            int i = 0;
            foreach (String screenshot in screenshotList) // for each screenshot in it's chunk
            {
                string fileName = newPath + screenshot.Split(".ss")[0] + ".jpg"; // define the new filename that will be used
                ScreenshotWriter.writeScreenshot(currentPath + screenshot, fileName); // run screenshotwriter (NOT the from all version, as this takes slightly more processing to return the image which we don't care about)
                i++;
                worker.ReportProgress(i / screenshotList.Count * 100);
            }
        }

        private void threadDone(object sender, RunWorkerCompletedEventArgs e) // function to run when background worker is done, disposes and clears vars, hopefully garbage collection does the rest...
        {
            worker.Dispose();
            screenshotList.Clear();
            currentPath = "";
            newPath = "";
        }
    }
}
