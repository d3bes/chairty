using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace charityMVC.Models
{
    public class Roles
    {
        [Key]
        public string id { get; set; }

        public string Role { get; set; }
    }
}