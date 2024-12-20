﻿using System.Reflection;

namespace FFXV6_Screenshot_Grabber
{
    internal static class UpdateChecker
    {

        /// <summary>
        /// This function is used to retrieve the latest version number of the utility from the remote server
        /// </summary>
        /// <returns>A Task (of String), the result of which contains the latest version number as fetched from the remote server.</returns>
        private async static Task<string> getLatestVersion()
        {
            try // try and catch, for in case theres no internet, url is down, etc.
            {
                HttpClient verRequest = new(); // create a new httpclient to fetch the latest version
                HttpResponseMessage verResponse = await verRequest.GetAsync("https://ngserve.games/cdn/ffxvsg/latest-ver.txt"); // get the web page holding the latest ver info
                if (verResponse.IsSuccessStatusCode) // if we received a success HTTP code
                {
                    return await verResponse.Content.ReadAsStringAsync(); // read the web page and return the version
                }
            } catch (Exception) // if something has gone wrong
            {
                return "V0.0.0"; // return a 0 version number, so it will never ask the user to update 
            }
            return "V0.0.0"; // will occur if error HTTP code is returned
        }

        /// <summary>
        /// This function is used to check if an update is required
        /// </summary>
        /// <returns>Boolean, <c>True</c> if a newer version is available, <c>False</c> if a newer version isn't available.</returns>
        public static bool checkForUpdate() // public function called to check for update
        {
            string latestVersion = getLatestVersion().GetAwaiter().GetResult(); // run function to retrieve remote version info
            string latestVersionRaw = latestVersion[1..]; // remove the "V" at the start. this is in the remote version for potential future use for a better version checker
            latestVersionRaw = latestVersionRaw.Replace(".", ""); // replace the "." with nothing so can be converted to int, this is in the remote version for potential future use for a better version checker
            int latestVersionInt = Convert.ToInt32(latestVersionRaw); // convert the above string to int

            string currentVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString(); // get the current version of the installed FFXVSG
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
