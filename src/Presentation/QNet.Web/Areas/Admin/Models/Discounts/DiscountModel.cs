using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using QNet.Web.Framework.Mvc.ModelBinding;
using QNet.Web.Framework.Models;

namespace QNet.Web.Areas.Admin.Models.Discounts
{
    /// <summary>
    /// Represents a discount model
    /// </summary>
    public partial class DiscountModel : BaseQNetEntityModel
    {
        #region Ctor

        public DiscountModel()
        {
            AvailableDiscountRequirementRules = new List<SelectListItem>();
            AvailableRequirementGroups = new List<SelectListItem>();
            DiscountUsageHistorySearchModel = new DiscountUsageHistorySearchModel();
            DiscountProductSearchModel = new DiscountProductSearchModel();
            DiscountCategorySearchModel = new DiscountCategorySearchModel();
            DiscountManufacturerSearchModel = new DiscountManufacturerSearchModel();
        }

        #endregion

        #region Properties

        [QNetResourceDisplayName("Admin.Promotions.Discounts.Fields.Name")]
        public string Name { get; set; }

        [QNetResourceDisplayName("Admin.Promotions.Discounts.Fields.DiscountType")]
        public int DiscountTypeId { get; set; }

        [QNetResourceDisplayName("Admin.Promotions.Discounts.Fields.DiscountType")]
        public string DiscountTypeName { get; set; }

        //used for the list page
        [QNetResourceDisplayName("Admin.Promotions.Discounts.Fields.TimesUsed")]
        public int TimesUsed { get; set; }

        [QNetResourceDisplayName("Admin.Promotions.Discounts.Fields.UsePercentage")]
        public bool UsePercentage { get; set; }

        [QNetResourceDisplayName("Admin.Promotions.Discounts.Fields.DiscountPercentage")]
        public decimal DiscountPercentage { get; set; }

        [QNetResourceDisplayName("Admin.Promotions.Discounts.Fields.DiscountAmount")]
        public decimal DiscountAmount { get; set; }

        [QNetResourceDisplayName("Admin.Promotions.Discounts.Fields.MaximumDiscountAmount")]
        [UIHint("DecimalNullable")]
        public decimal? MaximumDiscountAmount { get; set; }

        public string PrimaryStoreCurrencyCode { get; set; }

        [QNetResourceDisplayName("Admin.Promotions.Discounts.Fields.StartDate")]
        [UIHint("DateTimeNullable")]
        public DateTime? StartDateUtc { get; set; }

        [QNetResourceDisplayName("Admin.Promotions.Discounts.Fields.EndDate")]
        [UIHint("DateTimeNullable")]
        public DateTime? EndDateUtc { get; set; }

        [QNetResourceDisplayName("Admin.Promotions.Discounts.Fields.RequiresCouponCode")]
        public bool RequiresCouponCode { get; set; }

        [QNetResourceDisplayName("Admin.Promotions.Discounts.Fields.DiscountUrl")]
        public string DiscountUrl { get; set; }

        [QNetResourceDisplayName("Admin.Promotions.Discounts.Fields.CouponCode")]
        public string CouponCode { get; set; }

        [QNetResourceDisplayName("Admin.Promotions.Discounts.Fields.IsCumulative")]
        public bool IsCumulative { get; set; }

        [QNetResourceDisplayName("Admin.Promotions.Discounts.Fields.DiscountLimitation")]
        public int DiscountLimitationId { get; set; }

        [QNetResourceDisplayName("Admin.Promotions.Discounts.Fields.LimitationTimes")]
        public int LimitationTimes { get; set; }

        [QNetResourceDisplayName("Admin.Promotions.Discounts.Fields.MaximumDiscountedQuantity")]
        [UIHint("Int32Nullable")]
        public int? MaximumDiscountedQuantity { get; set; }
        
        [QNetResourceDisplayName("Admin.Promotions.Discounts.Fields.AppliedToSubCategories")]
        public bool AppliedToSubCategories { get; set; }

        [QNetResourceDisplayName("Admin.Promotions.Discounts.Requirements.DiscountRequirementType")]
        public string AddDiscountRequirement { get; set; }

        public IList<SelectListItem> AvailableDiscountRequirementRules { get; set; }

        [QNetResourceDisplayName("Admin.Promotions.Discounts.Requirements.GroupName")]
        public string GroupName { get; set; }

        [QNetResourceDisplayName("Admin.Promotions.Discounts.Requirements.RequirementGroup")]
        public int RequirementGroupId { get; set; }

        public IList<SelectListItem> AvailableRequirementGroups { get; set; }

        public DiscountUsageHistorySearchModel DiscountUsageHistorySearchModel { get; set; }

        public DiscountProductSearchModel DiscountProductSearchModel { get; set; }

        public DiscountCategorySearchModel DiscountCategorySearchModel { get; set; }

        public DiscountManufacturerSearchModel DiscountManufacturerSearchModel { get; set; }

        #endregion
    }
}