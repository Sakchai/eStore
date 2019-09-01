﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using QNet.Web.Framework.Mvc.ModelBinding;
using QNet.Web.Framework.Models;

namespace QNet.Web.Areas.Admin.Models.Customers
{
    /// <summary>
    /// Represents a GDPR log search model
    /// </summary>
    public partial class GdprLogSearchModel : BaseSearchModel
    {
        #region Ctor

        public GdprLogSearchModel()
        {
            AvailableRequestTypes = new List<SelectListItem>();
        }

        #endregion

        #region Properties

        [QNetResourceDisplayName("Admin.Customers.GdprLog.List.SearchEmail")]
        public string SearchEmail { get; set; }

        [QNetResourceDisplayName("Admin.Customers.GdprLog.List.SearchRequestType")]
        public int SearchRequestTypeId { get; set; }

        public IList<SelectListItem> AvailableRequestTypes { get; set; }

        #endregion
    }
}