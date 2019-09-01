namespace QNet.Web.Areas.Admin.Infrastructure.Cache
{
    public static partial class QNetModelCacheDefaults
    {
        /// <summary>
        /// Key for QNet.com news cache
        /// </summary>
        public static string OfficialNewsModelKey => "QNet.pres.admin.official.news";
        public static string OfficialNewsPrefixCacheKey => "QNet.pres.admin.official.news";

        /// <summary>
        /// Key for specification attributes caching (product details page)
        /// </summary>
        public static string SpecAttributesModelKey => "QNet.pres.admin.product.specs";
        public static string SpecAttributesPrefixCacheKey => "QNet.pres.admin.product.specs";

        /// <summary>
        /// Key for categories caching
        /// </summary>
        /// <remarks>
        /// {0} : show hidden records?
        /// </remarks>
        public static string CategoriesListKey => "QNet.pres.admin.categories.list-{0}";
        public static string CategoriesListPrefixCacheKey => "QNet.pres.admin.categories.list";

        /// <summary>
        /// Key for manufacturers caching
        /// </summary>
        /// <remarks>
        /// {0} : show hidden records?
        /// </remarks>
        public static string ManufacturersListKey => "QNet.pres.admin.manufacturers.list-{0}";
        public static string ManufacturersListPrefixCacheKey => "QNet.pres.admin.manufacturers.list";

        /// <summary>
        /// Key for vendors caching
        /// </summary>
        /// <remarks>
        /// {0} : show hidden records?
        /// </remarks>
        public static string VendorsListKey => "QNet.pres.admin.vendors.list-{0}";
        public static string VendorsListPrefixCacheKey => "QNet.pres.admin.vendors.list";
    }
}
