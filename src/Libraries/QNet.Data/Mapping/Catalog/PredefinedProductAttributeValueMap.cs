using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QNet.Core.Domain.Catalog;

namespace QNet.Data.Mapping.Catalog
{
    /// <summary>
    /// Represents a predefined product attribute value mapping configuration
    /// </summary>
    public partial class PredefinedProductAttributeValueMap : QNetEntityTypeConfiguration<PredefinedProductAttributeValue>
    {
        #region Methods

        /// <summary>
        /// Configures the entity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<PredefinedProductAttributeValue> builder)
        {
            builder.ToTable(nameof(PredefinedProductAttributeValue));
            builder.HasKey(value => value.Id);

            builder.Property(value => value.Name).HasMaxLength(400).IsRequired();
            builder.Property(value => value.PriceAdjustment).HasColumnType("decimal(18, 4)");
            builder.Property(value => value.WeightAdjustment).HasColumnType("decimal(18, 4)");
            builder.Property(value => value.Cost).HasColumnType("decimal(18, 4)");

            builder.HasOne(value => value.ProductAttribute)
                .WithMany()
                .HasForeignKey(value => value.ProductAttributeId)
                .IsRequired();
            builder.Property(value => value.IsPreSelected).HasColumnType("bit(1)");
            builder.Property(value => value.PriceAdjustmentUsePercentage).HasColumnType("bit(1)");
            base.Configure(builder);
        }

        #endregion
    }
}