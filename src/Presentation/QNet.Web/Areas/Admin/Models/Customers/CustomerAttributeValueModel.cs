using System.Collections.Generic;
using QNet.Web.Framework.Models;
using QNet.Web.Framework.Mvc.ModelBinding;

namespace QNet.Web.Areas.Admin.Models.Customers
{
    /// <summary>
    /// Represents a customer attribute value model
    /// </summary>
    public partial class CustomerAttributeValueModel : BaseQNetEntityModel, ILocalizedModel<CustomerAttributeValueLocalizedModel>
    {
        #region Ctor

        public CustomerAttributeValueModel()
        {
            Locales = new List<CustomerAttributeValueLocalizedModel>();
        }

        #endregion

        #region Properties

        public int CustomerAttributeId { get; set; }

        [QNetResourceDisplayName("Admin.Customers.CustomerAttributes.Values.Fields.Name")]
        public string Name { get; set; }

        [QNetResourceDisplayName("Admin.Customers.CustomerAttributes.Values.Fields.IsPreSelected")]
        public bool IsPreSelected { get; set; }

        [QNetResourceDisplayName("Admin.Customers.CustomerAttributes.Values.Fields.DisplayOrder")]
        public int DisplayOrder {get;set;}

        public IList<CustomerAttributeValueLocalizedModel> Locales { get; set; }

        #endregion
    }

    public partial class CustomerAttributeValueLocalizedModel : ILocalizedLocaleModel
    {
        public int LanguageId { get; set; }

        [QNetResourceDisplayName("Admin.Customers.CustomerAttributes.Values.Fields.Name")]
        public string Name { get; set; }
    }
}