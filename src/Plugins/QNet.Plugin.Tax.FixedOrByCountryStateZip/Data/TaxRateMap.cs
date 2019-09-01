using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QNet.Data.Mapping;
using QNet.Plugin.Tax.FixedOrByCountryStateZip.Domain;

namespace QNet.Plugin.Tax.FixedOrByCountryStateZip.Data
{
    /// <summary>
    /// Represents a tax rate mapping configuration
    /// </summary>
    public partial class TaxRateMap : QNetEntityTypeConfiguration<TaxRate>
    {
        #region Methods

        /// <summary>
        /// Configures the entity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<TaxRate> builder)
        {
            builder.ToTable(nameof(TaxRate));
            builder.HasKey(rate => rate.Id);

            builder.Property(rate => rate.Percentage).HasColumnType("decimal(18, 4)");
        }

        #endregion
    }
}