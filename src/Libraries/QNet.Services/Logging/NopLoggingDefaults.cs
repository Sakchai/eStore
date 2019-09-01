namespace QNet.Services.Logging
{
    /// <summary>
    /// Represents default values related to logging services
    /// </summary>
    public static partial class QNetLoggingDefaults
    {
        /// <summary>
        /// Gets a key for caching
        /// </summary>
        public static string ActivityTypeAllCacheKey => "QNet.activitytype.all";

        /// <summary>
        /// Gets a key pattern to clear cache
        /// </summary>
        public static string ActivityTypePrefixCacheKey => "QNet.activitytype.";
    }
}