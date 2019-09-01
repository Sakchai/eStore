using QNet.Web.Framework.Mvc.ModelBinding;
using QNet.Web.Framework.Models;

namespace QNet.Web.Areas.Admin.Models.Settings
{
    /// <summary>
    /// Represents a sort option model
    /// </summary>
    public partial class SortOptionModel : BaseQNetEntityModel
    {
        #region Properties

        [QNetResourceDisplayName("Admin.Configuration.Settings.Catalog.SortOptions.Name")]
        public string Name { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Settings.Catalog.SortOptions.IsActive")]
        public bool IsActive { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Settings.Catalog.SortOptions.DisplayOrder")]
        public int DisplayOrder { get; set; }

        #endregion
    }
}