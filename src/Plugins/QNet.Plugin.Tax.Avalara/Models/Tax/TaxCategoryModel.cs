using QNet.Web.Framework.Mvc.ModelBinding;

namespace QNet.Plugin.Tax.Avalara.Models.Tax
{
    /// <summary>
    /// Represents an extended tax category model
    /// </summary>
    public class TaxCategoryModel : QNet.Web.Areas.Admin.Models.Tax.TaxCategoryModel
    {
        #region Properties

        public string Description { get; set; }

        [QNetResourceDisplayName("Plugins.Tax.Avalara.Fields.TaxCodeType")]
        public string TypeId { get; set; }
        public string Type { get; set; }

        #endregion
    }
}