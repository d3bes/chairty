using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using charityMVC.Models;

namespace charityMVC.ViewModels
{
    public class ClerkProfileVM
    {
        public List<User> Users { get; set; }
        public Clerk clerk { get; set; }
    }
}