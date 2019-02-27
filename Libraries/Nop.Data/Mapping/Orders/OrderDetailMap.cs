using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nop.Core.Domain.Orders;

namespace Nop.Data.Mapping.Orders
{
    /// <summary>
    /// Represents an order note mapping configuration
    /// </summary>
    public partial class OrderDetailMap : NopEntityTypeConfiguration<OrderDetail>
    {
        #region Methods

        /// <summary>
        /// Configures the entity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<OrderDetail> entity)
        {
            entity.ToTable(nameof(OrderDetail));
            entity.HasKey(e => e.Id);

            entity.Property(e => e.AutoDebitCc).HasColumnName("AutoDebitCC");

            entity.Property(e => e.Bvol).HasColumnName("BVol");

            entity.Property(e => e.ComboPriceSchemeId).HasColumnName("ComboPriceSchemeID");

            entity.Property(e => e.ComboProdCode)
                .HasMaxLength(13)
                .IsUnicode(false);

            entity.Property(e => e.EarnedQuv)
                .HasColumnName("EarnedQUV")
                .HasColumnType("decimal(18, 2)");

            entity.Property(e => e.FirstPayment).HasColumnType("decimal(18, 2)");

            entity.Property(e => e.FullAmt).HasColumnType("decimal(18, 2)");

            entity.Property(e => e.FullDiscPrice).HasColumnType("decimal(18, 2)");

            entity.Property(e => e.FullPrice).HasColumnType("decimal(18, 2)");

            entity.Property(e => e.NextPayment).HasColumnType("decimal(18, 0)");

            entity.Property(e => e.Note)
                .IsRequired()
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            entity.Property(e => e.OrderItemNo).HasColumnType("decimal(18, 0)");

            entity.Property(e => e.OrderNo)
                .IsRequired()
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.Property(e => e.OrderQty).HasDefaultValueSql("((1))");

            entity.Property(e => e.PartialDiscPrice).HasColumnType("decimal(18, 2)");

            entity.Property(e => e.PartialPrice).HasColumnType("decimal(18, 2)");

            entity.Property(e => e.Point).HasColumnType("decimal(18, 2)");

            entity.Property(e => e.PriceSchemeId).HasColumnName("PriceSchemeID");

            entity.Property(e => e.ProdCode)
                .HasMaxLength(13)
                .IsUnicode(false);

            entity.Property(e => e.PromoId)
                .HasColumnName("PromoID")
                .HasColumnType("decimal(18, 0)");

            entity.Property(e => e.QplusBv)
                .HasColumnName("QPlusBV")
                .HasColumnType("decimal(18, 5)");

            entity.Property(e => e.RemainBalAmt).HasColumnType("decimal(18, 2)");

            entity.Property(e => e.Rsp)
                .HasColumnName("RSP")
                .HasColumnType("decimal(18, 2)");

            entity.Property(e => e.SapfullPrice)
                .HasColumnName("SAPFullPrice")
                .HasColumnType("decimal(18, 2)");

            entity.Property(e => e.ServiceId).HasColumnName("ServiceID");

            entity.Property(e => e.ShipFee).HasColumnType("decimal(18, 2)");

            entity.Property(e => e.SubProdCode)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            entity.Property(e => e.Tcext)
                .HasColumnName("TCExt")
                .HasMaxLength(3)
                .IsUnicode(false);

            entity.Property(e => e.Tco)
                .IsRequired()
                .HasColumnName("TCO")
                .HasMaxLength(8)
                .IsUnicode(false);

            entity.Property(e => e.TcsubExt)
                .HasColumnName("TCSubExt")
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

            entity.Property(e => e.Tctype).HasColumnName("TCType");

            entity.Property(e => e.Uv)
                .HasColumnName("UV")
                .HasColumnType("decimal(18, 2)");

            entity.Property(e => e.WaiveShipFee)
                .IsRequired()
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("('0')");

            entity.HasOne(d => d.OrderAttribute)
                .WithOne(p => p.OrderDetail)
                .HasForeignKey<OrderDetail>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderDetail_OrderAttribute");

            entity.HasOne(d => d.OrderHeader)
                .WithMany(p => p.OrderDetail)
                .HasForeignKey(d => d.OrderHeaderId)
                .HasConstraintName("FK_OrderDetail_OrderHeader");

            entity.HasOne(d => d.Product)
                .WithMany(p => p.OrderDetail)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_OrderDetail_ProductQ");

            base.Configure(entity);
        }

        #endregion
    }
}