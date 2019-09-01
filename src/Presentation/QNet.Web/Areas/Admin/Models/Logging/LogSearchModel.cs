using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using QNet.Web.Framework.Mvc.ModelBinding;
using QNet.Web.Framework.Models;

namespace QNet.Web.Areas.Admin.Models.Logging
{
    /// <summary>
    /// Represents a log search model
    /// </summary>
    public partial class LogSearchModel : BaseSearchModel
    {
        #region Ctor

        public LogSearchModel()
        {
            AvailableLogLevels = new List<SelectListItem>();
        }

        #endregion

        #region Properties

        [QNetResourceDisplayName("Admin.System.Log.List.CreatedOnFrom")]
        [UIHint("DateNullable")]
        public DateTime? CreatedOnFrom { get; set; }

        [QNetResourceDisplayName("Admin.System.Log.List.CreatedOnTo")]
        [UIHint("DateNullable")]
        public DateTime? CreatedOnTo { get; set; }

        [QNetResourceDisplayName("Admin.System.Log.List.Message")]
        public string Message { get; set; }

        [QNetResourceDisplayName("Admin.System.Log.List.LogLevel")]
        public int LogLevelId { get; set; }

        public IList<SelectListItem> AvailableLogLevels { get; set; }

        #endregion
    }
}