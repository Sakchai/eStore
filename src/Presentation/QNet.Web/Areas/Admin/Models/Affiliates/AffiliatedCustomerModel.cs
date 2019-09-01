using QNet.Web.Framework.Models;
using QNet.Web.Framework.Mvc.ModelBinding;

namespace QNet.Web.Areas.Admin.Models.Affiliates
{
    /// <summary>
    /// Represents an affiliated customer model
    /// </summary>
    public partial class AffiliatedCustomerModel : BaseQNetEntityModel
    {
        #region Properties

        [QNetResourceDisplayName("Admin.Affiliates.Customers.Name")]
        public string Name { get; set; }

        #endregion
    }
}