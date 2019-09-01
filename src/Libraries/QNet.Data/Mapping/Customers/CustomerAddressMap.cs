using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QNet.Core.Domain.Customers;

namespace QNet.Data.Mapping.Customers
{
    /// <summary>
    /// Represents a customer-address mapping configuration
    /// </summary>
    public partial class CustomerAddressMap : QNetEntityTypeConfiguration<CustomerAddressMapping>
    {
        #region Methods

        /// <summary>
        /// Configures the entity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<CustomerAddressMapping> builder)
        {
            builder.ToTable(QNetMappingDefaults.CustomerAddressesTable);
            builder.HasKey(mapping => new { mapping.CustomerId, mapping.AddressId });

            builder.Property(mapping => mapping.CustomerId).HasColumnName("Customer_Id");
            builder.Property(mapping => mapping.AddressId).HasColumnName("Address_Id");

            builder.HasOne(mapping => mapping.Customer)
                .WithMany(customer => customer.CustomerAddressMappings)
                .HasForeignKey(mapping => mapping.CustomerId)
                .IsRequired();

            builder.HasOne(mapping => mapping.Address)
                .WithMany()
                .HasForeignKey(mapping => mapping.AddressId)
                .IsRequired();

            builder.Ignore(mapping => mapping.Id);

            base.Configure(builder);
        }

        #endregion
    }
}