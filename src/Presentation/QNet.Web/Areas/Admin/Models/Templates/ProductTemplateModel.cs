using QNet.Web.Framework.Mvc.ModelBinding;
using QNet.Web.Framework.Models;

namespace QNet.Web.Areas.Admin.Models.Templates
{
    /// <summary>
    /// Represents a product template model
    /// </summary>
    public partial class ProductTemplateModel : BaseQNetEntityModel
    {
        #region Properties

        [QNetResourceDisplayName("Admin.System.Templates.Product.Name")]
        public string Name { get; set; }

        [QNetResourceDisplayName("Admin.System.Templates.Product.ViewPath")]
        public string ViewPath { get; set; }

        [QNetResourceDisplayName("Admin.System.Templates.Product.DisplayOrder")]
        public int DisplayOrder { get; set; }

        [QNetResourceDisplayName("Admin.System.Templates.Product.IgnoredProductTypes")]
        public string IgnoredProductTypes { get; set; }

        #endregion
    }
}