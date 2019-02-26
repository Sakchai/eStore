using System;
using System.Collections.Generic;

namespace Nop.Core.Domain.Catalog
{
    public partial class Service : BaseEntity
    {
        public int ServiceTypeId { get; set; }
        public int PriceSchemeId { get; set; }
        public int? ProductCountryId { get; set; }
        public string ProdCode { get; set; }
        public string CountryCode { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Currency { get; set; }
        public decimal Fee { get; set; }
        public decimal Percentage { get; set; }
        public DateTime CreationDate { get; set; }
        public string UpdatedBy { get; set; }
        public decimal? Weight { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime UpdatedOnUtc { get; set; }

        public virtual ProductQ ProductCountry { get; set; }
        public virtual ServiceType ServiceType { get; set; }
    }
}