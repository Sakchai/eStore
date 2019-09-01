using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QNet.Core.Domain.News;

namespace QNet.Data.Mapping.News
{
    /// <summary>
    /// Represents a news comment mapping configuration
    /// </summary>
    public partial class NewsCommentMap : QNetEntityTypeConfiguration<NewsComment>
    {
        #region Methods

        /// <summary>
        /// Configures the entity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<NewsComment> builder)
        {
            builder.ToTable(nameof(NewsComment));
            builder.HasKey(comment => comment.Id);

            builder.HasOne(comment => comment.NewsItem)
                .WithMany(news => news.NewsComments)
                .HasForeignKey(comment => comment.NewsItemId)
                .IsRequired();

            builder.HasOne(comment => comment.Customer)
                .WithMany()
                .HasForeignKey(comment => comment.CustomerId)
                .IsRequired();

            builder.HasOne(comment => comment.Store)
                .WithMany()
                .HasForeignKey(comment => comment.StoreId)
                .IsRequired();
            builder.Property(newscomment => newscomment.IsApproved).HasColumnType("bit(1)");
            base.Configure(builder);
        }

        #endregion
    }
}