using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QNet.Core.Domain.Vendors;

namespace QNet.Data.Mapping.Vendors
{
    /// <summary>
    /// Represents a vendor attribute value mapping configuration
    /// </summary>
    public partial class VendorAttributeValueMap : QNetEntityTypeConfiguration<VendorAttributeValue>
    {
        #region Methods

        /// <summary>
        /// Configures the entity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<VendorAttributeValue> builder)
        {
            builder.ToTable(nameof(VendorAttributeValue));
            builder.HasKey(value => value.Id);

            builder.Property(value => value.Name).HasMaxLength(400).IsRequired();

            builder.HasOne(value => value.VendorAttribute)
                .WithMany(attribute => attribute.VendorAttributeValues)
                .HasForeignKey(value => value.VendorAttributeId)
                .IsRequired();
            builder.Property(value => value.IsPreSelected).HasColumnType("bit(1)");
            base.Configure(builder);
        }
        
        #endregion
    }
}