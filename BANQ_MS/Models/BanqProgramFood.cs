using System;
using System.Collections.Generic;

namespace BANQ_MS.Models
{
    public partial class BanqProgramFood
    {
        public int Id { get; set; }
        public int BanqProId { get; set; }
        public int FoodId { get; set; }
        public int Quantity { get; set; }

        public virtual BanqProgram BanqPro { get; set; }
        public virtual BanqFood Food { get; set; }
    }
}
