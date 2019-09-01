using QNet.Web.Framework.Models;
using QNet.Web.Framework.Mvc.ModelBinding;

namespace QNet.Web.Areas.Admin.Models.Settings
{
    /// <summary>
    /// Represents an admin area settings model
    /// </summary>
    public partial class AdminAreaSettingsModel : BaseQNetModel, ISettingsModel
    {
        #region Properties

        public int ActiveStoreScopeConfiguration { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Settings.GeneralCommon.AdminArea.UseRichEditorInMessageTemplates")]
        public bool UseRichEditorInMessageTemplates { get; set; }
        public bool UseRichEditorInMessageTemplates_OverrideForStore { get; set; }

        #endregion
    }
}