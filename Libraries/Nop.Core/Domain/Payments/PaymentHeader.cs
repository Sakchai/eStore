using Nop.Core.Domain.TCOs;
using System;
using System.Collections.Generic;

namespace Nop.Core.Domain.Payments
{
    public partial class PaymentHeader : BaseEntity
    {
        public PaymentHeader()
        {
            PaymentAttribute = new HashSet<PaymentAttribute>();
            PaymentDetail = new HashSet<PaymentDetail>();
        }

        public string ReceiptNo { get; set; }
        public string OrderNo { get; set; }
        public DateTime? ReceiptDate { get; set; }
        public string ReceivedBy { get; set; }
        public string RepOffCode { get; set; }
        public string Tconame { get; set; }
        public string PaidStatus { get; set; }
        public decimal TranFee { get; set; }
        public string Currency { get; set; }
        public int? Status { get; set; }
        public byte SentEmail { get; set; }
        public string Tco { get; set; }
        public int? TcownerId { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime UpdatedOnUtc { get; set; }

        public virtual TcOwner TcOwner { get; set; }
        public virtual ICollection<PaymentAttribute> PaymentAttribute { get; set; }
        public virtual ICollection<PaymentDetail> PaymentDetail { get; set; }
    }
}