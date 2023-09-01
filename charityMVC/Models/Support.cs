using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace charityMVC.Models
{
    public class Support
    {
    [Key]
    public int Id { get; set; }
     public string userId { get; set; }

    public string name { get; set; }
    public string city { get; set; }
    public string fullAddress { get; set; }
    public string phone { get; set; }

    public decimal? Amount { get; set; }

    public DateTime? ApprovalDate { get; set; } // Date when support was approved
    
    [DefaultValue(false)]
    public bool isApproved { get; set;}
    public int points { get; set; }
        
    [DefaultValue(false)]
     public bool isDeleted {get;set;}

        public static implicit operator List<object>(Support v)
        {
            throw new NotImplementedException();
        }

        // public string? Description { get; set; } // Details about the support request

        // public string? DocumentUrl { get; set; } // URL to any supporting documents



        // [ForeignKey("User")]
        // public virtual User? User { get; set; }







    }
}