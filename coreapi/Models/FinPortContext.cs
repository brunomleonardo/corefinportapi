using Microsoft.EntityFrameworkCore;

namespace coreapi.Models
{
    public class FinPortContext : DbContext
    {
        public FinPortContext(DbContextOptions<FinPortContext> options)
            : base(options)
        {

        }
        public DbSet<User> Users { get; set; }

        public override int SaveChanges()
        {
            
            return base.SaveChanges();
        }

    }
}