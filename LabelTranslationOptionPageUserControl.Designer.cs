
namespace LabelTranslator
{
    partial class LabelTranslationOptionPageUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelTranslationServiceProvider = new System.Windows.Forms.Label();
            this.comboBoxTranslationServiceProvider = new System.Windows.Forms.ComboBox();
            this.groupBoxAzureTranslatorServiceParameters = new System.Windows.Forms.GroupBox();
            this.textBoxAzureRegion = new System.Windows.Forms.TextBox();
            this.labelAzureRegion = new System.Windows.Forms.Label();
            this.textBoxAzureApiEndpoint = new System.Windows.Forms.TextBox();
            this.labelAzureApiEndpoint = new System.Windows.Forms.Label();
            this.textBoxAzureApiKey = new System.Windows.Forms.TextBox();
            this.labelAzureApiKey = new System.Windows.Forms.Label();
            this.groupBoxYandexTranslatorServiceParameters = new System.Windows.Forms.GroupBox();
            this.textBoxYandexFolderId = new System.Windows.Forms.TextBox();
            this.labelYandexFolderId = new System.Windows.Forms.Label();
            this.textBoxYandexApiEndpoint = new System.Windows.Forms.TextBox();
            this.labelYandexApiEndpoint = new System.Windows.Forms.Label();
            this.textBoxYandexApiKey = new System.Windows.Forms.TextBox();
            this.labelYandexApiKey = new System.Windows.Forms.Label();
            this.groupBoxGoogleTranslatorServiceParameters = new System.Windows.Forms.GroupBox();
            this.textBoxGoogleProject = new System.Windows.Forms.TextBox();
            this.labelGoogleProject = new System.Windows.Forms.Label();
            this.textBoxGoogleJsonCredentials = new System.Windows.Forms.TextBox();
            this.labelGoogleJsonCredentials = new System.Windows.Forms.Label();
            this.groupBoxAzureTranslatorServiceParameters.SuspendLayout();
            this.groupBoxYandexTranslatorServiceParameters.SuspendLayout();
            this.groupBoxGoogleTranslatorServiceParameters.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelTranslationServiceProvider
            // 
            this.labelTranslationServiceProvider.AutoSize = true;
            this.labelTranslationServiceProvider.Location = new System.Drawing.Point(17, 20);
            this.labelTranslationServiceProvider.Name = "labelTranslationServiceProvider";
            this.labelTranslationServiceProvider.Size = new System.Drawing.Size(140, 13);
            this.labelTranslationServiceProvider.TabIndex = 1;
            this.labelTranslationServiceProvider.Text = "Translation service provider:";
            // 
            // comboBoxTranslationServiceProvider
            // 
            this.comboBoxTranslationServiceProvider.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxTranslationServiceProvider.FormattingEnabled = true;
            this.comboBoxTranslationServiceProvider.Location = new System.Drawing.Point(173, 17);
            this.comboBoxTranslationServiceProvider.Name = "comboBoxTranslationServiceProvider";
            this.comboBoxTranslationServiceProvider.Size = new System.Drawing.Size(296, 21);
            this.comboBoxTranslationServiceProvider.TabIndex = 2;
            this.comboBoxTranslationServiceProvider.SelectionChangeCommitted += new System.EventHandler(this.comboBoxTranslationServiceProvider_SelectionChangeCommitted);
            // 
            // groupBoxAzureTranslatorServiceParameters
            // 
            this.groupBoxAzureTranslatorServiceParameters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxAzureTranslatorServiceParameters.Controls.Add(this.textBoxAzureRegion);
            this.groupBoxAzureTranslatorServiceParameters.Controls.Add(this.labelAzureRegion);
            this.groupBoxAzureTranslatorServiceParameters.Controls.Add(this.textBoxAzureApiEndpoint);
            this.groupBoxAzureTranslatorServiceParameters.Controls.Add(this.labelAzureApiEndpoint);
            this.groupBoxAzureTranslatorServiceParameters.Controls.Add(this.textBoxAzureApiKey);
            this.groupBoxAzureTranslatorServiceParameters.Controls.Add(this.labelAzureApiKey);
            this.groupBoxAzureTranslatorServiceParameters.Location = new System.Drawing.Point(17, 230);
            this.groupBoxAzureTranslatorServiceParameters.Name = "groupBoxAzureTranslatorServiceParameters";
            this.groupBoxAzureTranslatorServiceParameters.Size = new System.Drawing.Size(468, 107);
            this.groupBoxAzureTranslatorServiceParameters.TabIndex = 3;
            this.groupBoxAzureTranslatorServiceParameters.TabStop = false;
            this.groupBoxAzureTranslatorServiceParameters.Text = "Azure translator service parameters";
            // 
            // textBoxAzureRegion
            // 
            this.textBoxAzureRegion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxAzureRegion.Location = new System.Drawing.Point(156, 77);
            this.textBoxAzureRegion.Name = "textBoxAzureRegion";
            this.textBoxAzureRegion.Size = new System.Drawing.Size(296, 20);
            this.textBoxAzureRegion.TabIndex = 7;
            this.textBoxAzureRegion.TextChanged += new System.EventHandler(this.textBoxAzureRegion_TextChanged);
            // 
            // labelAzureRegion
            // 
            this.labelAzureRegion.AutoSize = true;
            this.labelAzureRegion.Location = new System.Drawing.Point(10, 80);
            this.labelAzureRegion.Name = "labelAzureRegion";
            this.labelAzureRegion.Size = new System.Drawing.Size(90, 13);
            this.labelAzureRegion.TabIndex = 6;
            this.labelAzureRegion.Text = "Location/Region:";
            // 
            // textBoxAzureApiEndpoint
            // 
            this.textBoxAzureApiEndpoint.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxAzureApiEndpoint.Location = new System.Drawing.Point(156, 51);
            this.textBoxAzureApiEndpoint.Name = "textBoxAzureApiEndpoint";
            this.textBoxAzureApiEndpoint.Size = new System.Drawing.Size(296, 20);
            this.textBoxAzureApiEndpoint.TabIndex = 5;
            this.textBoxAzureApiEndpoint.TextChanged += new System.EventHandler(this.textBoxAzureApiEndpoint_TextChanged);
            // 
            // labelAzureApiEndpoint
            // 
            this.labelAzureApiEndpoint.AutoSize = true;
            this.labelAzureApiEndpoint.Location = new System.Drawing.Point(10, 54);
            this.labelAzureApiEndpoint.Name = "labelAzureApiEndpoint";
            this.labelAzureApiEndpoint.Size = new System.Drawing.Size(72, 13);
            this.labelAzureApiEndpoint.TabIndex = 4;
            this.labelAzureApiEndpoint.Text = "API Endpoint:";
            // 
            // textBoxAzureApiKey
            // 
            this.textBoxAzureApiKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxAzureApiKey.Location = new System.Drawing.Point(156, 25);
            this.textBoxAzureApiKey.Name = "textBoxAzureApiKey";
            this.textBoxAzureApiKey.Size = new System.Drawing.Size(296, 20);
            this.textBoxAzureApiKey.TabIndex = 3;
            this.textBoxAzureApiKey.UseSystemPasswordChar = true;
            this.textBoxAzureApiKey.TextChanged += new System.EventHandler(this.textBoxAzureApiKey_TextChanged);
            // 
            // labelAzureApiKey
            // 
            this.labelAzureApiKey.AutoSize = true;
            this.labelAzureApiKey.Location = new System.Drawing.Point(10, 28);
            this.labelAzureApiKey.Name = "labelAzureApiKey";
            this.labelAzureApiKey.Size = new System.Drawing.Size(48, 13);
            this.labelAzureApiKey.TabIndex = 2;
            this.labelAzureApiKey.Text = "API Key:";
            // 
            // groupBoxYandexTranslatorServiceParameters
            // 
            this.groupBoxYandexTranslatorServiceParameters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxYandexTranslatorServiceParameters.Controls.Add(this.textBoxYandexFolderId);
            this.groupBoxYandexTranslatorServiceParameters.Controls.Add(this.labelYandexFolderId);
            this.groupBoxYandexTranslatorServiceParameters.Controls.Add(this.textBoxYandexApiEndpoint);
            this.groupBoxYandexTranslatorServiceParameters.Controls.Add(this.labelYandexApiEndpoint);
            this.groupBoxYandexTranslatorServiceParameters.Controls.Add(this.textBoxYandexApiKey);
            this.groupBoxYandexTranslatorServiceParameters.Controls.Add(this.labelYandexApiKey);
            this.groupBoxYandexTranslatorServiceParameters.Location = new System.Drawing.Point(17, 44);
            this.groupBoxYandexTranslatorServiceParameters.Name = "groupBoxYandexTranslatorServiceParameters";
            this.groupBoxYandexTranslatorServiceParameters.Size = new System.Drawing.Size(468, 108);
            this.groupBoxYandexTranslatorServiceParameters.TabIndex = 8;
            this.groupBoxYandexTranslatorServiceParameters.TabStop = false;
            this.groupBoxYandexTranslatorServiceParameters.Text = "Yandex translator service parameters";
            // 
            // textBoxYandexFolderId
            // 
            this.textBoxYandexFolderId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxYandexFolderId.Location = new System.Drawing.Point(156, 77);
            this.textBoxYandexFolderId.Name = "textBoxYandexFolderId";
            this.textBoxYandexFolderId.Size = new System.Drawing.Size(296, 20);
            this.textBoxYandexFolderId.TabIndex = 7;
            this.textBoxYandexFolderId.TextChanged += new System.EventHandler(this.textBoxYandexFolderId_TextChanged);
            // 
            // labelYandexFolderId
            // 
            this.labelYandexFolderId.AutoSize = true;
            this.labelYandexFolderId.Location = new System.Drawing.Point(10, 80);
            this.labelYandexFolderId.Name = "labelYandexFolderId";
            this.labelYandexFolderId.Size = new System.Drawing.Size(51, 13);
            this.labelYandexFolderId.TabIndex = 6;
            this.labelYandexFolderId.Text = "Folder Id:";
            // 
            // textBoxYandexApiEndpoint
            // 
            this.textBoxYandexApiEndpoint.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxYandexApiEndpoint.Location = new System.Drawing.Point(156, 51);
            this.textBoxYandexApiEndpoint.Name = "textBoxYandexApiEndpoint";
            this.textBoxYandexApiEndpoint.Size = new System.Drawing.Size(296, 20);
            this.textBoxYandexApiEndpoint.TabIndex = 5;
            this.textBoxYandexApiEndpoint.TextChanged += new System.EventHandler(this.textBoxYandexApiEndpoint_TextChanged);
            // 
            // labelYandexApiEndpoint
            // 
            this.labelYandexApiEndpoint.AutoSize = true;
            this.labelYandexApiEndpoint.Location = new System.Drawing.Point(10, 54);
            this.labelYandexApiEndpoint.Name = "labelYandexApiEndpoint";
            this.labelYandexApiEndpoint.Size = new System.Drawing.Size(72, 13);
            this.labelYandexApiEndpoint.TabIndex = 4;
            this.labelYandexApiEndpoint.Text = "API Endpoint:";
            // 
            // textBoxYandexApiKey
            // 
            this.textBoxYandexApiKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxYandexApiKey.Location = new System.Drawing.Point(156, 25);
            this.textBoxYandexApiKey.Name = "textBoxYandexApiKey";
            this.textBoxYandexApiKey.Size = new System.Drawing.Size(296, 20);
            this.textBoxYandexApiKey.TabIndex = 3;
            this.textBoxYandexApiKey.UseSystemPasswordChar = true;
            this.textBoxYandexApiKey.TextChanged += new System.EventHandler(this.textBoxYandexApiKey_TextChanged);
            // 
            // labelYandexApiKey
            // 
            this.labelYandexApiKey.AutoSize = true;
            this.labelYandexApiKey.Location = new System.Drawing.Point(10, 28);
            this.labelYandexApiKey.Name = "labelYandexApiKey";
            this.labelYandexApiKey.Size = new System.Drawing.Size(48, 13);
            this.labelYandexApiKey.TabIndex = 2;
            this.labelYandexApiKey.Text = "API Key:";
            // 
            // groupBoxGoogleTranslatorServiceParameters
            // 
            this.groupBoxGoogleTranslatorServiceParameters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxGoogleTranslatorServiceParameters.Controls.Add(this.textBoxGoogleProject);
            this.groupBoxGoogleTranslatorServiceParameters.Controls.Add(this.labelGoogleProject);
            this.groupBoxGoogleTranslatorServiceParameters.Controls.Add(this.textBoxGoogleJsonCredentials);
            this.groupBoxGoogleTranslatorServiceParameters.Controls.Add(this.labelGoogleJsonCredentials);
            this.groupBoxGoogleTranslatorServiceParameters.Location = new System.Drawing.Point(17, 343);
            this.groupBoxGoogleTranslatorServiceParameters.Name = "groupBoxGoogleTranslatorServiceParameters";
            this.groupBoxGoogleTranslatorServiceParameters.Size = new System.Drawing.Size(468, 83);
            this.groupBoxGoogleTranslatorServiceParameters.TabIndex = 8;
            this.groupBoxGoogleTranslatorServiceParameters.TabStop = false;
            this.groupBoxGoogleTranslatorServiceParameters.Text = "Google cloud translation parameters";
            // 
            // textBoxGoogleProject
            // 
            this.textBoxGoogleProject.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxGoogleProject.Location = new System.Drawing.Point(156, 51);
            this.textBoxGoogleProject.Name = "textBoxGoogleProject";
            this.textBoxGoogleProject.Size = new System.Drawing.Size(296, 20);
            this.textBoxGoogleProject.TabIndex = 7;
            this.textBoxGoogleProject.TextChanged += new System.EventHandler(this.textBoxGoogleProject_TextChanged);
            // 
            // labelGoogleProject
            // 
            this.labelGoogleProject.AutoSize = true;
            this.labelGoogleProject.Location = new System.Drawing.Point(10, 54);
            this.labelGoogleProject.Name = "labelGoogleProject";
            this.labelGoogleProject.Size = new System.Drawing.Size(43, 13);
            this.labelGoogleProject.TabIndex = 6;
            this.labelGoogleProject.Text = "Project:";
            // 
            // textBoxGoogleJsonCredentials
            // 
            this.textBoxGoogleJsonCredentials.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxGoogleJsonCredentials.Location = new System.Drawing.Point(156, 25);
            this.textBoxGoogleJsonCredentials.Name = "textBoxGoogleJsonCredentials";
            this.textBoxGoogleJsonCredentials.Size = new System.Drawing.Size(296, 20);
            this.textBoxGoogleJsonCredentials.TabIndex = 3;
            this.textBoxGoogleJsonCredentials.UseSystemPasswordChar = true;
            this.textBoxGoogleJsonCredentials.TextChanged += new System.EventHandler(this.textBoxGoogleJsonCredentials_TextChanged);
            // 
            // labelGoogleJsonCredentials
            // 
            this.labelGoogleJsonCredentials.AutoSize = true;
            this.labelGoogleJsonCredentials.Location = new System.Drawing.Point(10, 28);
            this.labelGoogleJsonCredentials.Name = "labelGoogleJsonCredentials";
            this.labelGoogleJsonCredentials.Size = new System.Drawing.Size(87, 13);
            this.labelGoogleJsonCredentials.TabIndex = 2;
            this.labelGoogleJsonCredentials.Text = "Json Credentials:";
            // 
            // LabelTranslationOptionPageUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.groupBoxGoogleTranslatorServiceParameters);
            this.Controls.Add(this.groupBoxYandexTranslatorServiceParameters);
            this.Controls.Add(this.groupBoxAzureTranslatorServiceParameters);
            this.Controls.Add(this.comboBoxTranslationServiceProvider);
            this.Controls.Add(this.labelTranslationServiceProvider);
            this.Name = "LabelTranslationOptionPageUserControl";
            this.Size = new System.Drawing.Size(496, 437);
            this.Load += new System.EventHandler(this.LabelTranslationOptionPageUserControl_Load);
            this.groupBoxAzureTranslatorServiceParameters.ResumeLayout(false);
            this.groupBoxAzureTranslatorServiceParameters.PerformLayout();
            this.groupBoxYandexTranslatorServiceParameters.ResumeLayout(false);
            this.groupBoxYandexTranslatorServiceParameters.PerformLayout();
            this.groupBoxGoogleTranslatorServiceParameters.ResumeLayout(false);
            this.groupBoxGoogleTranslatorServiceParameters.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTranslationServiceProvider;
        private System.Windows.Forms.ComboBox comboBoxTranslationServiceProvider;
        private System.Windows.Forms.GroupBox groupBoxAzureTranslatorServiceParameters;
        private System.Windows.Forms.Label labelAzureApiKey;
        private System.Windows.Forms.TextBox textBoxAzureApiKey;
        private System.Windows.Forms.TextBox textBoxAzureRegion;
        private System.Windows.Forms.Label labelAzureRegion;
        private System.Windows.Forms.TextBox textBoxAzureApiEndpoint;
        private System.Windows.Forms.Label labelAzureApiEndpoint;
        private System.Windows.Forms.GroupBox groupBoxYandexTranslatorServiceParameters;
        private System.Windows.Forms.TextBox textBoxYandexFolderId;
        private System.Windows.Forms.Label labelYandexFolderId;
        private System.Windows.Forms.TextBox textBoxYandexApiEndpoint;
        private System.Windows.Forms.Label labelYandexApiEndpoint;
        private System.Windows.Forms.TextBox textBoxYandexApiKey;
        private System.Windows.Forms.Label labelYandexApiKey;
        private System.Windows.Forms.GroupBox groupBoxGoogleTranslatorServiceParameters;
        private System.Windows.Forms.TextBox textBoxGoogleProject;
        private System.Windows.Forms.Label labelGoogleProject;
        private System.Windows.Forms.TextBox textBoxGoogleJsonCredentials;
        private System.Windows.Forms.Label labelGoogleJsonCredentials;
    }
}
