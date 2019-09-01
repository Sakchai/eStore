using QNet.Web.Framework.Mvc.ModelBinding;
using QNet.Web.Framework.Models;

namespace QNet.Web.Areas.Admin.Models.Common
{
    /// <summary>
    /// Represents a popular search term model
    /// </summary>
    public partial class PopularSearchTermModel : BaseQNetModel
    {
        #region Properties

        [QNetResourceDisplayName("Admin.SearchTermReport.Keyword")]
        public string Keyword { get; set; }

        [QNetResourceDisplayName("Admin.SearchTermReport.Count")]
        public int Count { get; set; }

        #endregion
    }
}
