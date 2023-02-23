using System.Net;

namespace FFXV6_Screenshot_Grabber
{
    internal static class UpdateChecker
    {

        private async static Task<string> getLatestVersion()
        {
            try // try and catch, for in case theres no internet, url is down, etc.
            {
                HttpClient verRequest = new HttpClient(); // create a new httpclient to fetch the latest version
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

        public static bool checkForUpdate() // public function called to check for update
        {
            string latestVersion = getLatestVersion().GetAwaiter().GetResult(); // run function to retrieve remote version info
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
