using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using charityMVC.Models;

namespace charityMVC.Repository
{
    public interface IUserRepo
    {
        public  Task<List<User>>  GetAllUsers();
        Task<User> GetUserById(string id);
        public  Task<List<User>> GetCityUsers(string city);

        public Task<User> AddUser (User user);
        public Task<User> Update (User user);
        public Task<bool> SoftDeleteUser (string id);
        public Task<bool> HardDeleteUser(string id);

        public Task<bool> Uploadimage(IFormFile formFile,string filePath);

        public  Task<int> GetPoints(User user);

        public User Find(string id,string password);

        public bool Found(string id,string password);

        public  Task<bool> AddRole (Roles role);

        public  Task<Roles> GetRoles(string id);

        public Task<User> UploadAllFiles(IFormFile id_image, IFormFile family_card_image,
                         IFormFile disability_proof, IFormFile debt_proof, IFormFile rent_proof ,User user);

       
        
    }
}