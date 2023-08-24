using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using charityMVC.Models;

namespace charityMVC.Repository
{
    public interface IAdminRepo
    {
        public List<Task<Admin>> GetAll { get; set;}
        public Task<Admin> GetSuperAdmin { get; set;}
        public Task<bool> Delete { get; set; }
 
        
    }
}