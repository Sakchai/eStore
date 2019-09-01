using System.Collections.Generic;
using QNet.Web.Areas.Admin.Models.Localization;
using QNet.Web.Framework.Models;

namespace QNet.Web.Areas.Admin.Models.Common
{
    /// <summary>
    /// Represents an admin language selector model
    /// </summary>
    public partial class LanguageSelectorModel : BaseQNetModel
    {
        #region Ctor

        public LanguageSelectorModel()
        {
            AvailableLanguages = new List<LanguageModel>();
        }

        #endregion

        #region Properties

        public IList<LanguageModel> AvailableLanguages { get; set; }

        public LanguageModel CurrentLanguage { get; set; }

        #endregion
    }
}