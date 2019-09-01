using System.Collections.Generic;
using QNet.Web.Framework.Models;
using QNet.Web.Framework.Mvc.ModelBinding;

namespace QNet.Web.Areas.Admin.Models.Shipping
{
    /// <summary>
    /// Represents a shipping method model
    /// </summary>
    public partial class ShippingMethodModel : BaseQNetEntityModel, ILocalizedModel<ShippingMethodLocalizedModel>
    {
        #region Ctor

        public ShippingMethodModel()
        {
            Locales = new List<ShippingMethodLocalizedModel>();
        }

        #endregion

        #region Properties

        [QNetResourceDisplayName("Admin.Configuration.Shipping.Methods.Fields.Name")]
        public string Name { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Shipping.Methods.Fields.Description")]
        public string Description { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Shipping.Methods.Fields.DisplayOrder")]
        public int DisplayOrder { get; set; }

        public IList<ShippingMethodLocalizedModel> Locales { get; set; }

        #endregion
    }

    public partial class ShippingMethodLocalizedModel : ILocalizedLocaleModel
    {
        public int LanguageId { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Shipping.Methods.Fields.Name")]
        public string Name { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Shipping.Methods.Fields.Description")]
        public string Description { get; set; }
    }
}