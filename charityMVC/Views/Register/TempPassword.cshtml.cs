using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace charityMVC.Views.Register
{
    public class TempPassword : PageModel
    {
        private readonly ILogger<TempPassword> _logger;

        public TempPassword(ILogger<TempPassword> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}