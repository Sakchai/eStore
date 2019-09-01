using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QNet.Data.Mapping;
using QNet.Plugin.Tax.Avalara.Domain;

namespace QNet.Plugin.Tax.Avalara.Data
{
    /// <summary>
    /// Represents the tax transaction log mapping class
    /// </summary>
    public class TaxTransactionLogMap : QNetEntityTypeConfiguration<TaxTransactionLog>
    {
        #region Methods

        /// <summary>
        /// Configures the entity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<TaxTransactionLog> builder)
        {
            builder.ToTable(nameof(TaxTransactionLog));
            builder.HasKey(logItem => logItem.Id);
        }

        #endregion
    }
}