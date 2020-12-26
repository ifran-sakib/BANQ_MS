using System;
using System.Collections.Generic;

namespace BANQ_MS.Models
{
    public partial class BanqFood
    {
        public BanqFood()
        {
            BanqProgramFood = new HashSet<BanqProgramFood>();
        }

        public int Id { get; set; }
        public string FoodName { get; set; }
        public string FoodNo { get; set; }
        public string Description { get; set; }
        public bool IsAvail { get; set; }
        public decimal Price { get; set; }
        public int FoodCategoryId { get; set; }

        public virtual BanqFoodCategory FoodCategory { get; set; }
        public virtual ICollection<BanqProgramFood> BanqProgramFood { get; set; }
    }
}
