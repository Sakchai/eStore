using System;
using System.Collections.Generic;

namespace Nop.Core.Domain.Payments
{
    public partial class PaymentDetailMode : BaseEntity
    {
        public int? PaymentDetailId { get; set; }
        public string ReceiptNo { get; set; }
        public string OrderNo { get; set; }
        public string Tcext { get; set; }
        public string TcsubExt { get; set; }
        public decimal PayLineNo { get; set; }
        public string PaymentMode { get; set; }
        public decimal? PayAmount { get; set; }
        public decimal? UspayAmount { get; set; }
        public string PayAccount { get; set; }
        public string PayRefNo { get; set; }
        public DateTime? PayRefDate { get; set; }
        public string PayBankType { get; set; }
        public string PayOtherInfo { get; set; }
        public string PayRoute { get; set; }
        public string Notes { get; set; }
        public decimal Point { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime UpdatedOnUtc { get; set; }

        public virtual PaymentDetail PaymentDetail { get; set; }
    }
}