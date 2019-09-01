using Microsoft.AspNetCore.Routing;
using QNet.Core.Data;
using QNet.Core.Domain.Common;
using QNet.Core.Infrastructure;
using QNet.Web.Framework.Localization;
using QNet.Web.Framework.Mvc.Routing;

namespace QNet.Web.Infrastructure
{
    /// <summary>
    /// Represents provider that provided routes used for backward compatibility with 2.x versions of QNet
    /// </summary>
    public partial class BackwardCompatibility2XRouteProvider : IRouteProvider
    {
        #region Methods

        /// <summary>
        /// Register routes
        /// </summary>
        /// <param name="routeBuilder">Route builder</param>
        public void RegisterRoutes(IRouteBuilder routeBuilder)
        {
            if (DataSettingsManager.DatabaseIsInstalled && !EngineContext.Current.Resolve<CommonSettings>().SupportPreviousQNetcommerceVersions)
                return;

            //products
            routeBuilder.MapLocalizedRoute("", "p/{productId:min(0)}/{SeName?}",
                new { controller = "BackwardCompatibility2X", action = "RedirectProductById" });

            //categories
            routeBuilder.MapLocalizedRoute("", "c/{categoryId:min(0)}/{SeName?}",
                new { controller = "BackwardCompatibility2X", action = "RedirectCategoryById" });

            //manufacturers
            routeBuilder.MapLocalizedRoute("", "m/{manufacturerId:min(0)}/{SeName?}",
                new { controller = "BackwardCompatibility2X", action = "RedirectManufacturerById" });

            //news
            routeBuilder.MapLocalizedRoute("", "news/{newsItemId:min(0)}/{SeName?}",
                new { controller = "BackwardCompatibility2X", action = "RedirectNewsItemById" });

            //blog
            routeBuilder.MapLocalizedRoute("", "blog/{blogPostId:min(0)}/{SeName?}",
                new { controller = "BackwardCompatibility2X", action = "RedirectBlogPostById" });

            //topic
            routeBuilder.MapLocalizedRoute("", "t/{SystemName}",
                new { controller = "BackwardCompatibility2X", action = "RedirectTopicBySystemName" });

            //vendors
            routeBuilder.MapLocalizedRoute("", "vendor/{vendorId:min(0)}/{SeName?}",
                new { controller = "BackwardCompatibility2X", action = "RedirectVendorById" });

            //product tags
            routeBuilder.MapLocalizedRoute("", "producttag/{productTagId:min(0)}/{SeName?}",
                new { controller = "BackwardCompatibility2X", action = "RedirectProductTagById" });
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets a priority of route provider
        /// </summary>
        public int Priority => -1000; //register it after all other IRouteProvider are processed

        #endregion
    }
}