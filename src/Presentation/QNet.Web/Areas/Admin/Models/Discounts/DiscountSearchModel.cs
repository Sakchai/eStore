using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using QNet.Web.Framework.Mvc.ModelBinding;
using QNet.Web.Framework.Models;

namespace QNet.Web.Areas.Admin.Models.Discounts
{
    /// <summary>
    /// Represents a discount search model
    /// </summary>
    public partial class DiscountSearchModel : BaseSearchModel
    {
        #region Ctor

        public DiscountSearchModel()
        {
            AvailableDiscountTypes = new List<SelectListItem>();
        }

        #endregion

        #region Properties

        [QNetResourceDisplayName("Admin.Promotions.Discounts.List.SearchDiscountCouponCode")]
        public string SearchDiscountCouponCode { get; set; }

        [QNetResourceDisplayName("Admin.Promotions.Discounts.List.SearchDiscountName")]
        public string SearchDiscountName { get; set; }

        [QNetResourceDisplayName("Admin.Promotions.Discounts.List.SearchDiscountType")]
        public int SearchDiscountTypeId { get; set; }

        public IList<SelectListItem> AvailableDiscountTypes { get; set; }

        [QNetResourceDisplayName("Admin.Promotions.Discounts.List.SearchStartDate")]
        [UIHint("DateNullable")]
        public DateTime? SearchStartDate { get; set; }

        [QNetResourceDisplayName("Admin.Promotions.Discounts.List.SearchEndDate")]
        [UIHint("DateNullable")]
        public DateTime? SearchEndDate { get; set; }

        #endregion
    }
}