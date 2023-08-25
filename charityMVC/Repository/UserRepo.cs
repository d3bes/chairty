using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using charityMVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;


namespace charityMVC.Repository
{
    public class UserRepo : IUserRepo
    {
        private Context context;
         private IWebHostEnvironment _webHostEnvironment;

        public UserRepo(Context _context, IWebHostEnvironment webHostEnvironment)
        {
            context= _context;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<int> GetPoints(User user)
        {
           var Points = await context.points.FirstOrDefaultAsync(i=> i.Id == 1 );
        
           var result = await CalculatePoints(user,Points) ;
            return result;

        }

        public async Task<int> CalculatePoints(User user, points points)
        {
            int ResultPoints = 0;
            if((bool)user.elderly) ResultPoints+= points.elderly;
            if((bool)user.widow) ResultPoints+= points.widow;
             if((bool)user.debt) ResultPoints += points.has_debt;
            if((bool)user.disability) ResultPoints += points.has_disability;
            if((bool)user.house_rent) ResultPoints += points.house_is_rent;
            if((bool)user.income_support) ResultPoints += points.hasNo_income_support;
            if(user.children_count==1) ResultPoints += points.children_count_1;
            if(user.children_count==2) ResultPoints += points.children_count_2;
            if(user.children_count==3) ResultPoints += points.children_count_3;
            if(user.children_count==4) ResultPoints += points.children_count_4;
            if(user.children_count==5) ResultPoints += points.children_count_4p;

            return ResultPoints;
            
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

        public async Task<bool> Uploadimage(IFormFile formFile,string filePath) //uplaod to wwwroot\userImages
        {
         

        try
        {
            using(FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
               await formFile.CopyToAsync(fileStream);
                return true;
            }
            
        }
        catch
        {
            return false;
        }

        }
    }
}