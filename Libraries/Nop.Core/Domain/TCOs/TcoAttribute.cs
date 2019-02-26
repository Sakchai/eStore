using System;
using System.Collections.Generic;

namespace Nop.Core.Domain.TCOs
{
    public partial class TcoAttribute : BaseEntity
    {
        public int TcownerId { get; set; }
        public string Tco { get; set; }
        public int AttributeCode { get; set; }
        public decimal? NumericValue { get; set; }
        public string TextValue { get; set; }
        public string Remarks { get; set; }
        public string CreatedBy { get; set; }
        public string Irvalue { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime UpdatedOnUtc { get; set; }

        public virtual TcOwner Tcowner { get; set; }
    }
}