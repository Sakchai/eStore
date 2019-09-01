using QNet.Web.Framework.Models;

namespace QNet.Web.Areas.Admin.Models.Plugins
{
    /// <summary>
    /// Represents a plugin model that is used for admin navigation
    /// </summary>
    public partial class AdminNavigationPluginModel : BaseQNetModel
    {
        #region Properties

        public string FriendlyName { get; set; }

        public string ConfigurationUrl { get; set; }

        #endregion
    }
}