using QNet.Web.Framework.Models;
using QNet.Web.Framework.Mvc.ModelBinding;

namespace QNet.Web.Areas.Admin.Models.Catalog
{
    /// <summary>
    /// Represents a related product model
    /// </summary>
    public partial class RelatedProductModel : BaseQNetEntityModel
    {
        #region Properties

        public int ProductId2 { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.Products.RelatedProducts.Fields.Product")]
        public string Product2Name { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.Products.RelatedProducts.Fields.DisplayOrder")]
        public int DisplayOrder { get; set; }

        #endregion
    }
}