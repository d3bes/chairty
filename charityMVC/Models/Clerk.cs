using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace charityMVC.Models
{
    public class Clerk
    {
        [Key]
        public int Id { get; set; }
        public string name { get; set; }
        public string city { get; set; }
        public string phone { get; set; }
        public string password { get; set; }

        [DefaultValue(false)]
        public bool isDeleted { get; set; }
        // public List<User> users { get; set; }


        
    }
}