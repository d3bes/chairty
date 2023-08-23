using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace charityMVC.Controllers
{
    [Route("[controller]/[action]")]
    public class UserProfile : Controller
    {
        private readonly ILogger<UserProfile> _logger;

        public UserProfile(ILogger<UserProfile> logger)
        {
            _logger = logger;
        }

        public IActionResult GetUserProfile()
        {
            return View("userProfile");
        }

    }
}