using System;
using System.Collections.Generic;

namespace Nop.Core.Domain.Prices
{
    public partial class PriceSchemeAttributes
    {
        public int Id { get; set; }
        public int? PriceSchemeId { get; set; }
        public int? AttributeCode { get; set; }
        public decimal? NumericValue { get; set; }
        public string TextValue { get; set; }
        public string Remarks { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreatedOnUtc { get; set; }

        public virtual PriceScheme PriceScheme { get; set; }
    }
}