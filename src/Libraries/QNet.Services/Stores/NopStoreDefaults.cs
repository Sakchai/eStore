namespace QNet.Services.Stores
{
    /// <summary>
    /// Represents default values related to stores services
    /// </summary>
    public static partial class QNetStoreDefaults
    {
        #region Store mappings

        /// <summary>
        /// Gets a key for caching
        /// </summary>
        /// <remarks>
        /// {0} : entity ID
        /// {1} : entity name
        /// </remarks>
        public static string StoreMappingByEntityIdNameCacheKey => "QNet.storemapping.entityid-name-{0}-{1}";

        /// <summary>
        /// Gets a key pattern to clear cache
        /// </summary>
        public static string StoreMappingPrefixCacheKey => "QNet.storemapping.";

        #endregion

        #region Stores

        /// <summary>
        /// Gets a key for caching
        /// </summary>
        public static string StoresAllCacheKey => "QNet.stores.all";

        /// <summary>
        /// Gets a key for caching
        /// </summary>
        /// <remarks>
        /// {0} : store ID
        /// </remarks>
        public static string StoresByIdCacheKey => "QNet.stores.id-{0}";

        /// <summary>
        /// Gets a key pattern to clear cache
        /// </summary>
        public static string StoresPrefixCacheKey => "QNet.stores.";

        #endregion
    }
}