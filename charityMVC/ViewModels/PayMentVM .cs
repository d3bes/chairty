using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using charityMVC.Models;

namespace charityMVC.ViewModels
{
    public class PayMentVM
    {
        public int Id { get; set; }
        public int acceptedsCount { get; set; }
        public int pointsCount { get; set; }
        public float pointValue { get; set; }
        public DateTime createDate { get; set; }
        public List<Accepted> accepteds { get; set; }

    }
}