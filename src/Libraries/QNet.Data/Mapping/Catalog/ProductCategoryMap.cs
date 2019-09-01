using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QNet.Core.Domain.Catalog;

namespace QNet.Data.Mapping.Catalog
{
    /// <summary>
    /// Represents a product category mapping configuration
    /// </summary>
    public partial class ProductCategoryMap : QNetEntityTypeConfiguration<ProductCategory>
    {
        #region Methods

        /// <summary>
        /// Configures the entity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.ToTable(QNetMappingDefaults.ProductCategoryTable);
            builder.HasKey(productCategory => productCategory.Id);

            builder.HasOne(productCategory => productCategory.Category)
                .WithMany()
                .HasForeignKey(productCategory => productCategory.CategoryId)
                .IsRequired();

            builder.HasOne(productCategory => productCategory.Product)
                .WithMany(product => product.ProductCategories)
                .HasForeignKey(productCategory => productCategory.ProductId)
                .IsRequired();
            builder.Property(productCategory => productCategory.IsFeaturedProduct).HasColumnType("bit(1)");
            base.Configure(builder);
        }

        #endregion
    }
}