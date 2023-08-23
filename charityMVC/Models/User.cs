using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace charityMVC.Models
{
    public class User
    {
        public string fullName { get; set;}
        public string id { get;set;}
        public string phone { get; set;}
        public string birthDate { get; set;}
        public int points { get; set;}
        public string city { get; set;}
        public string id_image { get; set;}
        public string family_card_image { get; set;}
        public string bank_account_number { get; set;}
        public int children_count { get; set;}
        public bool income_support { get; set;}
        public bool disability { get; set;}
        public string disability_proof { get; set;}
        public bool widow { get; set;}
        public bool elderly { get; set;}

        public bool debt { get; set;}
        public string debt_proof { get; set;}
        public bool house_rent { get; set;}
        public string rent_proof { get; set;}
        public bool proxy { get; set;}
        public string proxy_name { get; set;}
        public string proxy_account_number { get; set;}











    }
}