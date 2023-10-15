using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabelTranslator
{
    public partial class LabelTranslationOptionPageUserControl : UserControl
    {
        internal LabelTranslationOptionPage OptionPage { get; set; }

        public LabelTranslationOptionPageUserControl()
        {
            InitializeComponent();
        }

        private void LabelTranslationOptionPageUserControl_Load(object sender, EventArgs e)
        {
            comboBoxTranslationServiceProvider.DataSource = Enum.GetValues(typeof(TranslationServiceProviderType)).Cast<Enum>()
                                                                    .Select(value => new
                                                                    {
                                                                        Description = (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()), typeof(DescriptionAttribute)) as DescriptionAttribute)?.Description ?? value.ToString(),
                                                                        value
                                                                    })
                                                                    .OrderBy(item => item.value)
                                                                    .ToList();

            comboBoxTranslationServiceProvider.DisplayMember = "Description";
            comboBoxTranslationServiceProvider.ValueMember = "value";

            comboBoxTranslationServiceProvider.SelectedValue = OptionPage.TranslationServiceProviderType;

            textBoxAzureApiKey.Text = OptionPage.AzureApiKey;
            textBoxAzureApiEndpoint.Text = OptionPage.AzureApiEndpoint;
            textBoxAzureRegion.Text = OptionPage.AzureRegion;

            textBoxYandexApiKey.Text = OptionPage.YandexApiKey;
            textBoxYandexApiEndpoint.Text = OptionPage.YandexApiEndpoint;
            textBoxYandexFolderId.Text = OptionPage.YandexFolderId;

            textBoxGoogleJsonCredentials.Text = OptionPage.GoogleJsonCredentials;
            textBoxGoogleProject.Text = OptionPage.GoogleProject;

            updateLayout();
        }

        private void comboBoxTranslationServiceProvider_SelectionChangeCommitted(object sender, EventArgs e)
        {
            OptionPage.TranslationServiceProviderType = (TranslationServiceProviderType)comboBoxTranslationServiceProvider.SelectedValue;

            updateLayout();
        }

        private void updateLayout()
        {
            groupBoxAzureTranslatorServiceParameters.Visible = OptionPage.TranslationServiceProviderType == TranslationServiceProviderType.Azure;
            groupBoxYandexTranslatorServiceParameters.Visible = OptionPage.TranslationServiceProviderType == TranslationServiceProviderType.Yandex;
            groupBoxGoogleTranslatorServiceParameters.Visible = OptionPage.TranslationServiceProviderType == TranslationServiceProviderType.Google;

            groupBoxAzureTranslatorServiceParameters.Location = groupBoxYandexTranslatorServiceParameters.Location;
            groupBoxGoogleTranslatorServiceParameters.Location = groupBoxYandexTranslatorServiceParameters.Location;


        }

        private void textBoxAzureApiKey_TextChanged(object sender, EventArgs e)
        {
            OptionPage.AzureApiKey = textBoxAzureApiKey.Text;
        }

        private void textBoxAzureApiEndpoint_TextChanged(object sender, EventArgs e)
        {
            OptionPage.AzureApiEndpoint = textBoxAzureApiEndpoint.Text;
        }

        private void textBoxAzureRegion_TextChanged(object sender, EventArgs e)
        {
            OptionPage.AzureRegion = textBoxAzureRegion.Text;
        }

        private void textBoxYandexApiKey_TextChanged(object sender, EventArgs e)
        {
            OptionPage.YandexApiKey = textBoxYandexApiKey.Text;
        }

        private void textBoxYandexApiEndpoint_TextChanged(object sender, EventArgs e)
        {
            OptionPage.YandexApiEndpoint = textBoxYandexApiEndpoint.Text;
        }

        private void textBoxYandexFolderId_TextChanged(object sender, EventArgs e)
        {
            OptionPage.YandexFolderId = textBoxYandexFolderId.Text;
        }

        private void textBoxGoogleJsonCredentials_TextChanged(object sender, EventArgs e)
        {
            OptionPage.GoogleJsonCredentials = textBoxGoogleJsonCredentials.Text;
        }

        private void textBoxGoogleProject_TextChanged(object sender, EventArgs e)
        {
            OptionPage.GoogleProject = textBoxGoogleProject.Text;
        }
    }
}
