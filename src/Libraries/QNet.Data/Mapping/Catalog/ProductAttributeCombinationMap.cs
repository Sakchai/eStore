using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QNet.Core.Domain.Catalog;

namespace QNet.Data.Mapping.Catalog
{
    /// <summary>
    /// Represents a product attribute combination mapping configuration
    /// </summary>
    public partial class ProductAttributeCombinationMap : QNetEntityTypeConfiguration<ProductAttributeCombination>
    {
        #region Methods

        /// <summary>
        /// Configures the entity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<ProductAttributeCombination> builder)
        {
            builder.ToTable(nameof(ProductAttributeCombination));
            builder.HasKey(combination => combination.Id);

            builder.Property(combination => combination.Sku).HasMaxLength(400);
            builder.Property(combination => combination.ManufacturerPartNumber).HasMaxLength(400);
            builder.Property(combination => combination.Gtin).HasMaxLength(400);
            builder.Property(combination => combination.OverriddenPrice).HasColumnType("decimal(18, 4)");

            builder.HasOne(combination => combination.Product)
                .WithMany(product => product.ProductAttributeCombinations)
                .HasForeignKey(combination => combination.ProductId)
                .IsRequired();
            builder.Property(combination => combination.AllowOutOfStockOrders).HasColumnType("bit(1)");
            base.Configure(builder);
        }

        #endregion
    }
}