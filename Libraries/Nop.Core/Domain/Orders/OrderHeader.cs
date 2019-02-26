using Nop.Core.Domain.TCOs;
using System;
using System.Collections.Generic;

namespace Nop.Core.Domain.Orders
{
    public partial class OrderHeader : BaseEntity
    {
        public OrderHeader()
        {
            OrderDetail = new HashSet<OrderDetail>();
        }

        public string OrderNo { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public int? TcOwnerId { get; set; }
        public string Tco { get; set; }
        public string RepOffCode { get; set; }
        public string Tconame { get; set; }
        public string UserId { get; set; }
        public DateTime DateEncoded { get; set; }
        public byte OrderStatus { get; set; }
        public string Authorizedby { get; set; }
        public string TransactionOrderId { get; set; }
        public string GatewayTransactionNo { get; set; }
        public string GatewayAuthNumber { get; set; }
        public string Currency { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime UpdatedOnUtc { get; set; }

        public virtual TcOwner TcOwner { get; set; }
        public virtual ICollection<OrderDetail> OrderDetail { get; set; }
    }
}