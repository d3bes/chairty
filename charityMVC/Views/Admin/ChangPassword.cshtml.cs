using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace charityMVC.Views.Admin
{
    public class ChangPassword : PageModel
    {
        private readonly ILogger<ChangPassword> _logger;

        public ChangPassword(ILogger<ChangPassword> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}