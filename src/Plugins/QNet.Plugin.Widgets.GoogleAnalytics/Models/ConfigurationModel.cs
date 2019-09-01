using QNet.Web.Framework.Mvc.ModelBinding;
using QNet.Web.Framework.Models;

namespace QNet.Plugin.Widgets.GoogleAnalytics.Models
{
    public class ConfigurationModel : BaseQNetModel
    {
        public int ActiveStoreScopeConfiguration { get; set; }
        
        [QNetResourceDisplayName("Plugins.Widgets.GoogleAnalytics.GoogleId")]
        public string GoogleId { get; set; }
        public bool GoogleId_OverrideForStore { get; set; }

        [QNetResourceDisplayName("Plugins.Widgets.GoogleAnalytics.EnableEcommerce")]
        public bool EnableEcommerce { get; set; }
        public bool EnableEcommerce_OverrideForStore { get; set; }

        [QNetResourceDisplayName("Plugins.Widgets.GoogleAnalytics.UseJsToSendEcommerceInfo")]
        public bool UseJsToSendEcommerceInfo { get; set; }
        public bool UseJsToSendEcommerceInfo_OverrideForStore { get; set; }

        [QNetResourceDisplayName("Plugins.Widgets.GoogleAnalytics.TrackingScript")]
        public string TrackingScript { get; set; }
        public bool TrackingScript_OverrideForStore { get; set; }
        
        [QNetResourceDisplayName("Plugins.Widgets.GoogleAnalytics.IncludingTax")]
        public bool IncludingTax { get; set; }
        public bool IncludingTax_OverrideForStore { get; set; }

        [QNetResourceDisplayName("Plugins.Widgets.GoogleAnalytics.IncludeCustomerId")]
        public bool IncludeCustomerId { get; set; }
        public bool IncludeCustomerId_OverrideForStore { get; set; }
    }
}