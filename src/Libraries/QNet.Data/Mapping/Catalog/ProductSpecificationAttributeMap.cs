using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QNet.Core.Domain.Catalog;

namespace QNet.Data.Mapping.Catalog
{
    /// <summary>
    /// Represents a product specification attribute mapping configuration
    /// </summary>
    public partial class ProductSpecificationAttributeMap : QNetEntityTypeConfiguration<ProductSpecificationAttribute>
    {
        #region Methods

        /// <summary>
        /// Configures the entity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<ProductSpecificationAttribute> builder)
        {
            builder.ToTable(QNetMappingDefaults.ProductSpecificationAttributeTable);
            builder.HasKey(productSpecificationAttribute => productSpecificationAttribute.Id);

            builder.Property(productSpecificationAttribute => productSpecificationAttribute.CustomValue).HasMaxLength(4000);

            builder.HasOne(productSpecificationAttribute => productSpecificationAttribute.SpecificationAttributeOption)
                .WithMany()
                .HasForeignKey(productSpecificationAttribute => productSpecificationAttribute.SpecificationAttributeOptionId)
                .IsRequired();

            builder.HasOne(productSpecificationAttribute => productSpecificationAttribute.Product)
                .WithMany(product => product.ProductSpecificationAttributes)
                .HasForeignKey(productSpecificationAttribute => productSpecificationAttribute.ProductId)
                .IsRequired();

            builder.Ignore(productSpecificationAttribute => productSpecificationAttribute.AttributeType);
            builder.Property(productSpecificationAttribute => productSpecificationAttribute.AllowFiltering).HasColumnType("bit(1)");
            builder.Property(productSpecificationAttribute => productSpecificationAttribute.ShowOnProductPage).HasColumnType("bit(1)");
            base.Configure(builder);
        }

        #endregion
    }
}