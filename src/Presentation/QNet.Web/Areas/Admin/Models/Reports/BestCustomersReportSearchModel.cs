﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using QNet.Web.Framework.Mvc.ModelBinding;
using QNet.Web.Framework.Models;

namespace QNet.Web.Areas.Admin.Models.Reports
{
    /// <summary>
    /// Represents a best customers report search model
    /// </summary>
    public partial class BestCustomersReportSearchModel : BaseSearchModel
    {
        #region Ctor

        public BestCustomersReportSearchModel()
        {
            AvailableOrderStatuses = new List<SelectListItem>();
            AvailablePaymentStatuses = new List<SelectListItem>();
            AvailableShippingStatuses = new List<SelectListItem>();
        }

        #endregion

        #region Properties

        //keep it synchronized to CustomerReportService class, GetBestCustomersReport() method, orderBy parameter
        //TODO: move from int to enum
        public int OrderBy { get; set; }

        [QNetResourceDisplayName("Admin.Reports.Customers.BestBy.StartDate")]
        [UIHint("DateNullable")]
        public DateTime? StartDate { get; set; }

        [QNetResourceDisplayName("Admin.Reports.Customers.BestBy.EndDate")]
        [UIHint("DateNullable")]
        public DateTime? EndDate { get; set; }

        [QNetResourceDisplayName("Admin.Reports.Customers.BestBy.OrderStatus")]
        public int OrderStatusId { get; set; }

        [QNetResourceDisplayName("Admin.Reports.Customers.BestBy.PaymentStatus")]
        public int PaymentStatusId { get; set; }

        [QNetResourceDisplayName("Admin.Reports.Customers.BestBy.ShippingStatus")]
        public int ShippingStatusId { get; set; }

        public IList<SelectListItem> AvailableOrderStatuses { get; set; }

        public IList<SelectListItem> AvailablePaymentStatuses { get; set; }

        public IList<SelectListItem> AvailableShippingStatuses { get; set; }

        #endregion
    }
}