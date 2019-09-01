using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QNet.Core.Domain.Catalog;

namespace QNet.Data.Mapping.Catalog
{
    /// <summary>
    /// Represents a related product mapping configuration
    /// </summary>
    public partial class RelatedProductMap : QNetEntityTypeConfiguration<RelatedProduct>
    {
        #region Methods

        /// <summary>
        /// Configures the entity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<RelatedProduct> builder)
        {
            builder.ToTable(nameof(RelatedProduct));
            builder.HasKey(product => product.Id);

            base.Configure(builder);
        }

        #endregion
    }
}