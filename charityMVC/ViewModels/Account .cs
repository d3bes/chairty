using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace charityMVC.ViewModels
{
    public class Account 
    {
        
        [RegularExpression(@"^\d{10}$", ErrorMessage = "يجب ان يكون رقم الهوية 10 رقم")]
            [Required(ErrorMessage = "ادخل الهوية")]
        public string id { get; set; }

        // [RegularExpression(@"^\d{10}$", ErrorMessage = "يجب ان يكون رقم المرور 10 ارقام")]
        [Required(ErrorMessage ="ادخل كلمة المرور")]
        public string password { get; set; }

    }
}