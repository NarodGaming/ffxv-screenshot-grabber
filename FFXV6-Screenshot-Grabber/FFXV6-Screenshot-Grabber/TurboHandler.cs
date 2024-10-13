using System.ComponentModel; // import needed for backgroundworker

namespace FFXV6_Screenshot_Grabber
{
    /// <summary>
    /// Handles turbo mode, which speeds up the saving of all screenshots by using multiple threads
    /// </summary>
    internal class TurboHandler // turbo will split up the writing of all screenshot files in to the number of threads the PC has, in order to dramatically speed up screenshot retrieval
    {
        /// <summary>
        /// Handles the creation of <see cref="TurboWorker"/>, by splitting the total amount of screenshots in to chunks, and creating a new worker for each chunk
        /// </summary>
        /// <param name="screenshotNames">A list of Strings containing the screenshots to be saved, with extension but not full file path.</param>
        /// <param name="currPath">The path (folder) containing all of the screenshots.</param>
        /// <param name="newPath">The path (folder) where the exported screenshots should be saved.</param>
        /// <param name="mainForm">The <see cref="mainWindow"/> of the utility, so progress can be passed back.</param>
        /// <exception cref="ArgumentException">Thrown when there are no screenshots to save, or if either <c>currPath</c> or <c>newPath</c> do not exist.</exception>
        /// <exception cref="ArgumentNullException">Thrown when either <c>currPath</c> or <c>newPath</c> are <c>null</c>.</exception>
        public void configureTurbo(List<String> screenshotNames, string currPath, string newPath, mainWindow mainForm) { // called when you click the 'save all turbo' button
            if (screenshotNames.Count == 0)
            {
                throw new ArgumentException("No screenshots to save!");
            }
            if (currPath == null) {
                throw new ArgumentNullException("currPath");
            } else if (Directory.Exists(currPath) == false)
            {
                throw new ArgumentException("Current path does not exist!");
            }
            if (newPath == null)
            {
                throw new ArgumentNullException("newPath");
            } else if (Directory.Exists(newPath) == false)
            {
                Directory.CreateDirectory(newPath); // this could be a problem if the user doesn't have permission to create a new directory, but that will just throw the relevant exception anyway
            }
            foreach(var chunk in screenshotNames.Chunk(Environment.ProcessorCount)) { // splits the total amount of screenshots in to chunks to the amount of your CPU core count (not logical cores), and runs for each on this
                TurboWorker newWorker = new(chunk.ToList(), currPath, newPath, mainForm); // create a new worker with it's specific chunk
                newWorker.Start(); // tell the new worker to start
            }
        }
    }

    /// <summary>
    /// TurboMode worker, which handles the processing of a chunk of screenshots
    /// </summary>
    internal class TurboWorker // class which defines the worker itself
    {
        private BackgroundWorker worker; // worker has a background worker which handles the processing
        private List<String> screenshotList; // worker has a chunk of the total screenshot list
        private string currentPath; // link to the current path the screenshots are in
        private string newPath; // link to the new path the screenshots are in

        /// <summary>
        /// Handles the creation of a new <see cref="TurboWorker"/>, and assigns the relevant variables to the background worker
        /// </summary>
        /// <param name="screenshotList">A list of Strings, assigned to this worker, containing the screenshots to be saved, with extension but not full file path.</param>
        /// <param name="currentPath">The path (folder) containing all of the screenshots.</param>
        /// <param name="newPath">The path (folder) where the exported screenshots should be saved.</param>
        /// <param name="mainForm">The <see cref="mainWindow"/> of the utility, so progress can be passed back.</param>
        public TurboWorker(List<string> screenshotList, string currentPath, string newPath, mainWindow mainForm) // constructor
        { // no specific error checking here, because all of that is run in the turbohandler
            worker=new(); // create new background worker
            worker.DoWork += threadProcess; // assign relevant functions to their processing
            worker.RunWorkerCompleted += threadDone;
            worker.ProgressChanged += mainForm.turboReportProgress;
            worker.WorkerReportsProgress = true;
            this.screenshotList=screenshotList; // set up object variables from passed variables
            this.currentPath=currentPath;
            this.newPath=newPath;
        }

        /// <summary>
        /// Starts the background worker
        /// </summary>
        public void Start() // simple function, simply starts the background worker
        {
            worker.RunWorkerAsync();
        }

        /// <summary>
        /// Handles the processing of the worker, by running <see cref="ScreenshotWriter.writeScreenshot(string, string)"/> for each screenshot in the chunk
        /// </summary>
        private void threadProcess(object? sender, DoWorkEventArgs e) // this is the main processing of the worker
        {
            int i = 0; // define a counter
            foreach (String screenshot in screenshotList) // for each screenshot in it's chunk
            {
                string fileName = newPath + screenshot.Split(".ss")[0] + ".jpg"; // define the new filename that will be used
                ScreenshotWriter.writeScreenshot(currentPath + screenshot, fileName); // run screenshotwriter (NOT the from all version, as this takes slightly more processing to return the image which we don't care about)
                i++; // increment the counter
                worker.ReportProgress(i / screenshotList.Count * 100); // report progress back to the main form
            }
        }

        /// <summary>
        /// Handles the completion of the worker, by disposing of the worker and clearing the variables
        /// </summary>
        private void threadDone(object? sender, RunWorkerCompletedEventArgs e) // function to run when background worker is done, disposes and clears vars, hopefully garbage collection does the rest...
        {
            worker.Dispose(); // dispose of the worker (clears it from memory)
            screenshotList.Clear(); // clear the screenshot list
            currentPath = ""; // clear the current path
            newPath = ""; // clear the new path
        }
    }
}
