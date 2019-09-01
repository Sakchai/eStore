using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using QNet.Web.Framework.Models;
using QNet.Web.Framework.Mvc.ModelBinding;

namespace QNet.Web.Areas.Admin.Models.Affiliates
{
    /// <summary>
    /// Represents an affiliated order search model
    /// </summary>
    public partial class AffiliatedOrderSearchModel : BaseSearchModel
    {
        #region Ctor

        public AffiliatedOrderSearchModel()
        {
            AvailableOrderStatuses = new List<SelectListItem>();
            AvailablePaymentStatuses = new List<SelectListItem>();
            AvailableShippingStatuses = new List<SelectListItem>();
        }

        #endregion

        #region Properties

        public int AffliateId { get; set; }

        [QNetResourceDisplayName("Admin.Affiliates.Orders.StartDate")]
        [UIHint("DateNullable")]
        public DateTime? StartDate { get; set; }

        [QNetResourceDisplayName("Admin.Affiliates.Orders.EndDate")]
        [UIHint("DateNullable")]
        public DateTime? EndDate { get; set; }

        [QNetResourceDisplayName("Admin.Affiliates.Orders.OrderStatus")]
        public int OrderStatusId { get; set; }

        [QNetResourceDisplayName("Admin.Affiliates.Orders.PaymentStatus")]
        public int PaymentStatusId { get; set; }

        [QNetResourceDisplayName("Admin.Affiliates.Orders.ShippingStatus")]
        public int ShippingStatusId { get; set; }

        public IList<SelectListItem> AvailableOrderStatuses { get; set; }
        public IList<SelectListItem> AvailablePaymentStatuses { get; set; }
        public IList<SelectListItem> AvailableShippingStatuses { get; set; }

        #endregion
    }
}