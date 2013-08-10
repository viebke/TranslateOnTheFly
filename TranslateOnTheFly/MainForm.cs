using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Xml;
using System.Threading;


namespace TranslateOnTheFly
{
    public partial class MainForm : Form
    {
        //Declare fields
        public Translator translator { get; set; }

        //
        //Constructor
        //
        public MainForm()
        {
            InitializeComponent();
            translator = new Translator();
        }

        #region callbacks generated from GUI builder

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Translate_Click(object sender, EventArgs e)
        {
            translate();
        }

        private void Settings_Click(object sender, EventArgs e)
        {
            Form settings = new SettingsForm();
            settings.Visible = true;
        }
        #endregion

        /**
         * Translates the text in the soruce text box
         * Gets data from clipboard if any
         * */
        private void translate()
        {
            try
            {
                Logger.log.Info("Entering translate in MainForm");

                //Set  wait cursor
                Cursor.Current = Cursors.WaitCursor;

                //Check if anything on clipboard
                if (Clipboard.ContainsText(TextDataFormat.Text) && String.IsNullOrEmpty(SourceText.Text))
                {
                    SourceText.Text = Clipboard.GetText();
                    Logger.log.Info("Got information from clipboard");
                }

                //Translate
                translator.SourceText = SourceText.Text;
                translator.Translate();
                TargetText.Text = translator.Translation;
                SourceText.Text = String.Empty; //Clear the source text
                Logger.log.Info("Translation done");
            }
            catch (Exception e)
            {
                //Log and show message
                Logger.log.Error("Exception occured while translation data", e);
                MessageBox.Show("An error occured while translating the text. The error occured with the message:" +
                    e.Message);

            }
            finally
            {
                //Go to target tab
                Tabs.SelectedTab = TargetTab;

                //Reset cursor
                Cursor.Current = Cursors.Default;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                Updater u = new Updater();
                u.update();
                Logger.log.Info("Updated languages");
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
                Logger.log.Error("Unable to update languages", ee);
            }

            
        }

    }
}
