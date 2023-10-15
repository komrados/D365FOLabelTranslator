using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using Microsoft.VisualStudio.Threading;
using Microsoft.VisualStudio.Shell;


namespace LabelTranslator
{
    public class TranslationServiceProviderYandex : TranslationServiceProviderBase
    {
        public string ApiKey { get; private set; }
        public string ApiEndpoint { get; private set; }
        public string FolderId { get; private set; }


        public TranslationServiceProviderYandex(TranslationServiceProviderParameters parameters) : base(parameters)
        {
            ApiKey = parameters.ApiKey;
            ApiEndpoint = parameters.ApiEndpoint.TrimEnd('/') + "/{0}";
            FolderId = ((TranslationServiceProviderParametersYandex)parameters).FolderId;
        }

        public override bool SupportInputStringArray()
        {
            return true;
        }

        public async Task<string[]> GetLanguagesForTranslateAsync()
        {
            List<string> languageCodes = new List<string>();

            // send HTTP request to perform the translation
            string uri = string.Format(ApiEndpoint, "languages");

            System.Object[] body = new System.Object[] { new { folderId = FolderId } };
            var requestBody = JsonConvert.SerializeObject(body);

            using (var client = new HttpClient())
            using (var request = new HttpRequestMessage())
            {
                request.Method = HttpMethod.Post;
                request.RequestUri = new Uri(uri);
                request.Headers.Add("Authorization", string.Format("Api-Key {0}", ApiKey));

                var response = await client.SendAsync(request);
                var responseBody = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                    throw new Exception(responseBody);

                var result = JsonConvert.DeserializeObject<Dictionary<string, List<Dictionary<string, string>>>>(responseBody);
                var languages = result["languages"];

                foreach (var language in languages)
                    languageCodes.Add(language["code"]);
            }

            return languageCodes.ToArray();
        }

        public override string[] GetLanguagesForTranslate()
        {
            JoinableTaskFactory joinableTaskFactory = new JoinableTaskFactory(ThreadHelper.JoinableTaskContext);

            return joinableTaskFactory.Run(async delegate { return await GetLanguagesForTranslateAsync(); });
        }

        public override async Task<string> TranslateTextAsync(string textToTranslate, string languageIdFrom, string languageIdTo)
        {
            string[] textToTranslateArray = { textToTranslate };
            string translatedText = "";

            // send HTTP request to perform the translation
            string uri = string.Format(ApiEndpoint, "translate");

            System.Object[] body = new System.Object[] { new { sourceLanguageCode = languageIdFrom, targetLanguageCode = languageIdTo, texts = textToTranslateArray, folderId = FolderId } };
            var requestBody = JsonConvert.SerializeObject(body[0]);

            using (var client = new HttpClient())
            using (var request = new HttpRequestMessage())
            {
                request.Method = HttpMethod.Post;
                request.RequestUri = new Uri(uri);
                request.Content = new StringContent(requestBody, Encoding.UTF8, "application/json");
                request.Headers.Add("Authorization", string.Format("Api-Key {0}", ApiKey));

                var response = await client.SendAsync(request);
                var responseBody = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                    throw new Exception(responseBody);

                var result = JsonConvert.DeserializeObject<Dictionary<string, List<Dictionary<string, string>>>>(responseBody);
                var translation = result["translations"][0]["text"];

                // Update the translation field
                translatedText = translation;
            }

            return translatedText;
        }

        public override async Task<string[]> TranslateTextAsync(string[] arrayToTranslate, string languageIdFrom, string languageIdTo)
        {
            List<string> translatedtexts = new List<string>();

            // send HTTP request to perform the translation
            string uri = string.Format(ApiEndpoint, "translate");

            System.Object[] body = new System.Object[] { new { sourceLanguageCode = languageIdFrom, targetLanguageCode = languageIdTo, texts = arrayToTranslate, folderId = FolderId } };
            var requestBody = JsonConvert.SerializeObject(body[0]);

            using (var client = new HttpClient())
            using (var request = new HttpRequestMessage())
            {
                request.Method = HttpMethod.Post;
                request.RequestUri = new Uri(uri);
                request.Content = new StringContent(requestBody, Encoding.UTF8, "application/json");
                request.Headers.Add("Authorization", string.Format("Api-Key {0}", ApiKey));

                var response = await client.SendAsync(request);
                var responseBody = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                    throw new Exception(responseBody);

                var result = JsonConvert.DeserializeObject<Dictionary<string, List<Dictionary<string, string>>>>(responseBody);

                foreach (var translation in result["translations"])
                    translatedtexts.Add(translation["text"]);
            }

            return translatedtexts.ToArray();

        }
    }
}
