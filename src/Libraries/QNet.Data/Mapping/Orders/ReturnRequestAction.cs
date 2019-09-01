using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QNet.Core.Domain.Orders;

namespace QNet.Data.Mapping.Orders
{
    /// <summary>
    /// Represents a return request action mapping configuration
    /// </summary>
    public partial class ReturnRequestActionMap : QNetEntityTypeConfiguration<ReturnRequestAction>
    {
        #region Methods

        /// <summary>
        /// Configures the entity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<ReturnRequestAction> builder)
        {
            builder.ToTable(nameof(ReturnRequestAction));
            builder.HasKey(action => action.Id);

            builder.Property(action => action.Name).HasMaxLength(400).IsRequired();

            base.Configure(builder);
        }

        #endregion
    }
}