using QNet.Web.Areas.Admin.Models.Common;
using QNet.Web.Framework.Models;
using QNet.Web.Framework.Mvc.ModelBinding;

namespace QNet.Web.Areas.Admin.Models.Affiliates
{
    /// <summary>
    /// Represents an affiliate model
    /// </summary>
    public partial class AffiliateModel : BaseQNetEntityModel
    {
        #region Ctor

        public AffiliateModel()
        {
            Address = new AddressModel();
            AffiliatedOrderSearchModel= new AffiliatedOrderSearchModel();
            AffiliatedCustomerSearchModel = new AffiliatedCustomerSearchModel();
        }

        #endregion

        #region Properties

        [QNetResourceDisplayName("Admin.Affiliates.Fields.URL")]
        public string Url { get; set; }
        
        [QNetResourceDisplayName("Admin.Affiliates.Fields.AdminComment")]
        public string AdminComment { get; set; }

        [QNetResourceDisplayName("Admin.Affiliates.Fields.FriendlyUrlName")]
        public string FriendlyUrlName { get; set; }
        
        [QNetResourceDisplayName("Admin.Affiliates.Fields.Active")]
        public bool Active { get; set; }

        public AddressModel Address { get; set; }

        public AffiliatedOrderSearchModel AffiliatedOrderSearchModel { get; set; }

        public AffiliatedCustomerSearchModel AffiliatedCustomerSearchModel { get; set; }

        #endregion
    }
}