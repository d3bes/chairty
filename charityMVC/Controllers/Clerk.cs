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

            try
            {
            var ClerkProfil = new ClerkProfileVM();
            Models.Clerk clerk = await _clerkRepo.GetClerkById(id);
            var cityUsers = await _userRepo.GetCityUsers(clerk.city);
            ClerkProfil.clerk = clerk;
            ClerkProfil.Users = cityUsers;
            

            return View("cityUsers", ClerkProfil);
            }
             catch (Exception ex)
                    {
                        _logger.LogError(ex, "An error occurred in the Review action.");
                        
                        TempData["ErrorMessage"] = "عذرا لقد وقع خطا غير مقصود اذا تكرر عليك التواصل مع المبرمج !";
                        
                        if(ClerkProfil != null )
                        return View("cityUsers", ClerkProfil);
                        else
                        return View("cityUsers");
                        
                    }
        }

        public async Task<IActionResult> Review(string id)
        {
            var user =await _userRepo.GetUserById(id);

            return View("review",user);
        }

        
        [HttpPost]
        public async Task<IActionResult> UpdatePersonslData( PersonalData personalData, string id)
        {

                    try{     
                            
                                var user = await _userRepo.GetUserById(id);
                                if(user == null)
                                {
                                    user = await _userRepo.GetUserById(personalData.id);
                                }
                                            
                                user.fullName = personalData.fullName;
                                user.phone = "966"+personalData.phone;
                                user.birthDate = personalData.birthDate;
                                user.city = personalData.city;
                                user.fullAddress = personalData.fullAddress;
                                user.bank_account_number = personalData.bank_account_number;
                                user.children_count = personalData.children_count;
                                user._proxy_account_number = personalData._proxy_account_number;
                                user._proxy_name = personalData._proxy_name;
                                user.proxy = personalData.proxy;
                                user.elderly= personalData.elderly;
                                user.widow= personalData.widow;
                                user.income_support = personalData.income_support;
                              
                                var points =  await _userRepo.GetPoints(user);
                                user.points = points;

                                await _userRepo.Update(user);

                                // Redirect to the Index action of the HomeController
                      return RedirectToAction("Review", "Clerk", new { id = personalData.id });
                        // // If ModelState is not valid, return to the view with validation errors
                        // return View("register",user);

                    }    
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "An error occurred in the Review action.");
                        
                        TempData["ErrorMessage"] = "عذرا لقد وقع خطا غير مقصود اذا تكرر عليك التواصل مع المبرمج !";
                        
                        return RedirectToAction("Review", "Clerk", new { id = id });
                    }

                            

        }


    }

 
}