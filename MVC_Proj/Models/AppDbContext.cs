using Microsoft.EntityFrameworkCore;
using MVC_Proj.Models.Entities;

namespace MVC_Proj.Models
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base (options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }

    }
}
