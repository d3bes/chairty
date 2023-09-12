using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.ServiceModel.Channels;
using System.Threading.Tasks;

namespace charityMVC.ViewModels
{
    public class ChangPassword
    {

        [Required]
        public string oldPassword { get; set; }
        [Required]
        public string newPassword { get; set;}
        [Required]

        public string userName { get; set; }
    }
}