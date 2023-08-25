using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace charityMVC.Models
{
    public class User
    {
        [Key]
        public string id { get;set;}
        public string fullName { get; set;}
        public string? phone { get; set;}
        public string? birthDate { get; set;}
        public int? points { get; set;}
        public string? city { get; set;}
        public string? fullAddress { get; set;}
        public string? id_image { get; set;}
        public string? family_card_image { get; set;}
        public string? bank_account_number { get; set;}
        public int? children_count { get; set;}
        public bool? income_support { get; set;}
        public string? income_supportImg { get; set;}
        public bool? disability { get; set;}
        public string? disability_proof { get; set;}
        public bool? widow { get; set;}
        public bool? elderly { get; set;}

        public bool? debt { get; set;}
        public string? debt_proof { get; set;}
        public bool? house_rent { get; set;}
        public string? rent_proof { get; set;}
        public bool? proxy { get; set;}
        public string? proxy_name { get; set;}
        public string? proxy_account_number { get; set;}
        
        [DefaultValue(false)]
        public bool isDeleted {get;set;}

        // [ForeignKey("support")]
        // public string supportId { get; set;}
        // public Support support { get; set;}


    // [ForeignKey("clerk")]
        // public string clerkId { get; set;}

        // public Clerk clerk { get; set;}










    }
}