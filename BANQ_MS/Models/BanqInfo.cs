using System;
using System.Collections.Generic;

namespace BANQ_MS.Models
{
    public partial class BanqInfo
    {
        public BanqInfo()
        {
            BanqProgram = new HashSet<BanqProgram>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public decimal Rent { get; set; }
        public int MinimumGuest { get; set; }
        public int MaximumGuest { get; set; }
        public int BanqTypeId { get; set; }
        public bool IsAvail { get; set; }
        public decimal? VatPer { get; set; }
        public decimal? ScPer { get; set; }

        public virtual BanqType BanqType { get; set; }
        public virtual ICollection<BanqProgram> BanqProgram { get; set; }
    }
}
