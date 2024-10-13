namespace FFXV6_Screenshot_Grabber
{
    internal static class ScreenshotWriter
    {
        /// <summary>
        /// Converts a .ss file in to a .jpg file.
        /// </summary>
        /// <param name="ssPath">The full path of the screenshot to read in, including extension.</param>
        /// <returns>The bytes of the .jpg contained within the .ss file</returns>
        /// <exception cref="ArgumentNullException">Thrown when the ssPath provided is null.</exception>
        /// <exception cref="FileNotFoundException">Thrown when the ssPath provided does not exist.</exception>
        /// <exception cref="ArgumentException">Thrown when the ssPath provided is not a .ss file.</exception>
        private static byte[] returnScreenshot(string ssPath) // used internally to convert the .ss file in to a usable .jpg
        {
            if (ssPath == null)
            {
                throw new ArgumentNullException("ssPath");
            } else if (!File.Exists(ssPath))
            {
                throw new FileNotFoundException("SS file path provided does not exist!");
            } else if (Path.GetExtension(ssPath) != ".ss")
            {
                throw new ArgumentException("SS file path provided is not a .ss file!");
            }
            byte[] bytes = File.ReadAllBytes(ssPath); // read the .ss file in as an array of bytes
            return bytes[36..(bytes.Length - 130)]; // return a specific subsection of the bytes (the original .ss file), effectively converting it from .ss to .jpg
        }

        /// <summary>
        /// Converts an array of (jpg) bytes in to an Image.
        /// </summary>
        /// <param name="ssBytes">Bytes of a jpg file, usually provided from <see cref="returnScreenshot(string)"/>.</param>
        /// <returns>An <c>Image</c> created from the Bytes provided</returns>
        /// <exception cref="ArgumentNullException">Thrown when the ssBytes provided are null.</exception>
        /// <exception cref="ArgumentException">Thrown when the ssBytes provided are empty.</exception>
        private static Image createImageFromBytes(byte[] ssBytes) // used internally to convert an array of jpg bytes to an Image
        {
            if (ssBytes == null)
            {
                throw new ArgumentNullException("ssBytes");
            } else if (ssBytes.Length == 0)
            {
                throw new ArgumentException("Bytes provided are empty!");
            }
            using (var bytems = new MemoryStream(ssBytes)) // bytems as memorystream, read in array of bytes
            {
                return Image.FromStream(bytems); // create an Image from this stream, and return it
            }
        }

        /// <summary>
        /// Takes in a .ss file, converts it to a .jpg, and writes it out to a new location.
        /// </summary>
        /// <param name="ssPath">The full path, including extension, of the .ss file to be read in</param>
        /// <param name="newPath">The full path, including extension, of the .jpeg file to be exported</param>
        /// <exception cref="ArgumentNullException">Thrown when either the ssPath or newPath provided are null.</exception>
        /// <exception cref="ArgumentException">Thrown when the ssPath provided is not a .ss file, or when the newPath provided is not a .jpg file.</exception>
        /// <exception cref="FileNotFoundException">Thrown when the ssPath provided does not exist.</exception>
        public static void writeScreenshot(string ssPath, string newPath) // public function, called when you click 'Save One' on mainWindow
        {
            if (ssPath == null)
            {
                throw new ArgumentNullException("ssPath");
            } else if (!File.Exists(ssPath))
            {
                throw new FileNotFoundException("SS file path provided does not exist!");
            } else if (Path.GetExtension(ssPath) != ".ss")
            {
                throw new ArgumentException("SS file path provided is not a .ss file!");
            }
            if (newPath == null)
            {
                throw new ArgumentNullException("newPath");
            } else if (Path.GetExtension(newPath) != ".jpg")
            {
                throw new ArgumentException("New file path provided is not a .jpg file!");
            }
            byte[] jpegSS = returnScreenshot(ssPath); // convert .ss file in to .jpg
            File.WriteAllBytes(newPath, jpegSS); // write the .jpg out to the chosen location
            File.SetCreationTimeUtc(newPath, File.GetCreationTimeUtc(ssPath)); // set the creation date to the original .ss files creation date, rather than when the conversion occurred
        }

        /// <summary>
        /// Returns an Image of the .jpg contained within the .ss file provided.
        /// </summary>
        /// <param name="ssPath">The full path, including extension, of the .ss file to be read in</param>
        /// <returns>An <c>Image</c> of the .jpg contained within the .ss file</returns>
        /// <exception cref="ArgumentNullException">Thrown when the ssPath provided is null.</exception>
        /// <exception cref="ArgumentException">Thrown when the ssPath provided is not a .ss file.</exception>
        /// <exception cref="FileNotFoundException">Thrown when the ssPath provided does not exist.</exception>
        public static Image returnImageScreenshot(string ssPath) // public function, called when you change listbox selected item (to update preview image)
        {
            if (ssPath == null)
            {
                throw new ArgumentNullException("ssPath");
            }
            else if (!File.Exists(ssPath))
            {
                throw new FileNotFoundException("SS file path provided does not exist!");
            }
            else if (Path.GetExtension(ssPath) != ".ss")
            {
                throw new ArgumentException("SS file path provided is not a .ss file!");
            }
            byte[] jpegSS = returnScreenshot(ssPath); // convert .ss file in to .jpg
            return createImageFromBytes(jpegSS); // return Image of .jpg to update preview
        }

        /// <summary>
        /// Takes in a .ss file, converts it to a .jpg, writes it out to a new location, and also returns a preview <c>Image</c> of the .jpg.
        /// </summary>
        /// <param name="ssPath">The full path, including extension, of the .ss file to be read in</param>
        /// <param name="newPath">The full path, including extension, of the .jpeg file to be exported</param>
        /// <returns>An <c>Image</c> of the .jpg contained within the .ss file</returns>
        /// <exception cref="ArgumentNullException">Thrown when the ssPath provided is null.</exception>
        /// <exception cref="ArgumentException">Thrown when the ssPath provided is not a .ss file.</exception>
        /// <exception cref="FileNotFoundException">Thrown when the ssPath provided does not exist.</exception>
        public static Image writeScreenshotFromAll(string ssPath, string newPath) // public function, called when you click 'Save All' on mainWindow
        {
            if (ssPath == null)
            {
                throw new ArgumentNullException("ssPath");
            }
            else if (!File.Exists(ssPath))
            {
                throw new FileNotFoundException("SS file path provided does not exist!");
            }
            else if (Path.GetExtension(ssPath) != ".ss")
            {
                throw new ArgumentException("SS file path provided is not a .ss file!");
            }
            if (newPath == null)
            {
                throw new ArgumentNullException("newPath");
            }
            else if (Path.GetExtension(newPath) != ".jpg")
            {
                throw new ArgumentException("New file path provided is not a .jpg file!");
            }
            byte[] imageBytes = returnScreenshot(ssPath); // convert .ss file in to .jpg
            File.WriteAllBytes(newPath, imageBytes); // writes the .jpg out to the chosen location
            File.SetCreationTimeUtc(newPath, File.GetCreationTimeUtc(ssPath)); // set the creation date to the original .ss files creation date, rather than when the conversion occurred
            return createImageFromBytes(imageBytes); // return Image of .jpg to update preview
        }
    }
}
