using System;
using QNet.Web.Framework.Models;
using QNet.Web.Framework.Mvc.ModelBinding;

namespace QNet.Web.Areas.Admin.Models.Orders
{
    /// <summary>
    /// Represents a gift card usage history model
    /// </summary>
    public partial class GiftCardUsageHistoryModel : BaseQNetEntityModel
    {
        #region Properties

        [QNetResourceDisplayName("Admin.GiftCards.History.UsedValue")]
        public string UsedValue { get; set; }

        public int OrderId { get; set; }

        [QNetResourceDisplayName("Admin.GiftCards.History.CreatedOn")]
        public DateTime CreatedOn { get; set; }

        [QNetResourceDisplayName("Admin.GiftCards.History.CustomOrderNumber")]
        public string CustomOrderNumber { get; set; }

        #endregion
    }
}