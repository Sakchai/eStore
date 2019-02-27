using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nop.Core.Domain.Prices;
using Nop.Core.Domain.TCOs;

namespace Nop.Data.Mapping.Prices
{
    /// <summary>
    /// Represents a tcowner mapping configuration
    /// </summary>
    public partial class PriceProductMap : NopEntityTypeConfiguration<PriceProduct>
    {
        #region Methods

        /// <summary>
        /// Configures the entity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<PriceProduct> entity)
        {
            entity.ToTable(nameof(PriceProduct));
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Cvpoints).HasColumnName("CVPoints");

            entity.Property(e => e.EndDate).HasColumnType("smalldatetime");

            entity.Property(e => e.FullPrice).HasColumnType("decimal(18, 2)");

            entity.Property(e => e.Opprice)
                .HasColumnName("OPPrice")
                .HasColumnType("decimal(18, 0)");

            entity.Property(e => e.OpshipFee)
                .HasColumnName("OPShipFee")
                .HasColumnType("decimal(18, 0)");

            entity.Property(e => e.PartialPrice).HasColumnType("decimal(18, 2)");

            entity.Property(e => e.ProdCode)
                .IsRequired()
                .HasMaxLength(5)
                .IsUnicode(false);

            entity.Property(e => e.ShipFee).HasColumnType("decimal(18, 2)");

            entity.Property(e => e.StartDate).HasColumnType("smalldatetime");

            entity.HasOne(d => d.Product)
                .WithMany(p => p.PriceProduct)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_PriceProduct_ProductQ");
            base.Configure(entity);
        }

        #endregion Methods
    }
}