using System;
using System.ComponentModel.DataAnnotations;
using QNet.Web.Framework.Mvc.ModelBinding;
using QNet.Web.Framework.Models;

namespace QNet.Web.Areas.Admin.Models.Affiliates
{
    /// <summary>
    /// Represents an affiliate search model
    /// </summary>
    public partial class AffiliateSearchModel : BaseSearchModel
    {
        #region Properties

        [QNetResourceDisplayName("Admin.Affiliates.List.SearchFirstName")]
        public string SearchFirstName { get; set; }

        [QNetResourceDisplayName("Admin.Affiliates.List.SearchLastName")]
        public string SearchLastName { get; set; }

        [QNetResourceDisplayName("Admin.Affiliates.List.SearchFriendlyUrlName")]
        public string SearchFriendlyUrlName { get; set; }

        [QNetResourceDisplayName("Admin.Affiliates.List.LoadOnlyWithOrders")]
        public bool LoadOnlyWithOrders { get; set; }

        [QNetResourceDisplayName("Admin.Affiliates.List.OrdersCreatedFromUtc")]
        [UIHint("DateNullable")]
        public DateTime? OrdersCreatedFromUtc { get; set; }

        [QNetResourceDisplayName("Admin.Affiliates.List.OrdersCreatedToUtc")]
        [UIHint("DateNullable")]
        public DateTime? OrdersCreatedToUtc { get; set; }

        #endregion
    }
}