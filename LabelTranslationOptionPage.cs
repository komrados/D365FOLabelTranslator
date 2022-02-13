using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;

namespace LabelTranslator
{
    public class LabelTranslationOptionPage : DialogPage
    {
        private string translatorKey;
        private string textTranslationApiEndpoint;
        private string region;

        [Category("Azure")]
        [DisplayName("Translator service key")]
        [Description("Azure translator service key")]
        [PasswordPropertyText(true)]
        public string TranslatorKey
        {
            get { return translatorKey; }
            set { translatorKey = value; }
        }

        [Category("Azure")]
        [DisplayName("Text translation API")]
        [Description("Text translation API Endpoint")]       
        public string TextTranslationApiEndpoint
        {
            get { return textTranslationApiEndpoint; }
            set { textTranslationApiEndpoint = value; }
        }

        [Category("Azure")]
        [DisplayName("Location/Region")]
        [Description("This is the location (or region) of your resource. You may need to use this field when making calls to this API.")]
        public string Region
        {
            get { return region; }
            set { region = value; }
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
