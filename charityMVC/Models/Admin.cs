using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace charityMVC.Models
{
    public class Admin
    {
        [Key]
        public string id { get;set;}
        public string username { get; set; }
        public string password { get; set; }
        
        [DefaultValue(false)]
        public bool isDeleted { get; set; }
        [DefaultValue(false)]
        public bool isSuperAdmin { get; set;}


    }
}