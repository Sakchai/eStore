using System.Collections.Generic;
using QNet.Web.Framework.Models;
using QNet.Web.Framework.Mvc.ModelBinding;

namespace QNet.Web.Areas.Admin.Models.Customers
{
    /// <summary>
    /// Represents a associated external auth records search model
    /// </summary>
    public class CustomerAssociatedExternalAuthRecordsSearchModel : BaseSearchModel
    {
        #region Properties

        public int CustomerId { get; set; }

        [QNetResourceDisplayName("Admin.Customers.Customers.AssociatedExternalAuth")]
        public IList<CustomerAssociatedExternalAuthModel> AssociatedExternalAuthRecords { get; set; } = new List<CustomerAssociatedExternalAuthModel>();
        
        #endregion
    }
}
