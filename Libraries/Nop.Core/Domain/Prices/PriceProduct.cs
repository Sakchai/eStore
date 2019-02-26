using Nop.Core.Domain.Catalog;
using System;
using System.Collections.Generic;

namespace Nop.Core.Domain.Prices
{
    public partial class PriceProduct
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public string ProdCode { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal FullPrice { get; set; }
        public decimal PartialPrice { get; set; }
        public decimal ShipFee { get; set; }
        public short Cvpoints { get; set; }
        public decimal Opprice { get; set; }
        public decimal OpshipFee { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime UpdatedOnUtc { get; set; }

        public virtual ProductQ Product { get; set; }
    }
}