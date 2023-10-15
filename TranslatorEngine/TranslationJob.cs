using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.Threading;
using Microsoft.VisualStudio.Shell;
using System.Diagnostics;

namespace LabelTranslator
{
    public class TranslationJob
    {
        public string LanguageIdFrom { get; private set; }
        public string LanguageIdTo { get; private set; }

        public List<Label> LabelsToTranslate { get; set; }
        public List<Label> LabelsTranslated { get; set; }

        public TranslationJob(string languageIdFrom, string languageIdTo)
        {
            LanguageIdFrom = languageIdFrom;
            LanguageIdTo = languageIdTo;
        }

        public void DoTranslate()
        {
            if (LabelsToTranslate.Count == 0)
                return;

            LabelsTranslated = new List<Label>();

            List<TranslationJobRun> translationJobRuns = new List<TranslationJobRun>();
            TranslationJobRun curTranslationJobRun = new TranslationJobRun(LanguageIdFrom, LanguageIdTo);
            translationJobRuns.Add(curTranslationJobRun);

            // Prepare labels to translate
            foreach (Label label in LabelsToTranslate)
            {
                Label labelToTranslate = new Label(label.LabelId);
                labelToTranslate.Comment = label.Comment;

                LabelsTranslated.Add(labelToTranslate);

                if (label.LabelText.Trim() == "")
                    continue;

                curTranslationJobRun.AddLabel(labelToTranslate, label.LabelText);

                if (curTranslationJobRun.LabelsList.Count() >= 24)
                {
                    curTranslationJobRun = new TranslationJobRun(LanguageIdFrom, LanguageIdTo);
                    translationJobRuns.Add(curTranslationJobRun);
                }
            }

            // Translate labels
            foreach (TranslationJobRun translationJobRun in translationJobRuns)
                translationJobRun.DoTranslate();

            Trace.WriteLine(string.Format("{0} labels translated from {1} to {2}", LabelsToTranslate.Count, LanguageIdFrom, LanguageIdTo));
        }
    }
}
