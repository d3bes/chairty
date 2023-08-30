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
    public class AcceptedController : Controller
    {
        private readonly ILogger<AcceptedController> _logger;
        private Context _context;
        private IUserRepo _userRepo;
        public AcceptedController(ILogger<AcceptedController> logger,Context context,IUserRepo userRepo)
        {
            _logger = logger;
            _context = context;
            _userRepo = userRepo;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ClerkApprove(string id)
        {
            User user = await _userRepo.GetUserById(id);
            Accepted accepted = new Accepted{
                city = user.city,
                userId = user.id,
                dateTime = DateTime.UtcNow,
                name = user.fullName,
                fullAddress = user.fullAddress,
                phone = user.phone,
                points = (int)user.points
            };
            await _context.Accepteds.AddAsync(accepted);
            await _context.SaveChangesAsync();

             return  RedirectToAction("Review","Clerk",new {id =user.id});

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}