namespace TranslateOnTheFly
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.Settings = new System.Windows.Forms.Button();
            this.Tabs = new System.Windows.Forms.TabControl();
            this.TargetTab = new System.Windows.Forms.TabPage();
            this.TargetText = new System.Windows.Forms.RichTextBox();
            this.SourceTab = new System.Windows.Forms.TabPage();
            this.SourceText = new System.Windows.Forms.RichTextBox();
            this.Translate = new System.Windows.Forms.Button();
            this.Tabs.SuspendLayout();
            this.TargetTab.SuspendLayout();
            this.SourceTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // Settings
            // 
            this.Settings.Location = new System.Drawing.Point(123, 234);
            this.Settings.Name = "Settings";
            this.Settings.Size = new System.Drawing.Size(104, 23);
            this.Settings.TabIndex = 1;
            this.Settings.Text = "&Settings";
            this.Settings.UseVisualStyleBackColor = true;
            this.Settings.Click += new System.EventHandler(this.Settings_Click);
            // 
            // Tabs
            // 
            this.Tabs.Controls.Add(this.TargetTab);
            this.Tabs.Controls.Add(this.SourceTab);
            this.Tabs.Location = new System.Drawing.Point(13, 13);
            this.Tabs.Name = "Tabs";
            this.Tabs.SelectedIndex = 0;
            this.Tabs.Size = new System.Drawing.Size(218, 215);
            this.Tabs.TabIndex = 3;
            // 
            // TargetTab
            // 
            this.TargetTab.Controls.Add(this.TargetText);
            this.TargetTab.Location = new System.Drawing.Point(4, 23);
            this.TargetTab.Name = "TargetTab";
            this.TargetTab.Padding = new System.Windows.Forms.Padding(3);
            this.TargetTab.Size = new System.Drawing.Size(210, 188);
            this.TargetTab.TabIndex = 0;
            this.TargetTab.Text = "Target";
            this.TargetTab.UseVisualStyleBackColor = true;
            // 
            // TargetText
            // 
            this.TargetText.Enabled = false;
            this.TargetText.Location = new System.Drawing.Point(0, 0);
            this.TargetText.MaximumSize = new System.Drawing.Size(241, 193);
            this.TargetText.MinimumSize = new System.Drawing.Size(214, 193);
            this.TargetText.Name = "TargetText";
            this.TargetText.Size = new System.Drawing.Size(214, 193);
            this.TargetText.TabIndex = 0;
            this.TargetText.Text = "";
            // 
            // SourceTab
            // 
            this.SourceTab.Controls.Add(this.SourceText);
            this.SourceTab.Location = new System.Drawing.Point(4, 22);
            this.SourceTab.Name = "SourceTab";
            this.SourceTab.Padding = new System.Windows.Forms.Padding(3);
            this.SourceTab.Size = new System.Drawing.Size(210, 189);
            this.SourceTab.TabIndex = 1;
            this.SourceTab.Text = "Source";
            this.SourceTab.UseVisualStyleBackColor = true;
            // 
            // SourceText
            // 
            this.SourceText.Location = new System.Drawing.Point(0, 0);
            this.SourceText.Name = "SourceText";
            this.SourceText.Size = new System.Drawing.Size(214, 193);
            this.SourceText.TabIndex = 0;
            this.SourceText.Text = "";
            // 
            // Translate
            // 
            this.Translate.Location = new System.Drawing.Point(13, 234);
            this.Translate.Name = "Translate";
            this.Translate.Size = new System.Drawing.Size(104, 23);
            this.Translate.TabIndex = 2;
            this.Translate.Text = "&Translate";
            this.Translate.UseVisualStyleBackColor = true;
            this.Translate.Click += new System.EventHandler(this.Translate_Click);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(243, 258);
            this.Controls.Add(this.Tabs);
            this.Controls.Add(this.Translate);
            this.Controls.Add(this.Settings);
            this.Font = new System.Drawing.Font("Verdana", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "Translate on the fly";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Tabs.ResumeLayout(false);
            this.TargetTab.ResumeLayout(false);
            this.SourceTab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Settings;
        private System.Windows.Forms.TabControl Tabs;
        private System.Windows.Forms.TabPage TargetTab;
        private System.Windows.Forms.Button Translate;
        private System.Windows.Forms.RichTextBox TargetText;
        private System.Windows.Forms.TabPage SourceTab;
        private System.Windows.Forms.RichTextBox SourceText;
    }
}

