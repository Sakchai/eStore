using System.Collections.Generic;
using QNet.Web.Framework.Models;

namespace QNet.Web.Models.Common
{
    public partial class LanguageSelectorModel : BaseQNetModel
    {
        public LanguageSelectorModel()
        {
            AvailableLanguages = new List<LanguageModel>();
        }

        public IList<LanguageModel> AvailableLanguages { get; set; }

        public int CurrentLanguageId { get; set; }

        public bool UseImages { get; set; }
    }
}