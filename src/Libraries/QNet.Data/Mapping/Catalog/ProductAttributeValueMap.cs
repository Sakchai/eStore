using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QNet.Core.Domain.Catalog;

namespace QNet.Data.Mapping.Catalog
{
    /// <summary>
    /// Represents a product attribute value mapping configuration
    /// </summary>
    public partial class ProductAttributeValueMap : QNetEntityTypeConfiguration<ProductAttributeValue>
    {
        #region Methods

        /// <summary>
        /// Configures the entity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<ProductAttributeValue> builder)
        {
            builder.ToTable(nameof(ProductAttributeValue));
            builder.HasKey(value => value.Id);

            builder.Property(value => value.Name).HasMaxLength(400).IsRequired();
            builder.Property(value => value.ColorSquaresRgb).HasMaxLength(100);
            builder.Property(value => value.PriceAdjustment).HasColumnType("decimal(18, 4)");
            builder.Property(value => value.WeightAdjustment).HasColumnType("decimal(18, 4)");
            builder.Property(value => value.Cost).HasColumnType("decimal(18, 4)");

            builder.HasOne(value => value.ProductAttributeMapping)
                .WithMany(productAttributeMapping => productAttributeMapping.ProductAttributeValues)
                .HasForeignKey(value => value.ProductAttributeMappingId)
                .IsRequired();

            builder.Ignore(value => value.AttributeValueType);
            builder.Property(value => value.CustomerEntersQty).HasColumnType("bit(1)");
            builder.Property(value => value.IsPreSelected).HasColumnType("bit(1)");
            builder.Property(value => value.PriceAdjustmentUsePercentage).HasColumnType("bit(1)");
            base.Configure(builder);
        }

        #endregion
    }
}