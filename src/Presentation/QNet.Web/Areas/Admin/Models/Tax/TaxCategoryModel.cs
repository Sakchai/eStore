using QNet.Web.Framework.Mvc.ModelBinding;
using QNet.Web.Framework.Models;

namespace QNet.Web.Areas.Admin.Models.Tax
{
    /// <summary>
    /// Represents a tax category model
    /// </summary>
    public partial class TaxCategoryModel : BaseQNetEntityModel
    {
        #region Properties

        [QNetResourceDisplayName("Admin.Configuration.Tax.Categories.Fields.Name")]
        public string Name { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Tax.Categories.Fields.DisplayOrder")]
        public int DisplayOrder { get; set; }

        #endregion
    }
}