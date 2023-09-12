using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace charityMVC.ViewModels
{
    public class MemberAccount
    {
         [Required(ErrorMessage = "ادخل الهوية")]
        public string username { get; set; }

        [Required(ErrorMessage ="ادخل كلمة المرور")]
        public string password { get; set; }
    }
}