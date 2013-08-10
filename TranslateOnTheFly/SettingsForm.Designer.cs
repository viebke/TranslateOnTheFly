namespace TranslateOnTheFly
{
    partial class SettingsForm
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
            this.cbsrcLang = new System.Windows.Forms.ComboBox();
            this.cbdstLang = new System.Windows.Forms.ComboBox();
            this.labelSettingsSrcLang = new System.Windows.Forms.Label();
            this.labelSettingsDestLang = new System.Windows.Forms.Label();
            this.buttSettingsSave = new System.Windows.Forms.Button();
            this.buttSetCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbsrcLang
            // 
            this.cbsrcLang.FormattingEnabled = true;
            this.cbsrcLang.Location = new System.Drawing.Point(13, 31);
            this.cbsrcLang.Name = "cbsrcLang";
            this.cbsrcLang.Size = new System.Drawing.Size(121, 21);
            this.cbsrcLang.TabIndex = 0;
            // 
            // cbdstLang
            // 
            this.cbdstLang.FormattingEnabled = true;
            this.cbdstLang.Location = new System.Drawing.Point(141, 31);
            this.cbdstLang.Name = "cbdstLang";
            this.cbdstLang.Size = new System.Drawing.Size(121, 21);
            this.cbdstLang.TabIndex = 1;
            // 
            // labelSettingsSrcLang
            // 
            this.labelSettingsSrcLang.AutoSize = true;
            this.labelSettingsSrcLang.Location = new System.Drawing.Point(10, 9);
            this.labelSettingsSrcLang.Name = "labelSettingsSrcLang";
            this.labelSettingsSrcLang.Size = new System.Drawing.Size(92, 13);
            this.labelSettingsSrcLang.TabIndex = 2;
            this.labelSettingsSrcLang.Text = "Source Language";
            // 
            // labelSettingsDestLang
            // 
            this.labelSettingsDestLang.AutoSize = true;
            this.labelSettingsDestLang.Location = new System.Drawing.Point(138, 9);
            this.labelSettingsDestLang.Name = "labelSettingsDestLang";
            this.labelSettingsDestLang.Size = new System.Drawing.Size(111, 13);
            this.labelSettingsDestLang.TabIndex = 3;
            this.labelSettingsDestLang.Text = "Destination Language";
            // 
            // buttSettingsSave
            // 
            this.buttSettingsSave.Location = new System.Drawing.Point(13, 227);
            this.buttSettingsSave.Name = "buttSettingsSave";
            this.buttSettingsSave.Size = new System.Drawing.Size(121, 23);
            this.buttSettingsSave.TabIndex = 4;
            this.buttSettingsSave.Text = "Save";
            this.buttSettingsSave.UseVisualStyleBackColor = true;
            this.buttSettingsSave.Click += new System.EventHandler(this.buttSettingsSave_Click);
            // 
            // buttSetCancel
            // 
            this.buttSetCancel.Location = new System.Drawing.Point(141, 227);
            this.buttSetCancel.Name = "buttSetCancel";
            this.buttSetCancel.Size = new System.Drawing.Size(121, 23);
            this.buttSetCancel.TabIndex = 5;
            this.buttSetCancel.Text = "Cancel";
            this.buttSetCancel.UseVisualStyleBackColor = true;
            this.buttSetCancel.Click += new System.EventHandler(this.buttSetCancel_Click_1);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.buttSetCancel);
            this.Controls.Add(this.buttSettingsSave);
            this.Controls.Add(this.labelSettingsDestLang);
            this.Controls.Add(this.labelSettingsSrcLang);
            this.Controls.Add(this.cbdstLang);
            this.Controls.Add(this.cbsrcLang);
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbsrcLang;
        private System.Windows.Forms.ComboBox cbdstLang;
        private System.Windows.Forms.Label labelSettingsSrcLang;
        private System.Windows.Forms.Label labelSettingsDestLang;
        private System.Windows.Forms.Button buttSettingsSave;
        private System.Windows.Forms.Button buttSetCancel;
    }
}