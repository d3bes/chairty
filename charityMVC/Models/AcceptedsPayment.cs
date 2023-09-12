using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace charityMVC.Models
{
    public class AcceptedsPayment
    {
        public int Id { get; set; }
        public string payMentId { get; set; }
         public string acceptedId { get; set; }
         public DateTime createdTime { get; set; }

         
    }
}