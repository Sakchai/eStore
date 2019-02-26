using Nop.Core.Domain.Catalog;
using System;
using System.Collections.Generic;

namespace Nop.Core.Domain.Prices
{
    public partial class PricePromo
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public string ProdCode { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal FullPrice { get; set; }
        public decimal PartialPrice { get; set; }
        public decimal ShipFee { get; set; }
        public string PromoDesc { get; set; }
        public short Cvpoints { get; set; }
        public bool? ProdSaleType { get; set; }
        public string CountryCode { get; set; }
        public decimal Puv { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime UpdatedOnUtc { get; set; }

        public virtual ProductQ Product { get; set; }
    }
}