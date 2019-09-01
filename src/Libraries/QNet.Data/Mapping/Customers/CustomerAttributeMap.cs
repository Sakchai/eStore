using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QNet.Core.Domain.Customers;

namespace QNet.Data.Mapping.Customers
{
    /// <summary>
    /// Represents a customer attribute mapping configuration
    /// </summary>
    public partial class CustomerAttributeMap : QNetEntityTypeConfiguration<CustomerAttribute>
    {
        #region Methods

        /// <summary>
        /// Configures the entity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<CustomerAttribute> builder)
        {
            builder.ToTable(nameof(CustomerAttribute));
            builder.HasKey(attribute => attribute.Id);

            builder.Property(attribute => attribute.Name).HasMaxLength(400).IsRequired();

            builder.Ignore(attribute => attribute.AttributeControlType);
            builder.Property(attribute => attribute.IsRequired).HasColumnType("bit(1)");
            base.Configure(builder);
        }

        #endregion
    }
}