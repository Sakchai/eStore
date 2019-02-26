using System;
using System.Collections.Generic;

namespace Nop.Core.Domain.Prices
{
    public partial class PriceRestriction
    {
        public int Id { get; set; }
        public int PriceSchemeId { get; set; }
        public string CountryCode { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime UpdatedOnUtc { get; set; }

        public virtual PriceScheme PriceScheme { get; set; }
    }
}