using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;


namespace charityMVC.Models
{
    public class Accepted
    {
        [Key]
        public int Id { get; set; }
        public string name { get; set; }
        public string city { get; set; }
        public string fullAddress { get; set; }
        public string phone { get; set; }

        public string userId { get; set; }
        
        [DefaultValue(false)]
        public bool isApproved { get; set;}
        public DateTime dateTime { get; set; }
        public int points { get; set; }
           [DefaultValue(false)]
        public bool isDeleted {get;set;}

    }
}