using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using QNet.Web.Framework.Mvc.ModelBinding;
using QNet.Web.Framework.Models;

namespace QNet.Web.Areas.Admin.Models.Orders
{
    /// <summary>
    /// Represents a return request search model
    /// </summary>
    public class ReturnRequestSearchModel: BaseSearchModel
    {
        #region Ctor

        public ReturnRequestSearchModel()
        {
            ReturnRequestStatusList = new List<SelectListItem>();
        }

        #endregion

        #region Properties

        [QNetResourceDisplayName("Admin.ReturnRequests.SearchStartDate")]
        [UIHint("DateNullable")]
        public DateTime? StartDate { get; set; }

        [QNetResourceDisplayName("Admin.ReturnRequests.SearchEndDate")]
        [UIHint("DateNullable")]
        public DateTime? EndDate { get; set; }

        [QNetResourceDisplayName("Admin.ReturnRequests.SearchCustomNumber")]
        public string CustomNumber { get; set; }

        [QNetResourceDisplayName("Admin.ReturnRequests.SearchReturnRequestStatus")]
        public int ReturnRequestStatusId { get; set; }

        public IList<SelectListItem> ReturnRequestStatusList { get; set; }

        #endregion
    }
}