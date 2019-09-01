using QNet.Web.Framework.Models;
using QNet.Web.Framework.Mvc.ModelBinding;

namespace QNet.Web.Areas.Admin.Models.Catalog
{
    /// <summary>
    /// Represents a review type localized model
    /// </summary>
    public partial class ReviewTypeLocalizedModel : ILocalizedLocaleModel
    {
        public int LanguageId { get; set; }

        [QNetResourceDisplayName("Admin.Settings.ReviewType.Fields.Name")]
        public string Name { get; set; }

        [QNetResourceDisplayName("Admin.Settings.ReviewType.Fields.Description")]
        public string Description { get; set; }
    }
}
