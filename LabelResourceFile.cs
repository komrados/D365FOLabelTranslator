using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace LabelTranslator
{
    public class LabelResourceFile
    {
        public string LabelFileId { get; private set; }
        public string LanguageId { get; private set; }
        public string ResourceFilePath { get; private set; }

        public List<Label> Labels { get; private set; }

        public string Report { get; private set; }        

        public LabelResourceFile(string resFilePath)
        {
            ResourceFilePath = resFilePath;

            string fileName = Path.GetFileNameWithoutExtension(ResourceFilePath);
            string[] labelFileParams = fileName.Split('.');

            LabelFileId = labelFileParams[0];
            LanguageId = labelFileParams[1];
        }

        public void LoadLabels()
        {
            Labels = new List<Label>();

            using (StreamReader sr = new StreamReader(ResourceFilePath))
            {
                Label curLabel = null;

                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (line.TrimStart().StartsWith(";") && curLabel != null)
                    {
                        curLabel.Comment = line.TrimStart().Substring(1);
                        continue;
                    }

                    if (line.Contains("="))
                    {
                        int pos = line.IndexOf("=");

                        string labelId = line.Substring(0, pos);
                        string labelText = line.Substring(pos+1);

                        curLabel = new Label(labelId);
                        curLabel.LabelText = labelText;

                        Labels.Add(curLabel);
                    }
                }
            }
        }

        public void SaveLabels(List<Label> labelsToSave)
        {
            if (labelsToSave == null || labelsToSave.Count == 0)
                return;

            bool lastLineNotEmpty = false;
            using (FileStream fs = new FileStream(ResourceFilePath, FileMode.Open))
            using (BinaryReader rd = new BinaryReader(fs))
            {
                fs.Position = fs.Length - 1;
                int last = rd.Read();

                // The last byte is not 10 if there is a LineFeed 
                if (last != 10)
                    lastLineNotEmpty = true;
            }

            using (StreamWriter sw = new StreamWriter(new FileStream(ResourceFilePath, FileMode.Append)))
            {
                if (lastLineNotEmpty)
                    sw.WriteLine();

                foreach (Label label in labelsToSave)
                {
                    sw.WriteLine(string.Format("{0}={1}", label.LabelId, label.LabelText));
                    if (label.Comment != null && label.Comment != "")
                        sw.WriteLine(string.Format(" ;{0}", label.Comment));
                }

                sw.Flush();
                sw.Close();
            }

            Report = string.Format("{0} labels were created in file {1}", labelsToSave.Count, ResourceFilePath);
        }
    }
}
