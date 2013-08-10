using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RavSoft;
using System.Linq;

namespace TranslateOnTheFly
{
    /**
     * Class representing an updater for the languages and codes
     * */
    class Updater : RavSoft.WebResourceProvider
    {
        /**
         * Updates the list with languages
         * */
        public void update()
        {
            this.fetchResource(); //Get the resource
            parseContent(); //Parse and save the content
        }

        protected override string getFetchUrl()
        {
            return "http://translate.google.com";
        }

        /**
         * Parses and saves the content
         * */
        private void parseContent()
        {
            try
            {
                //Declare variables
                String contentToParse = String.Empty;
                String langToParse = String.Empty;
                List<Language> languages = new List<Language>();
                StringParser sp = new StringParser(this.Content);

                //Do the parsing
                sp.skipToEndOf("&#8212;</option>");
                sp.extractTo("</select>", ref contentToParse);
                String[] separations = { "</option>", "<option ", "value=" };
                String[] options = contentToParse.ToString().Split(separations, System.StringSplitOptions.RemoveEmptyEntries);
                options = options.Except(new List<string>() { "SELECTED " }).ToArray<string>();

                //Get languages
                languages = (from lang in options
                             select new Language
                             {
                                 code = lang.ToString().Split('>')[0].ToString(),
                                 name = lang.ToString().Split('>')[1].ToString()
                             }).ToList<Language>();

                //Write over current languages in settings and save them to file
                Settings.set.languages = languages.ToArray();
                Settings.SaveSettings();
            }
            catch (ArgumentNullException ae)
            {
                Logger.log.Error("Couldn't create language object from fetched data", ae);
                throw new Exception("Couldn't create language object from fetched data. See log for more information");
            }
            catch (Exception e)
            {
                Logger.log.Error("Exception occured", e);
                throw new Exception("Exception occured. See log for more information");
            }
        }


    }
}
