using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nop.Core.Domain.Catalog;

namespace Nop.Data.Mapping.Catalog
{
    /// <summary>
    /// Represents a product mapping configuration
    /// </summary>
    public partial class ServiceMap : NopEntityTypeConfiguration<Service>
    {
        #region Methods

        /// <summary>
        /// Configures the entity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<Service> entity)
        {
            entity.ToTable(nameof(Service));
            entity.HasKey(e => e.Id);

            entity.Property(e => e.CountryCode)
                   .IsRequired()
                   .HasMaxLength(3)
                   .IsUnicode(false);

            entity.Property(e => e.CreationDate).HasColumnType("datetime");

            entity.Property(e => e.Currency)
                .HasMaxLength(3)
                .IsUnicode(false);

            entity.Property(e => e.EndDate).HasColumnType("datetime");

            entity.Property(e => e.Fee).HasColumnType("decimal(18, 2)");

            entity.Property(e => e.Percentage).HasColumnType("smallmoney");

            entity.Property(e => e.ProdCode)
                .IsRequired()
                .HasMaxLength(13)
                .IsUnicode(false);

            entity.Property(e => e.StartDate).HasColumnType("datetime");

            entity.Property(e => e.UpdatedBy)
                .IsRequired()
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.Property(e => e.Weight).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.ProductCountry)
                .WithMany(p => p.Service)
                .HasForeignKey(d => d.ProductCountryId)
                .HasConstraintName("FK_Service_ProductQ");

            entity.HasOne(d => d.ServiceType)
                .WithMany(p => p.Service)
                .HasForeignKey(d => d.ServiceTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Service_ServiceType");

            base.Configure(entity);
        }

        #endregion
    }
}