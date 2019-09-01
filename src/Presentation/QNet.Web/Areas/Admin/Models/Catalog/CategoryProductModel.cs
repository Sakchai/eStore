using QNet.Web.Framework.Models;
using QNet.Web.Framework.Mvc.ModelBinding;

namespace QNet.Web.Areas.Admin.Models.Catalog
{
    /// <summary>
    /// Represents a category product model
    /// </summary>
    public partial class CategoryProductModel : BaseQNetEntityModel
    {
        #region Properties

        public int CategoryId { get; set; }

        public int ProductId { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.Categories.Products.Fields.Product")]
        public string ProductName { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.Categories.Products.Fields.IsFeaturedProduct")]
        public bool IsFeaturedProduct { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.Categories.Products.Fields.DisplayOrder")]
        public int DisplayOrder { get; set; }

        #endregion
    }
}