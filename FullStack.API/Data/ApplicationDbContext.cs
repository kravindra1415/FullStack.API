using FullStack.API.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FullStack.API.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext()
        {

        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
    }
}
