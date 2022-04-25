using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using Microsoft.VisualStudio.Threading;
using Microsoft.VisualStudio.Shell;
using System.IO;

namespace LabelTranslator
{
    public class TranslateJobRun
    {
        public string LanguageIdFrom { get; private set; }
        public string LanguageIdTo { get; private set; }

        public Dictionary<int, Label> LabelsList { get; private set; }

        StringBuilder sb;

        public TranslateJobRun(string languageIdFrom, string languageIdTo)
        {
            LanguageIdFrom = languageIdFrom;
            LanguageIdTo = languageIdTo;

            sb = new StringBuilder();

            LabelsList = new Dictionary<int, Label>();
        }

        public void AddLabel(Label label, string labelText)
        {
            int num = LabelsList.Count;

            LabelsList.Add(num, label);

            sb.AppendLine(string.Format("{0}|||{1}", num.ToString("D2"), labelText));
        }

        public void DoTranslate()
        {
            JoinableTaskFactory joinableTaskFactory = new JoinableTaskFactory(ThreadHelper.JoinableTaskContext);

            string dataToTranslate = sb.ToString();
            string translatedData = joinableTaskFactory.Run(async delegate { return await TranslateTextAsync(dataToTranslate); });

            int i = 0;
            string line;
            StringReader sr = new StringReader(translatedData);
            while ((line = sr.ReadLine()) != null)
            {
                //string[] data = line.Split("|||");
                string[] data = line.Split( new string[] { "|||" }, StringSplitOptions.None);
                //int num = int.Parse(line.Substring(0, 2));
                int num = int.Parse(data[0]);

                if (i != num)
                    new Exception("Incorrect label position");

                LabelsList[num].LabelText = data[1].Trim(); //line.Substring(2).Trim();

                i++;
            }
        }

        private async Task<string> TranslateTextAsync(string textToTranslate)
        {
            string translatedText = "";

            // handle null operations: no text or same source/target languages
            if (textToTranslate == "" || LanguageIdFrom == LanguageIdTo)
            {
                translatedText = textToTranslate;
                return translatedText;
            }

            // send HTTP request to perform the translation
            string endpoint = string.Format(LabelTranslatorEngine.TEXT_TRANSLATION_API_ENDPOINT, "translate");
            string uri = string.Format(endpoint + "&from={0}&to={1}", LanguageIdFrom, LanguageIdTo);

            System.Object[] body = new System.Object[] { new { Text = textToTranslate } };
            var requestBody = JsonConvert.SerializeObject(body);

            using (var client = new HttpClient())
            using (var request = new HttpRequestMessage())
            {
                request.Method = HttpMethod.Post;
                request.RequestUri = new Uri(uri);
                request.Content = new StringContent(requestBody, Encoding.UTF8, "application/json");
                request.Headers.Add("Ocp-Apim-Subscription-Key", LabelTranslatorEngine.COGNITIVE_SERVICES_KEY);
                request.Headers.Add("Ocp-Apim-Subscription-Region", LabelTranslatorEngine.COGNITIVE_SERVICES_REGION);
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
    }
}
