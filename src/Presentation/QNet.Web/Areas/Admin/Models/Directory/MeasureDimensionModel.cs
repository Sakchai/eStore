using QNet.Web.Framework.Mvc.ModelBinding;
using QNet.Web.Framework.Models;

namespace QNet.Web.Areas.Admin.Models.Directory
{
    /// <summary>
    /// Represents a measure dimension model
    /// </summary>
    public partial class MeasureDimensionModel : BaseQNetEntityModel
    {
        #region Properties

        [QNetResourceDisplayName("Admin.Configuration.Shipping.Measures.Dimensions.Fields.Name")]
        public string Name { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Shipping.Measures.Dimensions.Fields.SystemKeyword")]
        public string SystemKeyword { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Shipping.Measures.Dimensions.Fields.Ratio")]
        public decimal Ratio { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Shipping.Measures.Dimensions.Fields.DisplayOrder")]
        public int DisplayOrder { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Shipping.Measures.Dimensions.Fields.IsPrimaryDimension")]
        public bool IsPrimaryDimension { get; set; }

        #endregion
    }
}