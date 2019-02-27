using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nop.Core.Domain.Catalog;

namespace Nop.Data.Mapping.Catalog
{
    /// <summary>
    /// Represents a product mapping configuration
    /// </summary>
    public partial class ProductRestrictionMap : NopEntityTypeConfiguration<ProductRestriction>
    {
        #region Methods

        /// <summary>
        /// Configures the entity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<ProductRestriction> entity)
        {
            entity.ToTable(nameof(ProductRestriction));
            entity.HasKey(e => e.Id);

            entity.Property(e => e.ProductId).HasColumnName("ProductId");

            entity.Property(e => e.ProdCode)
                .IsRequired()
                .HasMaxLength(5)
                .IsUnicode(false);

            entity.Property(e => e.ProdRestrict)
                .IsRequired()
                .HasDefaultValueSql("('')");

            entity.Property(e => e.RestrictCode)
                .IsRequired()
                .HasMaxLength(3)
                .IsUnicode(false);

            entity.HasOne(d => d.Product)
                .WithMany(p => p.ProductRestriction)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_ProductRestriction_ProductQ");

            base.Configure(entity);
        }

        #endregion
    }
}