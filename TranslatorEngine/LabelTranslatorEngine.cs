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
using System.Diagnostics;

namespace LabelTranslator
{
    public class LabelTranslatorEngine
    {
        public static readonly string LABEL_FILE_DIRECTORY_NAME = "AxLabelFile";

        public static TranslationServiceProviderBase TranslationServiceProvider { get; private set; }

        // An array of language codes
        private string[] languageCodes;

        List<LabelFile> labelFiles;
        List<TranslationJob> translationJobs;

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

            CreateTranslationJobs();

            DoTranslate();

            SaveLabels();

            UpdateXLIFF();

            GenerateReport();
        }

        private void InitParameters()
        {
            Trace.Listeners.Add(new DefaultTraceListener());
            Trace.AutoFlush = true;
            Trace.Indent();

            TranslationServiceProviderParameters translationServiceProviderParameters = optionsPage.GetTranslationServiceProviderParameters();
            TranslationServiceProvider = TranslationServiceProviderBase.Construct(translationServiceProviderParameters);

            axLabelFileDirectory = commandParameters.FilePath.Substring(0, commandParameters.FilePath.IndexOf(LABEL_FILE_DIRECTORY_NAME) + LABEL_FILE_DIRECTORY_NAME.Length);
        }

        private void InitLabelFiles()
        {
            labelFiles = new List<LabelFile>();

            // Collect all *.xml label files with provided label file Id
            string searchPattern = string.Format("{0}_*.xml", commandParameters.LabelFileId);
            foreach (string fileName in Directory.GetFiles(axLabelFileDirectory, searchPattern))
            {
                if (!Path.GetFileNameWithoutExtension(fileName).Substring(commandParameters.LabelFileId.Length + 1).Contains("_"))
                    labelFiles.Add(new LabelFile(fileName));
            }

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

        private void CreateTranslationJobs()
        {
            translationJobs = new List<TranslationJob>();

            LabelFile baseLabelFile = labelFiles.Find(lf => lf.IsBase == true);

            foreach (LabelFile labelFile in labelFiles.Where(lf => lf.IsBase == false && lf.TranslatorLanguageId != ""))
            {
                TranslationJob translationJob = new TranslationJob(baseLabelFile.TranslatorLanguageId, labelFile.TranslatorLanguageId);

                translationJob.LabelsToTranslate = baseLabelFile.LabelResourceFile.Labels.Except(labelFile.LabelResourceFile.Labels).ToList();
                translationJobs.Add(translationJob);

                labelFile.TranslationJob = translationJob;
            }
        }

        private void DoTranslate()
        {
            foreach (TranslationJob translationJob in translationJobs)
                translationJob.DoTranslate();
        }

        private void SaveLabels()
        {
            foreach (LabelFile labelFile in labelFiles.Where(lf => lf.IsBase == false && lf.TranslatorLanguageId != ""))
                labelFile.LabelResourceFile.SaveLabels(labelFile.TranslationJob.LabelsTranslated);
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

            Trace.Unindent();
        }

        private void GetLanguagesForTranslate()
        {
            languageCodes = TranslationServiceProvider.GetLanguagesForTranslate();
        }
    }
}
