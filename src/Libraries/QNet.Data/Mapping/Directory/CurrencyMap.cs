using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QNet.Core.Domain.Directory;

namespace QNet.Data.Mapping.Directory
{
    /// <summary>
    /// Represents a currency mapping configuration
    /// </summary>
    public partial class CurrencyMap : QNetEntityTypeConfiguration<Currency>
    {
        #region Methods

        /// <summary>
        /// Configures the entity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<Currency> builder)
        {
            builder.ToTable(nameof(Currency));
            builder.HasKey(currency => currency.Id);

            builder.Property(currency => currency.Name).HasMaxLength(50).IsRequired();
            builder.Property(currency => currency.CurrencyCode).HasMaxLength(5).IsRequired();
            builder.Property(currency => currency.DisplayLocale).HasMaxLength(50);
            builder.Property(currency => currency.CustomFormatting).HasMaxLength(50);
            builder.Property(currency => currency.Rate).HasColumnType("decimal(18, 4)");

            builder.Ignore(currency => currency.RoundingType);
            builder.Property(currency => currency.LimitedToStores).HasColumnType("bit(1)");
            builder.Property(currency => currency.Published).HasColumnType("bit(1)");
            base.Configure(builder);
        }

        #endregion
    }
}