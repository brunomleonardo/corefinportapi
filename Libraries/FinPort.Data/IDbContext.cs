using FinPort.Core;
using Microsoft.EntityFrameworkCore;

namespace FinPort.Data
{
    public interface IDbContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity;
        int SaveChanges();
    }
}