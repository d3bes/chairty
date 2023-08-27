
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace charityMVC.ViewModels
{
    public class PersonalData
    {
        public string id {get; set; }
        
        [Required(ErrorMessage = "ادخل الاسم كاملا")]
        public string fullName { get; set;}
        [RegularExpression(@"^\d{10}$", ErrorMessage = "يجب ان يكون رقم الهاتف 10 ارقام")]
        public string? phone { get; set;}
        public string? birthDate { get; set;}
        public string? city { get; set;}
        [Required(ErrorMessage = "العنوان مطلوب")]
        public string? fullAddress { get; set;}
        public string? bank_account_number { get; set;}
        public int? children_count { get; set;}
        public bool? widow { get; set;}
        public bool? elderly { get; set;}
        public bool? income_support { get; set;}
         public int? points { get; set;}
        public bool? proxy { get; set;}

        public string? _proxy_name { get; set;}
        [RegularExpression(@"^\d{16}$", ErrorMessage = "يجب ان يكون رقم الحساب 16 رقم")]
        public string? _proxy_account_number { get; set;}
    }
}