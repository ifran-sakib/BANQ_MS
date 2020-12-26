using System;
using System.Collections.Generic;

namespace BANQ_MS.Models
{
    public partial class BanqCustomer
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public string Nid { get; set; }
        public string Adress { get; set; }
    }
}
