using System.Collections.Generic;
using QNet.Web.Framework.Models;
using QNet.Web.Framework.Mvc.ModelBinding;

namespace QNet.Web.Areas.Admin.Models.Orders
{
    /// <summary>
    /// Represents a checkout attribute value model
    /// </summary>
    public partial class CheckoutAttributeValueModel : BaseQNetEntityModel, ILocalizedModel<CheckoutAttributeValueLocalizedModel>
    {
        #region Ctor

        public CheckoutAttributeValueModel()
        {
            Locales = new List<CheckoutAttributeValueLocalizedModel>();
        }

        #endregion

        #region Properties

        public int CheckoutAttributeId { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.Attributes.CheckoutAttributes.Values.Fields.Name")]
        public string Name { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.Attributes.CheckoutAttributes.Values.Fields.ColorSquaresRgb")]
        public string ColorSquaresRgb { get; set; }
        public bool DisplayColorSquaresRgb { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.Attributes.CheckoutAttributes.Values.Fields.PriceAdjustment")]
        public decimal PriceAdjustment { get; set; }
        public string PrimaryStoreCurrencyCode { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.Attributes.CheckoutAttributes.Values.Fields.WeightAdjustment")]
        public decimal WeightAdjustment { get; set; }
        public string BaseWeightIn { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.Attributes.CheckoutAttributes.Values.Fields.IsPreSelected")]
        public bool IsPreSelected { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.Attributes.CheckoutAttributes.Values.Fields.DisplayOrder")]
        public int DisplayOrder {get;set;}

        public IList<CheckoutAttributeValueLocalizedModel> Locales { get; set; }

        #endregion
    }

    public partial class CheckoutAttributeValueLocalizedModel : ILocalizedLocaleModel
    {
        public int LanguageId { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.Attributes.CheckoutAttributes.Values.Fields.Name")]
        public string Name { get; set; }
    }
}