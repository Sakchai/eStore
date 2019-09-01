using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QNet.Core.Domain.Catalog;

namespace QNet.Data.Mapping.Catalog
{
    /// <summary>
    /// Represents a product product attribute mapping configuration
    /// </summary>
    public partial class ProductAttributeMappingMap : QNetEntityTypeConfiguration<ProductAttributeMapping>
    {
        #region Methods

        /// <summary>
        /// Configures the entity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<ProductAttributeMapping> builder)
        {
            builder.ToTable(QNetMappingDefaults.ProductProductAttributeTable);
            builder.HasKey(productAttributeMapping => productAttributeMapping.Id);

            builder.HasOne(productAttributeMapping => productAttributeMapping.Product)
                .WithMany(product => product.ProductAttributeMappings)
                .HasForeignKey(productAttributeMapping => productAttributeMapping.ProductId)
                .IsRequired();

            builder.HasOne(productAttributeMapping => productAttributeMapping.ProductAttribute)
                .WithMany()
                .HasForeignKey(productAttributeMapping => productAttributeMapping.ProductAttributeId)
                .IsRequired();

            builder.Ignore(pam => pam.AttributeControlType);
            builder.Property(productAttributeMapping => productAttributeMapping.IsRequired).HasColumnType("bit(1)");
            base.Configure(builder);
        }

        #endregion
    }
}