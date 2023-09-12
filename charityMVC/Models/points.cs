using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace charityMVC.Models
{
    public class points
    {
         public int Id { get; set; }

        [DefaultValue(5)]
         public int children_count_1  { get; set; }

        [DefaultValue(10)]
         public int children_count_2  { get; set; }

        [DefaultValue(15)]
         public int children_count_3  { get; set; }

        [DefaultValue(20)]
         public int children_count_4  { get; set; }

        [DefaultValue(20)]
         public int children_count_4p  { get; set; }

        [DefaultValue(10)]
         public int hasNo_income_support { get; set; }
        [DefaultValue(20)]
         public int has_disability { get; set; }

        [DefaultValue(10)]
         public int widow { get; set; }

        [DefaultValue(20)]
         public int elderly { get; set; }
        [DefaultValue(10)]
         public int has_debt { get; set; }
        [DefaultValue(10)]
         public int house_is_rent { get; set; }

         public float pointValue { get; set; }


    }
}