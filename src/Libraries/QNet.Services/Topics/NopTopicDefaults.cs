namespace QNet.Services.Topics
{
    /// <summary>
    /// Represents default values related to topic services
    /// </summary>
    public static partial class QNetTopicDefaults
    {
        /// <summary>
        /// Gets a key for caching
        /// </summary>
        /// <remarks>
        /// {0} : store ID
        /// {1} : ignore ACL?
        /// {2} : show hidden?
        /// </remarks>
        public static string TopicsAllCacheKey => "QNet.topics.all-{0}-{1}-{2}";

        /// <summary>
        /// Gets a key for caching
        /// </summary>
        /// <remarks>
        /// {0} : topic ID
        /// </remarks>
        public static string TopicsByIdCacheKey => "QNet.topics.id-{0}";

        /// <summary>
        /// Gets a pattern to clear cache
        /// </summary>
        public static string TopicsPrefixCacheKey => "QNet.topics.";
    }
}