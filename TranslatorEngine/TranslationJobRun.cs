using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.Threading;
using Microsoft.VisualStudio.Shell;
using System.IO;

namespace LabelTranslator
{
    public class TranslationJobRun
    {
        public string LanguageIdFrom { get; private set; }
        public string LanguageIdTo { get; private set; }

        public Dictionary<int, Label> LabelsList { get; private set; }
        private Dictionary<int, string> LabelTextsList { get; set; }

        StringBuilder sb;

        public TranslationJobRun(string languageIdFrom, string languageIdTo)
        {
            LanguageIdFrom = languageIdFrom;
            LanguageIdTo = languageIdTo;

            sb = new StringBuilder();

            LabelsList = new Dictionary<int, Label>();
            LabelTextsList = new Dictionary<int, string>();
        }

        public void AddLabel(Label label, string labelText)
        {
            int num = LabelsList.Count;

            LabelsList.Add(num, label);

            if (LabelTranslatorEngine.TranslationServiceProvider.SupportInputStringArray())
                LabelTextsList.Add(num, labelText);
            else
                sb.AppendLine(string.Format("{0}|||{1}", num.ToString("D2"), labelText));
        }

        public void DoTranslate()
        {
            if (LabelTranslatorEngine.TranslationServiceProvider.SupportInputStringArray())
                DoTranslateArray();
            else
                DoTranslateString();
        }

        private void DoTranslateArray()
        {
            JoinableTaskFactory joinableTaskFactory = new JoinableTaskFactory(ThreadHelper.JoinableTaskContext);

            string[] dataToTranslate = new string[LabelTextsList.Count];
            foreach (KeyValuePair<int, string> item in LabelTextsList.OrderBy(lt => lt.Key))
                dataToTranslate[item.Key] = item.Value;

            string[] translatedData = joinableTaskFactory.Run(async delegate { return await TranslateTextAsync(dataToTranslate); });

            for (int i = 0; i < translatedData.Length; i++)
                LabelsList[i].LabelText = translatedData[i].Trim();
        }

        private void DoTranslateString()
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

        private async Task<string[]> TranslateTextAsync(string[] arrayToTranslate)
        {
            // handle null operations: no text or same source/target languages
            if (arrayToTranslate.Length == 0 || LanguageIdFrom == LanguageIdTo)
            {
                return arrayToTranslate;
            }

            return await LabelTranslatorEngine.TranslationServiceProvider.TranslateTextAsync(arrayToTranslate, LanguageIdFrom, LanguageIdTo);
        }

        private async Task<string> TranslateTextAsync(string textToTranslate)
        {
            // handle null operations: no text or same source/target languages
            if (textToTranslate == "" || LanguageIdFrom == LanguageIdTo)
            {
                return textToTranslate;
            }

            return await LabelTranslatorEngine.TranslationServiceProvider.TranslateTextAsync(textToTranslate, LanguageIdFrom, LanguageIdTo);
        }
    }
}
