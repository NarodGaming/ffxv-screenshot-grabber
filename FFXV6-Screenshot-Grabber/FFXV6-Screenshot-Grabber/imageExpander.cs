namespace FFXV6_Screenshot_Grabber
{
    /// <summary>
    /// The imageExpander window is used to display a larger version of the screenshot preview image on the mainWindow.
    /// </summary>
    public partial class imageExpander : Form
    {
        /// <summary>
        /// ImageExpander constructor.
        /// </summary>
        public imageExpander()
        {
            InitializeComponent();

            DarkMode.SetupDarkMode(this);

            imageExpander_FirstSize(); // set the size of this window to be 1/4 of the screen width, with a 16:9 aspect ratio
        }

        /// <summary>
        /// Used to pass a new <c>Image</c> to this window, to be displayed in the preview box.
        /// </summary>
        /// <param name="newImage">The <c>Image</c> to be shown in this window</param>
        public void retrieveScreenshot(Image newImage) // public function, called when preview image on mainWindow has been updated
        {
            previewBox.BackgroundImage = newImage; // set preview image on this window to be the new image passed
        }

        /// <summary>
        /// Handles the ImageExpander window being closed by the user, intercepting the close event and hiding the window instead.
        /// </summary>
        private void imageExpander_FormClosing(object sender, FormClosingEventArgs e) // when the user chooses to close this window
        {
            // this is required, otherwise we need to reinitialise this window if it's closed & re-opened, which is slow and requires more checking to be stable
            Hide(); // hide the window instead
            e.Cancel = true; // silently prevent window from being disposed/closed
        }

        /// <summary>
        /// Automatically sizes the ImageExpander window to be 1/4 of the screen width, with a 16:9 aspect ratio.
        /// </summary>
        private void imageExpander_FirstSize()
        {
            // get the current screen size
            int width = Screen.PrimaryScreen.Bounds.Width;
            int height = Screen.PrimaryScreen.Bounds.Height;

            int newWidth = (width / 4) - ((width / 4) % 16); // calculate new width to be 1/4 of the screen width, rounded down to the nearest multiple of 16

            int newHeight = (newWidth * 9) / 16; // calculate new height to be 16:9 aspect ratio of the new width

            Size = new Size(newWidth, newHeight + 30); // set the size of this window to be the new width & height, plus 30 pixels for the title bar
        }
    }
}
