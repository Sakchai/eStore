﻿using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Web.Areas.Admin.Models.Settings
{
    /// <summary>
    /// Represents a common configuration model
    /// </summary>
    public partial record CommonConfigModel : BaseNopModel, IConfigModel
    {
        #region Properties

        [NopResourceDisplayName("Admin.Configuration.AppSettings.Common.DisplayFullErrorStack")]
        public bool DisplayFullErrorStack { get; set; }

        [NopResourceDisplayName("Admin.Configuration.AppSettings.Common.UserAgentStringsPath")]
        public string UserAgentStringsPath { get; set; }

        [NopResourceDisplayName("Admin.Configuration.AppSettings.Common.CrawlerOnlyUserAgentStringsPath")]
        public string CrawlerOnlyUserAgentStringsPath { get; set; }

        [NopResourceDisplayName("Admin.Configuration.AppSettings.Common.UseSessionStateTempDataProvider")]
        public bool UseSessionStateTempDataProvider { get; set; }

        [NopResourceDisplayName("Admin.Configuration.AppSettings.Common.MiniProfilerEnabled")]
        public bool MiniProfilerEnabled { get; set; }

        [NopResourceDisplayName("Admin.Configuration.AppSettings.Common.ScheduleTaskRunTimeout")]
        public int? ScheduleTaskRunTimeout { get; set; }

        [NopResourceDisplayName("Admin.Configuration.AppSettings.Common.StaticFilesCacheControl")]
        public string StaticFilesCacheControl { get; set; }

        [NopResourceDisplayName("Admin.Configuration.AppSettings.Common.SupportPreviousNopcommerceVersions")]
        public bool SupportPreviousNopcommerceVersions { get; set; }

        [NopResourceDisplayName("Admin.Configuration.AppSettings.Common.PluginStaticFileExtensionsBlacklist")]
        public string PluginStaticFileExtensionsBlacklist { get; set; }

        #endregion
    }
}