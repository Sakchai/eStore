using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QNet.Core.Domain.Catalog;

namespace QNet.Data.Mapping.Catalog
{
    /// <summary>
    /// Represents a product manufacturer mapping configuration
    /// </summary>
    public partial class ProductManufacturerMap : QNetEntityTypeConfiguration<ProductManufacturer>
    {
        #region Methods

        /// <summary>
        /// Configures the entity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<ProductManufacturer> builder)
        {
            builder.ToTable(QNetMappingDefaults.ProductManufacturerTable);
            builder.HasKey(productManufacturer => productManufacturer.Id);

            builder.HasOne(productManufacturer => productManufacturer.Manufacturer)
                .WithMany()
                .HasForeignKey(productManufacturer => productManufacturer.ManufacturerId)
                .IsRequired();

            builder.HasOne(productManufacturer => productManufacturer.Product)
                .WithMany(product => product.ProductManufacturers)
                .HasForeignKey(productManufacturer => productManufacturer.ProductId)
                .IsRequired();
            builder.Property(productManufacturer => productManufacturer.IsFeaturedProduct).HasColumnType("bit(1)");
            base.Configure(builder);
        }

        #endregion
    }
}