using QNet.Web.Framework.Models;
using QNet.Web.Framework.Mvc.ModelBinding;

namespace QNet.Web.Areas.Admin.Models.Catalog
{
    /// <summary>
    /// Represents an associated product model
    /// </summary>
    public partial class AssociatedProductModel : BaseQNetEntityModel
    {
        #region Properties

        [QNetResourceDisplayName("Admin.Catalog.Products.AssociatedProducts.Fields.Product")]
        public string ProductName { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.Products.AssociatedProducts.Fields.DisplayOrder")]
        public int DisplayOrder { get; set; }

        #endregion
    }
}