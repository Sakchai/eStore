using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QNet.Core.Domain.Common;


namespace QNet.Data.Mapping.Common
{
    /// <summary>
    /// Represents an address attribute value mapping configuration
    /// </summary>
    public partial class AddressAttributeValueMap : QNetEntityTypeConfiguration<AddressAttributeValue>
    {
        #region Methods

        /// <summary>
        /// Configures the entity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<AddressAttributeValue> builder)
        {
            builder.ToTable(nameof(AddressAttributeValue));
            builder.HasKey(value => value.Id);

            builder.Property(value => value.Name).HasMaxLength(400).IsRequired();

            builder.HasOne(value => value.AddressAttribute)
                .WithMany(attribute => attribute.AddressAttributeValues)
                .HasForeignKey(value => value.AddressAttributeId)
                .IsRequired();
            builder.Property(value => value.IsPreSelected).HasColumnType("bit(1)");
            base.Configure(builder);
        }

        #endregion
    }
}