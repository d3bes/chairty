using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using charityMVC.Repository;
using charityMVC.Models;

namespace charityMVC.Controllers
{
    [Route("[controller]/[action]")]
    public class UserProfile : Controller
    {
        private readonly ILogger<UserProfile> _logger;
        public IUserRepo _userRepo;
        public UserProfile(ILogger<UserProfile> logger, IUserRepo userRepo)
        {
            _logger = logger;
            _userRepo = userRepo;
        }

        public async Task<IActionResult> GetUserProfile(string id)
        {
          
            User user  = await _userRepo.GetUserById(id);

            return View("userProfile",user);
        }

    }
}