using System;
using System.Collections.Generic;

namespace Nop.Core.Domain.Payments
{
    public partial class PaymentAttributeType : BaseEntity
    {
        public PaymentAttributeType()
        {
            PaymentAttribute = new HashSet<PaymentAttribute>();
        }

        public int AttributeCode { get; set; }
        public string AttributeDescription { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime UpdatedOnUtc { get; set; }

        public virtual ICollection<PaymentAttribute> PaymentAttribute { get; set; }
    }
}