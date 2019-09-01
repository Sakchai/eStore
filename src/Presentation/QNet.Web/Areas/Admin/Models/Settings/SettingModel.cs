using QNet.Web.Framework.Mvc.ModelBinding;
using QNet.Web.Framework.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace QNet.Web.Areas.Admin.Models.Settings
{
    /// <summary>
    /// Represents a setting model
    /// </summary>
    public partial class SettingModel : BaseQNetEntityModel
    {
        #region Ctor

        public SettingModel()
        {
            AvailableStores = new List<SelectListItem>();
        }

        #endregion

        #region Properties

        [QNetResourceDisplayName("Admin.Configuration.Settings.AllSettings.Fields.Name")]
        public string Name { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Settings.AllSettings.Fields.Value")]
        public string Value { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Settings.AllSettings.Fields.StoreName")]
        public string Store { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Settings.AllSettings.Fields.Store")]
        public int StoreId { get; set; }
        public IList<SelectListItem> AvailableStores { get; set; }

        #endregion
    }
}