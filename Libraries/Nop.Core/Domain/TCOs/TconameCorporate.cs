using System;
using System.Collections.Generic;

namespace Nop.Core.Domain.TCOs
{
    public partial class TconameCorporate : BaseEntity
    {
        public string Tco { get; set; }
        public string CompanyName { get; set; }
        public string CheckName { get; set; }
        public string BusinessType { get; set; }
        public string ContactPerson { get; set; }
        public string TitleContactPerson { get; set; }
        public string ContactPosition { get; set; }
        public string ContactPositionOther { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime UpdatedOnUtc { get; set; }

        public virtual TcOwner IdNavigation { get; set; }
    }
}