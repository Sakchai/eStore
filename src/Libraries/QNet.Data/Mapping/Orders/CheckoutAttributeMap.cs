using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QNet.Core.Domain.Orders;

namespace QNet.Data.Mapping.Orders
{
    /// <summary>
    /// Represents a checkout attribute mapping configuration
    /// </summary>
    public partial class CheckoutAttributeMap : QNetEntityTypeConfiguration<CheckoutAttribute>
    {
        #region Methods

        /// <summary>
        /// Configures the entity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<CheckoutAttribute> builder)
        {
            builder.ToTable(nameof(CheckoutAttribute));
            builder.HasKey(attribute => attribute.Id);

            builder.Property(attribute => attribute.Name).HasMaxLength(400).IsRequired();

            builder.Ignore(attribute => attribute.AttributeControlType);
            builder.Property(attribute => attribute.IsRequired).HasColumnType("bit(1)");
            builder.Property(attribute => attribute.ShippableProductRequired).HasColumnType("bit(1)");
            builder.Property(attribute => attribute.IsTaxExempt).HasColumnType("bit(1)");
            builder.Property(attribute => attribute.LimitedToStores).HasColumnType("bit(1)");
            base.Configure(builder);
        }

        #endregion
    }
}