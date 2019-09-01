using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QNet.Core.Domain.Discounts;

namespace QNet.Data.Mapping.Discounts
{
    /// <summary>
    /// Represents a discount mapping configuration
    /// </summary>
    public partial class DiscountMap : QNetEntityTypeConfiguration<Discount>
    {
        #region Methods

        /// <summary>
        /// Configures the entity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<Discount> builder)
        {
            builder.ToTable(nameof(Discount));
            builder.HasKey(discount => discount.Id);

            builder.Property(discount => discount.Name).HasMaxLength(200).IsRequired();
            builder.Property(discount => discount.CouponCode).HasMaxLength(100);
            builder.Property(discount => discount.DiscountPercentage).HasColumnType("decimal(18, 4)");
            builder.Property(discount => discount.DiscountAmount).HasColumnType("decimal(18, 4)");
            builder.Property(discount => discount.MaximumDiscountAmount).HasColumnType("decimal(18, 4)");

            builder.HasMany(discount => discount.DiscountRequirements)
                .WithOne(requirement => requirement.Discount)
                .HasForeignKey(requirement => requirement.DiscountId)
                .IsRequired();

            builder.Ignore(discount => discount.DiscountType);
            builder.Ignore(discount => discount.DiscountLimitation);
            builder.Property(discount => discount.AppliedToSubCategories).HasColumnType("bit(1)");
            builder.Property(discount => discount.IsCumulative).HasColumnType("bit(1)");
            builder.Property(discount => discount.RequiresCouponCode).HasColumnType("bit(1)");
            builder.Property(discount => discount.UsePercentage).HasColumnType("bit(1)");
            base.Configure(builder);
        }

        #endregion
    }
}