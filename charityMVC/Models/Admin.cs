using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace charityMVC.Models
{
    public class Admin
    {
        public string id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public bool isDeleted { get; set; }
        public bool isSuperAdmin { get; set;}


    }
}