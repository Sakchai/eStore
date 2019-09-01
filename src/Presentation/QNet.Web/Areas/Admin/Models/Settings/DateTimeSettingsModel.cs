using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using QNet.Web.Framework.Models;
using QNet.Web.Framework.Mvc.ModelBinding;

namespace QNet.Web.Areas.Admin.Models.Settings
{
    /// <summary>
    /// Represents a date time settings model
    /// </summary>
    public partial class DateTimeSettingsModel : BaseQNetModel, ISettingsModel
    {
        #region Ctor

        public DateTimeSettingsModel()
        {
            AvailableTimeZones = new List<SelectListItem>();
        }

        #endregion

        #region Properties

        public int ActiveStoreScopeConfiguration { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Settings.CustomerUser.AllowCustomersToSetTimeZone")]
        public bool AllowCustomersToSetTimeZone { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Settings.CustomerUser.DefaultStoreTimeZone")]
        public string DefaultStoreTimeZoneId { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Settings.CustomerUser.DefaultStoreTimeZone")]
        public IList<SelectListItem> AvailableTimeZones { get; set; }

        #endregion
    }
}