using QNet.Web.Framework.Models;
using QNet.Web.Framework.Mvc.ModelBinding;

namespace QNet.Web.Areas.Admin.Models.Catalog
{
    /// <summary>
    /// Represents a manufacturer product model
    /// </summary>
    public partial class ManufacturerProductModel : BaseQNetEntityModel
    {
        #region Properties

        public int ManufacturerId { get; set; }

        public int ProductId { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.Manufacturers.Products.Fields.Product")]
        public string ProductName { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.Manufacturers.Products.Fields.IsFeaturedProduct")]
        public bool IsFeaturedProduct { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.Manufacturers.Products.Fields.DisplayOrder")]
        public int DisplayOrder { get; set; }

        #endregion
    }
}