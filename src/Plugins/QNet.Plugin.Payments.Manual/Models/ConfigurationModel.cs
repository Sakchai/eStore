using Microsoft.AspNetCore.Mvc.Rendering;
using QNet.Web.Framework.Mvc.ModelBinding;
using QNet.Web.Framework.Models;

namespace QNet.Plugin.Payments.Manual.Models
{
    public class ConfigurationModel : BaseQNetModel
    {
        public int ActiveStoreScopeConfiguration { get; set; }

        [QNetResourceDisplayName("Plugins.Payments.Manual.Fields.AdditionalFeePercentage")]
        public bool AdditionalFeePercentage { get; set; }
        public bool AdditionalFeePercentage_OverrideForStore { get; set; }

        [QNetResourceDisplayName("Plugins.Payments.Manual.Fields.AdditionalFee")]
        public decimal AdditionalFee { get; set; }
        public bool AdditionalFee_OverrideForStore { get; set; }

        public int TransactModeId { get; set; }
        [QNetResourceDisplayName("Plugins.Payments.Manual.Fields.TransactMode")]
        public SelectList TransactModeValues { get; set; }
        public bool TransactModeId_OverrideForStore { get; set; }
    }
}