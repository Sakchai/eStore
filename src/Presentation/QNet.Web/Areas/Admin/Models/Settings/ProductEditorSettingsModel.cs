using QNet.Web.Framework.Mvc.ModelBinding;
using QNet.Web.Framework.Models;

namespace QNet.Web.Areas.Admin.Models.Settings
{
    /// <summary>
    /// Represents a product editor settings model
    /// </summary>
    public partial class ProductEditorSettingsModel : BaseQNetModel, ISettingsModel
    {
        #region Properties

        public int ActiveStoreScopeConfiguration { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Settings.ProductEditor.ProductType")]
        public bool ProductType { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Settings.ProductEditor.VisibleIndividually")]
        public bool VisibleIndividually { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Settings.ProductEditor.ProductTemplate")]
        public bool ProductTemplate { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Settings.ProductEditor.AdminComment")]
        public bool AdminComment { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Settings.ProductEditor.Vendor")]
        public bool Vendor { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Settings.ProductEditor.Stores")]
        public bool Stores { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Settings.ProductEditor.ACL")]
        public bool ACL { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Settings.ProductEditor.ShowOnHomepage")]
        public bool ShowOnHomepage { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Settings.ProductEditor.DisplayOrder")]
        public bool DisplayOrder { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Settings.ProductEditor.AllowCustomerReviews")]
        public bool AllowCustomerReviews { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Settings.ProductEditor.ProductTags")]
        public bool ProductTags { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Settings.ProductEditor.ManufacturerPartNumber")]
        public bool ManufacturerPartNumber { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Settings.ProductEditor.GTIN")]
        public bool GTIN { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Settings.ProductEditor.ProductCost")]
        public bool ProductCost { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Settings.ProductEditor.TierPrices")]
        public bool TierPrices { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Settings.ProductEditor.Discounts")]
        public bool Discounts { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Settings.ProductEditor.DisableBuyButton")]
        public bool DisableBuyButton { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Settings.ProductEditor.DisableWishlistButton")]
        public bool DisableWishlistButton { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Settings.ProductEditor.AvailableForPreOrder")]
        public bool AvailableForPreOrder { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Settings.ProductEditor.CallForPrice")]
        public bool CallForPrice { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Settings.ProductEditor.OldPrice")]
        public bool OldPrice { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Settings.ProductEditor.CustomerEntersPrice")]
        public bool CustomerEntersPrice { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Settings.ProductEditor.PAngV")]
        public bool PAngV { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Settings.ProductEditor.RequireOtherProductsAddedToTheCart")]
        public bool RequireOtherProductsAddedToTheCart { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Settings.ProductEditor.IsGiftCard")]
        public bool IsGiftCard { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Settings.ProductEditor.DownloadableProduct")]
        public bool DownloadableProduct { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Settings.ProductEditor.RecurringProduct")]
        public bool RecurringProduct { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Settings.ProductEditor.IsRental")]
        public bool IsRental { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Settings.ProductEditor.FreeShipping")]
        public bool FreeShipping { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Settings.ProductEditor.ShipSeparately")]
        public bool ShipSeparately { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Settings.ProductEditor.AdditionalShippingCharge")]
        public bool AdditionalShippingCharge { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Settings.ProductEditor.DeliveryDate")]
        public bool DeliveryDate { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Settings.ProductEditor.TelecommunicationsBroadcastingElectronicServices")]
        public bool TelecommunicationsBroadcastingElectronicServices { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Settings.ProductEditor.ProductAvailabilityRange")]
        public bool ProductAvailabilityRange { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Settings.ProductEditor.UseMultipleWarehouses")]
        public bool UseMultipleWarehouses { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Settings.ProductEditor.Warehouse")]
        public bool Warehouse { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Settings.ProductEditor.DisplayStockAvailability")]
        public bool DisplayStockAvailability { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Settings.ProductEditor.DisplayStockQuantity")]
        public bool DisplayStockQuantity { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Settings.ProductEditor.MinimumStockQuantity")]
        public bool MinimumStockQuantity { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Settings.ProductEditor.LowStockActivity")]
        public bool LowStockActivity { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Settings.ProductEditor.NotifyAdminForQuantityBelow")]
        public bool NotifyAdminForQuantityBelow { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Settings.ProductEditor.Backorders")]
        public bool Backorders { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Settings.ProductEditor.AllowBackInStockSubscriptions")]
        public bool AllowBackInStockSubscriptions { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Settings.ProductEditor.MinimumCartQuantity")]
        public bool MinimumCartQuantity { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Settings.ProductEditor.MaximumCartQuantity")]
        public bool MaximumCartQuantity { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Settings.ProductEditor.AllowedQuantities")]
        public bool AllowedQuantities { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Settings.ProductEditor.AllowAddingOnlyExistingAttributeCombinations")]
        public bool AllowAddingOnlyExistingAttributeCombinations { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Settings.ProductEditor.NotReturnable")]
        public bool NotReturnable { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Settings.ProductEditor.Weight")]
        public bool Weight { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Settings.ProductEditor.Dimensions")]
        public bool Dimensions { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Settings.ProductEditor.AvailableStartDate")]
        public bool AvailableStartDate { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Settings.ProductEditor.AvailableEndDate")]
        public bool AvailableEndDate { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Settings.ProductEditor.MarkAsNew")]
        public bool MarkAsNew { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Settings.ProductEditor.MarkAsNewStartDate")]
        public bool MarkAsNewStartDate { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Settings.ProductEditor.MarkAsNewEndDate")]
        public bool MarkAsNewEndDate { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Settings.ProductEditor.Published")]
        public bool Published { get; set; }
        
        [QNetResourceDisplayName("Admin.Configuration.Settings.ProductEditor.RelatedProducts")]
        public bool RelatedProducts { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Settings.ProductEditor.CrossSellsProducts")]
        public bool CrossSellsProducts { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Settings.ProductEditor.Seo")]
        public bool Seo { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Settings.ProductEditor.PurchasedWithOrders")]
        public bool PurchasedWithOrders { get; set; }
       
        [QNetResourceDisplayName("Admin.Configuration.Settings.ProductEditor.ProductAttributes")]
        public bool ProductAttributes { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Settings.ProductEditor.SpecificationAttributes")]
        public bool SpecificationAttributes { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Settings.ProductEditor.Manufacturers")]
        public bool Manufacturers { get; set; }

        [QNetResourceDisplayName("Admin.Configuration.Settings.ProductEditor.StockQuantityHistory")]
        public bool StockQuantityHistory { get; set; }

        #endregion
    }
}