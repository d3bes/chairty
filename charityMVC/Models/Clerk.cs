using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace charityMVC.Models
{
    public class Clerk
    {
        public string id { get; set; }
        public string name { get; set; }
        public string city { get; set; }
        public string password { get; set; }
        public bool isDeleted { get; set; }
    }
}