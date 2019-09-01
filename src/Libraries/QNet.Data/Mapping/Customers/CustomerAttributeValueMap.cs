using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QNet.Core.Domain.Customers;

namespace QNet.Data.Mapping.Customers
{
    /// <summary>
    /// Represents a customer attribute value mapping configuration
    /// </summary>
    public partial class CustomerAttributeValueMap : QNetEntityTypeConfiguration<CustomerAttributeValue>
    {
        #region Methods

        /// <summary>
        /// Configures the entity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<CustomerAttributeValue> builder)
        {
            builder.ToTable(nameof(CustomerAttributeValue));
            builder.HasKey(value => value.Id);

            builder.Property(value => value.Name).HasMaxLength(400).IsRequired();

            builder.HasOne(value => value.CustomerAttribute)
                .WithMany(attribute => attribute.CustomerAttributeValues)
                .HasForeignKey(value => value.CustomerAttributeId)
                .IsRequired();
            builder.Property(value => value.IsPreSelected).HasColumnType("bit(1)");
            base.Configure(builder);
        }

        #endregion
    }
}