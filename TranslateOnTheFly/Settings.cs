using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace TranslateOnTheFly
{
    public class Settings
    {
        //Declare variables
        public Language[] languages { get; set; }
        public String src { get; set; }
        public String dst { get; set; }
        public static Settings set;
        static String FILENAME = "settings.xml";

        /**
         * Save settings to file
         * */
        public static void SaveSettings()
        {
            //Declare
            TextWriter writer = null;
            XmlSerializer serializer;

            try
            {
                //Serialize file
                if (set != null)
                {
                    serializer = new XmlSerializer(typeof(Settings));

                    using (writer = new StreamWriter(FILENAME, false))
                    {
                        serializer.Serialize(writer, set);
                        writer.Flush();

                        Logger.log.Info("Serialized settings Settings.xml");
                    }
                }
            }
            catch (IOException ie)
            {
                Logger.log.Error("Problem opening settings file. Do you have permissions to application folder", ie);
            }
            catch (Exception e)
            {
                Logger.log.Error("Exception occured", e);
            }
        }

        /*
         * Load settings from file
         * */
        public static Settings LoadSettings()
        {
            //Declare
            TextReader reader = null;
            XmlSerializer serializer;

            try
            {
                //Read and deserialize
                serializer = new XmlSerializer(typeof(Settings));
                using (reader = new StreamReader(FILENAME))
                {
                    set = (Settings)serializer.Deserialize(reader);
                    Logger.log.Info("Settings file loaded into memory");

                    //Check if src and/or dst is empty. Set default
                    if (String.IsNullOrEmpty(set.dst) || String.IsNullOrEmpty(set.src))
                    {
                        set.dst = "Swedish";
                        set.src = "English";
                        Logger.log.Info("Falling back t default language (English and Swedish)");
                    }
                }
                return set;

            }
            catch (FileNotFoundException fe)
            {
                Logger.log.Error("Settings file not find. Make sure Settings.xml is in the app dir", fe);
                throw new Exception("Settings file not found");
            }
            catch (Exception e)
            {
                Logger.log.Error("Exception occured", e);
                throw new Exception("Exception occured see log for more info");
            }
        }
    }
}
