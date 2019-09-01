using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QNet.Core.Domain.Affiliates;

namespace QNet.Data.Mapping.Affiliates
{
    /// <summary>
    /// Represents an affiliate mapping configuration
    /// </summary>
    public partial class AffiliateMap : QNetEntityTypeConfiguration<Affiliate>
    {
        #region Methods

        /// <summary>
        /// Configures the entity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<Affiliate> builder)
        {
            builder.ToTable(nameof(Affiliate));
            builder.HasKey(affiliate => affiliate.Id);

            builder.HasOne(affiliate => affiliate.Address)
                .WithMany()
                .HasForeignKey(affiliate => affiliate.AddressId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
            builder.Property(affiliate => affiliate.Deleted).HasColumnType("bit(1)");
            builder.Property(affiliate => affiliate.Active).HasColumnType("bit(1)");
            base.Configure(builder);
        }

        #endregion
    }
}