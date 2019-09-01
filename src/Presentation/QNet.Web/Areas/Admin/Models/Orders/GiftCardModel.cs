using System;
using System.ComponentModel.DataAnnotations;
using QNet.Web.Framework.Mvc.ModelBinding;
using QNet.Web.Framework.Models;

namespace QNet.Web.Areas.Admin.Models.Orders
{
    /// <summary>
    /// Represents a gift card model
    /// </summary>
    public partial class GiftCardModel: BaseQNetEntityModel
    {
        #region Ctor

        public GiftCardModel()
        {
            GiftCardUsageHistorySearchModel = new GiftCardUsageHistorySearchModel();
        }

        #endregion

        #region Properties

        [QNetResourceDisplayName("Admin.GiftCards.Fields.GiftCardType")]
        public int GiftCardTypeId { get; set; }

        [QNetResourceDisplayName("Admin.GiftCards.Fields.OrderId")]
        public int? PurchasedWithOrderId { get; set; }

        [QNetResourceDisplayName("Admin.GiftCards.Fields.CustomOrderNumber")]
        public string PurchasedWithOrderNumber { get; set; }

        [QNetResourceDisplayName("Admin.GiftCards.Fields.Amount")]
        public decimal Amount { get; set; }

        [QNetResourceDisplayName("Admin.GiftCards.Fields.Amount")]
        public string AmountStr { get; set; }

        [QNetResourceDisplayName("Admin.GiftCards.Fields.RemainingAmount")]
        public string RemainingAmountStr { get; set; }

        [QNetResourceDisplayName("Admin.GiftCards.Fields.IsGiftCardActivated")]
        public bool IsGiftCardActivated { get; set; }

        [QNetResourceDisplayName("Admin.GiftCards.Fields.GiftCardCouponCode")]
        public string GiftCardCouponCode { get; set; }

        [QNetResourceDisplayName("Admin.GiftCards.Fields.RecipientName")]
        public string RecipientName { get; set; }

        [DataType(DataType.EmailAddress)]
        [QNetResourceDisplayName("Admin.GiftCards.Fields.RecipientEmail")]
        public string RecipientEmail { get; set; }

        [QNetResourceDisplayName("Admin.GiftCards.Fields.SenderName")]
        public string SenderName { get; set; }

        [DataType(DataType.EmailAddress)]
        [QNetResourceDisplayName("Admin.GiftCards.Fields.SenderEmail")]
        public string SenderEmail { get; set; }

        [QNetResourceDisplayName("Admin.GiftCards.Fields.Message")]
        public string Message { get; set; }

        [QNetResourceDisplayName("Admin.GiftCards.Fields.IsRecipientNotified")]
        public bool IsRecipientNotified { get; set; }

        [QNetResourceDisplayName("Admin.GiftCards.Fields.CreatedOn")]
        public DateTime CreatedOn { get; set; }

        public string PrimaryStoreCurrencyCode { get; set; }

        public GiftCardUsageHistorySearchModel GiftCardUsageHistorySearchModel { get; set; }

        #endregion
    }
}