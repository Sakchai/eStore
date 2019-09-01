using System.Collections.Generic;
using QNet.Core.Domain.Localization;
using QNet.Core.Domain.Seo;

namespace QNet.Core.Domain.Catalog
{
    /// <summary>
    /// Represents a product tag
    /// </summary>
    public partial class ProductTag : BaseEntity, ILocalizedEntity, ISlugSupported
    {
        private ICollection<ProductProductTagMapping> _productProductTagMappings;

        /// <summary>
        /// Gets or sets the name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets product-product tag mappings
        /// </summary>
        public virtual ICollection<ProductProductTagMapping> ProductProductTagMappings
        {
            get => _productProductTagMappings ?? (_productProductTagMappings = new List<ProductProductTagMapping>());
            protected set => _productProductTagMappings = value;
        }
    }
}