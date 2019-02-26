using System;
using System.Collections.Generic;

namespace Nop.Core.Domain.Catalog
{
    public partial class ProductCategoryDetail : BaseEntity
    {
        public int CategoryTypeId { get; set; }
        public int CategoryId { get; set; }
        public int? ProductId { get; set; }
        public string ProdCode { get; set; }
        public int? PricePlanId { get; set; }
        public string CountryCode { get; set; }
        public int? SortId { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime UpdatedOnUtc { get; set; }

        public virtual ProductCategory Category { get; set; }
        public virtual ProductQ Product { get; set; }
    }
}