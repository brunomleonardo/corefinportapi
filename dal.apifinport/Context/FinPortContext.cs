using entities.apifinport.Entities;
using entities.apifinport.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace dal.apifinport.Context
{
    public class FinPortContext : DbContext
    {
        public FinPortContext(DbContextOptions<FinPortContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(t => new { t.Id })
                .ForSqlServerIsClustered();

            modelBuilder.Entity<UserOperationHistory>()
                .HasKey(t => new { t.Id });

            modelBuilder.Entity<UserOperationHistory>()
                .HasOne(pt => pt.User)
                .WithMany(p => p.UserOperationHistories)
                .HasForeignKey(pt => pt.UserId);

            modelBuilder.Entity<UserOperationHistory>()
                .HasOne(pt => pt.Ticker)
                .WithMany(t => t.UserOperationHistories)
                .HasForeignKey(pt => pt.TickerId);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Ticker> Tickers { get; set; }
        public DbSet<UserOperationHistory> UserOperationHistories { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<WalletDeposit> WalletDeposits { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public override int SaveChanges()
        {
            string UserName = "system.user"; // to validate
            var objects = this.ChangeTracker.Entries<BaseEntity>()
                    .Where(x => x.State == EntityState.Added | x.State == EntityState.Modified).ToList();

            foreach (var obj in objects)
            {
                if (obj.State == EntityState.Added)
                {
                    obj.Entity.CreatedBy = UserName;
                    obj.Entity.ModifiedBy = UserName;
                    obj.Entity.CreatedOn = System.DateTime.Now;
                    obj.Entity.ModifiedOn = System.DateTime.Now;
                }
                else if (obj.State == EntityState.Modified)
                {
                    obj.Entity.ModifiedBy = UserName;
                    obj.Entity.ModifiedOn = System.DateTime.Now;
                }
            }

            try
            {
                return base.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}