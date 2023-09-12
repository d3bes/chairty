using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using charityMVC.Models;
using System.Collections.Generic;
using System.Net;
using System.Collections.Specialized;
using Microsoft.EntityFrameworkCore;

namespace charityMVC.Repository
{
    public class smsRepo : IsmsRepo
    {
        private Context _context;
        private IUserRepo _userRepo;
        public smsRepo(Context context, IUserRepo userRepo)
    {
        _context = context;
        _userRepo = userRepo;
    }
        public async Task<smsValidation> Create(string userId)
        {
            

            //make random code
            Random rand = new Random();
            int randomNumber = rand.Next(100000, 999999); // Generates a random number between 100000 and 999999 (inclusive)
            // string random6DigitNumber = randomNumber.ToString("D6"); // Ensures it's always 6 digits with leading zeros if necessar
            
            smsValidation _smsValidation = new smsValidation
            {
                userId = userId,
                ValidationCode = randomNumber
            };

            User user = await _userRepo.GetUserById(userId);
            
            sendSMS(_smsValidation.ValidationCode.ToString(), user.phone, "Test sms" );
            var smsModel= _context.smsValidation.FirstOrDefaultAsync(s=>s.userId == userId);
            if (smsModel != null)
            {
              _context.Update(_smsValidation);
               _context.SaveChanges();
            }
            else
            {
            await _context.AddAsync(_smsValidation);
            await _context.SaveChangesAsync();
            }
            return _smsValidation;
        }


        public async Task<smsValidation> GetSmsValidation(string userId)
        {
            return await _context.smsValidation.FirstOrDefaultAsync(u => u.userId == userId);
        }

      public string sendSMS(string code, string phone, string sender)
        {
            String message = System.Web.HttpUtility.UrlEncode(" \nكود التفعيل\n" + code);
            using (var wb = new WebClient())
            {
                byte[] response = wb.UploadValues("https://api.txtlocal.com/send/", new NameValueCollection()
                {
                {"apikey" , "MzY3NDRkNTk0OTQ1NTEzNzY0Njc2MzczNDc0MTM2NzM="},
                {"numbers" , phone},
                {"message" , message},
                {"sender" , sender}
                });

                string result = System.Text.Encoding.UTF8.GetString(response);
                return result;
            }
        }
    }
}