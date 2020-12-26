using System;
using System.Collections.Generic;

namespace BANQ_MS.Models
{
    public partial class BanqAmenity
    {
        public BanqAmenity()
        {
            BanqProgramAmenity = new HashSet<BanqProgramAmenity>();
        }

        public int Id { get; set; }
        public string AmenityHead { get; set; }
        public string Details { get; set; }
        public decimal Cost { get; set; }
        public bool IsAvail { get; set; }

        public virtual ICollection<BanqProgramAmenity> BanqProgramAmenity { get; set; }
    }
}
