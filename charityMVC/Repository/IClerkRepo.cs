using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using charityMVC.Models;

namespace charityMVC.Repository
{
    public interface IClerkRepo
    {
        public Task<List<Clerk>> GetAll();
       public Task<Clerk> GetClerkById (string id);
    }
}