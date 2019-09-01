using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QNet.Core.Domain.Catalog;

namespace QNet.Data.Mapping.Catalog
{
    /// <summary>
    /// Represents a cross-sell product mapping configuration
    /// </summary>
    public partial class CrossSellProductMap : QNetEntityTypeConfiguration<CrossSellProduct>
    {
        #region Methods

        /// <summary>
        /// Configures the entity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<CrossSellProduct> builder)
        {
            builder.ToTable(nameof(CrossSellProduct));
            builder.HasKey(product => product.Id);

            base.Configure(builder);
        }

        #endregion
    }
}