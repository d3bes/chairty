using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Text.Unicode;
using System.Threading.Tasks;
using charityMVC.Models;
using charityMVC.Repository;
using iText.Kernel.Pdf;
using iText.Layout;
using Microsoft.AspNetCore.Authorization;
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
     [Authorize(Policy = "AdminOrClerk")]
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
         
         List<PayMent> payMents = _context.PayMents.ToList();
         return View(payMents);

                                
            // List<Support> supportes =await _supportRepo.GetAllSupports();

            // return View(supportes);
        }


        public async Task<IActionResult> UserReports(string id)
{
        List<Support> userSupports = await _supportRepo.GetUsersSupport(id);
    // string filePath = Path.Combine(_webHostEnvironment.ContentRootPath, "Reports", "Accepted.rdl");

         return View(userSupports);
    

}

// public async Task<IActionResult> PaymentSupportsPdf(string id)
// {
//     List<Support> supportList = await _supportRepo.GetSupportsByPayment(id);
//     string filePath = Path.Combine(_webHostEnvironment.ContentRootPath, "Reports", "Accepted.rdl"); 

//     using (var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
//         {
//             foreach(var support in supportList)
//             {
//             var report = new LocalReport();
//             report.LoadReportDefinition(fileStream);

//             // Additional logic to set parameters and data sources if need
//             report.DataSources.Add(new ReportDataSource(name:"Support",support));

//             byte[] bytes = report.Render("PDF");

//             return File(bytes, "application/pdf", $"{support.ApprovalDate}.pdf");
//             }
//         }

// }


public async Task<IActionResult> SupportPdfReportByPayment(string id)
{
    // Get the list of Support objects
    List<Support> supportList = await _supportRepo.GetSupportsByPayment(id); // Assuming you have a method to retrieve all supports

    // Create a MemoryStream to hold the PDF data
    using (var memoryStream = new MemoryStream())
    {
        var pdfWriter = new PdfWriter(memoryStream);
        var pdfDocument = new PdfDocument(pdfWriter);
        var document = new Document(pdfDocument);

        // Load the report template for the first page
        string filePath = Path.Combine(_webHostEnvironment.ContentRootPath, "wwwroot\\Reports", "Accepted.rdl");
        var firstPageReport = new LocalReport();
        firstPageReport.LoadReportDefinition(new FileStream(filePath, FileMode.Open, FileAccess.Read));

        // Loop through the Support objects and create a new page for each
        foreach (var support in supportList)
        {
            // Add a new page for each Support object
           // pdfDocument.AddNewPage();

            // Create a new page report for the current Support object
            var pageReport = new LocalReport();
            pageReport.LoadReportDefinition(new FileStream(filePath, FileMode.Open, FileAccess.Read));
            pageReport.DataSources.Add(new ReportDataSource(name: "Support", new List<Support> { support }));

            // Render the page report and add it to the PDF document
            byte[] pageBytes = pageReport.Render("PDF");
            var pagePdf = new PdfDocument(new PdfReader(new MemoryStream(pageBytes)));
            pagePdf.CopyPagesTo(1, pagePdf.GetNumberOfPages(), pdfDocument);

            // Close the page report's resources
            pagePdf.Close();
        }

        // Close the main PDF document
        pdfDocument.Close();

        // Return the combined PDF as a downloadable file
        byte[] pdfBytes = memoryStream.ToArray();
        return File(pdfBytes, "application/pdf", $"{supportList[1].ApprovalDate}الدفعة المالية_.pdf");
    }
}


public async Task<IActionResult> SupportPdfReport(int id)
{
    // var accepted = await _context.Accepteds.FirstOrDefaultAsync(a=> a.Id == id);
    Support _support = await _supportRepo.GetSupportById(id);
    
        string filePath = Path.Combine(_webHostEnvironment.ContentRootPath, "wwwroot\\Reports", "Accepted.rdl");
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


// public async Task<IActionResult> ZipSupportPdfReport()
// {
//     // Get the list of Support objects
//     List<Support> supportList = await _supportRepo.GetAllSupports(); // Assuming you have a method to retrieve all supports

//     // Load the report template
//     string filePath = Path.Combine(_webHostEnvironment.ContentRootPath, "Reports", "Accepted.rdl");

//     // Create a folder to store individual PDF files
//     string outputFolder = Path.Combine(_webHostEnvironment.ContentRootPath, "Reports", "PDFOutput");

//     if (!Directory.Exists(outputFolder))
//     {
//         Directory.CreateDirectory(outputFolder);
//     }

//     // Generate a PDF report for each Support item
//     foreach (var support in supportList)
//     {
//         using (var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
//         {
//             var report = new LocalReport();
//             report.LoadReportDefinition(fileStream);

//             // Set parameters and data sources based on the current support item if needed
//             report.DataSources.Add(new ReportDataSource(name: "Support", new List<Support> { support }));

//             byte[] bytes = report.Render("PDF");

//             // Save the PDF file with a unique name (e.g., support ID)
//             string pdfFileName = $"{support.Id}.pdf";
//             string pdfFilePath = Path.Combine(outputFolder, pdfFileName);
//             System.IO.File.WriteAllBytes(pdfFilePath, bytes);
//         }
//     }

//     // Create a ZIP archive containing all generated PDF files
//     string zipFilePath = Path.Combine(outputFolder, "SupportReports.zip");
//     ZipFile.CreateFromDirectory(outputFolder, zipFilePath);

//     // Return the ZIP archive as a downloadable file
//     byte[] zipBytes = System.IO.File.ReadAllBytes(zipFilePath);
//     return File(zipBytes, "application/zip", "SupportReports.zip");
// }


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
      [Authorize(Roles="admin")]
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

   [Authorize(Roles="admin")]
public async Task<IActionResult> AllSupportsExcel()
{

    List<Support> _list = await _supportRepo.GetAllSupports();

    return _reportRepo.UsersExcelReport(_list,"قائمة التقارير");
}
[Authorize(Roles="admin")]
public async Task<IActionResult> AllSupportsExcelByPayment(string id)
{

    List<Support> _list = await _supportRepo.GetSupportsByPayment(id);

    return _reportRepo.UsersExcelReport(_list,$"{id}قائمة التقارير");
}


public async Task<IActionResult> GetSupportsByPaymentId (string id)
{

    List<Support> _list = await _supportRepo.GetSupportsByPayment(id);

    return View("payment",_list);

}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}