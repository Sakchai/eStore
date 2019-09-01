using QNet.Web.Framework.Models;

namespace QNet.Web.Models.Customer
{
    public partial class GdprConsentModel : BaseQNetEntityModel
    {
        public string Message { get; set; }

        public bool IsRequired { get; set; }

        public string RequiredMessage { get; set; }

        public bool Accepted { get; set; }
    }
}