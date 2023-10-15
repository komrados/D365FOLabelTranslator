using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LabelTranslator
{
    public class TranslationServiceProviderParameters
    {
        public TranslationServiceProviderType TranslationServiceProviderType { get; set; }

        public string ApiKey { get; private set; }
        public string ApiEndpoint { get; private set; }

        public TranslationServiceProviderParameters(TranslationServiceProviderType type, string apiKey, string apiEndpoint)
        {
            TranslationServiceProviderType = type;
            ApiKey = apiKey;
            ApiEndpoint = apiEndpoint;
        }
    }
}
