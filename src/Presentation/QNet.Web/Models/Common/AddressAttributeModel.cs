using System.Collections.Generic;
using QNet.Core.Domain.Catalog;
using QNet.Web.Framework.Models;

namespace QNet.Web.Models.Common
{
    public partial class AddressAttributeModel : BaseQNetEntityModel
    {
        public AddressAttributeModel()
        {
            Values = new List<AddressAttributeValueModel>();
        }

        public string Name { get; set; }

        public bool IsRequired { get; set; }

        /// <summary>
        /// Default value for textboxes
        /// </summary>
        public string DefaultValue { get; set; }

        public AttributeControlType AttributeControlType { get; set; }

        public IList<AddressAttributeValueModel> Values { get; set; }
    }

    public partial class AddressAttributeValueModel : BaseQNetEntityModel
    {
        public string Name { get; set; }

        public bool IsPreSelected { get; set; }
    }
}