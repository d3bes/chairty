using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using charityMVC.Models;
using charityMVC.Repository;
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
           if (ModelState.IsValid)
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
            if (file == id_image) user.id_image = filePath;
            else if (file == family_card_image) user.family_card_image = filePath;
            else if (file == disability_proof) user.disability_proof = filePath;
            else if (file == debt_proof) user.debt_proof = filePath;
            else if (file == rent_proof) user.rent_proof = filePath;
        }
    }
    
            // Calculate user points and add the user
            user.points = await _userRepo.GetPoints(user);
            await _userRepo.AddUser(user);

            // Redirect to the Index action of the HomeController
        return RedirectToRoute($"/UserProfile/GetUserProfile/{user.id}");
        }

        // If ModelState is not valid, return to the view with validation errors
        return View("register",user);

        }



     
    }
}


  //   user.id_image = Path.Combine(_webHostEnvironment.WebRootPath,"userImages",id_image.FileName);
            // user.family_card_image = Path.Combine(_webHostEnvironment.WebRootPath,"userImages",family_card_image.FileName);
            // user.disability_proof = Path.Combine(_webHostEnvironment.WebRootPath,"userImages",disability_proof.FileName);
            // user.debt_proof = Path.Combine(_webHostEnvironment.WebRootPath,"userImages",debt_proof.FileName);
            // user.rent_proof = Path.Combine(_webHostEnvironment.WebRootPath,"userImages",rent_proof.FileName);

            // string UploadPath = Path.Combine(_webHostEnvironment.WebRootPath,"userImages");
            // string fileName = Guid.NewGuid().ToString()+"_"+ id_image.FileName;
            // string filePath = Path.Combine(UploadPath, fileName);

            // using(FileStream fileStream = new FileStream(filePath, FileMode.Create))
            // {
            //     id_image.CopyTo(fileStream);
            // }
