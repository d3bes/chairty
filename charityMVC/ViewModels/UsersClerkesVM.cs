using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using charityMVC.Models;

namespace charityMVC.ViewModels
{
    public class UsersClerkesVM
    {
        public List<User> users { get; set; }
        public List<Clerk> clerkes { get; set; }
    }
}