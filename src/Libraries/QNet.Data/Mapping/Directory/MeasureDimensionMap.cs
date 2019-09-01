using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QNet.Core.Domain.Directory;

namespace QNet.Data.Mapping.Directory
{
    /// <summary>
    /// Represents a measure dimension mapping configuration
    /// </summary>
    public partial class MeasureDimensionMap : QNetEntityTypeConfiguration<MeasureDimension>
    {
        #region Methods

        /// <summary>
        /// Configures the entity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<MeasureDimension> builder)
        {
            builder.ToTable(nameof(MeasureDimension));
            builder.HasKey(dimension => dimension.Id);

            builder.Property(dimension => dimension.Name).HasMaxLength(100).IsRequired();
            builder.Property(dimension => dimension.SystemKeyword).HasMaxLength(100).IsRequired();
            builder.Property(dimension => dimension.Ratio).HasColumnType("decimal(18, 8)");

            base.Configure(builder);
        }

        #endregion
    }
}