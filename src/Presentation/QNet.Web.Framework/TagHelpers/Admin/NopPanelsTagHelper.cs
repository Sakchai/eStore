using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace QNet.Web.Framework.TagHelpers.Admin
{
    /// <summary>
    /// nop-panel tag helper
    /// </summary>
    [HtmlTargetElement("nop-panels", Attributes = ID_ATTRIBUTE_NAME)]
    public class QNetPanelsTagHelper : TagHelper
    {
        private const string ID_ATTRIBUTE_NAME = "id";

        /// <summary>
        /// ViewContext
        /// </summary>
        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }
    }
}