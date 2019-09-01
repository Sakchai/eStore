using QNet.Web.Framework.Models;
using QNet.Web.Framework.Mvc.ModelBinding;

namespace QNet.Web.Areas.Admin.Models.Localization
{
    /// <summary>
    /// Represents a locale resource model
    /// </summary>
    public partial class LocaleResourceModel : BaseQNetEntityModel
    {
        #region Properties

        [QNetResourceDisplayName("Admin.Configuration.Languages.Resources.Fields.Name")]
        public string ResourceName { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Languages.Resources.Fields.Value")]
        public string ResourceValue { get; set; }

        public int LanguageId { get; set; }

        #endregion
    }
}