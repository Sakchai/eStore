using QNet.Web.Framework.Mvc.ModelBinding;
using QNet.Web.Framework.Models;

namespace QNet.Web.Areas.Admin.Models.Templates
{
    /// <summary>
    /// Represents a topic template model
    /// </summary>
    public partial class TopicTemplateModel : BaseQNetEntityModel
    {
        #region Properties

        [QNetResourceDisplayName("Admin.System.Templates.Topic.Name")]
        public string Name { get; set; }

        [QNetResourceDisplayName("Admin.System.Templates.Topic.ViewPath")]
        public string ViewPath { get; set; }

        [QNetResourceDisplayName("Admin.System.Templates.Topic.DisplayOrder")]
        public int DisplayOrder { get; set; }

        #endregion
    }
}