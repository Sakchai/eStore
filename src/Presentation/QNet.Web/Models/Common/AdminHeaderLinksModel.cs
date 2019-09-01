using QNet.Web.Framework.Models;

namespace QNet.Web.Models.Common
{
    public partial class AdminHeaderLinksModel : BaseQNetModel
    {
        public string ImpersonatedCustomerName { get; set; }
        public bool IsCustomerImpersonated { get; set; }
        public bool DisplayAdminLink { get; set; }
        public string EditPageUrl { get; set; }
    }
}