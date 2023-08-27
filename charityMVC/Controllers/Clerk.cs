using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using charityMVC.ViewModels;
using Microsoft.Extensions.Logging;
using charityMVC.Repository;
using charityMVC.Models;

namespace charityMVC.Controllers
{
    [Route("[controller]/[action]")]
    public class ClerkController : Controller
    {
        private readonly ILogger<Clerk> _logger;
        private  IUserRepo _userRepo;
        private IClerkRepo _clerkRepo;
        public ClerkController(ILogger<Clerk> logger, IUserRepo userRepo, IClerkRepo clerkRepo)
        {
            _logger = logger;
            _userRepo = userRepo;
            _clerkRepo =clerkRepo;
        }

        public IActionResult profile()
        {
            return View("userProfile");
        }

        public async Task<IActionResult> ClerkProfil(string id)
        {
            var ClerkProfil = new ClerkProfileVM();
            Models.Clerk clerk = await _clerkRepo.GetClerkById(id);
            var cityUsers = await _userRepo.GetCityUsers(clerk.city);
            ClerkProfil.clerk = clerk;
            ClerkProfil.Users = cityUsers;
            

            return View("cityUsers", ClerkProfil);
        }

        public async Task<IActionResult> Review(string id)
        {
            var user =await _userRepo.GetUserById(id);

            return View("review",user);
        }

    }

 
}