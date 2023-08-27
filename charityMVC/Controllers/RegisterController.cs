using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using charityMVC.Models;
using charityMVC.Repository;
using charityMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace charityMVC.Controllers
{
    [Route("[controller]/[action]")]
    public class RegisterController : Controller
    {
        private readonly ILogger<RegisterController> _logger;
        private IUserRepo _userRepo;
        private IWebHostEnvironment _webHostEnvironment;
        public RegisterController(ILogger<RegisterController> logger, IUserRepo userRepo, IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            _userRepo = userRepo;
            _webHostEnvironment = webHostEnvironment;
        }
        
        public IActionResult register()
        { 
            return View("register");
        }
        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile id_image, IFormFile family_card_image, IFormFile disability_proof,
                                    IFormFile debt_proof, IFormFile rent_proof, User user )
        {
                  
                        // List of form files to be uploaded
                        List<IFormFile> formFiles = new List<IFormFile> { id_image, family_card_image, disability_proof, debt_proof, rent_proof };

                        foreach (var file in formFiles)
                        {
                            if (file != null)
                            {
                                string UploadPath = Path.Combine(_webHostEnvironment.WebRootPath, "userImages");
                                string fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                                string filePath = Path.Combine(UploadPath, fileName);
                                
                                // Upload the image file
                                _userRepo.Uploadimage(file, filePath);
                                
                                // Assign the uploaded file path to the corresponding property in the user object
                                if (file == id_image) user.id_image = Path.Combine("\\userImages", fileName);
                                else if (file == family_card_image) user.family_card_image = Path.Combine("\\userImages", fileName);
                                else if (file == disability_proof) user.disability_proof = Path.Combine("\\userImages", fileName);
                                else if (file == debt_proof) user.debt_proof = Path.Combine("\\userImages", fileName);
                                else if (file == rent_proof) user.rent_proof = Path.Combine("\\userImages", fileName);
                            }
                        }
                        
                                // Calculate user points and add the user
                                user.points = await _userRepo.GetPoints(user);
                                await _userRepo.AddUser(user);

                                // Redirect to the Index action of the HomeController
                 return RedirectToAction("GetUserProfile", "UserProfile", new { id = user.id });


                        // // If ModelState is not valid, return to the view with validation errors
                        // return View("register",user);

        }


        [HttpPost]
        public async Task<IActionResult> UpdatePersonslData( PersonalData personalData )
        {

 #region edited
                        // List<IFormFile> formFiles = new List<IFormFile> ();

                        // if(OldUser.id_image != user.id_image ) formFiles.Add(id_image);
                        // if(OldUser.family_card_image != user.family_card_image ) formFiles.Add(family_card_image);
                        // if(OldUser.disability_proof != user.disability_proof ) formFiles.Add(disability_proof);
                        // if(OldUser.debt_proof != user.debt_proof ) formFiles.Add(debt_proof);
                        // if(OldUser.rent_proof != user.rent_proof ) formFiles.Add(rent_proof);

                        // if(formFiles != null)
                        // {
                        //     foreach (var file in formFiles)
                        //     {
                        //         if (file != null)
                        //         {
                        //             string UploadPath = Path.Combine(_webHostEnvironment.WebRootPath, "userImages");
                        //             string fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                        //             string filePath = Path.Combine(UploadPath, fileName);
                                    
                        //             // Upload the image file
                        //             _userRepo.Uploadimage(file, filePath);
                                    
                        //             // Assign the uploaded file path to the corresponding property in the user object
                        //             if (file == id_image) user.id_image = Path.Combine("\\userImages", fileName);
                        //             else if (file == family_card_image) user.family_card_image = Path.Combine("\\userImages", fileName);
                        //             else if (file == disability_proof) user.disability_proof = Path.Combine("\\userImages", fileName);
                        //             else if (file == debt_proof) user.debt_proof = Path.Combine("\\userImages", fileName);
                        //             else if (file == rent_proof) user.rent_proof = Path.Combine("\\userImages", fileName);
                        //         }
                        //     }
                        // }
                        
                                // Calculate user points and add the user
                                // user.points = await _userRepo.GetPoints(user);

        #endregion
                               
                             var user = await _userRepo.GetUserById(personalData.id);
                                
                                user.fullName = personalData.fullName;
                                user.phone = personalData.phone;
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
                return RedirectToAction("GetUserProfile", "UserProfile", new { id = user.id });


                        // // If ModelState is not valid, return to the view with validation errors
                        // return View("register",user);

        }

     
    }
}


 
