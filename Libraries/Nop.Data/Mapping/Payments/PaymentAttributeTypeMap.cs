using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nop.Core.Domain.Orders;
using Nop.Core.Domain.Payments;

namespace Nop.Data.Mapping.Payments
{
    /// <summary>
    /// Represents an order note mapping configuration
    /// </summary>
    public partial class PaymentAttributeTypeMap : NopEntityTypeConfiguration<PaymentAttributeType>
    {
        #region Methods

        /// <summary>
        /// Configures the entity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<PaymentAttributeType> entity)
        {
            entity.ToTable(nameof(PaymentAttributeType));
            entity.HasKey(e => e.Id);
            entity.Property(e => e.AttributeDescription)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            base.Configure(entity);
        }

        #endregion
    }
}