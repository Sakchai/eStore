using System.Collections.Generic;
using QNet.Web.Framework.Models;
using QNet.Web.Framework.Mvc.ModelBinding;

namespace QNet.Web.Areas.Admin.Models.Customers
{
    /// <summary>
    /// Represents a customer attribute model
    /// </summary>
    public partial class CustomerAttributeModel : BaseQNetEntityModel, ILocalizedModel<CustomerAttributeLocalizedModel>
    {
        #region Ctor

        public CustomerAttributeModel()
        {
            Locales = new List<CustomerAttributeLocalizedModel>();
            CustomerAttributeValueSearchModel = new CustomerAttributeValueSearchModel();
        }

        #endregion

        #region Properties

        [QNetResourceDisplayName("Admin.Customers.CustomerAttributes.Fields.Name")]
        public string Name { get; set; }

        [QNetResourceDisplayName("Admin.Customers.CustomerAttributes.Fields.IsRequired")]
        public bool IsRequired { get; set; }

        [QNetResourceDisplayName("Admin.Customers.CustomerAttributes.Fields.AttributeControlType")]
        public int AttributeControlTypeId { get; set; }

        [QNetResourceDisplayName("Admin.Customers.CustomerAttributes.Fields.AttributeControlType")]
        public string AttributeControlTypeName { get; set; }

        [QNetResourceDisplayName("Admin.Customers.CustomerAttributes.Fields.DisplayOrder")]
        public int DisplayOrder { get; set; }

        public IList<CustomerAttributeLocalizedModel> Locales { get; set; }

        public CustomerAttributeValueSearchModel CustomerAttributeValueSearchModel { get; set; }

        #endregion
    }

    public partial class CustomerAttributeLocalizedModel : ILocalizedLocaleModel
    {
        public int LanguageId { get; set; }

        [QNetResourceDisplayName("Admin.Customers.CustomerAttributes.Fields.Name")]
        public string Name { get; set; }
    }
}