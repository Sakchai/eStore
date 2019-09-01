using QNet.Web.Framework.Mvc.ModelBinding;
using QNet.Web.Framework.Models;

namespace QNet.Web.Areas.Admin.Models.Templates
{
    /// <summary>
    /// Represents a category template model
    /// </summary>
    public partial class CategoryTemplateModel : BaseQNetEntityModel
    {
        #region Properties

        [QNetResourceDisplayName("Admin.System.Templates.Category.Name")]
        public string Name { get; set; }

        [QNetResourceDisplayName("Admin.System.Templates.Category.ViewPath")]
        public string ViewPath { get; set; }

        [QNetResourceDisplayName("Admin.System.Templates.Category.DisplayOrder")]
        public int DisplayOrder { get; set; }

        #endregion
    }
}