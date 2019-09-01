using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using QNet.Web.Framework.Mvc.ModelBinding;
using QNet.Web.Framework.Models;

namespace QNet.Web.Areas.Admin.Models.Orders
{
    /// <summary>
    /// Represents an order search model
    /// </summary>
    public partial class OrderSearchModel : BaseSearchModel
    {
        #region Ctor

        public OrderSearchModel()
        {
            AvailableOrderStatuses = new List<SelectListItem>();
            AvailablePaymentStatuses = new List<SelectListItem>();
            AvailableShippingStatuses = new List<SelectListItem>();
            AvailableStores = new List<SelectListItem>();
            AvailableVendors = new List<SelectListItem>();
            AvailableWarehouses = new List<SelectListItem>();
            AvailablePaymentMethods = new List<SelectListItem>();
            AvailableCountries = new List<SelectListItem>();
            OrderStatusIds = new List<int>();
            PaymentStatusIds = new List<int>();
            ShippingStatusIds = new List<int>();
        }

        #endregion

        #region Properties

        [QNetResourceDisplayName("Admin.Orders.List.StartDate")]
        [UIHint("DateNullable")]
        public DateTime? StartDate { get; set; }

        [QNetResourceDisplayName("Admin.Orders.List.EndDate")]
        [UIHint("DateNullable")]
        public DateTime? EndDate { get; set; }

        [QNetResourceDisplayName("Admin.Orders.List.OrderStatus")]
        public IList<int> OrderStatusIds { get; set; }

        [QNetResourceDisplayName("Admin.Orders.List.PaymentStatus")]
        public IList<int> PaymentStatusIds { get; set; }

        [QNetResourceDisplayName("Admin.Orders.List.ShippingStatus")]
        public IList<int> ShippingStatusIds { get; set; }

        [QNetResourceDisplayName("Admin.Orders.List.PaymentMethod")]
        public string PaymentMethodSystemName { get; set; }

        [QNetResourceDisplayName("Admin.Orders.List.Store")]
        public int StoreId { get; set; }

        [QNetResourceDisplayName("Admin.Orders.List.Vendor")]
        public int VendorId { get; set; }

        [QNetResourceDisplayName("Admin.Orders.List.Warehouse")]
        public int WarehouseId { get; set; }

        [QNetResourceDisplayName("Admin.Orders.List.Product")]
        public int ProductId { get; set; }

        [QNetResourceDisplayName("Admin.Orders.List.BillingEmail")]
        public string BillingEmail { get; set; }

        [QNetResourceDisplayName("Admin.Orders.List.BillingPhone")]
        public string BillingPhone { get; set; }

        public bool BillingPhoneEnabled { get; set; }

        [QNetResourceDisplayName("Admin.Orders.List.BillingLastName")]
        public string BillingLastName { get; set; }

        [QNetResourceDisplayName("Admin.Orders.List.BillingCountry")]
        public int BillingCountryId { get; set; }

        [QNetResourceDisplayName("Admin.Orders.List.OrderNotes")]
        public string OrderNotes { get; set; }

        [QNetResourceDisplayName("Admin.Orders.List.GoDirectlyToNumber")]
        public string GoDirectlyToCustomOrderNumber { get; set; }

        public bool IsLoggedInAsVendor { get; set; }

        public IList<SelectListItem> AvailableOrderStatuses { get; set; }

        public IList<SelectListItem> AvailablePaymentStatuses { get; set; }

        public IList<SelectListItem> AvailableShippingStatuses { get; set; }

        public IList<SelectListItem> AvailableStores { get; set; }

        public IList<SelectListItem> AvailableVendors { get; set; }

        public IList<SelectListItem> AvailableWarehouses { get; set; }

        public IList<SelectListItem> AvailablePaymentMethods { get; set; }

        public IList<SelectListItem> AvailableCountries { get; set; }

        public bool HideStoresList { get; set; }

        #endregion
    }
}