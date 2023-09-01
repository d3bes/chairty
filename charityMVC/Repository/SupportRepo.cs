using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using charityMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace charityMVC.Repository
{   
    public class SupportRepo : ISupportRepo
    {
        private Context _context;
        public SupportRepo(Context context)
        {
            _context = context;
        }
        public async Task<Support> GetSupportById(int Id)
        {
            Support support = await _context.support
                        .FirstOrDefaultAsync(s=> s.Id == Id);
            return support;
        }

        public async Task<List<Support>> GetUsersSupport(string userId)
        {
           List<Support> supports = await _context.support
                                  .Where(u=> u.userId == userId)
                                  .ToListAsync();
            return supports;
        }

        public async Task<bool> NewSupport(Support support)
        {
            await _context.AddAsync(support);
            await _context.SaveChangesAsync();

            return true;

        }
    }
}