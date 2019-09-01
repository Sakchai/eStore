using System.Collections.Generic;
using QNet.Web.Framework.Models;
using QNet.Web.Framework.Mvc.ModelBinding;

namespace QNet.Web.Areas.Admin.Models.Catalog
{
    /// <summary>
    /// Represents a product tag model
    /// </summary>
    public partial class ProductTagModel : BaseQNetEntityModel, ILocalizedModel<ProductTagLocalizedModel>
    {
        #region Ctor

        public ProductTagModel()
        {
            Locales = new List<ProductTagLocalizedModel>();
        }
        
        #endregion

        #region Properties

        [QNetResourceDisplayName("Admin.Catalog.ProductTags.Fields.Name")]
        public string Name { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.ProductTags.Fields.ProductCount")]
        public int ProductCount { get; set; }

        public IList<ProductTagLocalizedModel> Locales { get; set; }

        #endregion
    }

    public partial class ProductTagLocalizedModel : ILocalizedLocaleModel
    {
        public int LanguageId { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.ProductTags.Fields.Name")]
        public string Name { get; set; }
    }
}