using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QNet.Core.Domain.Catalog;

namespace QNet.Data.Mapping.Catalog
{
    /// <summary>
    /// Represents a product attribute mapping configuration
    /// </summary>
    public partial class ProductAttributeMap : QNetEntityTypeConfiguration<ProductAttribute>
    {
        #region Methods

        /// <summary>
        /// Configures the entity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<ProductAttribute> builder)
        {
            builder.ToTable(nameof(ProductAttribute));
            builder.HasKey(attribute => attribute.Id);

            builder.Property(attribute => attribute.Name).IsRequired();

            base.Configure(builder);
        }

        #endregion
    }
}