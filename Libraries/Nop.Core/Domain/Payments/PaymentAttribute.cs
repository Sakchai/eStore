using System;
using System.Collections.Generic;

namespace Nop.Core.Domain.Payments
{
    public partial class PaymentAttribute : BaseEntity
    {
        public int? PaymentHeaderId { get; set; }
        public int? PaymentAttributeTypeId { get; set; }
        public string ReceiptNo { get; set; }
        public int AttributeCode { get; set; }
        public decimal? NumericValue { get; set; }
        public string TextValue { get; set; }
        public string Remarks { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime UpdatedOnUtc { get; set; }

        public virtual PaymentAttributeType PaymentAttributeType { get; set; }
        public virtual PaymentHeader PaymentHeader { get; set; }
    }
}