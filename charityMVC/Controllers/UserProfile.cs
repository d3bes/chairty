using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using charityMVC.Repository;
using charityMVC.Models;
using charityMVC.ViewModels;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace charityMVC.Controllers
{
    [Route("[controller]/[action]")]
    [Authorize]
    public class UserProfile : Controller
    {
        private readonly ILogger<UserProfile> _logger;
        public IUserRepo _userRepo;
        public IsmsRepo _smsRepo;
        public UserProfile(ILogger<UserProfile> logger, IUserRepo userRepo,IsmsRepo ismsRepo)
        {
            _logger = logger;
            _userRepo = userRepo;
            _smsRepo = ismsRepo;
        }
        [Authorize]
        public async Task<IActionResult> GetUserProfile()
        {
            try
            {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            User user  = await _userRepo.GetUserById(userId);
            // if(user.isPhoneValid)
            // {
            return View("userProfile",user);
            // }
            // else
            // return RedirectToAction("validatePhone","sms");
            }
             catch (Exception ex)
                  {
                    
                        _logger.LogError(ex, "An error occurred in the Review action.");
                        
                        TempData["ErrorMessage"] = "عذرا لقد وقع خطا غير مقصود اذا تكرر اكثر عليك التواصل مع المبرمج !";
                    
                      return View("UserProfile");

                    }
        }


    [Authorize]
    public async Task<IActionResult> ChangePassword( )
    {
       return View("ChangPassword");

    }

       
        

    }
}