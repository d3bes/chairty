using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using charityMVC.Models;

namespace charityMVC.Repository
{
    public interface ISupportRepo
    {
        public Task<List<Support>> GetUsersSupport(string userId);
        public Task<Support> GetSupportById(int Id);
        public Task<bool> NewSupport (Support support);

    }
}