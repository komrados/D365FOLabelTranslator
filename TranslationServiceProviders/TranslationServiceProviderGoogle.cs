using Google.Cloud.Translate.V3;
using Google.Protobuf.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabelTranslator
{
    public class TranslationServiceProviderGoogle : TranslationServiceProviderBase
    {
        private TranslationServiceClient Client { get; set; }
        private string Project { get; set; }

        public TranslationServiceProviderGoogle(TranslationServiceProviderParameters parameters) : base(parameters)
        {
            TranslationServiceProviderParametersGoogle parametersGoogle = (TranslationServiceProviderParametersGoogle)parameters;

            Client = new TranslationServiceClientBuilder()
            {
                JsonCredentials = parametersGoogle.JsonCredentials

            }.Build();

            Project = parametersGoogle.Project;
        }

        public override bool SupportInputStringArray()
        {
            return true;
        }

        public override string[] GetLanguagesForTranslate()
        {
            List<string> languages = new List<string>();

            GetSupportedLanguagesRequest request = new GetSupportedLanguagesRequest() 
            { 
                Parent = Project 
            };

            var supportedLanguages = Client.GetSupportedLanguages(request);

            foreach (var language in supportedLanguages.Languages)
                languages.Add(language.LanguageCode);

            return languages.ToArray();
        }

        public async override Task<string> TranslateTextAsync(string textToTranslate, string languageIdFrom, string languageIdTo)
        {
            List<string> translatedTexts = new List<string>();

            TranslateTextRequest request = new TranslateTextRequest()
            {
                Contents = { textToTranslate },
                SourceLanguageCode = languageIdFrom,
                TargetLanguageCode = languageIdTo,
                Parent = Project
            };

            var response = await Client.TranslateTextAsync(request);

            foreach (var translation in response.Translations)
                translatedTexts.Add(translation.TranslatedText);

            return translatedTexts[0];
        }

        public async override Task<string[]> TranslateTextAsync(string[] arrayToTranslate, string languageIdFrom, string languageIdTo)
        {
            List<string> translatedTexts = new List<string>();

            TranslateTextRequest request = new TranslateTextRequest()
            {
                Contents = { arrayToTranslate },
                SourceLanguageCode = languageIdFrom,
                TargetLanguageCode = languageIdTo,
                Parent = Project
            };

            var response = await Client.TranslateTextAsync(request);

            foreach (var translation in response.Translations)
                translatedTexts.Add(translation.TranslatedText);

            return translatedTexts.ToArray();
        }
    }
}
