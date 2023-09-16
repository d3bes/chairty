using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using charityMVC.Models;
using OfficeOpenXml;
using Microsoft.Reporting.NETCore;
using Microsoft.AspNetCore.Mvc;


using System.IO;

namespace charityMVC.Repository
{
    public class ReportRepo : IReportRepo
    {
public IActionResult UsersExcelReport(List<Support> supports, string reportName)
{
     ExcelPackage.LicenseContext = LicenseContext.NonCommercial; // Set the license context

    using (var package = new ExcelPackage())
    {
        var worksheet = package.Workbook.Worksheets.Add($"{reportName}");
        int column = 1;
        float result = 0;

        // Add Arabic header row
        worksheet.Cells[1, 1].Value = "الاسم";
        worksheet.Cells[1, 2].Value = "رقم الهوية";
        worksheet.Cells[1, 3].Value = "المدينة";
        worksheet.Cells[1, 4].Value = "العنوان";
        worksheet.Cells[1, 5].Value = " رقم حساب المستفيد ";
        worksheet.Cells[1, 6].Value = "رقم الهاتف";
        worksheet.Cells[1, 7].Value = "النقاظ";
        worksheet.Cells[1, 8].Value = "اسم الوكيل";
        worksheet.Cells[1, 9].Value = " رقم حساب الوكيل ";
        worksheet.Cells[1, 10].Value = "تاريخ اقرار الدفعة";
        worksheet.Cells[1, 11].Value = "الدفعة المالية";


        foreach (var _support in supports)
        {
            column++;
            result +=(float) _support.Amount;
            worksheet.Cells[column, 1].Value = _support.name;
            worksheet.Cells[column, 2].Value = _support.userId;
            worksheet.Cells[column, 3].Value = _support.city;
            worksheet.Cells[column, 4].Value = _support.fullAddress;
            worksheet.Cells[column, 5].Value = _support.bank_account_number;
            worksheet.Cells[column, 6].Value = _support.phone;
            worksheet.Cells[column, 7].Value = _support.points;
            worksheet.Cells[column, 8].Value = _support.proxyName;
            worksheet.Cells[column, 9].Value = _support.proxy_account_number;
              if (_support.ApprovalDate.HasValue)
            {
                worksheet.Cells[column, 10].Value = _support.ApprovalDate.Value.ToString("yyyy-MM-dd HH:mm:ss");
            }
            worksheet.Cells[column, 11].Value = _support.Amount;
          
        }
        column+= 2;
            worksheet.Cells[column, 11].Value = result;
            worksheet.Cells[column, 12].Value = "اجمالى الدفعات";




        worksheet.Cells.AutoFitColumns();

        // Save the Excel package to a stream
        var stream = new MemoryStream(package.GetAsByteArray());

        // Reset the position of the stream to the beginning
        stream.Position = 0;

        return new FileContentResult(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
        {
            FileDownloadName = $"{DateTime.UtcNow.ToString("yyyy-MM-dd-hh-mm")}_تقرير.xlsx"
        };
    }
}

public IActionResult AcceptedExcelReport(List<Accepted> accepteds, string reportName)
{
     ExcelPackage.LicenseContext = LicenseContext.NonCommercial; // Set the license context

    using (var package = new ExcelPackage())
    {
        var worksheet = package.Workbook.Worksheets.Add($"{reportName}");
        int column = 1;

        // Add Arabic header row
        worksheet.Cells[1, 1].Value = "الاسم";
        worksheet.Cells[1, 2].Value = "رقم الهوية";
        worksheet.Cells[1, 3].Value = "المدينة";
        worksheet.Cells[1, 4].Value = "العنوان";
        worksheet.Cells[1, 5].Value = "رقم الهاتف";
        worksheet.Cells[1, 6].Value = "النقاظ";
      

        foreach (var _accepted in accepteds)
        {
            column++;
            worksheet.Cells[column, 1].Value = _accepted.name;
            worksheet.Cells[column, 2].Value = _accepted.userId;
            worksheet.Cells[column, 3].Value = _accepted.city;
            worksheet.Cells[column, 4].Value = _accepted.fullAddress;
            worksheet.Cells[column, 5].Value = _accepted.phone;
            worksheet.Cells[column, 6].Value = _accepted.points;
            
        }

        worksheet.Cells.AutoFitColumns();

        // Save the Excel package to a stream
        var stream = new MemoryStream(package.GetAsByteArray());

        // Reset the position of the stream to the beginning
        stream.Position = 0;

        return new FileContentResult(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
        {
            FileDownloadName = $"{DateTime.Now.ToString("yyyy-MM-dd-hh-mm")}_{reportName}.xlsx"
        };
    }
}



public IActionResult UserModelExcel(List<User> supports, string reportName)
{
     ExcelPackage.LicenseContext = LicenseContext.NonCommercial; // Set the license context

    using (var package = new ExcelPackage())
    {
        var worksheet = package.Workbook.Worksheets.Add($"{reportName}");
        int column = 1;

        // Add Arabic header row
        worksheet.Cells[1, 1].Value = "الاسم";
        worksheet.Cells[1, 2].Value = "رقم الهوية";
        worksheet.Cells[1, 3].Value = "المدينة";
        worksheet.Cells[1, 4].Value = "العنوان";
        worksheet.Cells[1, 5].Value = "رقم الهاتف";
        worksheet.Cells[1, 6].Value = " رقم حساب المستفيد ";
        worksheet.Cells[1, 7].Value = "تاريخ الميلاد";
        worksheet.Cells[1, 8].Value = " عدد الاولاد";
        worksheet.Cells[1, 9].Value = "توجد اعاقة";
        worksheet.Cells[1, 10].Value = "يوجد كبير (فوق60)";
        worksheet.Cells[1, 11].Value = " يوجد دين";
        worksheet.Cells[1, 11].Value = " يوجد ارملة او مطلقة";
        worksheet.Cells[1, 12].Value = "المنزل ايجار ";
        worksheet.Cells[1, 13].Value = " النقاط ";
        worksheet.Cells[1, 14].Value = "يوجد وكيل ";
        worksheet.Cells[1, 15].Value = "اسم الوكيل";
        worksheet.Cells[1, 16].Value = " رقم حساب الوكيل ";
        worksheet.Cells[1, 17].Value = "حالة الطلب";

        

        foreach (var _support in supports)
        {
            column++;
            worksheet.Cells[column, 1].Value = _support.fullName;
            worksheet.Cells[column, 2].Value = _support.id;
            worksheet.Cells[column, 3].Value = _support.city;
            worksheet.Cells[column, 4].Value = _support.fullAddress;
            worksheet.Cells[column, 5].Value = _support.phone;
            worksheet.Cells[column, 6].Value = _support.bank_account_number;
            worksheet.Cells[column, 7].Value = _support.birthDate;
            worksheet.Cells[column, 8].Value = _support.children_count;
            worksheet.Cells[column, 9].Value = GetBool(_support.disability);
            worksheet.Cells[column, 10].Value = GetBool( _support.elderly);
            worksheet.Cells[column, 11].Value = GetBool(_support.debt);
            worksheet.Cells[column, 12].Value = GetBool(_support.house_rent);
            worksheet.Cells[column, 13].Value = _support.points;
            worksheet.Cells[column, 14].Value = GetBool(_support.proxy);
            worksheet.Cells[column, 15].Value = _support._proxy_name;
            worksheet.Cells[column, 16].Value = _support._proxy_account_number;
            if (_support.isAccepted)
            {
                worksheet.Cells[column, 17].Value = "تم القبول من المراجع";
            }
            else
                worksheet.Cells[column, 17].Value = "جارى المراجعة ";

       

        }

        worksheet.Cells.AutoFitColumns();

        // Save the Excel package to a stream
        var stream = new MemoryStream(package.GetAsByteArray());

        // Reset the position of the stream to the beginning
        stream.Position = 0;

        return new FileContentResult(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
        {
            FileDownloadName = $"{DateTime.Now.ToString("yyyy-MM-dd-hh-mm")}_{reportName}.xlsx"
        };
    }
}


public IActionResult ClerksExcelReport(List<Clerk> clerks, string reportName)
{
     ExcelPackage.LicenseContext = LicenseContext.NonCommercial; // Set the license context

    using (var package = new ExcelPackage())
    {
        var worksheet = package.Workbook.Worksheets.Add($"{reportName}");
        int column = 1;

        // Add Arabic header row
        worksheet.Cells[1, 1].Value = "الاسم";
        worksheet.Cells[1, 2].Value = "رقم الهوية";
        worksheet.Cells[1, 3].Value = "المدينة";
        worksheet.Cells[1, 4].Value = "رقم الهاتف";
        

        foreach (var clerk in clerks)
        {
            column++;
            worksheet.Cells[column, 1].Value = clerk.name;
            worksheet.Cells[column, 2].Value = clerk.Id;
            worksheet.Cells[column, 3].Value = clerk.city;
            worksheet.Cells[column, 4].Value = clerk.phone;
          
        }

        worksheet.Cells.AutoFitColumns();

        // Save the Excel package to a stream
        var stream = new MemoryStream(package.GetAsByteArray());

        // Reset the position of the stream to the beginning
        stream.Position = 0;

        return new FileContentResult(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
        {
            FileDownloadName = $"{DateTime.Now.ToString("yyyy-MM-dd-hh-mm")}_{reportName}.xlsx"
        };
    }
}


public string GetBool(bool _bool)
{
    if(_bool) 
        return "نعم";
    else
    return "لا";
}

       
    }
}