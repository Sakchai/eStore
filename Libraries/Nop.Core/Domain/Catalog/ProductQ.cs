using Nop.Core.Domain.Orders;
using Nop.Core.Domain.Prices;
using System;
using System.Collections.Generic;

namespace Nop.Core.Domain.Catalog
{
    public partial class ProductQ : BaseEntity
    {
        public ProductQ()
        {
            OrderDetail = new HashSet<OrderDetail>();
            PriceProduct = new HashSet<PriceProduct>();
            PricePromo = new HashSet<PricePromo>();
            PriceScheme = new HashSet<PriceScheme>();
            ProductAttribute = new HashSet<ProductAttribute>();
            ProductCategoryDetail = new HashSet<ProductCategoryDetail>();
            ProductRestriction = new HashSet<ProductRestriction>();
            Service = new HashSet<Service>();
        }

        public string ProdCode { get; set; }
        public string ProdName { get; set; }
        public string ProdDesc { get; set; }
        public int CompanyId { get; set; }
        public byte ItemTypeId { get; set; }
        public int SellingMargin { get; set; }
        public int ConsumedQty { get; set; }
        public int AvailableQty { get; set; }
        public int Threshold { get; set; }
        public bool AllowBackOrder { get; set; }
        public string ProdLink { get; set; }
        public string ImageFileName { get; set; }
        public byte IsShipRequired { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime RevisionDate { get; set; }
        public string UpdatedBy { get; set; }
        public int Available { get; set; }
        public byte IsAlertOn { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime UpdatedOnUtc { get; set; }

        public virtual ICollection<OrderDetail> OrderDetail { get; set; }
        public virtual ICollection<PriceProduct> PriceProduct { get; set; }
        public virtual ICollection<PricePromo> PricePromo { get; set; }
        public virtual ICollection<PriceScheme> PriceScheme { get; set; }
        public virtual ICollection<ProductAttribute> ProductAttribute { get; set; }
        public virtual ICollection<ProductCategoryDetail> ProductCategoryDetail { get; set; }
        public virtual ICollection<ProductRestriction> ProductRestriction { get; set; }
        public virtual ICollection<Service> Service { get; set; }
    }
}