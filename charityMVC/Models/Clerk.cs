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
        [Required(ErrorMessage = "ادخل الاسم")]
        public string name { get; set; }
         [Required(ErrorMessage = "ادخل المدينة")]
        public string city { get; set; }
        [RegularExpression(@"^\d{9}$", ErrorMessage = "يجب ان يكون رقم الهاتف 9 ارقام")]
        public string phone { get; set; }
         [Required(ErrorMessage = "ادخل كلمة المرور")]
        public string password { get; set; }

        [DefaultValue(false)]
        public bool isDeleted { get; set; }
        // public List<User> users { get; set; }


        
    }
}