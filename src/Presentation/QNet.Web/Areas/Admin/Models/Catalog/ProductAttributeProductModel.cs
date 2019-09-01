using QNet.Web.Framework.Models;
using QNet.Web.Framework.Mvc.ModelBinding;

namespace QNet.Web.Areas.Admin.Models.Catalog
{
    /// <summary>
    /// Represents a model of products that use the product attribute
    /// </summary>
    public partial class ProductAttributeProductModel : BaseQNetEntityModel
    {
        #region Properties

        [QNetResourceDisplayName("Admin.Catalog.Attributes.ProductAttributes.UsedByProducts.Product")]
        public string ProductName { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.Attributes.ProductAttributes.UsedByProducts.Published")]
        public bool Published { get; set; }

        #endregion
    }
}