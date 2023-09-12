using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AspNetCore.ReportingServices.ReportProcessing.ReportObjectModel;
using charityMVC.Models;
using charityMVC.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace charityMVC.Controllers
{
    [Route("[controller]/[action]")]
    public class smsController : Controller
    {
        private readonly ILogger<smsController> _logger;
        private IUserRepo _userRepo;
        private IsmsRepo _smsRepo;

        public smsController(ILogger<smsController> logger, IUserRepo userRepo, IsmsRepo smsRepo)
        {
            _logger = logger;
            _userRepo = userRepo;
            _smsRepo = smsRepo;
            
        }

        public IActionResult Index( )
        {
            return View( );
        }

        public async Task<IActionResult> validatePhone (smsValidation _smsValidation)
        {
         var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

         var user = await _userRepo.GetUserById(userId);
         smsValidation validation = await _smsRepo.GetSmsValidation(userId);
        
         if(validation.ValidationCode == _smsValidation.ValidationCode)
         {
            user.isPhoneValid = true;
           await _userRepo.Update(user);

            return View("userProfile",user);
         }

         else 
         
         return RedirectToAction("Index");


        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}