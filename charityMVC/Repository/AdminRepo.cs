using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using charityMVC.Models;

namespace charityMVC.Repository
{
    public class AdminRepo : IAdminRepo
    {
        public List<Task<Admin>> GetAll { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Task<Admin> GetSuperAdmin { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Task<bool> Delete { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}