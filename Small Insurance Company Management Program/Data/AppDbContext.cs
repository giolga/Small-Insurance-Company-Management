using Microsoft.EntityFrameworkCore;
using Small_Insurance_Company_Management_Program.Models;

namespace Small_Insurance_Company_Management_Program.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
        }
        public DbSet<AuthorizedUser> AuthorizedUsers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<InsuranceProduct> InsuranceProducts { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Typee> Types { get; set; }
        public DbSet<User> Users { get; set; }

        
    }
}
