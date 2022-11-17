using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FFXV6_Screenshot_Grabber
{
    public partial class imageExpander : Form
    {
        public imageExpander()
        {
            InitializeComponent();
        }

        public void retrieveScreenshot(Image newImage) // public function, called when preview image on mainWindow has been updated
        {
            previewBox.BackgroundImage = newImage; // set preview image on this window to be the new image passed
        }

        private void imageExpander_FormClosing(object sender, FormClosingEventArgs e) // when the user chooses to close this window
        {
            // this is required, otherwise we need to reinitialise this window if it's closed & re-opened, which is slow and requires more checking to be stable
            Hide(); // hide the window instead
            e.Cancel = true; // silently prevent window from being disposed/closed
        }
    }
}
