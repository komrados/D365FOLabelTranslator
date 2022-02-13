using EnvDTE;
using EnvDTE80;
using System;
using System.Windows;
using System.Net;
using System.Net.Http;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Microsoft.VisualStudio.Threading;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Task = System.Threading.Tasks.Task;

namespace LabelTranslator
{
    public class LabelTranslatorEngine
    {
        public static readonly string LABEL_FILE_DIRECTORY_NAME = "AxLabelFile";

        // This sample uses the Cognitive Services subscription key for all services. To learn more about
        // authentication options, see: https://docs.microsoft.com/azure/cognitive-services/authentication.
        public static string COGNITIVE_SERVICES_KEY;
        public static string COGNITIVE_SERVICES_REGION;
        // Endpoints for Translator and Bing Spell Check
        public static string TEXT_TRANSLATION_API_ENDPOINT;// = "https://api.cognitive.microsofttranslator.com/{0}?api-version=3.0";
        //const string BING_SPELL_CHECK_API_ENDPOINT = "https://westus.api.cognitive.microsoft.com/bing/v7.0/spellcheck/";
        // An array of language codes
        private string[] languageCodes;

        List<LabelFile> labelFiles;
        List<TranslateJob> translateJobs;

        LabelTranslationOptionPage optionsPage;
        CommandParameters commandParameters;
        string axLabelFileDirectory;

        public string Report { get; private set; }

        public void Execute(LabelTranslationOptionPage options, CommandParameters parameters)
        {
            optionsPage = options;
            commandParameters = parameters;

            InitParameters();

            GetLanguagesForTranslate();

            InitLabelFiles();

            LoadLabels();

            CreateTranslateJobs();

            DoTranslate();

            SaveLabels();

            UpdateXLIFF();

            GenerateReport();
        }

        private void InitParameters()
        {
            COGNITIVE_SERVICES_KEY = optionsPage.TranslatorKey;
            TEXT_TRANSLATION_API_ENDPOINT = optionsPage.TextTranslationApiEndpoint.TrimEnd('/') + "/{0}?api-version=3.0";
            COGNITIVE_SERVICES_REGION = optionsPage.Region;

            axLabelFileDirectory = commandParameters.FilePath.Substring(0, commandParameters.FilePath.IndexOf(LABEL_FILE_DIRECTORY_NAME) + LABEL_FILE_DIRECTORY_NAME.Length);
        }

        private void InitLabelFiles()
        {
            labelFiles = new List<LabelFile>();

            // Collect all *.xml label files with provided label file Id
            string searchPattern = string.Format("{0}_*.xml", commandParameters.LabelFileId);
            foreach (string fileName in Directory.GetFiles(axLabelFileDirectory, searchPattern))
                labelFiles.Add(new LabelFile(fileName));

            labelFiles.Find(lf => lf.LanguageId == commandParameters.LanguageId).IsBase = true;

            if (labelFiles.Where(lf => lf.IsBase == true).Count() != 1)
                throw new Exception("Incorrect translation base file");

            // Map AX language codes to translator language codes
            foreach (LabelFile labelFile in labelFiles)
            {
                string languageCode = labelFile.LanguageId.ToLower();
                string languageCodeShort = languageCode.Contains("-") ? languageCode.Substring(0, languageCode.IndexOf("-")) : languageCode;

                labelFile.TranslatorLanguageId = languageCodes.FirstOrDefault(lc => lc == languageCode || lc == languageCodeShort);
            }    
        }

        private void LoadLabels()
        {
            foreach (LabelFile labelFile in labelFiles)
                labelFile.LabelResourceFile.LoadLabels();
        }

        private void CreateTranslateJobs()
        {
            translateJobs = new List<TranslateJob>();

            LabelFile baseLabelFile = labelFiles.Find(lf => lf.IsBase == true);

            foreach (LabelFile labelFile in labelFiles.Where(lf => lf.IsBase == false && lf.TranslatorLanguageId != ""))
            {
                TranslateJob translateJob = new TranslateJob(baseLabelFile.TranslatorLanguageId, labelFile.TranslatorLanguageId);

                translateJob.LabelsToTranslate = baseLabelFile.LabelResourceFile.Labels.Except(labelFile.LabelResourceFile.Labels).ToList();
                translateJobs.Add(translateJob);

                labelFile.TranslateJob = translateJob;
            }
        }

        private void DoTranslate()
        {
            foreach (TranslateJob translateJob in translateJobs)
                translateJob.DoTranslate();
        }

        private void SaveLabels()
        {
            foreach (LabelFile labelFile in labelFiles.Where(lf => lf.IsBase == false && lf.TranslatorLanguageId != ""))
                labelFile.LabelResourceFile.SaveLabels(labelFile.TranslateJob.LabelsTranslated);
        }
        
        private void UpdateXLIFF()
        {
            // TODOs
        }

        private void GenerateReport()
        {
            StringBuilder sb = new StringBuilder();

            foreach (LabelFile labelFile in labelFiles.Where(lf => lf.LabelResourceFile.Report != null))
                sb.AppendLine(labelFile.LabelResourceFile.Report);

            sb.AppendLine("");
            sb.AppendLine("Translation complete");

            Report = sb.ToString();
        }

        private void GetLanguagesForTranslate()
        {
            // Send request to get supported language codes
            string uri = string.Format(TEXT_TRANSLATION_API_ENDPOINT, "languages") + "&scope=translation";
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
        }
    }
}
