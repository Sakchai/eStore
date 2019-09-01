using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QNet.Core.Domain.Catalog;

namespace QNet.Data.Mapping.Catalog
{
    /// <summary>
    /// Represents a product review mapping configuration
    /// </summary>
    public partial class ProductReviewMap : QNetEntityTypeConfiguration<ProductReview>
    {
        #region Methods

        /// <summary>
        /// Configures the entity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<ProductReview> builder)
        {
            builder.ToTable(nameof(ProductReview));
            builder.HasKey(productReview => productReview.Id);

            builder.HasOne(productReview => productReview.Product)
                .WithMany(product => product.ProductReviews)
                .HasForeignKey(productReview => productReview.ProductId)
                .IsRequired();

            builder.HasOne(productReview => productReview.Customer)
                .WithMany()
                .HasForeignKey(productReview => productReview.CustomerId)
                .IsRequired();

            builder.HasOne(productReview => productReview.Store)
                .WithMany()
                .HasForeignKey(productReview => productReview.StoreId)
                .IsRequired();
            builder.Property(productreview => productreview.CustomerNotifiedOfReply).HasColumnType("bit(1)");
            builder.Property(productreview => productreview.IsApproved).HasColumnType("bit(1)");
            base.Configure(builder);
        }

        #endregion
    }
}