using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using charityMVC.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace charityMVC.Controllers
{
    [Route("[controller]/[action]")]
    public class ClerkImagesController : Controller
    {
        private readonly ILogger<ClerkImagesController> _logger;
        private IUserRepo _userRepo;
        private IWebHostEnvironment _webHostEnvironment;

        public ClerkImagesController(ILogger<ClerkImagesController> logger ,  IUserRepo userRepo, IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
             _userRepo = userRepo;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> UpdateIdImage(IFormFile id_image, string id)
        {
               // var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        try
        {

          string UploadPath =  Path.Combine(_webHostEnvironment.WebRootPath, "userImages");
                         string fileName = Guid.NewGuid().ToString() + "_" + id_image.FileName;
                         string filePath = Path.Combine(UploadPath, fileName);
                         string dbFilePath = Path.Combine(@"\userImages",fileName);
                        
                      var Uploaded =await   _userRepo.Uploadimage(id_image, filePath);
                      if(Uploaded)
                      {
                          var user =  await _userRepo.GetUserById(id);
                          user.id_image =dbFilePath;
                           var points = await _userRepo.GetPoints(user);
                          user.points = points;
                        await _userRepo.Update(user);
                      }

                      return RedirectToAction("Review", "Clerk", new { id = id });
        }
       catch (Exception ex)
                    {
                        _logger.LogError(ex, "An error occurred in the Review action.");
                        
                        TempData["ErrorMessage"] = "عذرا لقد وقع خطا غير مقصود اذا تكرر اكثر عليك التواصل مع المبرمج !";
                    
                        return RedirectToAction("Review", "Clerk", new { id = id });

                    }
           
                        
                      
        }


           public async Task<IActionResult> UpdateFamilyImg(IFormFile family_card_image, string id)
        {

            try{
                        //   var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                          string UploadPath =  Path.Combine(_webHostEnvironment.WebRootPath, "userImages");
                         string fileName = Guid.NewGuid().ToString() + "_" + family_card_image.FileName;
                         string filePath = Path.Combine(UploadPath, fileName);
                         string dbFilePath = Path.Combine(@"\userImages",fileName);
                        
                      var Uploaded =await   _userRepo.Uploadimage(family_card_image, filePath);
                      if(Uploaded)
                      {
                          var user =  await _userRepo.GetUserById(id);
                          user.family_card_image =dbFilePath;
                           var points = await _userRepo.GetPoints(user);
                          user.points = points;
                        await _userRepo.Update(user);
                      }

                     return RedirectToAction("Review", "Clerk", new { id = id });

            }
              catch (Exception ex)
                    {
                        _logger.LogError(ex, "An error occurred in the Review action.");
                        
                        TempData["ErrorMessage"] = "عذرا لقد وقع خطا غير مقصود اذا تكرر اكثر عليك التواصل مع المبرمج !";
                    
                        return RedirectToAction("Review", "Clerk", new { id = id });

                    }


        }
        public async Task<IActionResult> UpdateDisiability(IFormFile disability_proof,string id, bool disability)
        {

                try
                {
                  // var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                          string UploadPath =  Path.Combine(_webHostEnvironment.WebRootPath, "userImages");
                         string fileName = Guid.NewGuid().ToString() + "_" + disability_proof.FileName;
                         string filePath = Path.Combine(UploadPath, fileName);
                         string dbFilePath = Path.Combine(@"\userImages",fileName);
                        
                      var Uploaded =await   _userRepo.Uploadimage(disability_proof, filePath);
                      if(Uploaded)
                      {
                          var user =  await _userRepo.GetUserById(id);
                          user.disability_proof = dbFilePath;
                           var points = await _userRepo.GetPoints(user);
                          user.points = points;
                          user.disability = disability;
                        await _userRepo.Update(user);
                      }

                     return RedirectToAction("Review", "Clerk", new { id = id });
                }
                  catch (Exception ex)
                    {
                        _logger.LogError(ex, "An error occurred in the Review action.");
                        
                        TempData["ErrorMessage"] = "عذرا لقد وقع خطا غير مقصود اذا تكرر اكثر عليك التواصل مع المبرمج !";
                    
                        return RedirectToAction("Review", "Clerk", new { id = id });

                    }

        }

          public async  Task<IActionResult> UpdateDebtImg( IFormFile debt_proof,string id, bool debt)
        {
                try
                {
                // var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                          string UploadPath =  Path.Combine(_webHostEnvironment.WebRootPath, "userImages");
                         string fileName = Guid.NewGuid().ToString() + "_" + debt_proof.FileName;
                         string filePath = Path.Combine(UploadPath, fileName);
                         string dbFilePath = Path.Combine(@"\userImages",fileName);
                        
                      var Uploaded =await   _userRepo.Uploadimage(debt_proof, filePath);
                      if(Uploaded)
                      {
                          var user =  await _userRepo.GetUserById(id);
                          user.debt_proof = dbFilePath;
                           var points = await _userRepo.GetPoints(user);
                          user.points = points;
                          user.debt = debt ;
                        await _userRepo.Update(user);
                      }

                     return RedirectToAction("Review", "Clerk", new { id = id });
                }
                  catch (Exception ex)
                    {
                        _logger.LogError(ex, "An error occurred in the Review action.");
                        
                        TempData["ErrorMessage"] = "عذرا لقد وقع خطا غير مقصود اذا تكرر اكثر عليك التواصل مع المبرمج !";
                    
                        return RedirectToAction("Review", "Clerk", new { id = id });

                    }

        }
          public async Task<IActionResult> UpdateRentImg(IFormFile rent_proof, string id, bool house_rent)
        {
              try
              {
            //  var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                          string UploadPath =  Path.Combine(_webHostEnvironment.WebRootPath, "userImages");
                         string fileName = Guid.NewGuid().ToString() + "_" + rent_proof.FileName;
                         string filePath = Path.Combine(UploadPath, fileName);
                         string dbFilePath = Path.Combine(@"\userImages",fileName);
                        
                      var Uploaded =await   _userRepo.Uploadimage(rent_proof, filePath);
                      if(Uploaded)
                      {
                          var user =  await _userRepo.GetUserById(id);  
                          user.rent_proof = dbFilePath;
                          var points = await _userRepo.GetPoints(user);
                          user.points = points;
                          user.house_rent = house_rent;
                        await _userRepo.Update(user);
                      }

                     return RedirectToAction("Review", "Clerk", new { id = id });
              }
                catch (Exception ex)
                    {
                        _logger.LogError(ex, "An error occurred in the Review action.");
                        
                        TempData["ErrorMessage"] = "عذرا لقد وقع خطا غير مقصود اذا تكرر اكثر عليك التواصل مع المبرمج !";
                    
                        return RedirectToAction("Review", "Clerk", new { id = id });

                    }

        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}