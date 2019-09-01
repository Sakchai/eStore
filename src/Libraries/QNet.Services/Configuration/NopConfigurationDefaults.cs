namespace QNet.Services.Configuration
{
    /// <summary>
    /// Represents default values related to configuration services
    /// </summary>
    public static partial class QNetConfigurationDefaults
    {
        /// <summary>
        /// Gets a key for caching
        /// </summary>
        public static string SettingsAllCacheKey => "QNet.setting.all";

        /// <summary>
        /// Gets a key pattern to clear cache
        /// </summary>
        public static string SettingsPrefixCacheKey => "QNet.setting.";
    }
}