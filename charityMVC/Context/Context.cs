using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using charityMVC.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace charityMVC
{
    public class Context: DbContext
    {
      public DbSet<Roles> Roles { get; set; }
      public DbSet<Admin> admin { get; set; }
      public DbSet<Clerk> clerk { get; set; }
      public DbSet<User> user { get; set; }
      public DbSet<Support> support { get; set; }
      public DbSet<points> points { get; set; }
      public DbSet<Accepted> Accepteds { get; set; } 

    //    public void DropClerkTable()
    // {
    //     Database.ExecuteSqlRaw("DROP TABLE IF EXISTS clerk;");
    // }
      public Context(DbContextOptions<Context> options) : base(options) 
        {
        }
    //  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //     {
    //       optionsBuilder.UseNpgsql("Host=ep-broad-tooth-96391691.pooler.ap-southeast-1.aws.neon.tech; Database=charity; User Id=fc297269;Password=UFoyG1iEI7tW");
                                    //  postgres://fc297269:UFoyG1iEI7tW@ep-broad-tooth-96391691.ap-southeast-1.aws.neon.tech/charity
    //        base.OnConfiguring(optionsBuilder);
    //     }

    }
}