using QNet.Web.Framework.Models;
using QNet.Web.Framework.Mvc.ModelBinding;

namespace QNet.Web.Areas.Admin.Models.Customers
{
    /// <summary>
    /// Represents a customer associated external authentication model
    /// </summary>
    public partial class CustomerAssociatedExternalAuthModel : BaseQNetEntityModel
    {
        #region Properties

        [QNetResourceDisplayName("Admin.Customers.Customers.AssociatedExternalAuth.Fields.Email")]
        public string Email { get; set; }

        [QNetResourceDisplayName("Admin.Customers.Customers.AssociatedExternalAuth.Fields.ExternalIdentifier")]
        public string ExternalIdentifier { get; set; }
        
        [QNetResourceDisplayName("Admin.Customers.Customers.AssociatedExternalAuth.Fields.AuthMethodName")]
        public string AuthMethodName { get; set; }

        #endregion
    }
}