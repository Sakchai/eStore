using QNet.Web.Framework.Mvc.ModelBinding;
using QNet.Web.Framework.Models;

namespace QNet.Web.Areas.Admin.Models.Reports
{
    /// <summary>
    /// Represents a low stock product model
    /// </summary>
    public partial class LowStockProductModel : BaseQNetEntityModel
    {
        #region Properties

        [QNetResourceDisplayName("Admin.Catalog.Products.Fields.Name")]
        public string Name { get; set; }

        public string Attributes { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.Products.Fields.ManageInventoryMethod")]
        public string ManageInventoryMethod { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.Products.Fields.StockQuantity")]
        public int StockQuantity { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.Products.Fields.Published")]
        public bool Published { get; set; }

        #endregion
    }
}