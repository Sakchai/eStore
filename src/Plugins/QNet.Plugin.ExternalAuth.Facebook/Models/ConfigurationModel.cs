using QNet.Web.Framework.Models;
using QNet.Web.Framework.Mvc.ModelBinding;

namespace QNet.Plugin.ExternalAuth.Facebook.Models
{
    /// <summary>
    /// Represents plugin configuration model
    /// </summary>
    public class ConfigurationModel : BaseQNetModel
    {
        [QNetResourceDisplayName("Plugins.ExternalAuth.Facebook.ClientKeyIdentifier")]
        public string ClientId { get; set; }

        [QNetResourceDisplayName("Plugins.ExternalAuth.Facebook.ClientSecret")]
        public string ClientSecret { get; set; }
    }
}