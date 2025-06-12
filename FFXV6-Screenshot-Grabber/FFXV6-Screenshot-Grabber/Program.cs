using System.Globalization;

namespace FFXV6_Screenshot_Grabber
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            Thread.CurrentThread.CurrentUICulture = new CultureInfo("ja");


            ApplicationConfiguration.Initialize();
            Application.Run(new mainWindow());
        }
    }
}