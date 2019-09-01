using QNet.Web.Framework.Models;

namespace QNet.Web.Areas.Admin.Models.Settings
{
    /// <summary>
    /// Represents a setting mode model
    /// </summary>
    public partial class SettingModeModel : BaseQNetModel
    {
        #region Properties

        public string ModeName { get; set; }

        public bool Enabled { get; set; }

        #endregion
    }
}