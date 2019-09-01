using System.Collections.Generic;
using QNet.Web.Framework.Models;
using QNet.Web.Framework.Mvc.ModelBinding;

namespace QNet.Web.Areas.Admin.Models.Catalog
{
    /// <summary>
    /// Represents a product attribute model
    /// </summary>
    public partial class ProductAttributeModel : BaseQNetEntityModel, ILocalizedModel<ProductAttributeLocalizedModel>
    {
        #region Ctor

        public ProductAttributeModel()
        {
            Locales = new List<ProductAttributeLocalizedModel>();
            PredefinedProductAttributeValueSearchModel = new PredefinedProductAttributeValueSearchModel();
            ProductAttributeProductSearchModel = new ProductAttributeProductSearchModel();
        }

        #endregion

        #region Properties

        [QNetResourceDisplayName("Admin.Catalog.Attributes.ProductAttributes.Fields.Name")]
        public string Name { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.Attributes.ProductAttributes.Fields.Description")]
        public string Description {get;set;}

        public IList<ProductAttributeLocalizedModel> Locales { get; set; }

        public PredefinedProductAttributeValueSearchModel PredefinedProductAttributeValueSearchModel { get; set; }

        public ProductAttributeProductSearchModel ProductAttributeProductSearchModel { get; set; }

        #endregion
    }

    public partial class ProductAttributeLocalizedModel : ILocalizedLocaleModel
    {
        public int LanguageId { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.Attributes.ProductAttributes.Fields.Name")]
        public string Name { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.Attributes.ProductAttributes.Fields.Description")]
        public string Description {get;set;}
    }
}