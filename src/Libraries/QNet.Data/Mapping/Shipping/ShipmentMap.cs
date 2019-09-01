using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QNet.Core.Domain.Shipping;

namespace QNet.Data.Mapping.Shipping
{
    /// <summary>
    /// Represents a shipment mapping configuration
    /// </summary>
    public partial class ShipmentMap : QNetEntityTypeConfiguration<Shipment>
    {
        #region Methods

        /// <summary>
        /// Configures the entity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<Shipment> builder)
        {
            builder.ToTable(nameof(Shipment));
            builder.HasKey(shipment => shipment.Id);

            builder.Property(shipment => shipment.TotalWeight).HasColumnType("decimal(18, 4)");

            builder.HasOne(shipment => shipment.Order)
                .WithMany(order => order.Shipments)
                .HasForeignKey(shipment => shipment.OrderId)
                .IsRequired();

            base.Configure(builder);
        }

        #endregion
    }
}