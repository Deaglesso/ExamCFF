using FinalExamSaid.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FinalExamSaid.DAL
{
    public class AppDbContext:IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) :base(opt) 
        {

        }
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Setting> Settings { get; set; }
    }
}
