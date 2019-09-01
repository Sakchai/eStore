using QNet.Web.Framework.Models;
using QNet.Web.Framework.Mvc.ModelBinding;

namespace QNet.Web.Areas.Admin.Models.Catalog
{
    /// <summary>
    /// Represents an add specification attribute localized model
    /// </summary>
    public partial class AddSpecificationAttributeLocalizedModel : ILocalizedLocaleModel
    {
        public int LanguageId { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.Products.SpecificationAttributes.Fields.CustomValue")]
        public string ValueRaw { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.Products.SpecificationAttributes.Fields.CustomValue")]
        public string Value { get; set; }
    }
}