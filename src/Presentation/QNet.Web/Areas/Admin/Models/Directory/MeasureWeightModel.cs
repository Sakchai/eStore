using QNet.Web.Framework.Mvc.ModelBinding;
using QNet.Web.Framework.Models;

namespace QNet.Web.Areas.Admin.Models.Directory
{
    /// <summary>
    /// Represents a measure weight model
    /// </summary>
    public partial class MeasureWeightModel : BaseQNetEntityModel
    {
        #region Properties

        [QNetResourceDisplayName("Admin.Configuration.Shipping.Measures.Weights.Fields.Name")]
        public string Name { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Shipping.Measures.Weights.Fields.SystemKeyword")]
        public string SystemKeyword { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Shipping.Measures.Weights.Fields.Ratio")]
        public decimal Ratio { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Shipping.Measures.Weights.Fields.DisplayOrder")]
        public int DisplayOrder { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Shipping.Measures.Weights.Fields.IsPrimaryWeight")]
        public bool IsPrimaryWeight { get; set; }

        #endregion
    }
}