using Code.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Code.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Catagory> Catagories { get; set; }
        public DbSet<bank> Banks { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Arthmeticoperation> Arthmeticoperations { get; set; }
        public DbSet<PaymentDeatails> PaymentDeatails { get; set; }
      
     
       
       
    }
}
