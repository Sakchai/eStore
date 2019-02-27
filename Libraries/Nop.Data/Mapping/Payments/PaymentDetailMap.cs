using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nop.Core.Domain.Orders;
using Nop.Core.Domain.Payments;

namespace Nop.Data.Mapping.Payments
{
    /// <summary>
    /// Represents an order note mapping configuration
    /// </summary>
    public partial class PaymentDetailMap : NopEntityTypeConfiguration<PaymentDetail>
    {
        #region Methods

        /// <summary>
        /// Configures the entity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<PaymentDetail> entity)
        {
            entity.ToTable(nameof(PaymentDetail));
            entity.HasKey(e => e.Id);

            entity.Property(e => e.BalanceAmount).HasColumnType("decimal(18, 2)");

            entity.Property(e => e.EarnedBvol).HasColumnName("EarnedBVol");

            entity.Property(e => e.EarnedQplusBv)
                .HasColumnName("EarnedQPlusBV")
                .HasColumnType("decimal(18, 5)");

            entity.Property(e => e.EarnedQuv)
                .HasColumnName("EarnedQUV")
                .HasColumnType("decimal(18, 2)");

            entity.Property(e => e.EarnedUv)
                .HasColumnName("EarnedUV")
                .HasColumnType("decimal(18, 2)");

            entity.Property(e => e.ExRate).HasColumnType("decimal(18, 8)");

            entity.Property(e => e.FullDiscPrice)
                .HasColumnType("decimal(18, 2)")
                .HasDefaultValueSql("((0))");

            entity.Property(e => e.FullPrice).HasColumnType("decimal(18, 2)");

            entity.Property(e => e.ItemId).HasColumnName("ItemID");

            entity.Property(e => e.OrderNo)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.PartialDiscPrice)
                .HasColumnType("decimal(18, 2)")
                .HasDefaultValueSql("((0))");

            entity.Property(e => e.PartialPrice)
                .HasColumnType("decimal(18, 2)")
                .HasDefaultValueSql("((0))");

            entity.Property(e => e.PayAccount)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.PayAmount).HasColumnType("decimal(18, 2)");

            entity.Property(e => e.PayBank)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.PayModeDate).HasColumnType("datetime");

            entity.Property(e => e.PayOtherInfo)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            entity.Property(e => e.PayRefNo)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.PaymentMode)
                .HasMaxLength(3)
                .IsUnicode(false);

            entity.Property(e => e.Point).HasColumnType("decimal(18, 2)");

            entity.Property(e => e.ProdCode)
                .HasMaxLength(13)
                .IsUnicode(false);

            entity.Property(e => e.ProdCodeBk)
                .HasColumnName("ProdCode_BK")
                .HasMaxLength(13)
                .IsUnicode(false);

            entity.Property(e => e.ReceiptNo)
                .IsRequired()
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.Property(e => e.ShipFee)
                .HasColumnType("decimal(18, 2)")
                .HasDefaultValueSql("((0))");

            entity.Property(e => e.SubProdCode)
                .HasMaxLength(5)
                .IsUnicode(false);

            entity.Property(e => e.Tcext)
                .HasColumnName("TCExt")
                .HasMaxLength(3)
                .IsUnicode(false);

            entity.Property(e => e.TcsubExt)
                .HasColumnName("TCSubExt")
                .HasMaxLength(3)
                .IsUnicode(false);

            entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 2)");

            entity.Property(e => e.UspayAmount)
                .HasColumnName("USPayAmount")
                .HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.PaymentHeader)
                .WithMany(p => p.PaymentDetail)
                .HasForeignKey(d => d.PaymentHeaderId)
                .HasConstraintName("FK_PaymentDetail_PaymentHeader");

            base.Configure(entity);
        }

        #endregion
    }
}