using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nop.Core.Domain.Orders;

namespace Nop.Data.Mapping.Orders
{
    /// <summary>
    /// Represents an order note mapping configuration
    /// </summary>
    public partial class OrderHeaderMap : NopEntityTypeConfiguration<OrderHeader>
    {
        #region Methods

        /// <summary>
        /// Configures the entity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<OrderHeader> entity)
        {
            entity.ToTable(nameof(OrderHeader));
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Authorizedby)
                  .IsRequired()
                  .HasMaxLength(10)
                  .IsUnicode(false);

            entity.Property(e => e.Currency)
                .HasMaxLength(3)
                .IsUnicode(false);

            entity.Property(e => e.DateEncoded).HasColumnType("smalldatetime");

            entity.Property(e => e.GatewayAuthNumber)
                .IsRequired()
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            entity.Property(e => e.GatewayTransactionNo)
                .IsRequired()
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            entity.Property(e => e.OrderDate).HasColumnType("smalldatetime");

            entity.Property(e => e.OrderNo)
                .IsRequired()
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.Property(e => e.RepOffCode)
                .IsRequired()
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.Property(e => e.RequiredDate).HasColumnType("smalldatetime");

            entity.Property(e => e.Tco)
                .IsRequired()
                .HasColumnName("TCO")
                .HasMaxLength(8)
                .IsUnicode(false);

            entity.Property(e => e.Tconame)
                .HasColumnName("TCOName")
                .HasMaxLength(180);

            entity.Property(e => e.TcOwnerId).HasColumnName("TCOwnerId");

            entity.Property(e => e.TransactionOrderId)
                .IsRequired()
                .HasColumnName("TransactionOrderID")
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            entity.Property(e => e.UserId)
                .IsRequired()
                .HasColumnName("UserID")
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.TcOwner)
                .WithMany(p => p.OrderHeader)
                .HasForeignKey(d => d.TcOwnerId)
                .HasConstraintName("FK_OrderHeader_TCOwner");

            base.Configure(entity);
        }

        #endregion
    }
}