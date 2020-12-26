using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BANQ_MS.Models
{
    public partial class BanqProgram
    {
        public BanqProgram()
        {
            BanqProgramAmenity = new HashSet<BanqProgramAmenity>();
            BanqProgramFood = new HashSet<BanqProgramFood>();
        }

        public int Id { get; set; }
        public int BanqId { get; set; }
        public int CustomerId { get; set; }
        public int? EventMngrId { get; set; }
        public string ProgramName { get; set; }
        public DateTime ProgramDate { get; set; }
        public DateTime? StartTime { get; set; }
        public int NoOfPerson { get; set; }
        public decimal FoodAmount { get; set; }
        public decimal AmenityAmount { get; set; }
        public decimal HallRent { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal TotalVat { get; set; }
        public decimal TotalServiceCharge { get; set; }
        public decimal TotalPayable { get; set; }
        public decimal TotalPaid { get; set; }
        public decimal DueAmount { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string Note { get; set; }
        public string Status { get; set; }

        [NotMapped]
        public string DeletedFoodItemIds { get; set; }
        [NotMapped]
        public string DeletedAmenityItemIds { get; set; }

        public virtual BanqInfo Banq { get; set; }
        public virtual BanqEventManager EventMngr { get; set; }
        public virtual ICollection<BanqProgramAmenity> BanqProgramAmenity { get; set; }
        public virtual ICollection<BanqProgramFood> BanqProgramFood { get; set; }
    }
}
