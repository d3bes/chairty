using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using charityMVC.Migrations;
using charityMVC.Models;
using charityMVC.Repository;
using charityMVC.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace charityMVC.Controllers
{
    [Route("[controller]/[action]")]
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;
        private  IUserRepo _userRepo;
        private IClerkRepo _clerkRepo;
        private IAdminRepo _adminRepo;
        private Context _context;
        public AdminController(ILogger<AdminController> logger, IAdminRepo adminRepo,
         IUserRepo userRepo, IClerkRepo clerkRepo, Context context)
        {
            _logger = logger;
            _userRepo = userRepo;
            _clerkRepo =clerkRepo;
            _adminRepo = adminRepo;
            _context = context;
        }


        public async Task<IActionResult> Index()
        { 
            try{
            // List<Accepted> accepteds =   _context.Accepteds.ToList();
             List<Accepted> accepteds = await  _adminRepo.GetAccepteds();

        return View(accepteds);
            }
             catch
                    {
                        _logger.LogError( "An error occurred in the Review action.");
                        
                        TempData["ErrorMessage"] = "عذرا لقد وقع خطا غير مقصود برجاء التاكد من الاتصال , اذا تكرر عليك التواصل مع المبرمج !";
                        return View( );

                    }
        }

        public async Task<IActionResult> AllUsers()
        {
            try{
            List<User> users = await _userRepo.GetAllUsers();
            return View("AllUsers", users);
             }
             catch (Exception ex)
                    {
                        _logger.LogError(ex, "An error occurred in the Review action.");
                        
                        TempData["ErrorMessage"] = "عذرا لقد وقع خطا غير مقصود اذا تكرر عليك التواصل مع المبرمج !";
                        return View("Index", TempData);

                    }
        }
        public async Task<IActionResult> cityUsers ()
        {
            return View();
        }

        public async Task<IActionResult> AllClerks()
        {
            try{
            List<Clerk>  clerks = await _adminRepo.GetClerks();
            return View("AllClerks", clerks);
            }
            catch (Exception ex)
                    {
                        _logger.LogError(ex, "An error occurred in the Review action.");
                        
                        TempData["ErrorMessage"] = "عذرا لقد وقع خطا غير مقصود اذا تكرر عليك التواصل مع المبرمج !";
                        return View("Index", TempData);

                    }
        }
        public async Task<IActionResult> NewAdmin(Admin admin)
        {
            try{
                admin.id = Guid.NewGuid().ToString();
                
                await _adminRepo.addAdmin(admin);
                 Roles role = new Roles
                                {
                                    id = admin.id,
                                    Role = "admin"
                                };
                await _userRepo.AddRole(role);
                TempData["Success"] = "!تم بنجاح ";

                 }
                 catch (Exception ex)
                    {
                        _logger.LogError(ex, "An error occurred in the Review action.");
                        
                        TempData["ErrorMessage"] = "عذرا لقد وقع خطا غير مقصود اذا تكرر عليك التواصل مع المبرمج !";

                    }
                  return  RedirectToAction("Index");

        }

        public async Task<IActionResult> AddClerk( )
        {
            return  View("AddClerk");
        }

        [HttpPost]
        public async Task<IActionResult> AddClerk(Clerk clerk)
        {
             try{
                clerk.phone = "966" + clerk.phone;
                await _adminRepo.AddClerk(clerk);
                   Roles role = new Roles
                                {
                                    id = clerk.Id.ToString(),
                                    Role = "clerk"
                                };
                await _userRepo.AddRole(role);
                TempData["Success"] = "!تم بنجاح ";

                 }
                 catch (Exception ex)
                    {
                        _logger.LogError(ex, "An error occurred in the Review action.");
                        
                        TempData["ErrorMessage"] = "عذرا لقد وقع خطا غير مقصود اذا تكرر عليك التواصل مع المبرمج !";

                    }
                  return  RedirectToAction("AllClerks");
        }

        public async Task<IActionResult> RemoveClerk(int id)
        {

            try{

                bool IsSucceded = await _adminRepo.DeleteClerk(id); 
                if(IsSucceded)
                {
                   TempData["Success"] = "!تم بنجاح ";
                  
                }
              

              }
         catch (Exception ex)
                    {
                        _logger.LogError(ex, "An error occurred in the Review action.");
                        
                        TempData["ErrorMessage"] = "عذرا لقد وقع خطا غير مقصود اذا تكرر عليك التواصل مع المبرمج !";

                    }
                return  RedirectToAction("AllClerks");

        }

            public async Task<IActionResult> RemoveAdmin(string id)
        {

            try{

                bool IsSucceded = await _adminRepo.DeleteAdmin(id);
                if(IsSucceded)
                {
                   TempData["Success"] = "!تم بنجاح ";
                  
                }
                return   RedirectToAction("Index");

              }
         catch (Exception ex)
                    {
                        _logger.LogError(ex, "An error occurred in the Review action.");
                        
                        TempData["ErrorMessage"] = "عذرا لقد وقع خطا غير مقصود اذا تكرر عليك التواصل مع المبرمج !";

                    }
                  return  RedirectToAction("Index");

        }

        public async Task<IActionResult> LoginAdmin()
        {

            return View("LoginAdmin");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginAdmin(MemberAccount account)
        {
            try {

            if(_adminRepo.FoundAdmin(account.username, account.password))
            {
            Admin admin = await _adminRepo.FindAdmin(account.username, account.password);
              Roles role = await _userRepo.GetRoles(admin.id);
            
             ClaimsIdentity identity = 
                    new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);

                identity.AddClaim(new Claim("id", admin.id));
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, admin.id.ToString()));
                identity.AddClaim(new Claim(ClaimTypes.Name, admin.username.Split(' ')[0].ToString()));

                identity.AddClaim(new Claim(ClaimTypes.Role, role.Role));

                 ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                 
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,principal);
                 TempData["Success"] = "!تم بنجاح ";
                
                return   RedirectToAction("Index", "Home");
            }
            else 
                return View();
            }
                catch (Exception ex)
                    {
                        _logger.LogError(ex, "An error occurred in the Review action.");
                        
                        TempData["ErrorMessage"] = "عذرا لقد وقع خطا غير مقصود اذا تكرر عليك التواصل مع المبرمج !";
                        return View();
                    }
            
           

        }

        public async Task<IActionResult> ChangeClerkCity(int id, string city)
        {
            try{
            Clerk clerk = await _adminRepo.GetClerkById(id);
            clerk.city = city;
            bool IsSucceded = await _adminRepo.UpdateClerk(clerk);

              if(IsSucceded)
                {
                   TempData["Success"] = "!تم بنجاح ";
                  
                }
                return   RedirectToAction("Index");
            }
          catch (Exception ex)
                    {
                        _logger.LogError(ex, "An error occurred in the Review action.");
                        
                        TempData["ErrorMessage"] = "عذرا لقد وقع خطا غير مقصود اذا تكرر عليك التواصل مع المبرمج !";

                    }
                  return  RedirectToAction("Index");
  

        }

        public async Task<IActionResult> EditPoints()
        {
            points _points = await _adminRepo.Points();
            return View("EditPoints", _points);
        }
        [HttpPost]
        public async Task<IActionResult> EditPoints(points _points)
        {
             try{

                _points.Id = 6;
                
               await _adminRepo.EditPoints(_points);
               TempData["Success"] = "!تم بنجاح ";
                 
                    return   RedirectToAction("EditPoints");
             }
          catch (Exception ex)
                 {
                   _logger.LogError(ex, "An error occurred in the Review action.");
                        
                    TempData["ErrorMessage"] = "عذرا لقد وقع خطا غير مقصود اذا تكرر عليك التواصل مع المبرمج !";

                  }
            return  RedirectToAction("EditPoints");

        }



   public IActionResult Signout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}