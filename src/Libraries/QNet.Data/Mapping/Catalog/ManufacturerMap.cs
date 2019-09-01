using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QNet.Core.Domain.Catalog;

namespace QNet.Data.Mapping.Catalog
{
    /// <summary>
    /// Represents a manufacturer mapping configuration
    /// </summary>
    public partial class ManufacturerMap : QNetEntityTypeConfiguration<Manufacturer>
    {
        #region Methods

        /// <summary>
        /// Configures the entity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<Manufacturer> builder)
        {
            builder.ToTable(nameof(Manufacturer));
            builder.HasKey(manufacturer => manufacturer.Id);

            builder.Property(manufacturer => manufacturer.Name).HasMaxLength(400).IsRequired();
            builder.Property(manufacturer => manufacturer.MetaKeywords).HasMaxLength(400);
            builder.Property(manufacturer => manufacturer.MetaTitle).HasMaxLength(400);
            builder.Property(manufacturer => manufacturer.PriceRanges).HasMaxLength(400);
            builder.Property(manufacturer => manufacturer.PageSizeOptions).HasMaxLength(200);
            
            builder.Ignore(manufacturer => manufacturer.AppliedDiscounts);
            builder.Property(manufacturer => manufacturer.AllowCustomersToSelectPageSize).HasColumnType("bit(1)");
            builder.Property(manufacturer => manufacturer.AllowCustomersToSelectPageSize).HasColumnType("bit(1)");
            builder.Property(manufacturer => manufacturer.Deleted).HasColumnType("bit(1)");
            builder.Property(manufacturer => manufacturer.LimitedToStores).HasColumnType("bit(1)");
            builder.Property(manufacturer => manufacturer.Published).HasColumnType("bit(1)");
            builder.Property(manufacturer => manufacturer.SubjectToAcl).HasColumnType("bit(1)");
            base.Configure(builder);
        }

        #endregion
    }
}