using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QNet.Core.Domain.Customers;

namespace QNet.Data.Mapping.Customers
{
    /// <summary>
    /// Represents a customer role mapping configuration
    /// </summary>
    public partial class CustomerRoleMap : QNetEntityTypeConfiguration<CustomerRole>
    {
        #region Methods

        /// <summary>
        /// Configures the entity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<CustomerRole> builder)
        {
            builder.ToTable(nameof(CustomerRole));
            builder.HasKey(role => role.Id);

            builder.Property(role => role.Name).HasMaxLength(255).IsRequired();
            builder.Property(role => role.SystemName).HasMaxLength(255);
            builder.Property(role => role.Active).HasColumnType("bit(1)");
            builder.Property(role => role.EnablePasswordLifetime).HasColumnType("bit(1)");
            builder.Property(role => role.FreeShipping).HasColumnType("bit(1)");
            builder.Property(role => role.IsSystemRole).HasColumnType("bit(1)");
            builder.Property(role => role.OverrideTaxDisplayType).HasColumnType("bit(1)");
            builder.Property(role => role.TaxExempt).HasColumnType("bit(1)");
            base.Configure(builder);
        }

        #endregion
    }
}