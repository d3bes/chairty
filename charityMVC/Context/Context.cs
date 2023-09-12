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
      public DbSet<AcceptedsPayment> acceptedsPayments { get; set; }
      public DbSet<PayMent> PayMents { get; set; }
      public DbSet<Roles> Roles { get; set; }
      public DbSet<Admin> admin { get; set; }
      public DbSet<Clerk> clerk { get; set; }
      public DbSet<User> user { get; set; }
      public DbSet<Support> support { get; set; }
      public DbSet<points> points { get; set; }
      public DbSet<Accepted> Accepteds { get; set; } 
      public DbSet<smsValidation> smsValidation { get; set; }


    //   public void DropClerkTable()
    //{
    //    Database.ExecuteSqlRaw("DROP TABLE IF EXISTS Support;");
    //}
      public Context(DbContextOptions<Context> options) : base(options) 
        {
        }

       

        //      protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     modelBuilder.Entity<Accepted>()
        //         .HasIndex(a => a.userId)
        //         .IsUnique();

        //     // Other entity configurations

        //     base.OnModelCreating(modelBuilder);
        // }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    //optionsBuilder.UseSqlServer("Data Source=SQL8006.site4now.net;Initial Catalog=db_a9e627_charity4;User Id=db_a9e627_charity4_admin;Password=NKB5d7$zkxMy_qt");
        //    optionsBuilder.UseNpgsql("Host=ep-broad-tooth-96391691-pooler.ap-southeast-1.aws.neon.tech; Database=charity; User Id=fc297269;Password=UFoyG1iEI7tW");
        //    base.OnConfiguring(optionsBuilder);
        //}

    }
}