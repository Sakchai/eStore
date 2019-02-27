using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nop.Core.Domain.Orders;
using Nop.Core.Domain.Payments;

namespace Nop.Data.Mapping.Payments
{
    /// <summary>
    /// Represents an order note mapping configuration
    /// </summary>
    public partial class PaymentHeaderMap : NopEntityTypeConfiguration<PaymentHeader>
    {
        #region Methods

        /// <summary>
        /// Configures the entity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<PaymentHeader> entity)
        {
            entity.ToTable(nameof(PaymentHeader));
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Currency)
               .HasMaxLength(3)
               .IsUnicode(false);

            entity.Property(e => e.OrderNo)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.PaidStatus)
                .IsRequired()
                .HasMaxLength(18)
                .IsUnicode(false)
                .HasDefaultValueSql("('0')");

            entity.Property(e => e.ReceiptDate).HasColumnType("datetime");

            entity.Property(e => e.ReceiptNo)
                .IsRequired()
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.Property(e => e.ReceivedBy)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.Property(e => e.RepOffCode)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.Property(e => e.Status).HasDefaultValueSql("((0))");

            entity.Property(e => e.Tco)
                .HasColumnName("TCO")
                .HasMaxLength(8)
                .IsUnicode(false);

            entity.Property(e => e.Tconame)
                .HasColumnName("TCOName")
                .HasMaxLength(180);

            entity.Property(e => e.TcOwnerId).HasColumnName("TCOwnerId");

            entity.Property(e => e.TranFee).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.TcOwner)
                .WithMany(p => p.PaymentHeader)
                .HasForeignKey(d => d.TcOwnerId)
                .HasConstraintName("FK_PaymentHeader_TCOwner");

            base.Configure(entity);
        }

        #endregion
    }
}