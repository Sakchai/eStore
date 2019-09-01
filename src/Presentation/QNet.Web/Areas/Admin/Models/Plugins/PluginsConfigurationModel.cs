using QNet.Web.Areas.Admin.Models.Plugins.Marketplace;
using QNet.Web.Framework.Models;

namespace QNet.Web.Areas.Admin.Models.Plugins
{
    /// <summary>
    /// Represents a plugins configuration model
    /// </summary>
    public partial class PluginsConfigurationModel : BaseQNetModel
    {
        #region Ctor

        public PluginsConfigurationModel()
        {
            PluginsLocal = new PluginSearchModel();
            AllPluginsAndThemes = new OfficialFeedPluginSearchModel();
        }

        #endregion

        #region Properties

        public PluginSearchModel PluginsLocal { get; set; }

        public OfficialFeedPluginSearchModel AllPluginsAndThemes { get; set; }

        #endregion
    }
}
