using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabelTranslator
{
    public class TranslationServiceProviderParametersGoogle : TranslationServiceProviderParameters
    {
        public string JsonCredentials { get; private set; }
        public string Project { get; private set; }

        public TranslationServiceProviderParametersGoogle(string jsonCredentials, string project) : base(TranslationServiceProviderType.Google, "", "")
        {
            JsonCredentials = jsonCredentials;
            Project = string.Format("projects/{0}", project);
        }
    }
}
