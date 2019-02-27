using System;
using System.Collections.Generic;

namespace Nop.Core.Domain.Catalog
{
    public partial class ProductRestriction : BaseEntity
    {
        public int? ProductId { get; set; }
        public string ProdCode { get; set; }
        public bool? ProdRestrict { get; set; }
        public string RestrictCode { get; set; }
        public bool RestrictFlag { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime UpdatedOnUtc { get; set; }

        public virtual ProductQ Product { get; set; }
    }
}