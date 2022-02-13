using System.IO;

namespace LabelTranslator
{
    public class CommandParameters
    {
        public string LabelFileId { get; private set; }
        public string LanguageId { get; private set; }
        public string FilePath { get; private set; }

        public CommandParameters(string filePath)
        {
            FilePath = filePath;

            string fileName = Path.GetFileNameWithoutExtension(FilePath);
            string[] labelFileParams = fileName.Split('.');

            LabelFileId = labelFileParams[0];
            LanguageId = labelFileParams[1];
        }
    }
}
