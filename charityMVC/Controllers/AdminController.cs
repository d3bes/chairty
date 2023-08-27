using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using charityMVC.Repository;
using charityMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace charityMVC.Controllers
{
    [Route("[controller]/[action]")]
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;
        private  IUserRepo _userRepo;
        private IClerkRepo _clerkRepo;
        public AdminController(ILogger<AdminController> logger, IUserRepo userRepo, IClerkRepo clerkRepo)
        {
            _logger = logger;
            _userRepo = userRepo;
            _clerkRepo =clerkRepo;
        }


        public async Task<IActionResult> Index()
        { 
            var AdminProfile = new UsersClerkesVM ();
           var users = await _userRepo.GetAllUsers();
           var clerks = await _clerkRepo.GetAll();

            AdminProfile.users = users;
            AdminProfile.clerkes = clerks;

            return View(AdminProfile);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}