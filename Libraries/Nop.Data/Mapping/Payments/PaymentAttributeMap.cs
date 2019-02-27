using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nop.Core.Domain.Orders;
using Nop.Core.Domain.Payments;

namespace Nop.Data.Mapping.Payments
{
    /// <summary>
    /// Represents an order note mapping configuration
    /// </summary>
    public partial class PaymentAttributeMap : NopEntityTypeConfiguration<PaymentAttribute>
    {
        #region Methods

        /// <summary>
        /// Configures the entity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<PaymentAttribute> entity)
        {
            entity.ToTable(nameof(PaymentAttribute));
            entity.HasKey(e => e.Id);

            entity.Property(e => e.CreatedBy)
                  .HasMaxLength(8)
                  .IsUnicode(false);

            entity.Property(e => e.NumericValue).HasColumnType("decimal(18, 2)");

            entity.Property(e => e.ReceiptNo)
                .IsRequired()
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.Property(e => e.Remarks)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.TextValue)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.PaymentAttributeType)
                .WithMany(p => p.PaymentAttribute)
                .HasForeignKey(d => d.PaymentAttributeTypeId)
                .HasConstraintName("FK_PaymentAttribute_PaymentAttributeType");

            entity.HasOne(d => d.PaymentHeader)
                .WithMany(p => p.PaymentAttribute)
                .HasForeignKey(d => d.PaymentHeaderId)
                .HasConstraintName("FK_PaymentAttribute_PaymentHeader");

            base.Configure(entity);
        }

        #endregion
    }
}