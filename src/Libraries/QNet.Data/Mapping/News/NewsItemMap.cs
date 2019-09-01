using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QNet.Core.Domain.News;

namespace QNet.Data.Mapping.News
{
    /// <summary>
    /// Represents a news mapping configuration
    /// </summary>
    public partial class NewsItemMap : QNetEntityTypeConfiguration<NewsItem>
    {
        #region Methods

        /// <summary>
        /// Configures the entity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<NewsItem> builder)
        {
            builder.ToTable(QNetMappingDefaults.NewsItemTable);
            builder.HasKey(newsItem => newsItem.Id);

            builder.Property(newsItem => newsItem.Title).IsRequired();
            builder.Property(newsItem => newsItem.Short).IsRequired();
            builder.Property(newsItem => newsItem.Full).IsRequired();
            builder.Property(newsItem => newsItem.MetaKeywords).HasMaxLength(400);
            builder.Property(newsItem => newsItem.MetaTitle).HasMaxLength(400);

            builder.HasOne(newsItem => newsItem.Language)
                .WithMany()
                .HasForeignKey(newsItem => newsItem.LanguageId)
                .IsRequired();
            builder.Property(news => news.AllowComments).HasColumnType("bit(1)");
            builder.Property(news => news.LimitedToStores).HasColumnType("bit(1)");
            builder.Property(news => news.Published).HasColumnType("bit(1)");
            base.Configure(builder);
        }

        #endregion
    }
}