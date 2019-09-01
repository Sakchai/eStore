using System.Collections.Generic;
using QNet.Core.Domain.Catalog;
using QNet.Web.Framework.Models;

namespace QNet.Web.Models.Customer
{
    public partial class CustomerAttributeModel : BaseQNetEntityModel
    {
        public CustomerAttributeModel()
        {
            Values = new List<CustomerAttributeValueModel>();
        }

        public string Name { get; set; }

        public bool IsRequired { get; set; }

        /// <summary>
        /// Default value for textboxes
        /// </summary>
        public string DefaultValue { get; set; }

        public AttributeControlType AttributeControlType { get; set; }

        public IList<CustomerAttributeValueModel> Values { get; set; }

    }

    public partial class CustomerAttributeValueModel : BaseQNetEntityModel
    {
        public string Name { get; set; }

        public bool IsPreSelected { get; set; }
    }
}