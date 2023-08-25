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
    public string SupportId { get; set; }
    public decimal? Amount { get; set; }

    public DateTime RequestDate { get; set; }
    public DateTime? ApprovalDate { get; set; } // Date when support was approved
    public bool? IsApproved { get; set; }

    public string? Description { get; set; } // Details about the support request

    public string? DocumentUrl { get; set; } // URL to any supporting documents
    public string? username { get;set; } 
    [DefaultValue(false)]
    public bool isDeleted {get;set;}


    // [ForeignKey("User")]
    public string? UserId { get; set; }
    // public virtual User? User { get; set; }

    }
}