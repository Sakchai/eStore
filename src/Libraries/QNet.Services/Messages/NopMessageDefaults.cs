namespace QNet.Services.Messages
{
    /// <summary>
    /// Represents default values related to messages services
    /// </summary>
    public static partial class QNetMessageDefaults
    {
        /// <summary>
        /// Gets a key for caching
        /// </summary>
        /// <remarks>
        /// {0} : store ID
        /// </remarks>
        public static string MessageTemplatesAllCacheKey => "QNet.messagetemplate.all-{0}";

        /// <summary>
        /// Gets a key for caching
        /// </summary>
        /// <remarks>
        /// {0} : template name
        /// {1} : store ID
        /// </remarks>
        public static string MessageTemplatesByNameCacheKey => "QNet.messagetemplate.name-{0}-{1}";

        /// <summary>
        /// Gets a key pattern to clear cache
        /// </summary>
        public static string MessageTemplatesPrefixCacheKey => "QNet.messagetemplate.";

        /// <summary>
        /// Gets a key for notifications list from TempDataDictionary
        /// </summary>
        public static string NotificationListKey => "NotificationList";
    }
}