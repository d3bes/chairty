using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using charityMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace charityMVC.Repository
{
    public class UserRepo : IUserRepo
    {
        private Context context;
        public UserRepo(Context _context)
        {
            context= _context;
        }
        public async Task<User> AddUser(User user)
        {
           await context.user.AddAsync(user);
           await  context.SaveChangesAsync();
           return user;
        }

        public  async Task<List<User>> GetAllUsers()
        {
            List<User> users = await context.user.Where(u=> !u.isDeleted).ToListAsync();

            return  users;
        }

        public async Task<List<User>> GetCityUsers(string city)
        {
            List<User> users = await context.user.Where(c=> c.city == city && !c.isDeleted ).ToListAsync();

            return users;
        }

      

        public async Task<User> GetUserById(string id)
        {
            User user = await context.user.FirstOrDefaultAsync(u=> u.id == id);
            return user;
        }

      

        public async Task<bool> HardDeleteUser(string id)
        {
            User user = await GetUserById(id);
            if(user != null )
            {
             context.user.Remove(user);
             return true;
            }
            else
            {
            return false;
            }
        }

        public  async Task<bool>  SoftDeleteUser(string id)
        {
             User user = await GetUserById(id);

            if(!user.isDeleted)
            { 
                user.isDeleted = true;
                context.user.Update(user);
                return true;
            }
            else
            {
            return false;
            }
        }

        public async Task<User> Update(User user)
        {
            context.Update(user);
            await context.SaveChangesAsync();
            return user;
        }
    }
}