using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabelTranslator
{
    public class TranslationServiceProviderParametersAzure : TranslationServiceProviderParameters
    {
        public string Region { get; private set; }

        public TranslationServiceProviderParametersAzure(string apiKey, string apiEndpoint, string region) : base(TranslationServiceProviderType.Azure, apiKey, apiEndpoint)
        {
            Region = region;
        }
    }
}
