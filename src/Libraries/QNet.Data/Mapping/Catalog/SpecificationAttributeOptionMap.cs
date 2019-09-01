using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QNet.Core.Domain.Catalog;

namespace QNet.Data.Mapping.Catalog
{
    /// <summary>
    /// Represents a specification attribute option mapping configuration
    /// </summary>
    public partial class SpecificationAttributeOptionMap : QNetEntityTypeConfiguration<SpecificationAttributeOption>
    {
        #region Methods

        /// <summary>
        /// Configures the entity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<SpecificationAttributeOption> builder)
        {
            builder.ToTable(nameof(SpecificationAttributeOption));
            builder.HasKey(option => option.Id);

            builder.Property(option => option.Name).IsRequired();
            builder.Property(option => option.ColorSquaresRgb).HasMaxLength(100);

            builder.HasOne(option => option.SpecificationAttribute)
                .WithMany(attribute => attribute.SpecificationAttributeOptions)
                .HasForeignKey(option => option.SpecificationAttributeId)
                .IsRequired();

            base.Configure(builder);
        }

        #endregion
    }
}