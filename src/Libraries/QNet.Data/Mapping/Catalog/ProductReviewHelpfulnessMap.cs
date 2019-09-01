using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QNet.Core.Domain.Catalog;

namespace QNet.Data.Mapping.Catalog
{
    /// <summary>
    /// Represents a product review helpfulness mapping configuration
    /// </summary>
    public partial class ProductReviewHelpfulnessMap : QNetEntityTypeConfiguration<ProductReviewHelpfulness>
    {
        #region Methods

        /// <summary>
        /// Configures the entity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<ProductReviewHelpfulness> builder)
        {
            builder.ToTable(nameof(ProductReviewHelpfulness));
            builder.HasKey(productReviewHelpfulness => productReviewHelpfulness.Id);

            builder.HasOne(productReviewHelpfulness => productReviewHelpfulness.ProductReview)
                .WithMany(productReview => productReview.ProductReviewHelpfulnessEntries)
                .HasForeignKey(productReviewHelpfulness => productReviewHelpfulness.ProductReviewId)
                .IsRequired();
            builder.Property(productreviewhelpfulness => productreviewhelpfulness.WasHelpful).HasColumnType("bit(1)");
            base.Configure(builder);
        }

        #endregion
    }
}