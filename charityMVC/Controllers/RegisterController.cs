using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using charityMVC.Models;
using charityMVC.Repository;
using charityMVC.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace charityMVC.Controllers
{
    [Route("[controller]/[action]")]
    public class RegisterController : Controller
    {
        private readonly ILogger<RegisterController> _logger;
        private IUserRepo _userRepo;
        private IWebHostEnvironment _webHostEnvironment;
     

        public RegisterController(ILogger<RegisterController> logger, IUserRepo userRepo, IWebHostEnvironment webHostEnvironment )
        {
            _logger = logger;
            _userRepo = userRepo;
            _webHostEnvironment = webHostEnvironment;

        }
        
        public IActionResult register()
        { 
            return View("register");
        }
        public IActionResult Login()
        { 
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(Account account)
        {
        
        try 
        {
        //   if(ModelState.IsValid)
        //   {
            if(_userRepo.Found(account.id, account.password))
            {
                
                //get role
               Roles role = await _userRepo.GetRoles(account.id);
                User accountModel =   _userRepo.Find(account.id, account.password);
               
                   ClaimsIdentity identity = 
                    new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);

                identity.AddClaim(new Claim("id",account.id.ToString()));
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, account.id.ToString()));
                
                identity.AddClaim(new Claim(ClaimTypes.Role, role.Role));

                 ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                 
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,principal);

                 return RedirectToAction("GetUserProfile", "UserProfile");     
            }
            else
            {
                ModelState.AddModelError("","عذرا,الهوية او كلمة المرور غير صحيحة يرجى اعادة المحاولة");
            } 
         
        //   }
               return View(account);

        }
         catch (Exception ex)
                     {
                        _logger.LogError(ex, "An error occurred in the Review action.");
                        
                        TempData["ErrorMessage"] = "عذرا لقد وقع خطا غير مقصود اذا تكرر اكثر عليك التواصل مع المبرمج !";
                    
                      return View(); 

                       }


        }


          public IActionResult Signout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index","Home");
        }

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile id_image, IFormFile family_card_image, IFormFile disability_proof,
                                    IFormFile debt_proof, IFormFile rent_proof, User user )
        {
            try 
            {

                // if(ModelState.IsValid)
                // {
                       

                                
                                await _userRepo.UploadAllFiles( id_image, family_card_image, disability_proof, debt_proof, rent_proof ,user);
                                  // Calculate user points and add the user
                                user.points = await _userRepo.GetPoints(user);
                                await _userRepo.AddUser(user);
                                
                               Roles role = new Roles
                                {
                                    id = user.id,
                                    Role = "user"
                                };
                                 await _userRepo.AddRole(role);
                      
                        
                               
                                        // Redirect to the Index action of the HomeController
                        return View("Login");
                        // }
                        // else
                        // return View("register",user); 
                    }

                    catch (Exception ex)
                     {
                        _logger.LogError(ex, "An error occurred in the Review action.");
                        
                        TempData["ErrorMessage"] = "عذرا لقد وقع خطا غير مقصود اذا تكرر اكثر عليك التواصل مع المبرمج !";
                    
                      return View("register",user); 

                       }


                        // // If ModelState is not valid, return to the view with validation errors
                        // return View("register",user);

        }


        [HttpPost]
        public async Task<IActionResult> UpdatePersonslData( PersonalData personalData )
        {
                    try
                    {
                               
                             var user = await _userRepo.GetUserById(personalData.id);
                                
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
                                user.widow=(bool) personalData.widow;
                                user.income_support = (bool)personalData.income_support;
                              
                                var points =  await _userRepo.GetPoints(user);
                                user.points = points;

                                await _userRepo.Update(user);

                                // Redirect to the Index action of the HomeController
                 return RedirectToAction("GetUserProfile", "UserProfile");
                        // // If ModelState is not valid, return to the view with validation errors
                        // return View("register",user);
                    }
                      catch (Exception ex)
                    {
                        _logger.LogError(ex, "An error occurred in the Review action.");
                        
                        TempData["ErrorMessage"] = "عذرا لقد وقع خطا غير مقصود اذا تكرر اكثر عليك التواصل مع المبرمج !";
                    
                        return RedirectToAction("GetUserProfile", "UserProfile");

                    }

        }


        

     
    }
}


 
