using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QNet.Core.Domain.Catalog;

namespace QNet.Data.Mapping.Catalog
{
    /// <summary>
    /// Represents a product mapping configuration
    /// </summary>
    public partial class ProductMap : QNetEntityTypeConfiguration<Product>
    {
        #region Methods

        /// <summary>
        /// Configures the entity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable(nameof(Product));
            builder.HasKey(product => product.Id);

            builder.Property(product => product.Name).HasMaxLength(400).IsRequired();
            builder.Property(product => product.MetaKeywords).HasMaxLength(400);
            builder.Property(product => product.MetaTitle).HasMaxLength(400);
            builder.Property(product => product.Sku).HasMaxLength(400);
            builder.Property(product => product.ManufacturerPartNumber).HasMaxLength(400);
            builder.Property(product => product.Gtin).HasMaxLength(400);
            builder.Property(product => product.AdditionalShippingCharge).HasColumnType("decimal(18, 4)");
            builder.Property(product => product.Price).HasColumnType("decimal(18, 4)");
            builder.Property(product => product.OldPrice).HasColumnType("decimal(18, 4)");
            builder.Property(product => product.ProductCost).HasColumnType("decimal(18, 4)");
            builder.Property(product => product.MinimumCustomerEnteredPrice).HasColumnType("decimal(18, 4)");
            builder.Property(product => product.MaximumCustomerEnteredPrice).HasColumnType("decimal(18, 4)");
            builder.Property(product => product.Weight).HasColumnType("decimal(18, 4)");
            builder.Property(product => product.Length).HasColumnType("decimal(18, 4)");
            builder.Property(product => product.Width).HasColumnType("decimal(18, 4)");
            builder.Property(product => product.Height).HasColumnType("decimal(18, 4)");
            builder.Property(product => product.RequiredProductIds).HasMaxLength(1000);
            builder.Property(product => product.AllowedQuantities).HasMaxLength(1000);
            builder.Property(product => product.BasepriceAmount).HasColumnType("decimal(18, 4)");
            builder.Property(product => product.BasepriceBaseAmount).HasColumnType("decimal(18, 4)");
            builder.Property(product => product.OverriddenGiftCardAmount).HasColumnType("decimal(18, 4)");

            builder.Ignore(product => product.ProductType);
            builder.Ignore(product => product.BackorderMode);
            builder.Ignore(product => product.DownloadActivationType);
            builder.Ignore(product => product.GiftCardType);
            builder.Ignore(product => product.LowStockActivity);
            builder.Ignore(product => product.ManageInventoryMethod);
            builder.Ignore(product => product.RecurringCyclePeriod);
            builder.Ignore(product => product.RentalPricePeriod);
            builder.Ignore(product => product.AppliedDiscounts);
            builder.Property(product => product.AllowAddingOnlyExistingAttributeCombinations).HasColumnType("bit(1)");
            builder.Property(product => product.AllowBackInStockSubscriptions).HasColumnType("bit(1)");
            builder.Property(product => product.AllowCustomerReviews).HasColumnType("bit(1)");
            builder.Property(product => product.AutomaticallyAddRequiredProducts).HasColumnType("bit(1)");
            builder.Property(product => product.AvailableForPreOrder).HasColumnType("bit(1)");
            builder.Property(product => product.BasepriceEnabled).HasColumnType("bit(1)");
            builder.Property(product => product.CallForPrice).HasColumnType("bit(1)");
            builder.Property(product => product.CustomerEntersPrice).HasColumnType("bit(1)");
            builder.Property(product => product.Deleted).HasColumnType("bit(1)");
            builder.Property(product => product.DisableBuyButton).HasColumnType("bit(1)");
            builder.Property(product => product.DisableWishlistButton).HasColumnType("bit(1)");
            builder.Property(product => product.DisplayStockAvailability).HasColumnType("bit(1)");
            builder.Property(product => product.DisplayStockQuantity).HasColumnType("bit(1)");
            builder.Property(product => product.HasDiscountsApplied).HasColumnType("bit(1)");
            builder.Property(product => product.HasSampleDownload).HasColumnType("bit(1)");
            builder.Property(product => product.HasTierPrices).HasColumnType("bit(1)");
            builder.Property(product => product.HasUserAgreement).HasColumnType("bit(1)");
            builder.Property(product => product.IsDownload).HasColumnType("bit(1)");
            builder.Property(product => product.IsFreeShipping).HasColumnType("bit(1)");
            builder.Property(product => product.IsGiftCard).HasColumnType("bit(1)");
            builder.Property(product => product.IsRecurring).HasColumnType("bit(1)");
            builder.Property(product => product.IsRental).HasColumnType("bit(1)");
            builder.Property(product => product.IsShipEnabled).HasColumnType("bit(1)");
            builder.Property(product => product.IsTaxExempt).HasColumnType("bit(1)");
            builder.Property(product => product.IsTelecommunicationsOrBroadcastingOrElectronicServices).HasColumnType("bit(1)");
            builder.Property(product => product.LimitedToStores).HasColumnType("bit(1)");
            builder.Property(product => product.MarkAsNew).HasColumnType("bit(1)");
            builder.Property(product => product.NotReturnable).HasColumnType("bit(1)");
            builder.Property(product => product.Published).HasColumnType("bit(1)");
            builder.Property(product => product.RequireOtherProducts).HasColumnType("bit(1)");
            builder.Property(product => product.ShipSeparately).HasColumnType("bit(1)");
            builder.Property(product => product.ShowOnHomepage).HasColumnType("bit(1)");
            builder.Property(product => product.SubjectToAcl).HasColumnType("bit(1)");
            builder.Property(product => product.UnlimitedDownloads).HasColumnType("bit(1)");
            builder.Property(product => product.UseMultipleWarehouses).HasColumnType("bit(1)");
            builder.Property(product => product.VisibleIndividually).HasColumnType("bit(1)");
            base.Configure(builder);
        }

        #endregion
    }
}