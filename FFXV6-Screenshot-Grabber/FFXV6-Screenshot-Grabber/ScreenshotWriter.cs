using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection.Metadata.Ecma335;

namespace FFXV6_Screenshot_Grabber
{
    internal static class ScreenshotWriter
    {
        private static byte[] returnScreenshot(string ssPath) // used internally to convert the .ss file in to a usable .jpg
        {
            byte[] bytes = File.ReadAllBytes(ssPath); // read the .ss file in as an array of bytes
            return bytes[36..(bytes.Count()-130)]; // return a specific subsection of the bytes (the original .ss file), effectively converting it from .ss to .jpg
        }

        private static Image createImageFromBytes(byte[] ssBytes) // used internally to convert an array of jpg bytes to an Image
        {
            using (var bytems = new MemoryStream(ssBytes)) // bytems as memorystream, read in array of bytes
            {
                return Image.FromStream(bytems); // create an Image from this stream, and return it
            }
        }

        public static void writeScreenshot(string ssPath, string newPath) // public function, called when you click 'Save One' on mainWindow
        {
            byte[] jpegSS = returnScreenshot(ssPath); // convert .ss file in to .jpg
            File.WriteAllBytes(newPath, jpegSS); // write the .jpg out to the chosen location
            File.SetCreationTimeUtc(newPath, File.GetCreationTimeUtc(ssPath)); // set the creation date to the original .ss files creation date, rather than when the conversion occurred
        }

        public static Image returnImageScreenshot(string ssPath) // public function, called when you change listbox selected item (to update preview image)
        {
            byte[] jpegSS = returnScreenshot(ssPath); // convert .ss file in to .jpg
            return createImageFromBytes(jpegSS); // return Image of .jpg to update preview
        }

        public static Image writeScreenshotFromAll(string ssPath, string newPath) // public function, called when you click 'Save All' on mainWindow
        {
            byte[] imageBytes = returnScreenshot(ssPath); // convert .ss file in to .jpg
            File.WriteAllBytes(newPath, imageBytes); // writes the .jpg out to the chosen location
            File.SetCreationTimeUtc(newPath, File.GetCreationTimeUtc(ssPath)); // set the creation date to the original .ss files creation date, rather than when the conversion occurred
            return createImageFromBytes(imageBytes); // return Image of .jpg to update preview
        }
    }
}
