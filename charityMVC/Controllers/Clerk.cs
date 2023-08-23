using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using charityMVC.ViewModels;
using Microsoft.Extensions.Logging;

namespace charityMVC.Controllers
{
    [Route("[controller]/[action]")]
    public class Clerk : Controller
    {
        private readonly ILogger<Clerk> _logger;
        List<UserVM> cityUsers = new List<UserVM>()
            {
                new UserVM { fullName = "John Doe", id = "123", phone = "555-1234", birthDate = "1990-01-01", points = 100 },
                new UserVM { fullName = "Jane Smith", id = "456", phone = "555-5678", birthDate = "1985-05-10", points = 150 },
                new UserVM { fullName = "Alice Johnson", id = "789", phone = "555-9876", birthDate = "1995-08-20", points = 75 },
                new UserVM { fullName = "Bob Brown", id = "101", phone = "555-5555", birthDate = "1988-03-15", points = 200 },
                new UserVM { fullName = "Emily White", id = "202", phone = "555-2222", birthDate = "1992-11-30", points = 50 },
                new UserVM { fullName = "Michael Lee", id = "303", phone = "555-9999", birthDate = "1979-07-05", points = 300 },
                new UserVM { fullName = "Sophia Williams", id = "404", phone = "555-4444", birthDate = "2000-09-25", points = 125 },
                new UserVM { fullName = "William Johnson", id = "505", phone = "555-7777", birthDate = "1982-12-18", points = 90 },
                new UserVM { fullName = "Olivia Brown", id = "606", phone = "555-8888", birthDate = "1998-06-08", points = 180 },
                new UserVM { fullName = "Liam Davis", id = "707", phone = "555-6666", birthDate = "1975-04-02", points = 220 }
          

            };
        public Clerk(ILogger<Clerk> logger)
        {
            _logger = logger;
        }

        public IActionResult profile()
        {
            return View("userProfile");
        }

        public IActionResult GetCityUsers()
        {

            return View("cityUsers", cityUsers);
        }

        public IActionResult Review(string id)
        {
            var user = cityUsers.FirstOrDefault(u=> u.id == id);

            return View("review",user);
        }

    }

 
}