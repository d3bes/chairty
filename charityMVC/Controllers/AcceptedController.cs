using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using charityMVC.Models;
using charityMVC.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Reporting.NETCore;
using System.IO;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;
using Microsoft.AspNetCore.Authorization;



namespace charityMVC.Controllers
{
    [Route("[controller]/[action]")]
    public class AcceptedController : Controller
    {
        private readonly ILogger<AcceptedController> _logger;
        private Context _context;
        private IUserRepo _userRepo;
        private IWebHostEnvironment _webHostEnvironment;
        private IAdminRepo _adminRepo;
        private ISupportRepo _supportRepo;
        public AcceptedController(ILogger<AcceptedController> logger,Context context,ISupportRepo supportRepo,
        IWebHostEnvironment webHostEnvironment,IUserRepo userRepo, IAdminRepo adminRepo)
        {
            _logger = logger;
            _context = context;
            _userRepo = userRepo;
            _webHostEnvironment = webHostEnvironment;
            _adminRepo = adminRepo;
            _supportRepo = supportRepo;
        }

        [Authorize(Policy = "AdminOrClerk")]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Policy = "AdminOrClerk")]
        public async Task<IActionResult> ClerkApprove(string id)
        {
            try {
            User user = await _userRepo.GetUserById(id);
            Accepted accepted = new Accepted{
                city = user.city,
                userId = user.id,
                dateTime = DateTime.UtcNow,
                name = user.fullName,
                fullAddress = user.fullAddress,
                phone = user.phone,
                points = (float)user.points,
                bank_account_number = user.bank_account_number,
                proxyName = user._proxy_name,
                proxy_account_number = user._proxy_account_number
            };
           
            user.isAccepted = true;
            _userRepo.Update(user);
         
            await _context.Accepteds.AddAsync(accepted);
            await _context.SaveChangesAsync();
               TempData["Success"] = "!تم بنجاح ";

            }
              catch (Exception ex)
                 {
                   _logger.LogError(ex, "An error occurred in the Review action.");
                        
                    TempData["ErrorMessage"] = "عذرا لقد وقع خطا غير مقصود اذا تكرر عليك التواصل مع المبرمج !";
                  }

               return  RedirectToAction("Review","Clerk",new {id = id});


        }
        
         [Authorize(Policy = "AdminOrClerk")]
        public async Task<IActionResult> ReturnToReview(string id)
        {   
            try {
            User user = await _userRepo.GetUserById(id);
            user.isAccepted =false;
            _userRepo.Update(user);

            Accepted accepted = _context.Accepteds.FirstOrDefault(a => a.userId == id);
            _context.Accepteds.Remove(accepted);
            _context.SaveChanges(); 
            TempData["Success"] = "!   تم التحويل الى المراجعة بنجاح  ";

            }
             catch (Exception ex)
                 {
                   _logger.LogError(ex, "An error occurred in the Review action.");
                        
                    TempData["ErrorMessage"] = "عذرا لقد وقع خطا غير مقصود اذا تكرر عليك التواصل مع المبرمج !";
                        
                        return  RedirectToAction("Index","Admin",new {id = id});

                  }

            return RedirectToAction("Index","Admin");
        }


        [Authorize(Roles="admin")]
        public async Task<IActionResult> AcceptedReport(string id)
        {
            try{
            var accepted = await _context.Accepteds.FirstOrDefaultAsync(a=> a.userId == id);
            points _points = await _adminRepo.Points();
            float amount =( _points.pointValue * accepted.points);
      

            Support support = new Support(){

            Amount = amount, ApprovalDate = accepted.dateTime, city = accepted.city,
            userId = accepted.userId, fullAddress = accepted.fullAddress, name = accepted.name,
            phone = accepted.phone, points = accepted.points

            };

           bool NewSupportSuccess = await _supportRepo.NewSupport(support);
            if(NewSupportSuccess)
             {
                  accepted.isApproved = true;
                   _context.Accepteds.Update(accepted);
                    await _context.SaveChangesAsync();
                     TempData["Success"] = "! جارى انتظار التقرير  ";
                return  RedirectToAction("Index","Admin",new {id = id});
                
             }


                return  RedirectToAction("Index","Admin",new {id = id});

             

            // string filePath = Path.Combine(_webHostEnvironment.ContentRootPath, "Reports", "Accepted.rdl");
           
           
            // List<Accepted> acceptedsList = new List<Accepted>{
            //     accepted
            // };
            
            // using (var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            // {
            //     var report = new LocalReport();
            //     report.LoadReportDefinition(fileStream);

            //     // Additional logic to set parameters and data sources if need
            //     report.DataSources.Add(new ReportDataSource(name:"Accepted",acceptedsList));

            //     byte[] bytes = report.Render("PDF");
            //    TempData["Success"] = "! جارى انتظار التقرير  ";
            
            //     return File(bytes, "application/pdf", $"{accepted.name}.pdf");
            }
            
             catch (Exception ex)
                 {
                   _logger.LogError(ex, "An error occurred in the Review action.");
                        
                    TempData["ErrorMessage"] = "عذرا لقد وقع خطا غير مقصود اذا تكرر عليك التواصل مع المبرمج !";
                        
                        return  RedirectToAction("Index","Admin",new {id = id});

                  }

        }




         [Authorize(Roles="admin")]
         [HttpPost]
        public async Task<IActionResult> NewPay(PayMent payMent)
        {
            try{
          if(payMent.income != 0 )
          {
            payMent.Id = Guid.NewGuid().ToString();

             var accepteds = _context.Accepteds.ToList();

            points _points = await _adminRepo.Points();
            _points.pointValue = payMent.pointValue;

             _adminRepo.EditPoints(_points);

            

         //   var accepteds = await _adminRepo.GetAccepteds();
           // points _points = await _adminRepo.Points();

        // string _payMentId = Guid.NewGuid().ToString();
        // DateTime dateTime = DateTime.Now;
        foreach(var accepted in accepteds)
        {
             float amount =((_points.pointValue * accepted.points));
             
             Support support = new Support(){

            Amount = amount, ApprovalDate = accepted.dateTime, city = accepted.city,
            userId = accepted.userId, fullAddress = accepted.fullAddress, name = accepted.name,
            phone = accepted.phone, points = accepted.points,paymentId = payMent.Id,
            bank_account_number = accepted.bank_account_number,
            proxyName = accepted.proxyName,
            proxy_account_number = accepted.proxy_account_number

            };



             bool NewSupportSuccess = await _supportRepo.NewSupport(support);
            if(NewSupportSuccess)
             {
                  accepted.isApproved = true;
                   _context.Accepteds.Update(accepted);
                     _context.SaveChanges();
                  
             } 
        
        }   payMent.createDate = DateTime.Now;
             _context.PayMents.Add(payMent);
                  _context.SaveChanges();

            return RedirectToAction("GetSupportsByPaymentId", "Reports",new {id = payMent.Id});
        }
        else
        {
            return RedirectToAction("NewPay","Admin");
        }
            }
            catch (Exception ex)
                 {
                   _logger.LogError(ex, "An error occurred in the Review action.");
                        
                    TempData["ErrorMessage"] = "عذرا لقد وقع خطا غير مقصود اذا تكرر عليك التواصل مع المبرمج !";
                        
                    return RedirectToAction("NewPay","Admin");


                  }

        }


        

    }

}


    
// public class test
// {
//     public string city { get; set; }
//     public string userId { get; set; }
//     public string phone { get; set; }


// }

