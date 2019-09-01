using QNet.Web.Framework.Mvc.ModelBinding;
using QNet.Web.Framework.Models;

namespace QNet.Web.Areas.Admin.Models.Common
{
    /// <summary>
    /// Represents an URL record search model
    /// </summary>
    public partial class UrlRecordSearchModel : BaseSearchModel
    {
        #region Properties

        [QNetResourceDisplayName("Admin.System.SeNames.Name")]
        public string SeName { get; set; }

        #endregion
    }
}