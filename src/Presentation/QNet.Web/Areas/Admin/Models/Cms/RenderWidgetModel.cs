using QNet.Web.Framework.Models;

namespace QNet.Web.Areas.Admin.Models.Cms
{
    public partial class RenderWidgetModel : BaseQNetModel
    {
        public string WidgetViewComponentName { get; set; }
        public object WidgetViewComponentArguments { get; set; }
    }
}