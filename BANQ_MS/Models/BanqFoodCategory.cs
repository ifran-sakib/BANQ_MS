using System;
using System.Collections.Generic;

namespace BANQ_MS.Models
{
    public partial class BanqFoodCategory
    {
        public BanqFoodCategory()
        {
            BanqFood = new HashSet<BanqFood>();
        }

        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public bool? IsAvail { get; set; }

        public virtual ICollection<BanqFood> BanqFood { get; set; }
    }
}
