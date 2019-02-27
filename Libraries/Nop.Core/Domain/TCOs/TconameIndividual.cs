using System;
using System.Collections.Generic;

namespace Nop.Core.Domain.TCOs
{
    public partial class TconameIndividual : BaseEntity
    {
        public string Tco { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string CheckName { get; set; }
        public string MotherMaiden { get; set; }
        public string FullName { get; set; }
        public string GuardianName { get; set; }
        public string GuardianAddress { get; set; }
        public string GuardianContactNo { get; set; }
        public string GuardianBirthDate { get; set; }
        public string Title { get; set; }
        public string Occupation { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime UpdatedOnUtc { get; set; }

        public virtual TcOwner TcOwner { get; set; }
    }
}