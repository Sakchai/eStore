namespace QNet.Services.Customers
{
    /// <summary>
    /// Represents default values related to customer services
    /// </summary>
    public static partial class QNetCustomerServiceDefaults
    {
        #region Customer attributes

        /// <summary>
        /// Gets a key for caching
        /// </summary>
        public static string CustomerAttributesAllCacheKey => "QNet.customerattribute.all";

        /// <summary>
        /// Gets a key for caching
        /// </summary>
        /// <remarks>
        /// {0} : customer attribute ID
        /// </remarks>
        public static string CustomerAttributesByIdCacheKey => "QNet.customerattribute.id-{0}";

        /// <summary>
        /// Gets a key for caching
        /// </summary>
        /// <remarks>
        /// {0} : customer attribute ID
        /// </remarks>
        public static string CustomerAttributeValuesAllCacheKey => "QNet.customerattributevalue.all-{0}";

        /// <summary>
        /// Gets a key for caching
        /// </summary>
        /// <remarks>
        /// {0} : customer attribute value ID
        /// </remarks>
        public static string CustomerAttributeValuesByIdCacheKey => "QNet.customerattributevalue.id-{0}";

        /// <summary>
        /// Gets a key pattern to clear cache
        /// </summary>
        public static string CustomerAttributesPrefixCacheKey => "QNet.customerattribute.";

        /// <summary>
        /// Gets a key pattern to clear cache
        /// </summary>
        public static string CustomerAttributeValuesPrefixCacheKey => "QNet.customerattributevalue.";

        #endregion

        #region Customer roles

        /// <summary>
        /// Gets a key for caching
        /// </summary>
        /// <remarks>
        /// {0} : show hidden records?
        /// </remarks>
        public static string CustomerRolesAllCacheKey => "QNet.customerrole.all-{0}";

        /// <summary>
        /// Gets a key for caching
        /// </summary>
        /// <remarks>
        /// {0} : system name
        /// </remarks>
        public static string CustomerRolesBySystemNameCacheKey => "QNet.customerrole.systemname-{0}";

        /// <summary>
        /// Gets a key pattern to clear cache
        /// </summary>
        public static string CustomerRolesPrefixCacheKey => "QNet.customerrole.";

        #endregion

        /// <summary>
        /// Gets a key for caching current customer password lifetime
        /// </summary>
        /// <remarks>
        /// {0} : customer identifier
        /// </remarks>
        public static string CustomerPasswordLifetimeCacheKey => "QNet.customers.passwordlifetime-{0}";

        /// <summary>
        /// Gets a password salt key size
        /// </summary>
        public static int PasswordSaltKeySize => 5;
        
        /// <summary>
        /// Gets a max username length
        /// </summary>
        public static int CustomerUsernameLength => 100;

        /// <summary>
        /// Gets a default hash format for customer password
        /// </summary>
        public static string DefaultHashedPasswordFormat => "SHA512";
    }
}