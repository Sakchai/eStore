namespace QNet.Services.Forums
{
    /// <summary>
    /// Represents default values related to forums services
    /// </summary>
    public static partial class QNetForumDefaults
    {
        /// <summary>
        /// Gets a key for caching
        /// </summary>
        public static string ForumGroupAllCacheKey => "QNet.forumgroup.all";

        /// <summary>
        /// Gets a key for caching
        /// </summary>
        /// <remarks>
        /// {0} : forum group ID
        /// </remarks>
        public static string ForumAllByForumGroupIdCacheKey => "QNet.forum.allbyforumgroupid-{0}";

        /// <summary>
        /// Gets a key pattern to clear cache
        /// </summary>
        public static string ForumGroupPrefixCacheKey => "QNet.forumgroup.";

        /// <summary>
        /// Gets a key pattern to clear cache
        /// </summary>
        public static string ForumPrefixCacheKey => "QNet.forum.";
    }
}