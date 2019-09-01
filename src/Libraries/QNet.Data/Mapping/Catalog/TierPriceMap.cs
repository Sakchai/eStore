using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QNet.Core.Domain.Catalog;

namespace QNet.Data.Mapping.Catalog
{
    /// <summary>
    /// Represents a tier price mapping configuration
    /// </summary>
    public partial class TierPriceMap : QNetEntityTypeConfiguration<TierPrice>
    {
        #region Methods

        /// <summary>
        /// Configures the entity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<TierPrice> builder)
        {
            builder.ToTable(nameof(TierPrice));
            builder.HasKey(price => price.Id);

            builder.Property(price => price.Price).HasColumnType("decimal(18, 4)");

            builder.HasOne(price => price.Product)
                .WithMany(product => product.TierPrices)
                .HasForeignKey(price => price.ProductId)
                .IsRequired();

            builder.HasOne(price => price.CustomerRole)
                .WithMany()
                .HasForeignKey(price => price.CustomerRoleId)
                .OnDelete(DeleteBehavior.Cascade);

            base.Configure(builder);
        }

        #endregion
    }
}