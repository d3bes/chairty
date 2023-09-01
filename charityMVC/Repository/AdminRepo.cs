using System.IO.Enumeration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using charityMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace charityMVC.Repository
{
    public class AdminRepo : IAdminRepo
    {
        private Context _context;
        public AdminRepo(Context context)
        {
            _context= context;
        }

        public async Task<List<Accepted>> GetAccepteds ()
        {
            List<Accepted> accepteds = await _context.Accepteds.ToListAsync();
            return accepteds;
        }
        public async Task<Clerk> AddClerk( Clerk clerk)
        {
            await _context.clerk.AddAsync(clerk);
            await  _context.SaveChangesAsync();


            return clerk;
        }

        public async Task<bool> DeleteAdmin(string id)
        {
            Admin admin = await _context.admin.FirstOrDefaultAsync(admin=>admin.id == id && !admin.isSuperAdmin);

             _context.admin.Remove(admin);
           await  _context.SaveChangesAsync();
             return true;

        }

        public async Task<bool> DeleteClerk(int id)
        {
            Clerk clerk = await GetClerkById(id);
            //  _context.Remove(clerk);
            clerk.isDeleted = true;
            _context.Update(clerk);
           await  _context.SaveChangesAsync();

            return true;
        }
      

      
        public async Task<Admin> GetAdminById(string id)
        {
            return await _context.admin.FirstOrDefaultAsync(admin=>admin.id == id);
        }

        public async Task<List<Admin>> GetAll()
        {
            return await _context.admin.ToListAsync();
        }

        public async Task<Clerk> GetClerkById(int id)
        {
            return await _context.clerk.FirstOrDefaultAsync(c=> c.Id == id);
        }

        public async Task<Admin> GetSuperAdmin()
        {
             return await _context.admin.FirstOrDefaultAsync(admin=>admin.isSuperAdmin);
        }

        public async Task<points> EditPoints(points _points)
        {

             _context.points.Update(_points);
             await _context.SaveChangesAsync();
             return _points;
        }
        public async Task<points> Points()
        {
            points _points = await _context.points.FirstOrDefaultAsync(p=> p.Id == 6);
            return _points;
        }

        public async Task<bool> UpdateClerk(Clerk clerk )
        {
             _context.Update(clerk);
             await _context.SaveChangesAsync();

             return true;

        }

        public async Task<Admin> addAdmin(Admin admin)
        {
            await _context.admin.AddAsync(admin);
            await _context.SaveChangesAsync();
            return admin;
        }

        public async Task<List<Clerk>> GetClerks()
        {
            List<Clerk> clerks =await _context.clerk.Where(c=> !c.isDeleted).ToListAsync();
            return clerks;
        }

        public async Task<Clerk> FindClerk (string name, string password)
        {
            Clerk clerk = _context.clerk
                        .FirstOrDefault(u=> u.name == name && u.password == password  && ! u.isDeleted);

                // return user != null? true : false;

                return clerk;
        }

          public  bool FoundClerk (string name, string password)
        {
            Clerk clerk = _context.clerk
                        .FirstOrDefault(u=> u.name == name && u.password == password  && ! u.isDeleted);

                // return user != null? true : false;

                return clerk!=null;
        }

   public  bool FoundAdmin (string name, string password)
        {
            Admin admin = _context.admin
                        .FirstOrDefault(u=> u.username == name && u.password == password  && ! u.isDeleted);

                // return user != null? true : false;

                return admin!=null;
        }
         public async Task<Admin> FindAdmin (string name, string password)
        {
            Admin admin =  _context.admin
                        .FirstOrDefault(u=> u.username == name && u.password == password  && ! u.isDeleted);

                // return user != null? true : false;

                return admin;
        }


 
    }
}