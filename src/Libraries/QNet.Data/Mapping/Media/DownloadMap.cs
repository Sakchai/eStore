using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QNet.Core.Domain.Media;

namespace QNet.Data.Mapping.Media
{
    /// <summary>
    /// Represents a download mapping configuration
    /// </summary>
    public partial class DownloadMap : QNetEntityTypeConfiguration<Download>
    {
        #region Methods

        /// <summary>
        /// Configures the entity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<Download> builder)
        {
            builder.ToTable(nameof(Download));
            builder.HasKey(download => download.Id);
            builder.Property(download => download.IsNew).HasColumnType("bit(1)");
            builder.Property(download => download.UseDownloadUrl).HasColumnType("bit(1)");
            base.Configure(builder);
        }

        #endregion
    }
}