using QNet.Web.Framework.Models;
using QNet.Web.Framework.Mvc.ModelBinding;

namespace QNet.Web.Areas.Admin.Models.Localization
{
    /// <summary>
    /// Represents a locale resource search model
    /// </summary>
    public partial class LocaleResourceSearchModel : BaseSearchModel
    {
        #region Ctor

        public LocaleResourceSearchModel()
        {
            AddResourceString = new LocaleResourceModel();
        }

        #endregion

        #region Properties

        public int LanguageId { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Languages.Resources.SearchResourceName")]
        public string SearchResourceName { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Languages.Resources.SearchResourceValue")]
        public string SearchResourceValue { get; set; }

        public LocaleResourceModel AddResourceString { get; set; }

        #endregion
    }
}