using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nop.Core.Domain.Prices;
using Nop.Core.Domain.TCOs;

namespace Nop.Data.Mapping.Prices
{
    /// <summary>
    /// Represents a tcowner mapping configuration
    /// </summary>
    public partial class PriceRestrictionMap : NopEntityTypeConfiguration<PriceRestriction>
    {
        #region Methods

        /// <summary>
        /// Configures the entity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<PriceRestriction> entity)
        {
            entity.ToTable(nameof(PriceRestriction));
            entity.HasKey(e => e.Id);
            entity.Property(e => e.CountryCode)
                .IsRequired()
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.IsActive).HasColumnName("IsActive");

            entity.HasOne(d => d.PriceScheme)
                .WithMany(p => p.PriceRestriction)
                .HasForeignKey(d => d.PriceSchemeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PriceRestriction_PriceScheme");

 
            base.Configure(entity);
        }

        #endregion Methods
    }
}