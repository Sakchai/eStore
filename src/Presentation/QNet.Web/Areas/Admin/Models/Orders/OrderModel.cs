using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using QNet.Core.Domain.Tax;
using QNet.Web.Areas.Admin.Models.Common;
using QNet.Web.Framework.Models;
using QNet.Web.Framework.Mvc.ModelBinding;

namespace QNet.Web.Areas.Admin.Models.Orders
{
    /// <summary>
    /// Represents an order model
    /// </summary>
    public partial class OrderModel : BaseQNetEntityModel
    {
        #region Ctor

        public OrderModel()
        {
            CustomValues = new Dictionary<string, object>();
            TaxRates = new List<TaxRate>();
            GiftCards = new List<GiftCard>();
            Items = new List<OrderItemModel>();
            UsedDiscounts = new List<UsedDiscountModel>();
            OrderShipmentSearchModel = new OrderShipmentSearchModel();
            OrderNoteSearchModel = new OrderNoteSearchModel();
            BillingAddress = new AddressModel();
            ShippingAddress = new AddressModel();
            PickupAddress = new AddressModel();
        }

        #endregion

        #region Properties

        public bool IsLoggedInAsVendor { get; set; }

        //identifiers
        public override int Id { get; set; }
        [QNetResourceDisplayName("Admin.Orders.Fields.OrderGuid")]
        public Guid OrderGuid { get; set; }
        [QNetResourceDisplayName("Admin.Orders.Fields.CustomOrderNumber")]
        public string CustomOrderNumber { get; set; }
        
        //store
        [QNetResourceDisplayName("Admin.Orders.Fields.Store")]
        public string StoreName { get; set; }

        //customer info
        [QNetResourceDisplayName("Admin.Orders.Fields.Customer")]
        public int CustomerId { get; set; }
        [QNetResourceDisplayName("Admin.Orders.Fields.Customer")]
        public string CustomerInfo { get; set; }
        [QNetResourceDisplayName("Admin.Orders.Fields.CustomerEmail")]
        public string CustomerEmail { get; set; }
        public string CustomerFullName { get; set; }
        [QNetResourceDisplayName("Admin.Orders.Fields.CustomerIP")]
        public string CustomerIp { get; set; }

        [QNetResourceDisplayName("Admin.Orders.Fields.CustomValues")]
        public Dictionary<string, object> CustomValues { get; set; }

        [QNetResourceDisplayName("Admin.Orders.Fields.Affiliate")]
        public int AffiliateId { get; set; }
        [QNetResourceDisplayName("Admin.Orders.Fields.Affiliate")]
        public string AffiliateName { get; set; }

        //Used discounts
        [QNetResourceDisplayName("Admin.Orders.Fields.UsedDiscounts")]
        public IList<UsedDiscountModel> UsedDiscounts { get; set; }

        //totals
        public bool AllowCustomersToSelectTaxDisplayType { get; set; }
        public TaxDisplayType TaxDisplayType { get; set; }
        [QNetResourceDisplayName("Admin.Orders.Fields.OrderSubtotalInclTax")]
        public string OrderSubtotalInclTax { get; set; }
        [QNetResourceDisplayName("Admin.Orders.Fields.OrderSubtotalExclTax")]
        public string OrderSubtotalExclTax { get; set; }
        [QNetResourceDisplayName("Admin.Orders.Fields.OrderSubTotalDiscountInclTax")]
        public string OrderSubTotalDiscountInclTax { get; set; }
        [QNetResourceDisplayName("Admin.Orders.Fields.OrderSubTotalDiscountExclTax")]
        public string OrderSubTotalDiscountExclTax { get; set; }
        [QNetResourceDisplayName("Admin.Orders.Fields.OrderShippingInclTax")]
        public string OrderShippingInclTax { get; set; }
        [QNetResourceDisplayName("Admin.Orders.Fields.OrderShippingExclTax")]
        public string OrderShippingExclTax { get; set; }
        [QNetResourceDisplayName("Admin.Orders.Fields.PaymentMethodAdditionalFeeInclTax")]
        public string PaymentMethodAdditionalFeeInclTax { get; set; }
        [QNetResourceDisplayName("Admin.Orders.Fields.PaymentMethodAdditionalFeeExclTax")]
        public string PaymentMethodAdditionalFeeExclTax { get; set; }
        [QNetResourceDisplayName("Admin.Orders.Fields.Tax")]
        public string Tax { get; set; }
        public IList<TaxRate> TaxRates { get; set; }
        public bool DisplayTax { get; set; }
        public bool DisplayTaxRates { get; set; }
        [QNetResourceDisplayName("Admin.Orders.Fields.OrderTotalDiscount")]
        public string OrderTotalDiscount { get; set; }
        [QNetResourceDisplayName("Admin.Orders.Fields.RedeemedRewardPoints")]
        public int RedeemedRewardPoints { get; set; }
        [QNetResourceDisplayName("Admin.Orders.Fields.RedeemedRewardPoints")]
        public string RedeemedRewardPointsAmount { get; set; }
        [QNetResourceDisplayName("Admin.Orders.Fields.OrderTotal")]
        public string OrderTotal { get; set; }
        [QNetResourceDisplayName("Admin.Orders.Fields.RefundedAmount")]
        public string RefundedAmount { get; set; }
        [QNetResourceDisplayName("Admin.Orders.Fields.Profit")]
        public string Profit { get; set; }

        //edit totals
        [QNetResourceDisplayName("Admin.Orders.Fields.Edit.OrderSubtotal")]
        public decimal OrderSubtotalInclTaxValue { get; set; }
        [QNetResourceDisplayName("Admin.Orders.Fields.Edit.OrderSubtotal")]
        public decimal OrderSubtotalExclTaxValue { get; set; }
        [QNetResourceDisplayName("Admin.Orders.Fields.Edit.OrderSubTotalDiscount")]
        public decimal OrderSubTotalDiscountInclTaxValue { get; set; }
        [QNetResourceDisplayName("Admin.Orders.Fields.Edit.OrderSubTotalDiscount")]
        public decimal OrderSubTotalDiscountExclTaxValue { get; set; }
        [QNetResourceDisplayName("Admin.Orders.Fields.Edit.OrderShipping")]
        public decimal OrderShippingInclTaxValue { get; set; }
        [QNetResourceDisplayName("Admin.Orders.Fields.Edit.OrderShipping")]
        public decimal OrderShippingExclTaxValue { get; set; }
        [QNetResourceDisplayName("Admin.Orders.Fields.Edit.PaymentMethodAdditionalFee")]
        public decimal PaymentMethodAdditionalFeeInclTaxValue { get; set; }
        [QNetResourceDisplayName("Admin.Orders.Fields.Edit.PaymentMethodAdditionalFee")]
        public decimal PaymentMethodAdditionalFeeExclTaxValue { get; set; }
        [QNetResourceDisplayName("Admin.Orders.Fields.Edit.Tax")]
        public decimal TaxValue { get; set; }
        [QNetResourceDisplayName("Admin.Orders.Fields.Edit.TaxRates")]
        public string TaxRatesValue { get; set; }
        [QNetResourceDisplayName("Admin.Orders.Fields.Edit.OrderTotalDiscount")]
        public decimal OrderTotalDiscountValue { get; set; }
        [QNetResourceDisplayName("Admin.Orders.Fields.Edit.OrderTotal")]
        public decimal OrderTotalValue { get; set; }

        //associated recurring payment id
        [QNetResourceDisplayName("Admin.Orders.Fields.RecurringPayment")]
        public int RecurringPaymentId { get; set; }

        //order status
        [QNetResourceDisplayName("Admin.Orders.Fields.OrderStatus")]
        public string OrderStatus { get; set; }
        [QNetResourceDisplayName("Admin.Orders.Fields.OrderStatus")]
        public int OrderStatusId { get; set; }

        //payment info
        [QNetResourceDisplayName("Admin.Orders.Fields.PaymentStatus")]
        public string PaymentStatus { get; set; }
        [QNetResourceDisplayName("Admin.Orders.Fields.PaymentStatus")]
        public int PaymentStatusId { get; set; }
        [QNetResourceDisplayName("Admin.Orders.Fields.PaymentMethod")]
        public string PaymentMethod { get; set; }

        //credit card info
        public bool AllowStoringCreditCardNumber { get; set; }
        [QNetResourceDisplayName("Admin.Orders.Fields.CardType")]
        public string CardType { get; set; }
        [QNetResourceDisplayName("Admin.Orders.Fields.CardName")]
        public string CardName { get; set; }
        [QNetResourceDisplayName("Admin.Orders.Fields.CardNumber")]
        public string CardNumber { get; set; }
        [QNetResourceDisplayName("Admin.Orders.Fields.CardCVV2")]
        public string CardCvv2 { get; set; }
        [QNetResourceDisplayName("Admin.Orders.Fields.CardExpirationMonth")]
        public string CardExpirationMonth { get; set; }
        [QNetResourceDisplayName("Admin.Orders.Fields.CardExpirationYear")]
        public string CardExpirationYear { get; set; }

        //misc payment info
        [QNetResourceDisplayName("Admin.Orders.Fields.AuthorizationTransactionID")]
        public string AuthorizationTransactionId { get; set; }
        [QNetResourceDisplayName("Admin.Orders.Fields.CaptureTransactionID")]
        public string CaptureTransactionId { get; set; }
        [QNetResourceDisplayName("Admin.Orders.Fields.SubscriptionTransactionID")]
        public string SubscriptionTransactionId { get; set; }

        //shipping info
        public bool IsShippable { get; set; }
        public bool PickupInStore { get; set; }
        [QNetResourceDisplayName("Admin.Orders.Fields.PickupAddress")]
        public AddressModel PickupAddress { get; set; }
        public string PickupAddressGoogleMapsUrl { get; set; }
        [QNetResourceDisplayName("Admin.Orders.Fields.ShippingStatus")]
        public string ShippingStatus { get; set; }
        [QNetResourceDisplayName("Admin.Orders.Fields.ShippingStatus")]
        public int ShippingStatusId { get; set; }
        [QNetResourceDisplayName("Admin.Orders.Fields.ShippingAddress")]
        public AddressModel ShippingAddress { get; set; }
        [QNetResourceDisplayName("Admin.Orders.Fields.ShippingMethod")]
        public string ShippingMethod { get; set; }
        public string ShippingAddressGoogleMapsUrl { get; set; }
        public bool CanAddNewShipments { get; set; }

        //billing info
        [QNetResourceDisplayName("Admin.Orders.Fields.BillingAddress")]
        public AddressModel BillingAddress { get; set; }
        [QNetResourceDisplayName("Admin.Orders.Fields.VatNumber")]
        public string VatNumber { get; set; }
        
        //gift cards
        public IList<GiftCard> GiftCards { get; set; }

        //items
        public bool HasDownloadableProducts { get; set; }
        public IList<OrderItemModel> Items { get; set; }

        //creation date
        [QNetResourceDisplayName("Admin.Orders.Fields.CreatedOn")]
        public DateTime CreatedOn { get; set; }

        //checkout attributes
        public string CheckoutAttributeInfo { get; set; }

        //order notes
        [QNetResourceDisplayName("Admin.Orders.OrderNotes.Fields.DisplayToCustomer")]
        public bool AddOrderNoteDisplayToCustomer { get; set; }
        [QNetResourceDisplayName("Admin.Orders.OrderNotes.Fields.Note")]
        public string AddOrderNoteMessage { get; set; }
        public bool AddOrderNoteHasDownload { get; set; }
        [QNetResourceDisplayName("Admin.Orders.OrderNotes.Fields.Download")]
        [UIHint("Download")]
        public int AddOrderNoteDownloadId { get; set; }

        //refund info
        [QNetResourceDisplayName("Admin.Orders.Fields.PartialRefund.AmountToRefund")]
        public decimal AmountToRefund { get; set; }
        public decimal MaxAmountToRefund { get; set; }
        public string PrimaryStoreCurrencyCode { get; set; }

        //workflow info
        public bool CanCancelOrder { get; set; }
        public bool CanCapture { get; set; }
        public bool CanMarkOrderAsPaid { get; set; }
        public bool CanRefund { get; set; }
        public bool CanRefundOffline { get; set; }
        public bool CanPartiallyRefund { get; set; }
        public bool CanPartiallyRefundOffline { get; set; }
        public bool CanVoid { get; set; }
        public bool CanVoidOffline { get; set; }

        public OrderShipmentSearchModel OrderShipmentSearchModel { get; set; }

        public OrderNoteSearchModel OrderNoteSearchModel { get; set; }

        #endregion

        #region Nested Classes

        public partial class TaxRate : BaseQNetModel
        {
            public string Rate { get; set; }
            public string Value { get; set; }
        }

        public partial class GiftCard : BaseQNetModel
        {
            [QNetResourceDisplayName("Admin.Orders.Fields.GiftCardInfo")]
            public string CouponCode { get; set; }
            public string Amount { get; set; }
        }               
        
        public partial class UsedDiscountModel:BaseQNetModel
        {
            public int DiscountId { get; set; }
            public string DiscountName { get; set; }
        }

        #endregion
    }

    public partial class OrderAggreratorModel : BaseQNetModel
    {
        //aggergator properties
        public string aggregatorprofit { get; set; }
        public string aggregatorshipping { get; set; }
        public string aggregatortax { get; set; }
        public string aggregatortotal { get; set; }
    }
}