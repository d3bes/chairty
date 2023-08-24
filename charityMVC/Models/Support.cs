using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace charityMVC.Models
{
    public class Support
    {
   public int SupportId { get; set; }
    public decimal? Amount { get; set; }

    public DateTime RequestDate { get; set; }
    public DateTime? ApprovalDate { get; set; } // Date when support was approved
    public bool? IsApproved { get; set; }

    public string? Description { get; set; } // Details about the support request

    public string? DocumentUrl { get; set; } // URL to any supporting documents

     [ForeignKey("User")]
    public int UserId { get; set; }
    public virtual User User { get; set; }

    }
}