using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nop.Core.Domain.Prices;
using Nop.Core.Domain.TCOs;

namespace Nop.Data.Mapping.Prices
{
    /// <summary>
    /// Represents a tcowner mapping configuration
    /// </summary>
    public partial class PricePromoMap : NopEntityTypeConfiguration<PricePromo>
    {
        #region Methods

        /// <summary>
        /// Configures the entity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<PricePromo> entity)
        {
            entity.ToTable(nameof(PricePromo));
            entity.HasKey(e => e.Id);

            entity.Property(e => e.CountryCode)
               .HasMaxLength(3)
               .IsUnicode(false);

            entity.Property(e => e.Cvpoints).HasColumnName("CVPoints");

            entity.Property(e => e.EndDate).HasColumnType("smalldatetime");

            entity.Property(e => e.FullPrice).HasColumnType("decimal(18, 2)");

            entity.Property(e => e.PartialPrice).HasColumnType("decimal(18, 2)");

            entity.Property(e => e.ProdCode)
                .IsRequired()
                .HasMaxLength(5)
                .IsUnicode(false);

            entity.Property(e => e.PromoDesc)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.Puv)
                .HasColumnName("PUV")
                .HasColumnType("decimal(18, 2)");

            entity.Property(e => e.ShipFee).HasColumnType("decimal(18, 2)");

            entity.Property(e => e.StartDate).HasColumnType("smalldatetime");

            entity.HasOne(d => d.Product)
                .WithMany(p => p.PricePromo)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_PricePromo_ProductQ");
            base.Configure(entity);
        }

        #endregion Methods
    }
}