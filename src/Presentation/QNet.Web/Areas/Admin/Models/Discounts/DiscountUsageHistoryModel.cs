using System;
using QNet.Web.Framework.Models;
using QNet.Web.Framework.Mvc.ModelBinding;

namespace QNet.Web.Areas.Admin.Models.Discounts
{
    /// <summary>
    /// Represents a discount usage history model
    /// </summary>
    public partial class DiscountUsageHistoryModel : BaseQNetEntityModel
    {
        #region Properties

        public int DiscountId { get; set; }

        public int OrderId { get; set; }

        [QNetResourceDisplayName("Admin.Promotions.Discounts.History.CustomOrderNumber")]
        public string CustomOrderNumber { get; set; }

        [QNetResourceDisplayName("Admin.Promotions.Discounts.History.OrderTotal")]
        public string OrderTotal { get; set; }

        [QNetResourceDisplayName("Admin.Promotions.Discounts.History.CreatedOn")]
        public DateTime CreatedOn { get; set; }

        #endregion
    }
}