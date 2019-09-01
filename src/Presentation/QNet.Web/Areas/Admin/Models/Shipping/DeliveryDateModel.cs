using System.Collections.Generic;
using QNet.Web.Framework.Models;
using QNet.Web.Framework.Mvc.ModelBinding;

namespace QNet.Web.Areas.Admin.Models.Shipping
{
    /// <summary>
    /// Represents a delivery date model
    /// </summary>
    public partial class DeliveryDateModel : BaseQNetEntityModel, ILocalizedModel<DeliveryDateLocalizedModel>
    {
        #region Ctor

        public DeliveryDateModel()
        {
            Locales = new List<DeliveryDateLocalizedModel>();
        }

        #endregion

        #region Properties

        [QNetResourceDisplayName("Admin.Configuration.Shipping.DeliveryDates.Fields.Name")]
        public string Name { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Shipping.DeliveryDates.Fields.DisplayOrder")]
        public int DisplayOrder { get; set; }

        public IList<DeliveryDateLocalizedModel> Locales { get; set; }

        #endregion
    }

    public partial class DeliveryDateLocalizedModel : ILocalizedLocaleModel
    {
        public int LanguageId { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Shipping.DeliveryDates.Fields.Name")]
        public string Name { get; set; }
    }
}