using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nop.Core.Domain.Orders;
using Nop.Core.Domain.Payments;

namespace Nop.Data.Mapping.Payments
{
    /// <summary>
    /// Represents an order note mapping configuration
    /// </summary>
    public partial class PaymentDetailModeMap : NopEntityTypeConfiguration<PaymentDetailMode>
    {
        #region Methods

        /// <summary>
        /// Configures the entity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<PaymentDetailMode> entity)
        {
            entity.ToTable(nameof(PaymentDetailMode));
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Notes)
                 .HasMaxLength(300)
                 .IsUnicode(false);

            entity.Property(e => e.OrderNo)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.PayAccount)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.PayAmount).HasColumnType("decimal(18, 2)");

            entity.Property(e => e.PayBankType)
                .HasColumnName("PayBank_Type")
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.PayLineNo).HasColumnType("decimal(18, 0)");

            entity.Property(e => e.PayOtherInfo)
                .HasMaxLength(300)
                .IsUnicode(false);

            entity.Property(e => e.PayRefDate).HasColumnType("datetime");

            entity.Property(e => e.PayRefNo)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.PayRoute)
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.Property(e => e.PaymentMode)
                .IsRequired()
                .HasMaxLength(3)
                .IsUnicode(false);

            entity.Property(e => e.Point).HasColumnType("decimal(18, 2)");

            entity.Property(e => e.ReceiptNo)
                .IsRequired()
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.Property(e => e.Tcext)
                .HasColumnName("TCExt")
                .HasMaxLength(3)
                .IsUnicode(false);

            entity.Property(e => e.TcsubExt)
                .HasColumnName("TCSubExt")
                .HasMaxLength(3)
                .IsUnicode(false);

            entity.Property(e => e.UspayAmount)
                .HasColumnName("USPayAmount")
                .HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.PaymentDetail)
                .WithMany(p => p.PaymentDetailMode)
                .HasForeignKey(d => d.PaymentDetailId)
                .HasConstraintName("FK_PaymentDetailMode_PaymentDetail");

            base.Configure(entity);
        }

        #endregion
    }
}