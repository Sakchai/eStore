using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using QNet.Web.Framework.Mvc.ModelBinding;
using QNet.Web.Framework.Models;

namespace QNet.Web.Areas.Admin.Models.Plugins
{
    /// <summary>
    /// Represents a plugin search model
    /// </summary>
    public partial class PluginSearchModel : BaseSearchModel
    {
        #region Ctor

        public PluginSearchModel()
        {
            AvailableLoadModes = new List<SelectListItem>();
            AvailableGroups = new List<SelectListItem>();
        }

        #endregion

        #region Properties

        [QNetResourceDisplayName("Admin.Configuration.Plugins.LoadMode")]
        public int SearchLoadModeId { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Plugins.Group")]
        public string SearchGroup { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Plugins.LoadMode")]
        public IList<SelectListItem> AvailableLoadModes { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Plugins.Group")]
        public IList<SelectListItem> AvailableGroups { get; set; }

        public bool NeedToRestart { get; set; }

        #endregion
    }
}