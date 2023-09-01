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

        public ReportsController(ILogger<ReportsController> logger, ISupportRepo supportRepo,
             Context context, IWebHostEnvironment webHostEnvironment, IAdminRepo adminRepo)
        {
            _logger = logger;
            _webHostEnvironment = webHostEnvironment;
            _context = context;
            _adminRepo = adminRepo;
            _supportRepo = supportRepo;

        }

        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> UserReports(string id)
{
        List<Support> userSupports = await _supportRepo.GetUsersSupport(id);
    // string filePath = Path.Combine(_webHostEnvironment.ContentRootPath, "Reports", "Accepted.rdl");

         return View(userSupports);
    
    // using (var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
    // {
    //     var report = new LocalReport();
    //     report.LoadReportDefinition(fileStream);

    //     // Additional logic to set parameters and data sources if need
    //     report.DataSources.Add(new ReportDataSource(name:"Accepted",acceptedsList));

    //     byte[] bytes = report.Render("PDF");

    //     return File(bytes, "application/pdf", $"{accepted.name}.pdf");
    //}
}

// public async Task<IActionResult> ApproveSupport(string userId)
// {
//       var accepted = await _context.Accepteds.FirstOrDefaultAsync(a=> a.userId == userId);
//       points _points = await _adminRepo.Points();
//         int amount =  accepted.points *_points.pointValue;

//       Support support = new Support(){
//         Amount = amount, name = accepted.name, phone = accepted.phone,
//         ApprovalDate = DateTime.UtcNow, userId = accepted.userId,
//         city = accepted.city, fullAddress = accepted.fullAddress,
//         points = accepted.points
//       } ;

//      await _context.AddAsync(support);
//      await _context.SaveChangesAsync();
          
// }
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
// public async Task<IActionResult> SupportXlsxReport()
// {


// }



public async Task<IActionResult> SupportExcelReport(int id)
{
    Support _support = await _supportRepo.GetSupportById(id);
    _support.phone = "966" + _support.phone;

    using (var package = new ExcelPackage())
    {
        var worksheet = package.Workbook.Worksheets.Add("SupportData");

        // Add Arabic header row
        worksheet.Cells[1, 1].Value = "المستفيد";
        worksheet.Cells[1, 2].Value = "رقم الهوية";
        worksheet.Cells[1, 3].Value = "المدينة";
        worksheet.Cells[1, 4].Value = "العنوان";
        worksheet.Cells[1, 5].Value = "رقم الهاتف";
        worksheet.Cells[1, 6].Value = "النقاظ";
        worksheet.Cells[1, 7].Value = "الدفعة المالية";
        worksheet.Cells[1, 8].Value = "تاريخ اقرار الدفعة";

        // Populate data row
        worksheet.Cells[2, 1].Value = _support.name;
        worksheet.Cells[2, 2].Value = _support.userId;
        worksheet.Cells[2, 3].Value = _support.city;
        worksheet.Cells[2, 4].Value = _support.fullAddress;
        worksheet.Cells[2, 5].Value = _support.phone;
        worksheet.Cells[2, 6].Value = _support.points;
        worksheet.Cells[2, 7].Value = _support.Amount;
        if (_support.ApprovalDate.HasValue)
        {
            worksheet.Cells[2, 8].Value = _support.ApprovalDate.Value.ToString("yyyy-MM-dd HH:mm:ss");
        }


        // Apply cell formatting if needed
        // For example:
        // worksheet.Cells[1, 1, 2, 8].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

        // Auto-fit columns
        worksheet.Cells.AutoFitColumns();

        // Save the Excel package to a stream
        var stream = new MemoryStream(package.GetAsByteArray());

        return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"{_support.name}.xlsx");
    }
}


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}