using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FFXV6_Screenshot_Grabber
{
    internal static class UpdateChecker
    {

        private static string getLatestVersion()
        {
            try // try and catch, for in case theres no internet, url is down, etc.
            {
                WebRequest verRequest = WebRequest.Create("https://ngserve.games/cdn/ffxvsg/latest-ver.txt"); // open a webrequest to the URL storing the version info
                using (WebResponse response = verRequest.GetResponse()) // get the response of the webrequest, store it in response
                {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream())) // use a streamreader to get the output from the respose
                    {
                        return reader.ReadToEnd(); // return the streamreader (which will be version in format Vx.x.x)
                    }
                }
            } catch (Exception) // if something has gone wrong
            {
                return "V0.0.0"; // return a 0 version number, so it will never ask the user to update 
            }
        }

        public static bool checkForUpdate() // public function called to check for update
        {
            string latestVersion = getLatestVersion(); // run function to retrieve remote version info
            string latestVersionRaw = latestVersion.Substring(1); // remove the "V" at the start. this is in the remote version for potential future use for a better version checker
            latestVersionRaw = latestVersionRaw.Replace(".", ""); // replace the "." with nothing so can be converted to int, this is in the remote version for potential future use for a better version checker
            int latestVersionInt = Convert.ToInt32(latestVersionRaw); // convert the above string to int

            string currentVersion = Application.ProductVersion; // get the current version of the installed FFXVSG
            string currentVersionRaw = currentVersion.Replace(".", ""); // replace the "." with nothing so can be converted to int
            int currentVersionInt = Convert.ToInt32(currentVersionRaw); // convert the above string to int

            if (latestVersionInt > currentVersionInt) // if the latest (remote) version info is bigger than the local number
            {
                return true; // then an update is required
            }
            return false; // otherwise, it is not
        }
    }
}
