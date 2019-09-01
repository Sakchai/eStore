using QNet.Web.Framework.Mvc.ModelBinding;
using QNet.Web.Framework.Models;

namespace QNet.Web.Areas.Admin.Models.Templates
{
    /// <summary>
    /// Represents a manufacturer template model
    /// </summary>
    public partial class ManufacturerTemplateModel : BaseQNetEntityModel
    {
        #region Properties

        [QNetResourceDisplayName("Admin.System.Templates.Manufacturer.Name")]
        public string Name { get; set; }

        [QNetResourceDisplayName("Admin.System.Templates.Manufacturer.ViewPath")]
        public string ViewPath { get; set; }

        [QNetResourceDisplayName("Admin.System.Templates.Manufacturer.DisplayOrder")]
        public int DisplayOrder { get; set; }

        #endregion
    }
}