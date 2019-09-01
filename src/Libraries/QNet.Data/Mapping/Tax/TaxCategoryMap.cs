using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QNet.Core.Domain.Tax;

namespace QNet.Data.Mapping.Tax
{
    /// <summary>
    /// Represents a tax category mapping configuration
    /// </summary>
    public partial class TaxCategoryMap : QNetEntityTypeConfiguration<TaxCategory>
    {
        #region Methods

        /// <summary>
        /// Configures the entity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<TaxCategory> builder)
        {
            builder.ToTable(nameof(TaxCategory));
            builder.HasKey(taxCategory => taxCategory.Id);

            builder.Property(taxCategory => taxCategory.Name).HasMaxLength(400).IsRequired();

            base.Configure(builder);
        }

        #endregion
    }
}