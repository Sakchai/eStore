namespace QNet.Services.Discounts
{
    /// <summary>
    /// Represents default values related to discounts services
    /// </summary>
    public static partial class QNetDiscountDefaults
    {
        /// <summary>
        /// Gets the query parameter name to retrieve discount coupon code from URL
        /// </summary>
        public static string DiscountCouponQueryParameter => "discountcoupon";

        /// <summary>
        /// Key for discount requirement of a certain discount
        /// </summary>
        /// <remarks>
        /// {0} : discount id
        /// </remarks>
        public static string DiscountRequirementModelCacheKey => "QNet.discounts.requirements-{0}";

        /// <summary>
        /// Gets a key pattern to clear cache
        /// </summary>
        public static string DiscountRequirementPrefixCacheKey => "QNet.discounts.requirements";

        /// <summary>
        /// Key for caching
        /// </summary>
        /// <remarks>
        /// {0} : show hidden records?
        /// {1} : coupon code
        /// {2} : discount name
        /// </remarks>
        public static string DiscountAllCacheKey => "QNet.discounts.all-{0}-{1}-{2}";

        /// <summary>
        /// Gets a key pattern to clear cache
        /// </summary>
        public static string DiscountAllPrefixCacheKey => "QNet.discounts.all";

        /// <summary>
        /// Key for category IDs of a discount
        /// </summary>
        /// <remarks>
        /// {0} : discount id
        /// {1} : roles of the current user
        /// {2} : current store ID
        /// </remarks>
        public static string DiscountCategoryIdsModelCacheKey => "QNet.discounts.categoryids-{0}-{1}-{2}";

        /// <summary>
        /// Gets a key pattern to clear cache
        /// </summary>
        public static string DiscountCategoryIdsPrefixCacheKey => "QNet.discounts.categoryids";

        /// <summary>
        /// Key for manufacturer IDs of a discount
        /// </summary>
        /// <remarks>
        /// {0} : discount id
        /// {1} : roles of the current user
        /// {2} : current store ID
        /// </remarks>
        public static string DiscountManufacturerIdsModelCacheKey => "QNet.discounts.manufacturerids-{0}-{1}-{2}";

        /// <summary>
        /// Gets a key pattern to clear cache
        /// </summary>
        public static string DiscountManufacturerIdsPrefixCacheKey => "QNet.discounts.manufacturerids";
    }
}