using Microsoft.Win32;

namespace FFXV6_Screenshot_Grabber
{
    internal class DarkMode // initialise class for dark mode
    {
        private static void AddDarkMode(Control nControl) // main function which handles each control (UI element) in a form
        {
            if (nControl is Button) // if the control is a button
            {
                Button buttonCast = (Button)nControl; // cast the control to a button (needed for FlatStyle)
                buttonCast.BackColor = Color.Black; // set back colour of button to black
                buttonCast.FlatStyle = FlatStyle.Flat; // change style to flat (default FlatStyle is System, which looks better in light mode but doesn't support back colour change)
            }
            else if (nControl is ListBox) // if the control is a listbox
            {
                nControl.BackColor = Color.Black; // set back colour to black
                nControl.ForeColor = Color.White; // set fore colour (text) to white
            }
            else if (nControl is Label) // if the control is a label
            {
                nControl.ForeColor = Color.White; // set fore colour (text) to white
                nControl.BackColor = Color.Black; // set back colour to black
            }
            else if (nControl is CheckBox) // if the control is a checkbox
            {
                nControl.ForeColor = Color.White; // set fore colour (text) to white
            }
            else if (nControl is ProgressBar) // if the control is a progressbar (BROKEN)
            {
                nControl.BackColor = Color.Black; // set back colour to black (BROKEN, it appears the control doesn't support colour changing)
            }
        }

        private static bool ShouldUseDarkMode() // private function called to run registry checks
        {
            bool isDarkMode = false; // set variable as default to false
            try
            {
                bool readLightModeReg = Convert.ToBoolean(Registry.GetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize", "AppsUseLightTheme", null)); // pull regkey for lightmode, true means light mode, false means dark mode
                if (!readLightModeReg) // if reg key returns false
                {
                    isDarkMode = true; // then change variable to confirm we need dark mode
                }
            }
            catch (Exception) // if there is any error running this
            {
                return false; // then return that dark mode is not needed
            }
            return isDarkMode; // return result
        }

        public static void SetupDarkMode(Form callingForm) // main public function to run all tasks
        {
            if (ShouldUseDarkMode()) // check if we need to set up dark mode
            {
                callingForm.ForeColor = Color.White; // if we do, then set fore colour (text) to white
                callingForm.BackColor = Color.Black; // set back colour to black
                foreach (Control cControl in callingForm.Controls) // for each control (UI element) on the form which called this function
                {
                    AddDarkMode(cControl); // add a dark mode to the control (UI element)
                }
            }
        }
    }
}
