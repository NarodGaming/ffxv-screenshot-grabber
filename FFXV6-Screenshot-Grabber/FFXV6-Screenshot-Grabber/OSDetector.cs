using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXV6_Screenshot_Grabber
{
    /// <summary>
    /// An enum to represent the operating system we're running on.
    /// </summary>
    enum OperatingSystem
    {
        Unknown = 0, // only used to configure enum object to default, should never be used
        Windows = 1, // Windows 10 and above
        Linux = 2, // Linux (officially, SteamOS only)
        Mac = 3, // Mac (officially, macOS Sonoma 14.0 and above)
        LegacyWindows = 4 // Windows 8.1 and below
    }

    /// <summary>
    /// Class to detect the operating system we're running on.
    /// </summary>
    internal class OSDetector
    {
        /// <summary>
        /// Checks specific registry keys to determine operating system.
        /// </summary>
        /// <returns><see cref="OperatingSystem"/> enum object, between <c>Windows</c>, <c>Linux</c> and <c>Mac</c></returns>
        public static OperatingSystem detectOS()
        {
            OperatingSystem platform = OperatingSystem.Windows;

            foreach (string subValueKey in Registry.CurrentUser.OpenSubKey("Software")?.GetSubKeyNames() ?? Array.Empty<string>()) // a good way of checking if we're running on Linux or Mac
            {
                if (subValueKey == "Wine") // if wine key exists, then we're on Linux or Mac
                {
                    platform = OperatingSystem.Linux; // set default to Linux, as we'll search on top to see if we're on Mac
                    foreach (string macSearchKey in Registry.CurrentUser.OpenSubKey("Software\\Wine")?.GetSubKeyNames() ?? Array.Empty<string>()) // a good way of checking if we're running on Mac - looking for a "Mac Driver" subkey
                    {
                        if (macSearchKey == "Mac Driver") // if we find the mac driver subkey, then we're actually on Mac and not Linux
                        {
                            platform = OperatingSystem.Mac; // set the platform to Mac
                            break; // break to save time, as we've found what we're looking for
                        }
                    }
                    break; // break to save time, as we've found what we're looking for
                }
            }

            if(platform == OperatingSystem.Windows)
            {
                // check if we have a new or old version of windows
                Version osVersion = Environment.OSVersion.Version;
                // if we have a version of windows that is less than windows 10, then we shall consider it to be legacy windows
                if (osVersion.Major < 10)
                {
                    platform = OperatingSystem.LegacyWindows;
                }
            }

            return platform;
        }
    }
}
