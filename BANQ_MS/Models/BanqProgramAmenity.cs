using System;
using System.Collections.Generic;

namespace BANQ_MS.Models
{
    public partial class BanqProgramAmenity
    {
        public int Id { get; set; }
        public int? BanqProId { get; set; }
        public int? AmenityId { get; set; }
        public int? Quantity { get; set; }

        public virtual BanqAmenity Amenity { get; set; }
        public virtual BanqProgram BanqPro { get; set; }
    }
}
