using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;


namespace LabelTranslator
{
    public class TranslationServiceProviderAzure : TranslationServiceProviderBase
    {
        public string ApiKey { get; private set; }
        public string ApiEndpoint { get; private set; }
        public string Region { get; private set; }

        public TranslationServiceProviderAzure(TranslationServiceProviderParameters parameters) : base(parameters)
        {
            ApiKey = parameters.ApiKey;
            ApiEndpoint = parameters.ApiEndpoint.TrimEnd('/') + "/{0}?api-version=3.0";
            Region = ((TranslationServiceProviderParametersAzure)parameters).Region;
        }

        public override bool SupportInputStringArray()
        {
            return false;
        }

        public override string[] GetLanguagesForTranslate()
        {
            string[] languageCodes;

            // Send request to get supported language codes
            string uri = string.Format(ApiEndpoint, "languages") + "&scope=translation";
            WebRequest WebRequest = WebRequest.Create(uri);
            WebRequest.Headers.Add("Accept-Language", "en");
            WebResponse response = null;
            // Read and parse the JSON response
            response = WebRequest.GetResponse();
            using (var reader = new StreamReader(response.GetResponseStream(), UnicodeEncoding.UTF8))
            {
                var result = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, Dictionary<string, string>>>>(reader.ReadToEnd());
                var languages = result["translation"];

                languageCodes = languages.Keys.ToArray();
                //foreach (var kv in languages)
                //{
                //    languageCodesAndTitles.Add(kv.Value["name"], kv.Key);
                //}
            }

            return languageCodes;
        }

        public override async Task<string> TranslateTextAsync(string textToTranslate, string languageIdFrom, string languageIdTo)
        {
            string translatedText = "";

            // send HTTP request to perform the translation
            string endpoint = string.Format(ApiEndpoint, "translate");
            string uri = string.Format(endpoint + "&from={0}&to={1}", languageIdFrom, languageIdTo);

            System.Object[] body = new System.Object[] { new { Text = textToTranslate } };
            var requestBody = JsonConvert.SerializeObject(body);

            using (var client = new HttpClient())
            using (var request = new HttpRequestMessage())
            {
                request.Method = HttpMethod.Post;
                request.RequestUri = new Uri(uri);
                request.Content = new StringContent(requestBody, Encoding.UTF8, "application/json");
                request.Headers.Add("Ocp-Apim-Subscription-Key", ApiKey);
                request.Headers.Add("Ocp-Apim-Subscription-AzureRegion", Region);
                request.Headers.Add("X-ClientTraceId", Guid.NewGuid().ToString());

                var response = await client.SendAsync(request);
                var responseBody = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                    throw new Exception(responseBody);

                var result = JsonConvert.DeserializeObject<List<Dictionary<string, List<Dictionary<string, string>>>>>(responseBody);
                var translation = result[0]["translations"][0]["text"];

                // Update the translation field
                translatedText = translation;
            }

            return translatedText;
        }

        public override Task<string[]> TranslateTextAsync(string[] arrayToTranslate, string languageIdFrom, string languageIdTo)
        {
            // Azure doesn't support string arrays as translation input
            throw new NotImplementedException();
        }
    }
}
