using System.Runtime.CompilerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using charityMVC.Models;

namespace charityMVC.Repository
{
    public interface IsmsRepo
    {
        public Task<smsValidation> GetSmsValidation(string userId);
        public Task<smsValidation> Create (string userId);
        // public  Task<smsValidation> UpdateValidation (string userId);

         
        
    }
}