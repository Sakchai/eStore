using QNet.Web.Framework.Mvc.ModelBinding;
using QNet.Web.Framework.Models;

namespace QNet.Web.Areas.Admin.Models.Vendors
{
    /// <summary>
    /// Represents a vendor search model
    /// </summary>
    public partial class VendorSearchModel : BaseSearchModel
    {
        #region Properties

        [QNetResourceDisplayName("Admin.Vendors.List.SearchName")]
        public string SearchName { get; set; }

        #endregion
    }
}