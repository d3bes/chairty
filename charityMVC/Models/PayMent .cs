using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace charityMVC.Models
{
    public class PayMent 
    {
        
        public string Id { get; set; }
        public int acceptedsCount { get; set; }
        public float pointsCount { get; set; }
        public float pointValue { get; set; }
        public DateTime createDate { get; set; }
        public float income { get; set; }
      //  public List<Accepted>? accepteds { get; set; }
    }
}