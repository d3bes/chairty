using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using charityMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace charityMVC.Repository
{
    public interface IReportRepo
    {
    public IActionResult UsersExcelReport(List<Support> supports, string reportName);
    public IActionResult UserModelExcel(List<User> supports, string reportName);
    public IActionResult ClerksExcelReport(List<Clerk> clerks, string reportName);
    public IActionResult AcceptedExcelReport(List<Accepted> accepteds, string reportName);



    }
}