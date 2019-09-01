using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QNet.Core.Domain.Orders;

namespace QNet.Data.Mapping.Orders
{
    /// <summary>
    /// Represents a checkout attribute value mapping configuration
    /// </summary>
    public partial class CheckoutAttributeValueMap : QNetEntityTypeConfiguration<CheckoutAttributeValue>
    {
        #region Methods

        /// <summary>
        /// Configures the entity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<CheckoutAttributeValue> builder)
        {
            builder.ToTable(nameof(CheckoutAttributeValue));
            builder.HasKey(value => value.Id);

            builder.Property(value => value.Name).HasMaxLength(400).IsRequired();
            builder.Property(value => value.ColorSquaresRgb).HasMaxLength(100);
            builder.Property(value => value.PriceAdjustment).HasColumnType("decimal(18, 4)");
            builder.Property(value => value.WeightAdjustment).HasColumnType("decimal(18, 4)");

            builder.HasOne(value => value.CheckoutAttribute)
                .WithMany(attribute => attribute.CheckoutAttributeValues)
                .HasForeignKey(value => value.CheckoutAttributeId)
                .IsRequired();
            builder.Property(value => value.IsPreSelected).HasColumnType("bit(1)");

            base.Configure(builder);
        }

        #endregion
    }
}