using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabelTranslator
{
    public class TranslationServiceProviderParametersYandex : TranslationServiceProviderParameters
    {
        public string FolderId { get; private set; }

        public TranslationServiceProviderParametersYandex(string apiKey, string apiEndpoint, string folderId) : base(TranslationServiceProviderType.Yandex, apiKey, apiEndpoint)
        {
            FolderId = folderId;
        }
    }
}
