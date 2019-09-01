using System;
using System.Collections.Generic;
using QNet.Web.Framework.Mvc.ModelBinding;
using QNet.Web.Framework.Models;

namespace QNet.Web.Areas.Admin.Models.Common
{
    public partial class SystemInfoModel : BaseQNetModel
    {
        public SystemInfoModel()
        {
            Headers = new List<HeaderModel>();
            LoadedAssemblies = new List<LoadedAssembly>();
        }

        [QNetResourceDisplayName("Admin.System.SystemInfo.ASPNETInfo")]
        public string AspNetInfo { get; set; }

        [QNetResourceDisplayName("Admin.System.SystemInfo.IsFullTrust")]
        public string IsFullTrust { get; set; }

        [QNetResourceDisplayName("Admin.System.SystemInfo.QNetVersion")]
        public string QNetVersion { get; set; }

        [QNetResourceDisplayName("Admin.System.SystemInfo.OperatingSystem")]
        public string OperatingSystem { get; set; }

        [QNetResourceDisplayName("Admin.System.SystemInfo.ServerLocalTime")]
        public DateTime ServerLocalTime { get; set; }

        [QNetResourceDisplayName("Admin.System.SystemInfo.ServerTimeZone")]
        public string ServerTimeZone { get; set; }

        [QNetResourceDisplayName("Admin.System.SystemInfo.UTCTime")]
        public DateTime UtcTime { get; set; }

        [QNetResourceDisplayName("Admin.System.SystemInfo.CurrentUserTime")]
        public DateTime CurrentUserTime { get; set; }

        [QNetResourceDisplayName("Admin.System.SystemInfo.CurrentStaticCacheManager")]
        public string CurrentStaticCacheManager { get; set; }

        [QNetResourceDisplayName("Admin.System.SystemInfo.HTTPHOST")]
        public string HttpHost { get; set; }

        [QNetResourceDisplayName("Admin.System.SystemInfo.Headers")]
        public IList<HeaderModel> Headers { get; set; }

        [QNetResourceDisplayName("Admin.System.SystemInfo.LoadedAssemblies")]
        public IList<LoadedAssembly> LoadedAssemblies { get; set; }

        [QNetResourceDisplayName("Admin.System.SystemInfo.RedisEnabled")]
        public bool RedisEnabled { get; set; }

        [QNetResourceDisplayName("Admin.System.SystemInfo.UseRedisToStoreDataProtectionKeys")]
        public bool UseRedisToStoreDataProtectionKeys { get; set; }

        [QNetResourceDisplayName("Admin.System.SystemInfo.UseRedisForCaching")]
        public bool UseRedisForCaching { get; set; }

        [QNetResourceDisplayName("Admin.System.SystemInfo.UseRedisToStorePluginsInfo")]
        public bool UseRedisToStorePluginsInfo { get; set; }

        [QNetResourceDisplayName("Admin.System.SystemInfo.AzureBlobStorageEnabled")]
        public bool AzureBlobStorageEnabled { get; set; }

        public partial class HeaderModel : BaseQNetModel
        {
            public string Name { get; set; }
            public string Value { get; set; }
        }

        public partial class LoadedAssembly : BaseQNetModel
        {
            public string FullName { get; set; }
            public string Location { get; set; }
            public bool IsDebug { get; set; }
            public DateTime? BuildDate { get; set; }
        }
    }
}