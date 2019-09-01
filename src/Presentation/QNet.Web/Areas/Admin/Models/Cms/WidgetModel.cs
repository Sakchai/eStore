using Microsoft.AspNetCore.Routing;
using QNet.Web.Framework.Mvc.ModelBinding;
using QNet.Web.Framework.Models;

namespace QNet.Web.Areas.Admin.Models.Cms
{
    /// <summary>
    /// Represents a widget model
    /// </summary>
    public partial class WidgetModel : BaseQNetModel, IPluginModel
    {
        #region Properties

        [QNetResourceDisplayName("Admin.ContentManagement.Widgets.Fields.FriendlyName")]
        public string FriendlyName { get; set; }

        [QNetResourceDisplayName("Admin.ContentManagement.Widgets.Fields.SystemName")]
        public string SystemName { get; set; }

        [QNetResourceDisplayName("Admin.ContentManagement.Widgets.Fields.DisplayOrder")]
        public int DisplayOrder { get; set; }

        [QNetResourceDisplayName("Admin.ContentManagement.Widgets.Fields.IsActive")]
        public bool IsActive { get; set; }

        [QNetResourceDisplayName("Admin.ContentManagement.Widgets.Configure")]
        public string ConfigurationUrl { get; set; }

        public string LogoUrl { get; set; }

        public string WidgetViewComponentName { get; set; }

        public RouteValueDictionary WidgetViewComponentArguments { get; set; }

        #endregion
    }
}