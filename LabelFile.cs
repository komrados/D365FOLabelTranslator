using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;

namespace LabelTranslator
{
    public class LabelFile
    {
        public bool IsBase { get; set; }

        public string LabelFileId { get; private set; }
        public string LanguageId { get; private set; }
        public string LabelResourceFilePath { get; private set; }
        public string FilePath { get; private set; }

        public string TranslatorLanguageId { get; set; }

        public LabelResourceFile LabelResourceFile { get; private set; }
        public TranslateJob TranslateJob { get; set; }

        public LabelFile(string filePath)
        {
            FilePath = filePath;

            loadXML();

            LabelResourceFile = new LabelResourceFile(LabelResourceFilePath);
        }

        private void loadXML()
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(FilePath);

            XmlElement xRoot = xDoc.DocumentElement;

            foreach (XmlNode xnode in xRoot)
            {
                switch (xnode.Name)
                {
                    case "LabelFileId":
                        LabelFileId = xnode.InnerText;
                        break;

                    case "LabelContentFileName":
                        string content = xnode.InnerText;
                        string[] data = content.Split('.');
                        LanguageId = data[1];
                        break;

                    case "RelativeUriInModelStore":
                        string relativeUri = xnode.InnerText;
                        string dirName = LabelTranslatorEngine.LABEL_FILE_DIRECTORY_NAME;
                        string axLabelFileDirectory = FilePath.Substring(0, FilePath.IndexOf(dirName) + dirName.Length);
                        string relativeFilePath = relativeUri.Substring(relativeUri.IndexOf(dirName) + dirName.Length + 1);
                        LabelResourceFilePath = Path.Combine(axLabelFileDirectory, relativeFilePath);
                        break;
                }
            }
        }
    }
}
