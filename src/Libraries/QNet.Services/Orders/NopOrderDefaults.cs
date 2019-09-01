namespace QNet.Services.Orders
{
    /// <summary>
    /// Represents default values related to orders services
    /// </summary>
    public static partial class QNetOrderDefaults
    {
        #region Checkout attributes

        /// <summary>
        /// Gets a key for caching
        /// </summary>
        /// <remarks>
        /// {0} : store ID
        /// {1} : >A value indicating whether we should exclude shippable attributes
        /// </remarks>
        public static string CheckoutAttributesAllCacheKey => "QNet.checkoutattribute.all-{0}-{1}";

        /// <summary>
        /// Gets a key for caching
        /// </summary>
        /// <remarks>
        /// {0} : checkout attribute ID
        /// </remarks>
        public static string CheckoutAttributesByIdCacheKey => "QNet.checkoutattribute.id-{0}";

        /// <summary>
        /// Gets a key for caching
        /// </summary>
        /// <remarks>
        /// {0} : checkout attribute ID
        /// </remarks>
        public static string CheckoutAttributeValuesAllCacheKey => "QNet.checkoutattributevalue.all-{0}";

        /// <summary>
        /// Gets a key for caching
        /// </summary>
        /// <remarks>
        /// {0} : checkout attribute value ID
        /// </remarks>
        public static string CheckoutAttributeValuesByIdCacheKey => "QNet.checkoutattributevalue.id-{0}";

        /// <summary>
        /// Gets a key pattern to clear cache
        /// </summary>
        public static string CheckoutAttributesPrefixCacheKey => "QNet.checkoutattribute.";

        /// <summary>
        /// Gets a key pattern to clear cache
        /// </summary>
        public static string CheckoutAttributeValuesPrefixCacheKey => "QNet.checkoutattributevalue.";

        #endregion
    }
}