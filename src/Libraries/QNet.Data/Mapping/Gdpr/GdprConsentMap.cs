using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QNet.Core.Domain.Gdpr;

namespace QNet.Data.Mapping.Gdpr
{
    /// <summary>
    /// Represents a GDPR consent mapping configuration
    /// </summary>
    public partial class GdprConsentMap : QNetEntityTypeConfiguration<GdprConsent>
    {
        #region Methods

        /// <summary>
        /// Configures the entity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<GdprConsent> builder)
        {
            builder.ToTable(nameof(GdprConsent));
            builder.HasKey(gdpr => gdpr.Id);

            builder.Property(category => category.Message).IsRequired();
            builder.Property(gdpr => gdpr.DisplayDuringRegistration).HasColumnType("bit(1)");
            builder.Property(gdpr => gdpr.DisplayOnCustomerInfoPage).HasColumnType("bit(1)");
            builder.Property(gdpr => gdpr.IsRequired).HasColumnType("bit(1)");
            base.Configure(builder);
        }

        #endregion
    }
}