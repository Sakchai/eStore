using System;
using System.Collections.Generic;

namespace Nop.Core.Domain.TCOs
{
    public partial class TcoAddress : BaseEntity
    {
        public int TcownerId { get; set; }
        public string Tco { get; set; }
        public string AddrType { get; set; }
        public string Addr1 { get; set; }
        public string Addr2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string CountryCode { get; set; }
        public string ZipCode { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime UpdatedOnUtc { get; set; }

        public virtual TcOwner TcOwner { get; set; }
    }
}