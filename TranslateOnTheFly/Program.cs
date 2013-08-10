using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;


[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace TranslateOnTheFly
{
    static class Program
    {
        [STAThreadAttribute]
        // The main entry point for the application.
        static void Main()
        {
            //Load settings
            try
            {
                Settings settings = Settings.LoadSettings();
                Logger.log.Info("Settings loaded to memory");
            }
            catch (Exception)
            {
                //LOG + message
            }

            //Start application
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
