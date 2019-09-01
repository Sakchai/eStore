namespace QNet.Services.Localization
{
    /// <summary>
    /// Represents default values related to localization services
    /// </summary>
    public static partial class QNetLocalizationDefaults
    {
        #region Languages

        /// <summary>
        /// Gets a key for caching
        /// </summary>
        /// <remarks>
        /// {0} : language ID
        /// </remarks>
        public static string LanguagesByIdCacheKey => "QNet.language.id-{0}";

        /// <summary>
        /// Gets a key for caching
        /// </summary>
        /// <remarks>
        /// {0} : show hidden records?
        /// </remarks>
        public static string LanguagesAllCacheKey => "QNet.language.all-{0}";

        /// <summary>
        /// Gets a key pattern to clear cache
        /// </summary>
        public static string LanguagesPrefixCacheKey => "QNet.language.";

        #endregion

        #region Locales

        /// <summary>
        /// Gets a key for caching
        /// </summary>
        /// <remarks>
        /// {0} : language ID
        /// </remarks>
        public static string LocaleStringResourcesAllPublicCacheKey => "QNet.lsr.all.public-{0}";

        /// <summary>
        /// Gets a key for caching
        /// </summary>
        /// <remarks>
        /// {0} : language ID
        /// </remarks>
        public static string LocaleStringResourcesAllCacheKey => "QNet.lsr.all-{0}";

        /// <summary>
        /// Gets a key for caching
        /// </summary>
        /// <remarks>
        /// {0} : language ID
        /// </remarks>
        public static string LocaleStringResourcesAllAdminCacheKey => "QNet.lsr.all.admin-{0}";

        /// <summary>
        /// Gets a key for caching
        /// </summary>
        /// <remarks>
        /// {0} : language ID
        /// {1} : resource key
        /// </remarks>
        public static string LocaleStringResourcesByResourceNameCacheKey => "QNet.lsr.{0}-{1}";

        /// <summary>
        /// Gets a key pattern to clear cache
        /// </summary>
        public static string LocaleStringResourcesPrefixCacheKey => "QNet.lsr.";

        /// <summary>
        /// Gets a prefix of locale resources for the admin area
        /// </summary>
        public static string AdminLocaleStringResourcesPrefix => "Admin.";

        /// <summary>
        /// Gets a prefix of locale resources for enumerations 
        /// </summary>
        public static string EnumLocaleStringResourcesPrefix => "Enums.";

        /// <summary>
        /// Gets a prefix of locale resources for permissions 
        /// </summary>
        public static string PermissionLocaleStringResourcesPrefix => "Permission.";

        /// <summary>
        /// Gets a prefix of locale resources for plugin friendly names 
        /// </summary>
        public static string PluginNameLocaleStringResourcesPrefix => "Plugins.FriendlyName.";

        #endregion

        #region Localized properties

        /// <summary>
        /// Gets a key for caching
        /// </summary>
        /// <remarks>
        /// {0} : language ID
        /// {1} : entity ID
        /// {2} : locale key group
        /// {3} : locale key
        /// </remarks>
        public static string LocalizedPropertyCacheKey => "QNet.localizedproperty.value-{0}-{1}-{2}-{3}";

        /// <summary>
        /// Gets a key for caching
        /// </summary>
        public static string LocalizedPropertyAllCacheKey => "QNet.localizedproperty.all";

        /// <summary>
        /// Gets a key pattern to clear cache
        /// </summary>
        public static string LocalizedPropertyPrefixCacheKey => "QNet.localizedproperty.";

        #endregion
    }
}