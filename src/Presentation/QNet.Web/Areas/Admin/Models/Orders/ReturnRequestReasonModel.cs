﻿using System.Collections.Generic;
using QNet.Web.Framework.Models;
using QNet.Web.Framework.Mvc.ModelBinding;

namespace QNet.Web.Areas.Admin.Models.Orders
{
    /// <summary>
    /// Represents a return request reason model
    /// </summary>
    public partial class ReturnRequestReasonModel : BaseQNetEntityModel, ILocalizedModel<ReturnRequestReasonLocalizedModel>
    {
        #region Ctor

        public ReturnRequestReasonModel()
        {
            Locales = new List<ReturnRequestReasonLocalizedModel>();
        }

        #endregion

        #region Properties

        [QNetResourceDisplayName("Admin.Configuration.Settings.Order.ReturnRequestReasons.Name")]
        public string Name { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Settings.Order.ReturnRequestReasons.DisplayOrder")]
        public int DisplayOrder { get; set; }

        public IList<ReturnRequestReasonLocalizedModel> Locales { get; set; }

        #endregion
    }

    public partial class ReturnRequestReasonLocalizedModel : ILocalizedLocaleModel
    {
        public int LanguageId { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Settings.Order.ReturnRequestReasons.Name")]
        public string Name { get; set; }
    }
}