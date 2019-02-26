using System;
using System.Collections.Generic;

namespace Nop.Core.Domain.Payments
{
    public partial class PaymentDetail : BaseEntity
    {
        public PaymentDetail()
        {
            PaymentDetailMode = new HashSet<PaymentDetailMode>();
        }

        public int? PaymentHeaderId { get; set; }
        public string ReceiptNo { get; set; }
        public string OrderNo { get; set; }
        public int? ItemNo { get; set; }
        public string Tcext { get; set; }
        public string TcsubExt { get; set; }
        public string ProdCode { get; set; }
        public string SubProdCode { get; set; }
        public decimal? FullPrice { get; set; }
        public decimal? FullDiscPrice { get; set; }
        public decimal? PartialPrice { get; set; }
        public decimal? PartialDiscPrice { get; set; }
        public decimal? ShipFee { get; set; }
        public string PaymentMode { get; set; }
        public decimal? TotalAmount { get; set; }
        public decimal? BalanceAmount { get; set; }
        public decimal? PayAmount { get; set; }
        public decimal? UspayAmount { get; set; }
        public string PayAccount { get; set; }
        public string PayRefNo { get; set; }
        public DateTime? PayModeDate { get; set; }
        public string PayBank { get; set; }
        public string PayOtherInfo { get; set; }
        public byte? OrderQty { get; set; }
        public byte? WaiveShipFee { get; set; }
        public int? PayType { get; set; }
        public decimal? EarnedUv { get; set; }
        public int EarnedBvol { get; set; }
        public decimal? ExRate { get; set; }
        public int? PriceSchemeId { get; set; }
        public int? ServiceId { get; set; }
        public string ProdCodeBk { get; set; }
        public decimal? EarnedQuv { get; set; }
        public decimal EarnedQplusBv { get; set; }
        public decimal Point { get; set; }
        public int? ItemId { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime UpdatedOnUtc { get; set; }

        public virtual PaymentHeader PaymentHeader { get; set; }
        public virtual ICollection<PaymentDetailMode> PaymentDetailMode { get; set; }
    }
}