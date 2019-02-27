using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nop.Core.Domain.Prices;
using Nop.Core.Domain.TCOs;

namespace Nop.Data.Mapping.Prices
{
    /// <summary>
    /// Represents a tcowner mapping configuration
    /// </summary>
    public partial class PriceSchemeMap : NopEntityTypeConfiguration<PriceScheme>
    {
        #region Methods

        /// <summary>
        /// Configures the entity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<PriceScheme> entity)
        {
            entity.ToTable(nameof(PriceScheme));
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Bv)
                 .HasColumnName("BV")
                 .HasColumnType("decimal(18, 2)");

            entity.Property(e => e.CPriceSchemeId).HasColumnName("C_PriceSchemeId");

            entity.Property(e => e.CProdCode)
                .HasColumnName("C_ProdCode")
                .HasMaxLength(13)
                .IsUnicode(false);

            entity.Property(e => e.CreationDate).HasColumnType("datetime");

            entity.Property(e => e.Currency)
                .IsRequired()
                .HasMaxLength(3)
                .IsUnicode(false);

            entity.Property(e => e.CustomerTypeId).HasColumnName("CustomerTypeId");

            entity.Property(e => e.Cuv)
                .HasColumnName("CUV")
                .HasColumnType("decimal(18, 2)");

            entity.Property(e => e.CyclePoints).HasColumnType("decimal(18, 2)");

            entity.Property(e => e.Dsp)
                .HasColumnName("DSP")
                .HasColumnType("decimal(18, 2)");

            entity.Property(e => e.EndDate).HasColumnType("datetime");

            entity.Property(e => e.FirstPayment).HasColumnType("decimal(18, 2)");

            entity.Property(e => e.FullPrice).HasColumnType("decimal(18, 2)");

            entity.Property(e => e.NextPayment).HasColumnType("decimal(18, 2)");

            entity.Property(e => e.PartialPrice).HasColumnType("decimal(18, 2)");

            entity.Property(e => e.PricePlanId).HasColumnName("PricePlanId");

            entity.Property(e => e.PriceSchemeName)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.ProdCode)
                .IsRequired()
                .HasMaxLength(13)
                .IsUnicode(false);

            entity.Property(e => e.Qcuv)
                .HasColumnName("QCUV")
                .HasColumnType("decimal(18, 2)");

            entity.Property(e => e.QplusBv)
                .HasColumnName("QPlusBV")
                .HasColumnType("decimal(18, 5)");

            entity.Property(e => e.Quv)
                .HasColumnName("QUV")
                .HasColumnType("decimal(18, 2)");

            entity.Property(e => e.Rcuv)
                .HasColumnName("RCUV")
                .HasColumnType("decimal(18, 2)");

            entity.Property(e => e.RegularPrice).HasColumnType("decimal(18, 2)");

            entity.Property(e => e.RegularVolume).HasColumnType("decimal(18, 4)");

            entity.Property(e => e.ShipFee).HasColumnType("decimal(18, 2)");

            entity.Property(e => e.StartDate).HasColumnType("datetime");

            entity.Property(e => e.UpdatedBy)
                .IsRequired()
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.HasOne(d => d.Product)
                .WithMany(p => p.PriceScheme)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_PriceScheme_ProductQ");

            base.Configure(entity);
        }

        #endregion Methods
    }
}