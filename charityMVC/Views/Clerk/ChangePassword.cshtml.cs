using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace charityMVC.Views.Clerk
{
    public class ChangePassword : PageModel
    {
        private readonly ILogger<ChangePassword> _logger;

        public ChangePassword(ILogger<ChangePassword> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}