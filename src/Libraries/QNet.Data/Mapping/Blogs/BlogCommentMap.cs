using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QNet.Core.Domain.Blogs;

namespace QNet.Data.Mapping.Blogs
{
    /// <summary>
    /// Represents a blog comment mapping configuration
    /// </summary>
    public partial class BlogCommentMap : QNetEntityTypeConfiguration<BlogComment>
    {
        #region Methods

        /// <summary>
        /// Configures the entity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<BlogComment> builder)
        {
            builder.ToTable(nameof(BlogComment));
            builder.HasKey(comment => comment.Id);

            builder.HasOne(comment => comment.BlogPost)
                .WithMany(blog => blog.BlogComments)
                .HasForeignKey(comment => comment.BlogPostId)
                .IsRequired();

            builder.HasOne(comment => comment.Customer)
                .WithMany()
                .HasForeignKey(comment => comment.CustomerId)
                .IsRequired();

            builder.HasOne(comment => comment.Store)
                .WithMany()
                .HasForeignKey(comment => comment.StoreId)
                .IsRequired();
            builder.Property(comment => comment.IsApproved).HasColumnType("bit(1)");
            base.Configure(builder);
        }

        #endregion
    }
}