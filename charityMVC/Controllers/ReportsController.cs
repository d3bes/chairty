using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Unicode;
using System.Threading.Tasks;
using charityMVC.Models;
using charityMVC.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Reporting.NETCore;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using SixLabors.Fonts.Unicode;

namespace charityMVC.Controllers
{
    [Route("[controller]/[action]")]
    public class ReportsController : Controller
    {
        private readonly ILogger<ReportsController> _logger;
        private Context _context;
        private IWebHostEnvironment _webHostEnvironment;
        private IAdminRepo _adminRepo;
        private ISupportRepo _supportRepo;
        private IReportRepo _reportRepo;
        private IUserRepo _userRepo;

        public ReportsController(ILogger<ReportsController> logger, ISupportRepo supportRepo,IUserRepo userRepo,
             Context context, IWebHostEnvironment webHostEnvironment, IAdminRepo adminRepo, IReportRepo reportRepo)
        {
            _logger = logger;
            _webHostEnvironment = webHostEnvironment;
            _context = context;
            _adminRepo = adminRepo;
            _supportRepo = supportRepo;
            _reportRepo = reportRepo;
            _userRepo = userRepo;

        }

        public async Task<IActionResult> Index()
        {
            List<Support> supportes =await _supportRepo.GetAllSupports();

            return View(supportes);
        }


        public async Task<IActionResult> UserReports(string id)
{
        List<Support> userSupports = await _supportRepo.GetUsersSupport(id);
    // string filePath = Path.Combine(_webHostEnvironment.ContentRootPath, "Reports", "Accepted.rdl");

         return View(userSupports);
    

}


public async Task<IActionResult> SupportPdfReport(int id)
{
    // var accepted = await _context.Accepteds.FirstOrDefaultAsync(a=> a.Id == id);
    Support _support = await _supportRepo.GetSupportById(id);
    _support.phone = "966"+_support.phone; 
    string filePath = Path.Combine(_webHostEnvironment.ContentRootPath, "Reports", "Accepted.rdl");
    List<Support> supportList = new List<Support>{
        _support
    };
    
    using (var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
    {
        var report = new LocalReport();
        report.LoadReportDefinition(fileStream);

        // Additional logic to set parameters and data sources if need
        report.DataSources.Add(new ReportDataSource(name:"Support",supportList));

        byte[] bytes = report.Render("PDF");

        return File(bytes, "application/pdf", $"{_support.name}.pdf");
    }
}

public async Task<IActionResult> AllUsersExel()
{       
    try{
    List<User> users = await _userRepo.GetAllUsers();
        return _reportRepo.UserModelExcel(users,"كل المستفيدين");
    }
         catch (Exception ex)
                     {
                        _logger.LogError(ex, "An error occurred in the Review action.");
                        
                        TempData["ErrorMessage"] = "عذرا لقد وقع خطا غير مقصود اذا تكرر اكثر عليك التواصل مع المبرمج !";
                    
                      return RedirectToAction("AllUsers","Admin");

                       }


}
public async Task<IActionResult> CityUsersExel(string id)
{
    try
    {
    List<User> cityUsers = await _userRepo.GetCityUsers(id);
    return _reportRepo.UserModelExcel(cityUsers,$"{id}");
      }
         catch (Exception ex)
                     {
                        _logger.LogError(ex, "An error occurred in the Review action.");
                        
                        TempData["ErrorMessage"] = "عذرا لقد وقع خطا غير مقصود اذا تكرر اكثر عليك التواصل مع المبرمج !";
                    
                      return RedirectToAction("AllClerks","Admin");

                       }

}

    public async Task<IActionResult> ClerksExel()
    {
        try{
        List<Clerk> clerks =await _adminRepo.GetClerks();
        return _reportRepo.ClerksExcelReport(clerks,"قائمة المشرفين");
        }
         catch (Exception ex)
                     {
                        _logger.LogError(ex, "An error occurred in the Review action.");
                        
                        TempData["ErrorMessage"] = "عذرا لقد وقع خطا غير مقصود اذا تكرر اكثر عليك التواصل مع المبرمج !";
                    
                      return RedirectToAction("AllClerks","Admin");

                       }
        
    }

    public async Task<IActionResult> AcceptedExcel ()
    {
        List<Accepted> accepteds = await _adminRepo.GetAccepteds();
    return _reportRepo.AcceptedExcelReport(accepteds,"المقبولين من المراجع");
    }


public async Task<IActionResult> SupportExcelReport(int id)
{       
    
    Support _support = await _supportRepo.GetSupportById(id);
    _support.phone = "966" + _support.phone;
    List<Support> _list = new List<Support>(){_support};
   
    return _reportRepo.UsersExcelReport(_list,$"{_support.name}");
    
}

public async Task<IActionResult> AllSupportsExcel()
{

    List<Support> _list = await _supportRepo.GetAllSupports();

    return _reportRepo.UsersExcelReport(_list,"قائمة التقارير");
}


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}