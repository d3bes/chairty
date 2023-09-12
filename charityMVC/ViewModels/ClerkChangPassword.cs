using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace charityMVC.ViewModels
{
    public class ClerkChangPassword
    {
   
        [Required]
        public string oldPassword { get; set; }
        [Required]
        public string newPassword { get; set;}
        [Required]

        public string userName { get; set; }
   

        public string NewUserName { get; set; }

    }
}