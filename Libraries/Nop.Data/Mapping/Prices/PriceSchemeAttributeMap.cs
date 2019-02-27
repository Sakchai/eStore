using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nop.Core.Domain.Prices;
using Nop.Core.Domain.TCOs;

namespace Nop.Data.Mapping.Prices
{
    /// <summary>
    /// Represents a tcowner mapping configuration
    /// </summary>
    public partial class PriceSchemeAttributeMap : NopEntityTypeConfiguration<PriceSchemeAttribute>
    {
        #region Methods

        /// <summary>
        /// Configures the entity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<PriceSchemeAttribute> entity)
        {
            entity.ToTable(nameof(PriceSchemeAttribute));
            entity.HasKey(e => e.Id);

            entity.Property(e => e.CreateBy)
                 .HasMaxLength(15)
                 .IsUnicode(false);

            entity.Property(e => e.NumericValue).HasColumnType("decimal(18, 2)");

            entity.Property(e => e.Remarks)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.TextValue).HasMaxLength(200);

            entity.HasOne(d => d.PriceScheme)
                .WithMany(p => p.PriceSchemeAttribute)
                .HasForeignKey(d => d.PriceSchemeId)
                .HasConstraintName("FK_PriceSchemeAttributes_PriceScheme");

            base.Configure(entity);
        }

        #endregion Methods
    }
}