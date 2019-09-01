using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QNet.Core.Domain.Vendors;

namespace QNet.Data.Mapping.Vendors
{
    /// <summary>
    /// Represents an vendor attribute mapping configuration
    /// </summary>
    public partial class VendorAttributeMap : QNetEntityTypeConfiguration<VendorAttribute>
    {
        #region Methods

        /// <summary>
        /// Configures the entity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<VendorAttribute> builder)
        {
            builder.ToTable(nameof(VendorAttribute));
            builder.HasKey(attribute => attribute.Id);

            builder.Property(attribute => attribute.Name).HasMaxLength(400).IsRequired();

            builder.Ignore(attribute => attribute.AttributeControlType);
            builder.Property(attribute => attribute.IsRequired).HasColumnType("bit(1)");
            base.Configure(builder);
        }

        #endregion
    }
}