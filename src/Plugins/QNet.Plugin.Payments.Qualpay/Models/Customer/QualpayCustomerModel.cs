using QNet.Web.Framework.Models;
using QNet.Web.Framework.Mvc.ModelBinding;

namespace QNet.Plugin.Payments.Qualpay.Models.Customer
{
    /// <summary>
    /// Represents Qualpay customer model
    /// </summary>
    public class QualpayCustomerModel : BaseQNetEntityModel
    {
        #region Ctor

        public QualpayCustomerModel()
        {
            CustomerCardSearchModel = new QualpayCustomerCardSearchModel();
        }

        #endregion

        #region Properties

        [QNetResourceDisplayName("Plugins.Payments.Qualpay.Customer")]
        public string QualpayCustomerId { get; set; }

        public bool CustomerExists { get; set; }

        public bool HideBlock { get; set; }

        public QualpayCustomerCardSearchModel CustomerCardSearchModel { get; set; }

        #endregion
    }
}