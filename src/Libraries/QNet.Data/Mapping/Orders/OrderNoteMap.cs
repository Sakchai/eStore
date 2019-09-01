using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QNet.Core.Domain.Orders;

namespace QNet.Data.Mapping.Orders
{
    /// <summary>
    /// Represents an order note mapping configuration
    /// </summary>
    public partial class OrderNoteMap : QNetEntityTypeConfiguration<OrderNote>
    {
        #region Methods

        /// <summary>
        /// Configures the entity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<OrderNote> builder)
        {
            builder.ToTable(nameof(OrderNote));
            builder.HasKey(note => note.Id);

            builder.Property(note => note.Note).IsRequired();

            builder.HasOne(note => note.Order)
                .WithMany(order => order.OrderNotes)
                .HasForeignKey(note => note.OrderId)
                .IsRequired();
            builder.Property(ordernote => ordernote.DisplayToCustomer).HasColumnType("bit(1)");
            base.Configure(builder);
        }

        #endregion
    }
}