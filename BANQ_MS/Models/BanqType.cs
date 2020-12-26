using System;
using System.Collections.Generic;

namespace BANQ_MS.Models
{
    public partial class BanqType
    {
        public BanqType()
        {
            BanqInfo = new HashSet<BanqInfo>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<BanqInfo> BanqInfo { get; set; }
    }
}
