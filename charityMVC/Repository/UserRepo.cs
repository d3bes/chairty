using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using charityMVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using charityMVC.ViewModels;

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
           var Points = await context.points.FirstOrDefaultAsync(i=> i.Id == 2 );
        
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
            if(!user.income_support) ResultPoints += points.hasNo_income_support;
            if(user.children_count==1) ResultPoints += points.children_count_1;
            if(user.children_count==2) ResultPoints += points.children_count_2;
            if(user.children_count==3) ResultPoints += points.children_count_3;
            if(user.children_count==4) ResultPoints += points.children_count_4;
            if(user.children_count==5) ResultPoints += points.children_count_4p;

            return ResultPoints;
            
        }

        public async Task<User> AddUser(User user)
        {
            context.user.Add(user);
             context.SaveChanges();
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
             context.SaveChanges();
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
                context.SaveChanges();
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
             context.SaveChanges();
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


        public User Find(string id,string password)
        {
            User user = context.user
                        .FirstOrDefault(u=> u.id == id && u.password == password && ! u.isDeleted);

            return user;

        }

        public bool Found(string id,string password)
        {
              User user = context.user
                        .FirstOrDefault(u=> u.id == id && u.password == password  && ! u.isDeleted);

                // return user != null? true : false;

                return user != null;


        }

        public bool AddRole (Roles role)
        {
        
            context.Roles.Add(role);
            context.SaveChanges();
            return true;

        }

        public async Task<Roles> GetRoles(string id)
        {
            return await context.Roles.FirstOrDefaultAsync(r=> r.id == id);
        }

        public async Task<User> UploadAllFiles(IFormFile id_image, IFormFile family_card_image, IFormFile disability_proof
                                    , IFormFile debt_proof, IFormFile rent_proof, User user)
        {
                    try{
                    // List of form files to be uploaded
                        List<IFormFile> formFiles = new List<IFormFile> { id_image, family_card_image, disability_proof, debt_proof, rent_proof };
                        
                        foreach (var file in formFiles)
                        {
                            if (file != null)
                            {
                                DateTime date = DateTime.UtcNow;
                                string formattedDateTime = date.ToString("yyyyMMddHHmm");

                                string UploadPath = Path.Combine(_webHostEnvironment.WebRootPath, "userImages");
                                // string fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                                string fileName = formattedDateTime + "_" + user.id + "_" + file.FileName;
                                string filePath = Path.Combine(UploadPath, fileName);
                                
                                // Upload the image file
                             await Uploadimage(file, filePath);
                                
                                // Assign the uploaded file path to the corresponding property in the user object
                                if (file == id_image) user.id_image = Path.Combine("\\userImages", fileName);
                                else if (file == family_card_image) user.family_card_image = Path.Combine("\\userImages", fileName);
                                else if (file == disability_proof) user.disability_proof = Path.Combine("\\userImages", fileName);
                                else if (file == debt_proof) user.debt_proof = Path.Combine("\\userImages", fileName);
                                else if (file == rent_proof) user.rent_proof = Path.Combine("\\userImages", fileName);
                            }
                        }
                        return user;
                    }
                    catch(InvalidOperationException ex)
                    {
                         Console.WriteLine(ex.ToString()); 
                         return user;
                       
                    }


        }


    }
}