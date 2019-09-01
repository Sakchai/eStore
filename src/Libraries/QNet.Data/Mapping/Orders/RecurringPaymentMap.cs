using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QNet.Core.Domain.Orders;

namespace QNet.Data.Mapping.Orders
{
    /// <summary>
    /// Represents a recurring payment mapping configuration
    /// </summary>
    public partial class RecurringPaymentMap : QNetEntityTypeConfiguration<RecurringPayment>
    {
        #region Methods

        /// <summary>
        /// Configures the entity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<RecurringPayment> builder)
        {
            builder.ToTable(nameof(RecurringPayment));
            builder.HasKey(recurringPayment => recurringPayment.Id);

            builder.HasOne(recurringPayment => recurringPayment.InitialOrder)
                .WithMany()
                .HasForeignKey(recurringPayment => recurringPayment.InitialOrderId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.Ignore(recurringPayment => recurringPayment.NextPaymentDate);
            builder.Ignore(recurringPayment => recurringPayment.CyclesRemaining);
            builder.Ignore(recurringPayment => recurringPayment.CyclePeriod);
            builder.Property(recurringpayment => recurringpayment.Deleted).HasColumnType("bit(1)");
            builder.Property(recurringpayment => recurringpayment.IsActive).HasColumnType("bit(1)");
            builder.Property(recurringpayment => recurringpayment.LastPaymentFailed).HasColumnType("bit(1)");
            base.Configure(builder);
        }

        #endregion
    }
}