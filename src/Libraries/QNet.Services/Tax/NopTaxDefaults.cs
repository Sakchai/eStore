namespace QNet.Services.Tax
{
    /// <summary>
    /// Represents default values related to tax services
    /// </summary>
    public static partial class QNetTaxDefaults
    {
        /// <summary>
        /// Gets a key for caching
        /// </summary>
        public static string TaxCategoriesAllCacheKey => "QNet.taxcategory.all";

        /// <summary>
        /// Gets a key for caching
        /// </summary>
        /// <remarks>
        /// {0} : tax category ID
        /// </remarks>
        public static string TaxCategoriesByIdCacheKey => "QNet.taxcategory.id-{0}";

        /// <summary>
        /// Gets a key pattern to clear cache
        /// </summary>
        public static string TaxCategoriesPrefixCacheKey => "QNet.taxcategory.";
        
        /// <summary>
        /// Gets a key for caching
        /// </summary>
        /// <remarks>
        /// {0} : address ID
        /// </remarks>
        public static string TaxAddressByAddressIdCacheKey => "QNet.taxaddress.address.id-{0}-";

        /// <summary>
        /// Gets a key pattern to clear cache
        /// </summary>
        public static string TaxAddressPrefixCacheKey => "QNet.taxaddress.address.id-{0}-";
    }
}