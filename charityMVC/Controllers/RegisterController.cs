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
        public IActionResult Upload(IFormFile id_image, IFormFile family_card_image, IFormFile disability_proof,
                                    IFormFile debt_proof, IFormFile housing_proof )
        {
            List<IFormFile> formFiles = new List<IFormFile>{id_image, family_card_image, disability_proof,debt_proof,housing_proof};
            
            foreach(var file in formFiles)
            {
                _userRepo.Uploadimage(file);
            }
            // string UploadPath = Path.Combine(_webHostEnvironment.WebRootPath,"userImages");
            // string fileName = Guid.NewGuid().ToString()+"_"+ id_image.FileName;
            // string filePath = Path.Combine(UploadPath, fileName);

            // using(FileStream fileStream = new FileStream(filePath, FileMode.Create))
            // {
            //     id_image.CopyTo(fileStream);
            // }

           return RedirectToAction("Index");


        }

     
    }
}