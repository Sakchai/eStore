namespace QNet.Services.Common
{
    /// <summary>
    /// Represents default values related to common services
    /// </summary>
    public static partial class QNetCommonDefaults
    {
        /// <summary>
        /// Gets a request path to the keep alive URL
        /// </summary>
        public static string KeepAlivePath => "keepalive/index";

        #region Address attributes

        /// <summary>
        /// Gets a key for caching
        /// </summary>
        public static string AddressAttributesAllCacheKey => "QNet.addressattribute.all";

        /// <summary>
        /// Gets a key for caching
        /// </summary>
        /// <remarks>
        /// {0} : address attribute ID
        /// </remarks>
        public static string AddressAttributesByIdCacheKey => "QNet.addressattribute.id-{0}";

        /// <summary>
        /// Gets a key for caching
        /// </summary>
        /// <remarks>
        /// {0} : address attribute ID
        /// </remarks>
        public static string AddressAttributeValuesAllCacheKey => "QNet.addressattributevalue.all-{0}";

        /// <summary>
        /// Gets a key for caching
        /// </summary>
        /// <remarks>
        /// {0} : address attribute value ID
        /// </remarks>
        public static string AddressAttributeValuesByIdCacheKey => "QNet.addressattributevalue.id-{0}";

        /// <summary>
        /// Gets a key pattern to clear cache
        /// </summary>
        public static string AddressAttributesPrefixCacheKey => "QNet.addressattribute.";

        /// <summary>
        /// Gets a key pattern to clear cache
        /// </summary>
        public static string AddressAttributeValuesPrefixCacheKey => "QNet.addressattributevalue.";

        /// <summary>
        /// Gets a name of the custom address attribute control
        /// </summary>
        /// <remarks>
        /// {0} : address attribute id
        /// </remarks>
        public static string AddressAttributeControlName => "address_attribute_{0}";

        #endregion

        #region Addresses

        /// <summary>
        /// Gets a key for caching
        /// </summary>
        /// <remarks>
        /// {0} : address ID
        /// </remarks>
        public static string AddressesByIdCacheKey => "QNet.address.id-{0}";

        /// <summary>
        /// Gets a key pattern to clear cache
        /// </summary>
        public static string AddressesPrefixCacheKey => "QNet.address.";

        #endregion

        #region Generic attributes

        /// <summary>
        /// Gets a key for caching
        /// </summary>
        /// <remarks>
        /// {0} : entity ID
        /// {1} : key group
        /// </remarks>
        public static string GenericAttributeCacheKey => "QNet.genericattribute.{0}-{1}";

        /// <summary>
        /// Gets a key pattern to clear cache
        /// </summary>
        public static string GenericAttributePrefixCacheKey => "QNet.genericattribute.";

        #endregion

        #region Maintenance

        /// <summary>
        /// Gets a path to the database backup files
        /// </summary>
        public static string DbBackupsPath => "db_backups\\";

        /// <summary>
        /// Gets a database backup file extension
        /// </summary>
        public static string DbBackupFileExtension => "bak";

        #endregion

        #region Favicon and app icons

        /// <summary>
        /// Gets a name of the file with code for the head element
        /// </summary>
        public static string HeadCodeFileName => "html_code.html";

        /// <summary>
        /// Gets a path to the favicon and app icons
        /// </summary>
        public static string FaviconAndAppIconsPath => "icons\\icons_{0}";

        /// <summary>
        /// Gets a name of the old favicon icon for current store
        /// </summary>
        public static string OldFaviconIconName => "favicon-{0}.ico";

        #endregion

        #region QNet official site

        /// <summary>
        /// Gets a path to request the QNet official site for copyright warning
        /// </summary>
        /// <remarks>
        /// {0} : store URL
        /// {1} : whether the store based is on the localhost
        /// </remarks>
        public static string QNetCopyrightWarningPath => "SiteWarnings.aspx?local={0}&url={1}";

        /// <summary>
        /// Gets a path to request the QNet official site for news RSS
        /// </summary>
        /// <remarks>
        /// {0} : QNet version
        /// {1} : whether the store based is on the localhost
        /// {2} : whether advertisements are hidden
        /// {3} : store URL
        /// </remarks>
        public static string QNetNewsRssPath => "NewsRSS.aspx?Version={0}&Localhost={1}&HideAdvertisements={2}&StoreURL={3}";

        /// <summary>
        /// Gets a path to request the QNet official site for available categories of marketplace extensions
        /// </summary>
        public static string QNetExtensionsCategoriesPath => "ExtensionsXml.aspx?getCategories=1";

        /// <summary>
        /// Gets a path to request the QNet official site for available versions of marketplace extensions
        /// </summary>
        public static string QNetExtensionsVersionsPath => "ExtensionsXml.aspx?getVersions=1";

        /// <summary>
        /// Gets a path to request the QNet official site for marketplace extensions
        /// </summary>
        /// <remarks>
        /// {0} : extension category identifier
        /// {1} : extension version identifier
        /// {2} : extension price identifier
        /// {3} : search term
        /// {4} : page index
        /// {5} : page size
        /// </remarks>
        public static string QNetExtensionsPath => "ExtensionsXml.aspx?category={0}&version={1}&price={2}&searchTerm={3}&pageIndex={4}&pageSize={5}";

        #endregion
    }
}