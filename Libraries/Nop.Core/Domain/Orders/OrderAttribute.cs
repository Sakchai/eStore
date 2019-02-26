using System;
using System.Collections.Generic;

namespace Nop.Core.Domain.Orders
{
    public partial class OrderAttribute
    {
        public int Id { get; set; }
        public int? OrderDetailId { get; set; }
        public string OrderNo { get; set; }
        public int ItemNo { get; set; }
        public int AttributeCode { get; set; }
        public decimal? NumericValue { get; set; }
        public string TextValue { get; set; }
        public string Remarks { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime UpdatedOnUtc { get; set; }

        public virtual OrderDetail OrderDetail { get; set; }
    }
}