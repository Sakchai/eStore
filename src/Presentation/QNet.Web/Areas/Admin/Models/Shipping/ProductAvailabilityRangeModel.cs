using System.Collections.Generic;
using QNet.Web.Framework.Models;
using QNet.Web.Framework.Mvc.ModelBinding;

namespace QNet.Web.Areas.Admin.Models.Shipping
{
    /// <summary>
    /// Represents a product availability range model
    /// </summary>
    public partial class ProductAvailabilityRangeModel : BaseQNetEntityModel, ILocalizedModel<ProductAvailabilityRangeLocalizedModel>
    {
        #region Ctor

        public ProductAvailabilityRangeModel()
        {
            Locales = new List<ProductAvailabilityRangeLocalizedModel>();
        }

        #endregion

        #region Properties

        [QNetResourceDisplayName("Admin.Configuration.Shipping.ProductAvailabilityRanges.Fields.Name")]
        public string Name { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Shipping.ProductAvailabilityRanges.Fields.DisplayOrder")]
        public int DisplayOrder { get; set; }

        public IList<ProductAvailabilityRangeLocalizedModel> Locales { get; set; }

        #endregion
    }

    public partial class ProductAvailabilityRangeLocalizedModel : ILocalizedLocaleModel
    {
        public int LanguageId { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Shipping.ProductAvailabilityRanges.Fields.Name")]
        public string Name { get; set; }
    }
}