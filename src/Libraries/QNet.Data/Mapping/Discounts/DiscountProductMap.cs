using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QNet.Core.Domain.Discounts;

namespace QNet.Data.Mapping.Discounts
{
    /// <summary>
    /// Represents a discount-product mapping configuration
    /// </summary>
    public partial class DiscountProductMap : QNetEntityTypeConfiguration<DiscountProductMapping>
    {
        #region Methods

        /// <summary>
        /// Configures the entity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<DiscountProductMapping> builder)
        {
            builder.ToTable(QNetMappingDefaults.DiscountAppliedToProductsTable);
            builder.HasKey(mapping => new { mapping.DiscountId, mapping.ProductId});

            builder.Property(mapping => mapping.DiscountId).HasColumnName("Discount_Id");
            builder.Property(mapping => mapping.ProductId).HasColumnName("Product_Id");

            builder.HasOne(mapping => mapping.Discount)
                .WithMany(discount => discount.DiscountProductMappings)
                .HasForeignKey(mapping => mapping.DiscountId)
                .IsRequired();

            builder.HasOne(mapping => mapping.Product)
                .WithMany(product => product.DiscountProductMappings)
                .HasForeignKey(mapping => mapping.ProductId)
                .IsRequired();

            builder.Ignore(mapping => mapping.Id);

            base.Configure(builder);
        }

        #endregion
    }
}