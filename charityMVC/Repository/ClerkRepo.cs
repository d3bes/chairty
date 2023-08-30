using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using charityMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace charityMVC.Repository
{
    public class ClerkRepo: IClerkRepo
    {
        private Context _context; 
        public ClerkRepo( Context context)
        {
            _context = context;
        }

        public async Task<List<Clerk>> GetAll()
        {

            var clerks = await _context.clerk.ToListAsync();
            return clerks;
        }

        public async Task<Clerk> GetClerkById(int id)
        {
            var clerk = await _context.clerk.FirstOrDefaultAsync(c=>c.Id == id);
            return clerk;
        }

    }
}