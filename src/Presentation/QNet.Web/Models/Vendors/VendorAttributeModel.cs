using System.Collections.Generic;
using QNet.Core.Domain.Catalog;
using QNet.Web.Framework.Models;

namespace QNet.Web.Models.Vendors
{
    public partial class VendorAttributeModel : BaseQNetEntityModel
    {
        public VendorAttributeModel()
        {
            Values = new List<VendorAttributeValueModel>();
        }

        public string Name { get; set; }

        public bool IsRequired { get; set; }

        /// <summary>
        /// Default value for textboxes
        /// </summary>
        public string DefaultValue { get; set; }

        public AttributeControlType AttributeControlType { get; set; }

        public IList<VendorAttributeValueModel> Values { get; set; }

    }

    public partial class VendorAttributeValueModel : BaseQNetEntityModel
    {
        public string Name { get; set; }

        public bool IsPreSelected { get; set; }
    }
}