using Microsoft.Win32;

namespace FFXV6_Screenshot_Grabber
{
    /// <summary>
    /// Handles Dark Mode for WinForms GUI elements
    /// </summary>
    internal class DarkMode // initialise class for dark mode
    {
        /// <summary>
        /// Run on <see cref="Control"/> to configure Dark Mode colouring, styling and events
        /// </summary>
        /// <param name="nControl"><c>Button</c>, <c>ListBox</c>, <c>Label</c>, <c>CheckBox</c> or <c>GroupBox</c> controls (any other controls will be ignored)</param>
        private static void AddDarkMode(Control nControl) // main function which handles each control (UI element) in a form
        {
            if (nControl is Button) // if the control is a button
            {
                Button buttonCast = (Button)nControl; // cast the control to a button (needed for FlatStyle)
                buttonCast.BackColor = Color.FromArgb(33, 33, 33); // set back colour of button to (near) black
                buttonCast.FlatStyle = FlatStyle.Flat; // change style to flat (default FlatStyle is System, which looks better in light mode but doesn't support back colour change)
                buttonCast.MouseEnter += buttonMouseEnter; // add event for when mouse enters the bounds of the button, so we can 'highlight' it
                buttonCast.MouseLeave += buttonMouseLeave; // add event for when mouse leaves the bounds of the button, so we can 'unhighlight' it
                // the above will cause disabled buttons to have 'blank' text, so any disabled buttons should also be hidden
            }
            else if (nControl is ListBox || nControl is Label) // if the control is a listbox or label (same code used)
            {
                nControl.BackColor = Color.FromArgb(33, 33, 33); // set back colour to (near) black
                nControl.ForeColor = Color.FromArgb(238, 238, 238); // set fore colour (text) to (near) white
            }
            else if (nControl is CheckBox) // if the control is a checkbox
            {
                nControl.ForeColor = Color.FromArgb(238, 238, 238); // set fore colour (text) to (near) white
            }
            // progressbar colour setting used to be here - it was removed because it doesn't work
            else if (nControl is GroupBox)
            {
                nControl.ForeColor = Color.FromArgb(238, 238, 238); // set fore colour (text) to (near) white
                foreach (Control c in nControl.Controls) // as a group box can contain other controls, we need to iterate through those controls
                {
                    AddDarkMode(c); // recursively call this function for the control
                }
            }
            else if (nControl is TableLayoutPanel)
            {
                foreach (Control c in nControl.Controls)
                {
                    AddDarkMode(c); // recursively call this function for the control
                }
            }
        }

        /// <summary>
        /// Checks a specific registry key to see if Dark Mode should be used (Windows 8 and above (no Linux/Mac support), otherwise determined as False)
        /// </summary>
        /// <returns><c>True</c> if the system has Dark Mode selected, <c>False</c> if Dark Mode isn't selected, or the system doesn't support Dark Mode</returns>
        private static bool ShouldUseDarkMode() // private function called to run registry checks
        {
            bool isDarkMode = false; // set variable as default to false
            try
            {
                bool readLightModeReg; // create the bool object (to be used if the reg key exists)
                object? readLightModeRegObject = Registry.GetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize", "AppsUseLightTheme", null); // get the value at the reg key, or return null if it does not exist
                if (readLightModeRegObject != null) { readLightModeReg = Convert.ToBoolean(readLightModeRegObject); } else { readLightModeReg = true; } // if the reg key isn't null (so it exists) cast the value of it to a bool and store it in the bool object created, otherwise (if the reg key doesnt exist) light mode is enabled / dark mode is unsupported on system (e.g. win7)
                if (!readLightModeReg) // if light mode is false
                {
                    isDarkMode = true; // then dark mode is true
                }
            }
            catch (Exception) // if there is any error running this
            {
                return false; // then return that dark mode is not needed
            }
            return isDarkMode; // return result
        }

        /// <summary>
        /// Recursively sets up Dark Mode for all <see cref="Control"/>s on a <see cref="Form"/>
        /// </summary>
        /// <param name="callingForm">The <see cref="Form"/> you would like to configure Dark Mode on</param>
        public static void SetupDarkMode(Form callingForm) // main public function to run all tasks
        {
            if (ShouldUseDarkMode()) // check if we need to set up dark mode
            {
                callingForm.ForeColor = Color.FromArgb(238, 238, 238); // if we do, then set fore colour (text) to (near) white
                callingForm.BackColor = Color.FromArgb(33, 33, 33); // set back colour to black
                foreach (Control cControl in callingForm.Controls) // for each control (UI element) on the form which called this function
                {
                    AddDarkMode(cControl); // add a dark mode to the control (UI element)
                }
            }
        }

        /// <summary>
        /// Dark Mode event for <see cref="Button"/>s, which highlights the button when the mouse enters the bounds of the button
        /// </summary>
        public static void buttonMouseLeave(object sender, EventArgs e) // when button leaves the bounds of the button
        {
            Button buttonCast = (Button)sender; // cast the object to a button (which won't fail, this event is only applied to buttons)

            buttonCast.BackColor = Color.FromArgb(33, 33, 33); // change the back color back to (near) black
        }

        /// <summary>
        /// Dark Mode event for <see cref="Button"/>s, which unhighlights the button when the mouse leaves the bounds of the button
        /// </summary>
        public static void buttonMouseEnter(object sender, EventArgs e) // when button enters the bounds of the button
        {
            Button buttonCast = (Button)sender; // cast the object to a button (which won't fail, this event is only applied to buttons)

            buttonCast.BackColor = Color.FromArgb(66, 66, 66); // change the back color to grey (highlighting it)
        }
    }
}
