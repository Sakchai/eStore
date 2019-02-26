using Nop.Core.Domain.Catalog;
using System;
using System.Collections.Generic;

namespace Nop.Core.Domain.Orders
{
    public partial class OrderDetail : BaseEntity
    {
        public int? OrderHeaderId { get; set; }
        public int? ProductId { get; set; }
        public string OrderNo { get; set; }
        public int ItemId { get; set; }
        public int ItemNo { get; set; }
        public string Tco { get; set; }
        public string Tcext { get; set; }
        public string TcsubExt { get; set; }
        public decimal? OrderItemNo { get; set; }
        public decimal FullPrice { get; set; }
        public decimal? FullDiscPrice { get; set; }
        public decimal PartialPrice { get; set; }
        public decimal? PartialDiscPrice { get; set; }
        public decimal ShipFee { get; set; }
        public int? NoOfPayments { get; set; }
        public decimal? FirstPayment { get; set; }
        public decimal? NextPayment { get; set; }
        public byte? OrderStatus { get; set; }
        public byte OrderQty { get; set; }
        public string WaiveShipFee { get; set; }
        public decimal PromoId { get; set; }
        public byte? AutoDebitCc { get; set; }
        public decimal? FullAmt { get; set; }
        public decimal? RemainBalAmt { get; set; }
        public int? Tctype { get; set; }
        public int? ProdGrp { get; set; }
        public string Note { get; set; }
        public byte IsFixed { get; set; }
        public decimal? Uv { get; set; }
        public int Bvol { get; set; }
        public int? PriceSchemeId { get; set; }
        public int? ServiceId { get; set; }
        public string ProdCode { get; set; }
        public string SubProdCode { get; set; }
        public int? ComboPriceSchemeId { get; set; }
        public string ComboProdCode { get; set; }
        public decimal? EarnedQuv { get; set; }
        public decimal QplusBv { get; set; }
        public decimal Point { get; set; }
        public decimal? SapfullPrice { get; set; }
        public decimal? Rsp { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime UpdatedOnUtc { get; set; }

        public virtual OrderAttribute IdNavigation { get; set; }
        public virtual OrderHeader OrderHeader { get; set; }
        public virtual ProductQ Product { get; set; }
    }
}