using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using charityMVC.Models;

namespace charityMVC.Repository
{
    public interface IAdminRepo
    {
        public Task<List<Admin>> GetAll ();
        public Task<Admin> GetSuperAdmin ();
        public Task<Admin> GetAdminById (string id);
        public Task<bool> DeleteAdmin (string id);
        public Task<Clerk> AddClerk (Clerk clerk);
        public Task<Admin> addAdmin(Admin admin); 
        public Task<bool> DeleteClerk (int id);
        public Task<Clerk> GetClerkById (int id);
        public Task<points> EditPoints (points points);
        public Task<bool> UpdateClerk(Clerk clerk );
        public Task<List<Clerk>> GetClerks ();
        public  Task<Clerk> FindClerk (string name, string password);
         public  Task<Admin> FindAdmin (string name, string password);
        public  bool FoundAdmin (string name, string password);
        public  bool FoundClerk (string name, string password);
        public  Task<points> Points();



        
    }
}