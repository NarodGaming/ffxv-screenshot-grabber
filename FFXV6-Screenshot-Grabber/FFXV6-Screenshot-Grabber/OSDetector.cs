using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXV6_Screenshot_Grabber
{
    enum OperatingSystem
    {
        Unknown = 0,
        Windows = 1,
        Linux = 2,
        Mac = 3
    }

    internal class OSDetector
    {
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

            return platform;
        }
    }
}
