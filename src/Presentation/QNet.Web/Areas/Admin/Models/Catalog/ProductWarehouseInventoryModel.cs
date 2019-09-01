using QNet.Web.Framework.Models;
using QNet.Web.Framework.Mvc.ModelBinding;

namespace QNet.Web.Areas.Admin.Models.Catalog
{
    /// <summary>
    /// Represents a product warehouse inventory model
    /// </summary>
    public partial class ProductWarehouseInventoryModel : BaseQNetModel
    {
        #region Properties

        [QNetResourceDisplayName("Admin.Catalog.Products.ProductWarehouseInventory.Fields.Warehouse")]
        public int WarehouseId { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.Products.ProductWarehouseInventory.Fields.Warehouse")]
        public string WarehouseName { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.Products.ProductWarehouseInventory.Fields.WarehouseUsed")]
        public bool WarehouseUsed { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.Products.ProductWarehouseInventory.Fields.StockQuantity")]
        public int StockQuantity { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.Products.ProductWarehouseInventory.Fields.ReservedQuantity")]
        public int ReservedQuantity { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.Products.ProductWarehouseInventory.Fields.PlannedQuantity")]
        public int PlannedQuantity { get; set; }

        #endregion
    }
}