using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QNet.Core.Domain.Discounts;

namespace QNet.Data.Mapping.Discounts
{
    /// <summary>
    /// Represents a discount-category mapping configuration
    /// </summary>
    public partial class DiscountCategoryMap : QNetEntityTypeConfiguration<DiscountCategoryMapping>
    {
        #region Methods

        /// <summary>
        /// Configures the entity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<DiscountCategoryMapping> builder)
        {
            builder.ToTable(QNetMappingDefaults.DiscountAppliedToCategoriesTable);
            builder.HasKey(mapping => new { mapping.DiscountId, mapping.CategoryId});

            builder.Property(mapping => mapping.DiscountId).HasColumnName("Discount_Id");
            builder.Property(mapping => mapping.CategoryId).HasColumnName("Category_Id");

            builder.HasOne(mapping => mapping.Discount)
                .WithMany(discount => discount.DiscountCategoryMappings)
                .HasForeignKey(mapping => mapping.DiscountId)
                .IsRequired();

            builder.HasOne(mapping => mapping.Category)
                .WithMany(category => category.DiscountCategoryMappings)
                .HasForeignKey(mapping => mapping.CategoryId)
                .IsRequired();

            builder.Ignore(mapping => mapping.Id);

            base.Configure(builder);
        }

        #endregion
    }
}