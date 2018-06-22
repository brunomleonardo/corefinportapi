using Microsoft.EntityFrameworkCore;

namespace api_finport.Models
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