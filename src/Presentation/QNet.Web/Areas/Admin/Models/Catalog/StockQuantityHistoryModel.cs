using System;
using System.ComponentModel.DataAnnotations;
using QNet.Web.Framework.Models;
using QNet.Web.Framework.Mvc.ModelBinding;

namespace QNet.Web.Areas.Admin.Models.Catalog
{
    /// <summary>
    /// Represents a stock quantity history model
    /// </summary>
    public partial class StockQuantityHistoryModel : BaseQNetEntityModel
    {
        #region Properties

        [QNetResourceDisplayName("Admin.Catalog.Products.StockQuantityHistory.Fields.Warehouse")]
        public string WarehouseName { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.Products.StockQuantityHistory.Fields.Combination")]
        public string AttributeCombination { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.Products.StockQuantityHistory.Fields.QuantityAdjustment")]
        public int QuantityAdjustment { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.Products.StockQuantityHistory.Fields.StockQuantity")]
        public int StockQuantity { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.Products.StockQuantityHistory.Fields.Message")]
        public string Message { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.Products.StockQuantityHistory.Fields.CreatedOn")]
        [UIHint("DecimalNullable")]
        public DateTime CreatedOn { get; set; }

        #endregion
    }
}