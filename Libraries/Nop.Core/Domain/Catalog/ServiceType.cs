using System;
using System.Collections.Generic;

namespace Nop.Core.Domain.Catalog
{
    public partial class ServiceType : BaseEntity
    {
        public ServiceType()
        {
            Service = new HashSet<Service>();
        }

        public string Description { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime UpdatedOnUtc { get; set; }

        public virtual ICollection<Service> Service { get; set; }
    }
}