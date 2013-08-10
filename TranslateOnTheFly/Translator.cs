// Copyright (c) 2010 Ravi Bhavnani
// License: Code Project Open License
// http://www.codeproject.com/info/cpol10.aspx

using System;
using System.Collections.Generic;
using System.Net;
using System.IO;
using System.Linq;
using RavSoft;

namespace TranslateOnTheFly
{
    /// <summary>
    /// Translates text using Google's online language tools.
    /// </summary>
    public class Translator : WebResourceProvider
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="Translator"/> class.
        /// </summary>
        public Translator()
        {
            this.data = String.Empty;
        }

        #endregion

        /**  This region contians code taken from code project with some modifications **/
        #region Properties

        /// <summary>
        /// Gets or sets the source text.
        /// </summary>
        /// <value>The source text.</value>
        public string SourceText
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the translation.
        /// </summary>
        /// <value>The translated text.</value>
        public string Translation
        {
            get;
            private set;
        }

        #endregion

        /**  This region contians code taken from code project with some modifications **/
        #region Public methods

        /// <summary>
        /// Attempts to translate the text.
        /// </summary>
        public void Translate()
        {
            // Validate source and target languages
            if (string.IsNullOrEmpty(Settings.set.src) ||
                string.IsNullOrEmpty(Settings.set.dst) ||
                Settings.set.src.Trim().Equals(Settings.set.dst.Trim()))
            {
                throw new Exception("An invalid source or target language was specified.");
            }

            try
            {
                //Fetch content
                fetchData();
            }
            catch (Exception e)
            {
                Logger.log.Error("Exception occured while fetching data", e);
                throw new Exception("Unable to fetch data (check internet connection). See log for more information");
            }

            try
            {
                //Parse content
                parseContent();
            }
            catch (Exception e)
            {
                Logger.log.Error("Exception occured while fetching data", e);
                throw new Exception("Unable to parse the fetched data. See log for more information");
            }

        }

        #endregion

        /**  This region contians code taken from code project **/
        #region WebResourceProvider implementation

        /// <summary>
        /// Returns the url to be fetched.
        /// </summary>
        /// <returns>The url to be fetched.</returns>
        protected override string getFetchUrl()
        {
            return "http://translate.google.com/translate_t";

        }

        /// <summary>
        /// Retrieves the POST data (if any) to be sent to the url to be fetched.
        /// The data is returned as a string of the form "arg=val[&arg=val]...".
        /// </summary>
        /// <returns>A string containing the POST data or null if none.</returns>
        protected override string getPostData()
        {
            // Set translation mode
            string strPostData = string.Format("hl=en&ie=UTF8&oe=UTF8submit=Translate&langpair={0}|{1}",
                                                 convertStringToCode(Settings.set.src),
                                                 convertStringToCode(Settings.set.dst));

            // Set text to be translated
            strPostData += "&text=" + this.SourceText + "";
            return strPostData;
        }

        /// <summary>
        /// Parses the fetched content.
        /// </summary>
        protected override void parseContent()
        {
            try
            {
                // Initialize the scraper
                this.Translation = string.Empty;
                string strContent = this.data;
                StringParser parser = new StringParser(strContent);

                // Scrape the translation
                string strTranslation = string.Empty;
                if (parser.skipToEndOf("<span id=result_box"))
                {
                    if (parser.skipToEndOf("onmouseout=\"this.style.backgroundColor='#fff'\">"))
                    {
                        if (parser.extractTo("</span>", ref strTranslation))
                        {
                            strTranslation = StringParser.removeHtml(strTranslation);
                        }
                    }
                }

                #region Fix up the translation
                int startClean = 0;
                int endClean = 0;
                int i = 0;
                while (i < strTranslation.Length)
                {
                    if (Char.IsLetterOrDigit(strTranslation[i]))
                    {
                        startClean = i;
                        break;
                    }
                    i++;
                }
                i = strTranslation.Length - 1;
                while (i > 0)
                {
                    char ch = strTranslation[i];
                    if (Char.IsLetterOrDigit(ch) ||
                        (Char.IsPunctuation(ch) && (ch != '\"')))
                    {
                        endClean = i;
                        break;
                    }
                    i--;
                }

                this.Translation = strTranslation.Substring(startClean, endClean - startClean + 1).Replace("\"", "");
                #endregion
            }
            catch (Exception e)
            {
                Logger.log.Error("Exception occured while parsing data", e);
                throw new Exception("Unable to parse content: " + e.Message);
            }
        }

        #endregion

        #region Private methods

        /**
         * Fetch data via web request and saves it to data
         * */
        private void fetchData()
        {
            try
            {
                this.data = String.Empty; //Rest data

                //Create buffert and make request
                byte[] bytes = new byte[8192];
                String address = this.getFetchUrl() + "?" + this.getPostData();
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(address);
                req.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
                HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
                Stream dataStream = resp.GetResponseStream();

                //Get data from stream to string
                int ret = 1;
                while (ret > 0)
                {
                    ret = dataStream.Read(bytes, 0, bytes.Length);

                    if (ret > 0)
                        this.data += WebUtility.HtmlDecode(System.Text.Encoding.UTF8.GetString(bytes, 0, ret));
                   
                }
            }
            catch (Exception e)
            {
                Logger.log.Error("Exception occured while fetching data", e);
                throw new Exception("Unable to fetch data: " + e.Message);
            }
        }

        /**
         * Returns the code corresponding to the language
         */
        private static string convertStringToCode(String lang)
        {
            try
            {

                return (from c in Settings.set.languages
                        where lang.Equals(c.name)
                        select c.code).First<String>();
            }
            catch (Exception e)
            {
                Logger.log.Error("Exception occured while converting string to code", e);
                throw new Exception("Unable to find code for language in settings: " + e.Message);
            }
        }

        #endregion

        #region Fields
        /// <summary>
        /// The language to translation mode map.
        /// </summary>
        private static Dictionary<string, string> _languageModeMap;
        private String data;

        #endregion
    }
}
