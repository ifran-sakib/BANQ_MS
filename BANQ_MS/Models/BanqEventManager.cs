using System;
using System.Collections.Generic;

namespace BANQ_MS.Models
{
    public partial class BanqEventManager
    {
        public BanqEventManager()
        {
            BanqProgram = new HashSet<BanqProgram>();
        }

        public int Id { get; set; }
        public string EventOrganizerName { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public string Address { get; set; }

        public virtual ICollection<BanqProgram> BanqProgram { get; set; }
    }
}
