using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace LabelTranslator
{
    public abstract class TranslationServiceProviderBase
    {
        public TranslationServiceProviderBase(TranslationServiceProviderParameters parameters)
        {

        }

        public abstract bool SupportInputStringArray();

        public abstract Task<string> TranslateTextAsync(string textToTranslate, string languageIdFrom, string languageIdTo);
        public abstract Task<string[]> TranslateTextAsync(string[] arrayToTranslate, string languageIdFrom, string languageIdTo);

        public abstract string[] GetLanguagesForTranslate();

        public static TranslationServiceProviderBase Construct(TranslationServiceProviderParameters parameters)
        {
            switch (parameters.TranslationServiceProviderType)
            {
                case TranslationServiceProviderType.Yandex:
                    return new TranslationServiceProviderYandex(parameters);

                case TranslationServiceProviderType.Google:
                    return new TranslationServiceProviderGoogle(parameters);

                case TranslationServiceProviderType.Azure:
                    return new TranslationServiceProviderAzure(parameters);

                default:
                    throw new NotImplementedException();
            }
        }
    }

    public enum TranslationServiceProviderType
    {
        [Description("Yandex Translate")]
        Yandex,

        [Description("Google Cloud Translation")]
        Google,

        [Description("Azure Translator")]
        Azure
    }

}
