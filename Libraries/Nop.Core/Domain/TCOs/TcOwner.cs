using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Orders;
using Nop.Core.Domain.Payments;
using System;
using System.Collections.Generic;

namespace Nop.Core.Domain.TCOs
{
    public partial class TcOwner : BaseEntity
    {
        public TcOwner()
        {
            OrderHeader = new HashSet<OrderHeader>();
            PaymentHeader = new HashSet<PaymentHeader>();
            TcoAddress = new HashSet<TcoAddress>();
            TcoAttribute = new HashSet<TcoAttribute>();
        }

        public string Tco { get; set; }
        public bool Tcostatus { get; set; }
        public string Nature { get; set; }
        public string ValidIdType { get; set; }
        public string ValidId { get; set; }
        public string Email { get; set; }
        public string Email2 { get; set; }
        public string NatCode { get; set; }
        public string Gender { get; set; }
        public DateTime? BirthDate { get; set; }
        public string CivilStat { get; set; }
        public string SpouseName { get; set; }
        public DateTime? SpouseBirthdate { get; set; }
        public string Referrer { get; set; }
        public DateTime? DateApplied { get; set; }
        public string AuditBy { get; set; }
        public string Mlname { get; set; }
        public decimal OnAcctAmount { get; set; }
        public DateTime? DateChanged { get; set; }
        public DateTime? DateDeleted { get; set; }
        public string ChangedBy { get; set; }
        public short MaxExtension { get; set; }
        public string Fname { get; set; }
        public string ShipContactName { get; set; }
        public string ShipEmailAddr { get; set; }
        public int? Tcoclass { get; set; }
        public bool IsMigrated { get; set; }
        public int InnerLock { get; set; }
        public bool Activated { get; set; }
        public DateTime? DateActivated { get; set; }
        public int ActDlno { get; set; }
        public short Rank { get; set; }
        public string UniReferrer { get; set; }
        public bool IsF2allowed { get; set; }
        public DateTime? NextRegRenewalDate { get; set; }
        public DateTime? FirstFridayAfterRegExpire { get; set; }
        public string Tcoalias { get; set; }
        public bool IsQ2allowed { get; set; }
        public bool Q2rank { get; set; }
        public bool QplusPaidAsRank { get; set; }
        public bool QplusAdvancementRank { get; set; }
        public bool AdvancementRank { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime UpdatedOnUtc { get; set; }

        public virtual TconameCorporate TconameCorporate { get; set; }
        public virtual TconameIndividual TconameIndividual { get; set; }
        public virtual ICollection<OrderHeader> OrderHeader { get; set; }
        public virtual ICollection<PaymentHeader> PaymentHeader { get; set; }
        public virtual ICollection<TcoAddress> TcoAddress { get; set; }
        public virtual ICollection<TcoAttribute> TcoAttribute { get; set; }
        public virtual Customer Customer { get; set; }
        public int? CustomerId { get; set; }
    }
}