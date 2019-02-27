using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nop.Core.Domain.Catalog;

namespace Nop.Data.Mapping.Catalog
{
    /// <summary>
    /// Represents a product mapping configuration
    /// </summary>
    public partial class ProductQMap : NopEntityTypeConfiguration<ProductQ>
    {
        #region Methods

        /// <summary>
        /// Configures the entity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<ProductQ> entity)
        {
            entity.ToTable(nameof(ProductQ));
            entity.HasKey(e => e.Id);

            entity.Property(e => e.CompanyId).HasColumnName("CompanyId");

            entity.Property(e => e.CreationDate).HasColumnType("datetime");

            entity.Property(e => e.ImageFileName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.ItemTypeId).HasColumnName("ItemTypeID");

            entity.Property(e => e.ProdCode)
                .IsRequired()
                .HasMaxLength(13)
                .IsUnicode(false);

            entity.Property(e => e.ProdDesc)
                .IsRequired()
                .HasMaxLength(500)
                .IsUnicode(false);

            entity.Property(e => e.ProdLink)
                .IsRequired()
                .HasMaxLength(400)
                .IsUnicode(false);

            entity.Property(e => e.ProdName)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.RevisionDate).HasColumnType("datetime");

            entity.Property(e => e.UpdatedBy)
                .IsRequired()
                .HasMaxLength(15)
                .IsUnicode(false);

            base.Configure(entity);
        }

        #endregion
    }
}