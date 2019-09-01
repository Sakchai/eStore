using QNet.Web.Framework.Mvc.ModelBinding;
using QNet.Web.Framework.Models;

namespace QNet.Web.Areas.Admin.Models.Common
{
    /// <summary>
    /// Represents an URL record model
    /// </summary>
    public partial class UrlRecordModel : BaseQNetEntityModel
    {
        #region Properties

        [QNetResourceDisplayName("Admin.System.SeNames.Name")]
        public string Name { get; set; }

        [QNetResourceDisplayName("Admin.System.SeNames.EntityId")]
        public int EntityId { get; set; }

        [QNetResourceDisplayName("Admin.System.SeNames.EntityName")]
        public string EntityName { get; set; }

        [QNetResourceDisplayName("Admin.System.SeNames.IsActive")]
        public bool IsActive { get; set; }

        [QNetResourceDisplayName("Admin.System.SeNames.Language")]
        public string Language { get; set; }

        [QNetResourceDisplayName("Admin.System.SeNames.Details")]
        public string DetailsUrl { get; set; }

        #endregion
    }
}