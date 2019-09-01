using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Routing;
using QNet.Core;
using QNet.Core.Caching;
using QNet.Services.Cms;
using QNet.Web.Framework.Themes;
using QNet.Web.Infrastructure.Cache;
using QNet.Web.Models.Cms;

namespace QNet.Web.Factories
{
    /// <summary>
    /// Represents the widget model factory
    /// </summary>
    public partial class WidgetModelFactory : IWidgetModelFactory
    {
        #region Fields

        private readonly IStaticCacheManager _cacheManager;
        private readonly IStoreContext _storeContext;
        private readonly IThemeContext _themeContext;
        private readonly IWidgetPluginManager _widgetPluginManager;
        private readonly IWorkContext _workContext;

        #endregion

        #region Ctor

        public WidgetModelFactory(IStaticCacheManager cacheManager,
            IStoreContext storeContext,
            IThemeContext themeContext,
            IWidgetPluginManager widgetPluginManager,
            IWorkContext workContext)
        {
            _cacheManager = cacheManager;
            _storeContext = storeContext;
            _themeContext = themeContext;
            _widgetPluginManager = widgetPluginManager;
            _workContext = workContext;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Get the render widget models
        /// </summary>
        /// <param name="widgetZone">Name of widget zone</param>
        /// <param name="additionalData">Additional data object</param>
        /// <returns>List of the render widget models</returns>
        public virtual List<RenderWidgetModel> PrepareRenderWidgetModel(string widgetZone, object additionalData = null)
        {
            var cacheKey = string.Format(QNetModelCacheDefaults.WidgetModelKey,
                _workContext.CurrentCustomer.Id, _storeContext.CurrentStore.Id, widgetZone, _themeContext.WorkingThemeName);

            var cachedModels = _cacheManager.Get(cacheKey, () =>
                _widgetPluginManager.LoadActivePlugins(_workContext.CurrentCustomer, _storeContext.CurrentStore.Id, widgetZone)
                .Select(widget => new RenderWidgetModel
                {
                    WidgetViewComponentName = widget.GetWidgetViewComponentName(widgetZone),
                    WidgetViewComponentArguments = new RouteValueDictionary { ["widgetZone"] = widgetZone }
                }));

            //"WidgetViewComponentArguments" property of widget models depends on "additionalData".
            //We need to clone the cached model before modifications (the updated one should not be cached)
            var models = cachedModels.Select(renderModel => new RenderWidgetModel
            {
                WidgetViewComponentName = renderModel.WidgetViewComponentName,
                WidgetViewComponentArguments = new RouteValueDictionary { ["widgetZone"] = widgetZone, ["additionalData"] = additionalData }
            }).ToList();

            return models;
        }

        #endregion
    }
}