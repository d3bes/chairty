using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CsvHelper.Configuration.Attributes;

namespace charityMVC.Models
{
    public class smsValidation
    {
        [Key]
        public int Id { get; set; }
        public string userId { get; set; }
        public int ValidationCode { get; set; }
        // [DefaultValue(false)]
        // public bool IsValid { get; set; }
    }
}