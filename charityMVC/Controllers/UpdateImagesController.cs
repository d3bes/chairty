using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using charityMVC.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace charityMVC.Controllers
{
      [Route("[controller]/[action]")]
    public class UpdateImagesController : Controller
    {
        private readonly ILogger<UpdateImagesController> _logger;
         private IUserRepo _userRepo;
        private IWebHostEnvironment _webHostEnvironment;
        public UpdateImagesController(ILogger<UpdateImagesController> logger,  IUserRepo userRepo, IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            _userRepo = userRepo;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> UpdateIdImage(IFormFile id_image)
        {
                          string UploadPath =  Path.Combine(_webHostEnvironment.WebRootPath, "userImages");
                         string fileName = Guid.NewGuid().ToString() + "_" + id_image.FileName;
                         string filePath = Path.Combine(UploadPath, fileName);
                         string dbFilePath = Path.Combine(@"\userImages",fileName);
                        
                      var Uploaded =await   _userRepo.Uploadimage(id_image, filePath);
                      if(Uploaded)
                      {
                          var user =  await _userRepo.GetUserById("4578963214501236");
                          user.id_image =dbFilePath;
                        await _userRepo.Update(user);
                      }

                     return RedirectToAction("GetUserProfile", "UserProfile", new { id = "4578963214501236" });


        }


           public async Task<IActionResult> UpdateFamilyImg(IFormFile family_card_image)
        {
                          string UploadPath =  Path.Combine(_webHostEnvironment.WebRootPath, "userImages");
                         string fileName = Guid.NewGuid().ToString() + "_" + family_card_image.FileName;
                         string filePath = Path.Combine(UploadPath, fileName);
                         string dbFilePath = Path.Combine(@"\userImages",fileName);
                        
                      var Uploaded =await   _userRepo.Uploadimage(family_card_image, filePath);
                      if(Uploaded)
                      {
                          var user =  await _userRepo.GetUserById("4578963214501236");
                          user.family_card_image =dbFilePath;
                        await _userRepo.Update(user);
                      }

                     return RedirectToAction("GetUserProfile", "UserProfile", new { id = "4578963214501236" });


        }
        public async Task UpdateDisiability()
        {

        }

          public async Task UpdateDebtImg()
        {

        }
          public async Task UpdateRentImg()
        {

        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}