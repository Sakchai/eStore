using QNet.Web.Framework.Models;
using QNet.Web.Framework.Mvc.ModelBinding;

namespace QNet.Web.Areas.Admin.Models.Catalog
{
    /// <summary>
    /// Represents a model of products that use the specification attribute
    /// </summary>
    public partial class SpecificationAttributeProductModel : BaseQNetEntityModel
    {
        #region Properties

        public int SpecificationAttributeId { get; set; }

        public int ProductId { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.Attributes.SpecificationAttributes.UsedByProducts.Product")]
        public string ProductName { get; set; }

        [QNetResourceDisplayName("Admin.Catalog.Attributes.SpecificationAttributes.UsedByProducts.Published")]
        public bool Published { get; set; }

        #endregion
    }
}