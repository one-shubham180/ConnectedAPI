using ConnectedBackEnd.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConnectedBackEnd.Data
{
    public class ApplicationDBContext: DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> Options)
            : base(Options)
        {
            
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
