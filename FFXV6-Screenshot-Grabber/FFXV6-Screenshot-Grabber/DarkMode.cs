using Microsoft.Win32;

namespace FFXV6_Screenshot_Grabber
{
    internal class DarkMode
    {
        private static void AddDarkMode(Control pControl)
        {
            Control nControl = pControl; // allows re-use of code by setting variables to match
            if (nControl is Button)
            {
                Button buttonCast = (Button)nControl;
                buttonCast.BackColor = Color.Black;
                buttonCast.FlatStyle = FlatStyle.Flat;
            }
            else if (nControl is ListBox)
            {
                nControl.BackColor = Color.Black;
                nControl.ForeColor = Color.White;
            }
            else if (nControl is Label)
            {
                nControl.ForeColor = Color.White;
                nControl.BackColor = Color.Black;
            }
            else if (nControl is CheckBox)
            {
                nControl.ForeColor = Color.White;
            }
            else if (nControl is ProgressBar)
            {
                nControl.BackColor = Color.Black;
            }
        }

        private static bool ShouldUseDarkMode()
        {
            bool isDarkMode = false;
            try
            {
                bool readLightModeReg = Convert.ToBoolean(Registry.GetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize", "AppsUseLightTheme", null));
                if (!readLightModeReg)
                {
                    isDarkMode = true;
                }
            }
            catch (Exception)
            {
                return false;
            }
            return isDarkMode;
        }

        public static void SetupDarkMode(Form callingForm)
        {
            if (ShouldUseDarkMode())
            {
                callingForm.ForeColor = Color.White;
                callingForm.BackColor = Color.Black;
                foreach (Control cControl in callingForm.Controls)
                {
                    AddDarkMode(cControl);
                }
            }
        }
    }
}
