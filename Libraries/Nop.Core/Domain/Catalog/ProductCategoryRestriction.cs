using System;
using System.Collections.Generic;

namespace Nop.Core.Domain.Catalog
{
    public partial class ProductCategoryRestriction : BaseEntity
    {
        public string AppName { get; set; }
        public string AppType { get; set; }
        public int CategoryId { get; set; }
        public string ShoppingCartFilter { get; set; }
        public string ControlType { get; set; }
        public string ControlParentCategoryId { get; set; }
        public string CombineCategoryGroup { get; set; }
        public bool IsVisible { get; set; }
        public int SortId { get; set; }
        public bool IsEnabled { get; set; }
        public string UpdatedBy { get; set; }
        public string Remark { get; set; }
        public string Description { get; set; }
        public int? ShowProductOnPage { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime UpdatedOnUtc { get; set; }

        public virtual ProductCategory Category { get; set; }
    }
}