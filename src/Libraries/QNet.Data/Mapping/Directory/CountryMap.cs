using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QNet.Core.Domain.Directory;

namespace QNet.Data.Mapping.Directory
{
    /// <summary>
    /// Represents a country mapping configuration
    /// </summary>
    public partial class CountryMap : QNetEntityTypeConfiguration<Country>
    {
        #region Methods

        /// <summary>
        /// Configures the entity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.ToTable(nameof(Country));
            builder.HasKey(country => country.Id);

            builder.Property(country => country.Name).HasMaxLength(100).IsRequired();
            builder.Property(country => country.TwoLetterIsoCode).HasMaxLength(2);
            builder.Property(country => country.ThreeLetterIsoCode).HasMaxLength(3);
            builder.Property(country => country.AllowsBilling).HasColumnType("bit(1)");
            builder.Property(country => country.AllowsShipping).HasColumnType("bit(1)");
            builder.Property(country => country.LimitedToStores).HasColumnType("bit(1)");
            builder.Property(country => country.Published).HasColumnType("bit(1)");
            builder.Property(country => country.SubjectToVat).HasColumnType("bit(1)");
            base.Configure(builder);
        }

        #endregion
    }
}