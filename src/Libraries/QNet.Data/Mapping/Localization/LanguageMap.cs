using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QNet.Core.Domain.Localization;

namespace QNet.Data.Mapping.Localization
{
    /// <summary>
    /// Represents a language mapping configuration
    /// </summary>
    public partial class LanguageMap : QNetEntityTypeConfiguration<Language>
    {
        #region Methods

        /// <summary>
        /// Configures the entity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<Language> builder)
        {
            builder.ToTable(nameof(Language));
            builder.HasKey(language => language.Id);

            builder.Property(language => language.Name).HasMaxLength(100).IsRequired();
            builder.Property(language => language.LanguageCulture).HasMaxLength(20).IsRequired();
            builder.Property(language => language.UniqueSeoCode).HasMaxLength(2);
            builder.Property(language => language.FlagImageFileName).HasMaxLength(50);
            builder.Property(language => language.LimitedToStores).HasColumnType("bit(1)");
            builder.Property(language => language.Published).HasColumnType("bit(1)");
            builder.Property(language => language.Rtl).HasColumnType("bit(1)");
            base.Configure(builder);
        }

        #endregion
    }
}