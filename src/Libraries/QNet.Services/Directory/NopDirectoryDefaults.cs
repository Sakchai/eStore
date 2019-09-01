namespace QNet.Services.Directory
{
    /// <summary>
    /// Represents default values related to directory services
    /// </summary>
    public static partial class QNetDirectoryDefaults
    {
        #region Countries

        /// <summary>
        /// Gets a key for caching
        /// </summary>
        /// <remarks>
        /// {0} : country ID
        /// </remarks>
        public static string CountriesByIdCacheKey => "QNet.country.id-{0}";

        /// <summary>
        /// Gets a key for caching
        /// </summary>
        /// <remarks>
        /// {0} : Two letter ISO code
        /// </remarks>
        public static string CountriesByTwoLetterCodeCacheKey => "QNet.country.twoletter-{0}";

        /// <summary>
        /// Gets a key for caching
        /// </summary>
        /// <remarks>
        /// {0} : Two letter ISO code
        /// </remarks>
        public static string CountriesByThreeLetterCodeCacheKey => "QNet.country.threeletter-{0}";

        /// <summary>
        /// Gets a key for caching
        /// </summary>
        /// <remarks>
        /// {0} : language ID
        /// {1} : show hidden records?
        /// </remarks>
        public static string CountriesAllCacheKey => "QNet.country.all-{0}-{1}";

        /// <summary>
        /// Gets a key pattern to clear cache
        /// </summary>
        public static string CountriesPrefixCacheKey => "QNet.country.";

        #endregion

        #region Currencies

        /// <summary>
        /// Gets a key for caching
        /// </summary>
        /// <remarks>
        /// {0} : currency ID
        /// </remarks>
        public static string CurrenciesByIdCacheKey => "QNet.currency.id-{0}";

        /// <summary>
        /// Gets a key for caching
        /// </summary>
        /// <remarks>
        /// {0} : show hidden records?
        /// </remarks>
        public static string CurrenciesAllCacheKey => "QNet.currency.all-{0}";

        /// <summary>
        /// Gets a key pattern to clear cache
        /// </summary>
        public static string CurrenciesPrefixCacheKey => "QNet.currency.";

        #endregion

        #region Measures

        /// <summary>
        /// Gets a key for caching
        /// </summary>
        public static string MeasureDimensionsAllCacheKey => "QNet.measuredimension.all";

        /// <summary>
        /// Gets a key for caching
        /// </summary>
        /// <remarks>
        /// {0} : dimension ID
        /// </remarks>
        public static string MeasureDimensionsByIdCacheKey => "QNet.measuredimension.id-{0}";

        /// <summary>
        /// Gets a key for caching
        /// </summary>
        public static string MeasureWeightsAllCacheKey => "QNet.measureweight.all";

        /// <summary>
        /// Gets a key for caching
        /// </summary>
        /// <remarks>
        /// {0} : weight ID
        /// </remarks>
        public static string MeasureWeightsByIdCacheKey => "QNet.measureweight.id-{0}";

        /// <summary>
        /// Gets a key pattern to clear cache
        /// </summary>
        public static string MeasureDimensionsPrefixCacheKey => "QNet.measuredimension.";

        /// <summary>
        /// Gets a key pattern to clear cache
        /// </summary>
        public static string MeasureWeightsPrefixCacheKey => "QNet.measureweight.";

        #endregion

        #region States and provinces

        /// <summary>
        /// Gets a key for caching
        /// </summary>
        /// <remarks>
        /// {0} : country ID
        /// {1} : language ID
        /// {2} : show hidden records?
        /// </remarks>
        public static string StateProvincesAllCacheKey => "QNet.stateprovince.all-{0}-{1}-{2}";

        /// <summary>
        /// Gets a key for caching
        /// </summary>
        /// <remarks>
        /// {0} : abbreviation
        /// {1} : country ID
        /// </remarks>
        public static string StateProvincesByAbbreviationCacheKey => "QNet.stateprovince.abbreviationcountryid-{0}";


        /// <summary>
        /// Gets a key pattern to clear cache
        /// </summary>
        public static string StateProvincesPrefixCacheKey => "QNet.stateprovince.";

        #endregion
    }
}