﻿using QNet.Web.Framework.Models;

namespace QNet.Web.Models.Catalog
{
    /// <summary>
    /// Specification attribute model
    /// </summary>
    public partial class ProductSpecificationModel : BaseQNetModel
    {
        /// <summary>
        /// Specificartion attribute ID
        /// </summary>
        public int SpecificationAttributeId { get; set; }

        /// <summary>
        /// Specificartion attribute name
        /// </summary>
        public string SpecificationAttributeName { get; set; }

        /// <summary>
        /// Option value
        /// this value is already HTML encoded
        /// </summary>
        public string ValueRaw { get; set; }

        /// <summary>
        /// Option color (if specified). Used to display color squares
        /// </summary>
        public string ColorSquaresRgb { get; set; }

        /// <summary>
        /// Attribyte type ID
        /// </summary>
        public int AttributeTypeId { get; set; }
    }
}