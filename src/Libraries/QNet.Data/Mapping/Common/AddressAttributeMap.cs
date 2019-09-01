using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QNet.Core.Domain.Common;


namespace QNet.Data.Mapping.Common
{
    /// <summary>
    /// Represents an address attribute mapping configuration
    /// </summary>
    public partial class AddressAttributeMap : QNetEntityTypeConfiguration<AddressAttribute>
    {
        #region Methods

        /// <summary>
        /// Configures the entity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<AddressAttribute> builder)
        {
            builder.ToTable(nameof(AddressAttribute));
            builder.HasKey(attribute => attribute.Id);

            builder.Property(attribute => attribute.Name).HasMaxLength(400).IsRequired();
            builder.Ignore(attribute => attribute.AttributeControlType);
            builder.Property(attribute => attribute.IsRequired).HasColumnType("bit(1)");
            base.Configure(builder);
        }

        #endregion
    }
}