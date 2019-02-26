using Nop.Core.Domain.Catalog;
using System;
using System.Collections.Generic;

namespace Nop.Core.Domain.Prices
{
    public partial class PriceScheme
    {
        public PriceScheme()
        {
            PriceRestriction = new HashSet<PriceRestriction>();
            PriceSchemeAttributes = new HashSet<PriceSchemeAttributes>();
        }

        public int Id { get; set; }
        public string PriceSchemeName { get; set; }
        public int CustomerTypeId { get; set; }
        public int PricePlanId { get; set; }
        public int? ProductId { get; set; }
        public string ProdCode { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Currency { get; set; }
        public decimal FullPrice { get; set; }
        public decimal PartialPrice { get; set; }
        public decimal Cuv { get; set; }
        public decimal Quv { get; set; }
        public decimal Bv { get; set; }
        public decimal CyclePoints { get; set; }
        public int StartQty { get; set; }
        public int EndQty { get; set; }
        public int NoOfPayment { get; set; }
        public decimal FirstPayment { get; set; }
        public decimal NextPayment { get; set; }
        public DateTime CreationDate { get; set; }
        public string UpdatedBy { get; set; }
        public decimal ShipFee { get; set; }
        public string CProdCode { get; set; }
        public int? CPriceSchemeId { get; set; }
        public decimal QplusBv { get; set; }
        public decimal Dsp { get; set; }
        public decimal? RegularPrice { get; set; }
        public decimal? Rcuv { get; set; }
        public decimal? Qcuv { get; set; }
        public decimal? RegularVolume { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime UpdatedOnUtc { get; set; }

        public virtual ProductQ Product { get; set; }
        public virtual ICollection<PriceRestriction> PriceRestriction { get; set; }
        public virtual ICollection<PriceSchemeAttributes> PriceSchemeAttributes { get; set; }
    }
}