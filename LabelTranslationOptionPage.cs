using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using System.Windows.Forms;

namespace LabelTranslator
{
    public class LabelTranslationOptionPage : DialogPage
    {
        private TranslationServiceProviderType translationServiceProviderTypeValue;

        // Azure translation service parameters
        private string azureApiKey;
        private string azureApiEndpoint;
        private string azureRegion;

        // Yandex translator service parameters
        private string yandexApiKey;
        private string yandexApiEndpoint;
        private string yandexFolderId;

        // Google cloud translation parameters
        private string googleJsonCredentials;
        private string googleProject;

        protected override IWin32Window Window
        {
            get
            {
                LabelTranslationOptionPageUserControl page = new LabelTranslationOptionPageUserControl();
                page.OptionPage = this;
                return page;
            }
        }

        public TranslationServiceProviderType TranslationServiceProviderType
        {
            get { return translationServiceProviderTypeValue; }
            set { translationServiceProviderTypeValue = value; }
        }


        public string AzureApiKey
        {
            get { return azureApiKey; }
            set { azureApiKey = value; }
        }

        public string AzureApiEndpoint
        {
            get { return azureApiEndpoint; }
            set { azureApiEndpoint = value; }
        }

        public string AzureRegion
        {
            get { return azureRegion; }
            set { azureRegion = value; }
        }


        public string YandexApiKey
        {
            get { return yandexApiKey; }
            set { yandexApiKey = value; }
        }

        public string YandexApiEndpoint
        {
            get { return yandexApiEndpoint; }
            set { yandexApiEndpoint = value; }
        }

        public string YandexFolderId
        {
            get { return yandexFolderId; }
            set { yandexFolderId = value; }
        }


        public string GoogleJsonCredentials
        {
            get { return googleJsonCredentials; }
            set { googleJsonCredentials = value; }
        }
        public string GoogleProject
        {
            get { return googleProject; }
            set { googleProject = value; }
        }

        public TranslationServiceProviderParameters GetTranslationServiceProviderParameters()
        {
            switch (TranslationServiceProviderType)
            {
                case TranslationServiceProviderType.Yandex:
                    return new TranslationServiceProviderParametersYandex(YandexApiKey, YandexApiEndpoint, YandexFolderId);

                case TranslationServiceProviderType.Azure:
                    return new TranslationServiceProviderParametersAzure(AzureApiKey, AzureApiEndpoint, AzureRegion);

                case TranslationServiceProviderType.Google:
                    return new TranslationServiceProviderParametersGoogle(GoogleJsonCredentials, GoogleProject);

                default:
                    throw new NotImplementedException();
            }
        }


        public override void LoadSettingsFromStorage()
        {
            base.LoadSettingsFromStorage();
        }

        public override void SaveSettingsToStorage()
        {
            base.SaveSettingsToStorage();
        }

        public override void LoadSettingsFromXml(IVsSettingsReader reader)
        {
            base.LoadSettingsFromXml(reader);
        }
    }
}
