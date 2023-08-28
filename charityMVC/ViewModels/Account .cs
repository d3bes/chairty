using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace charityMVC.ViewModels
{
    public class Account 
    {
        
        [RegularExpression(@"^\d{16}$", ErrorMessage = "يجب ان يكون رقم الهوية 16 رقم")]
        public string id { get; set; }

        [RegularExpression(@"^\d{10}$", ErrorMessage = "يجب ان يكون رقم الهاتف 10 ارقام")]
        public string password { get; set; }
    }
}