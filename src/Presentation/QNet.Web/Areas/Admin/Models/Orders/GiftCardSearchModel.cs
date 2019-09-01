﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using QNet.Web.Framework.Mvc.ModelBinding;
using QNet.Web.Framework.Models;

namespace QNet.Web.Areas.Admin.Models.Orders
{
    /// <summary>
    /// Represents a gift card search model
    /// </summary>
    public partial class GiftCardSearchModel : BaseSearchModel
    {
        #region Ctor

        public GiftCardSearchModel()
        {
            ActivatedList = new List<SelectListItem>();
        }

        #endregion

        #region Properties

        [QNetResourceDisplayName("Admin.GiftCards.List.CouponCode")]
        public string CouponCode { get; set; }

        [QNetResourceDisplayName("Admin.GiftCards.List.RecipientName")]
        public string RecipientName { get; set; }

        [QNetResourceDisplayName("Admin.GiftCards.List.Activated")]
        public int ActivatedId { get; set; }

        [QNetResourceDisplayName("Admin.GiftCards.List.Activated")]
        public IList<SelectListItem> ActivatedList { get; set; }

        #endregion
    }
}