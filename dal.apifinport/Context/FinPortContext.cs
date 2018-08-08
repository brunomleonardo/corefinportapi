
using entities.apifinport.DtoModels;
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
        public virtual DbSet<Currencies> Currencies { get; set; }
        public virtual DbSet<ExchangeProducts> ExchangeProducts { get; set; }
        public virtual DbSet<Exchanges> Exchanges { get; set; }
        public virtual DbSet<ExchangeTaxes> ExchangeTaxes { get; set; }
        public virtual DbSet<MajorIndices> MajorIndices { get; set; }
        public virtual DbSet<MarketProducts> MarketProducts { get; set; }
        public virtual DbSet<Markets> Markets { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<TechnicalValues> TechnicalValues { get; set; }
        public virtual DbSet<UserExchangeTaxes> UserExchangeTaxes { get; set; }
        public virtual DbSet<UserOperationHistories> UserOperationHistories { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<WalletDeposits> WalletDeposits { get; set; }
        public virtual DbSet<Wallets> Wallets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=DESKI90ACAD5\SQLEXPRESSMVC;Initial Catalog=FinPortDb;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Currencies>(entity =>
            {
                entity.HasKey(e => e.CurrencyId);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Designation)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Symbol)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ExchangeProducts>(entity =>
            {
                entity.HasKey(e => e.ExchangeProductId);

                entity.HasOne(d => d.Exchange)
                    .WithMany(p => p.ExchangeProducts)
                    .HasForeignKey(d => d.ExchangeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ExchangeProducts_Exchanges");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ExchangeProducts)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ExchangeProducts_Products");
            });

            modelBuilder.Entity<Exchanges>(entity =>
            {
                entity.HasKey(e => e.ExchangeId);

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Designation).IsRequired();

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Symbol).IsRequired();

                entity.HasOne(d => d.Currency)
                    .WithMany(p => p.Exchanges)
                    .HasForeignKey(d => d.CurrencyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Exchanges_Currencies");
            });

            modelBuilder.Entity<ExchangeTaxes>(entity =>
            {
                entity.HasKey(e => e.ExchangeTaxId);

                entity.Property(e => e.ExchangeTaxId).ValueGeneratedOnAdd();

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.ExchangeTax)
                    .WithOne(p => p.ExchangeTaxes)
                    .HasForeignKey<ExchangeTaxes>(d => d.ExchangeTaxId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ExchangeTaxes_Exchanges");
            });

            modelBuilder.Entity<MajorIndices>(entity =>
            {
                entity.HasKey(e => e.MajorIndiceId);

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Designation).IsRequired();

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.TechnicalValue)
                    .WithMany(p => p.MajorIndices)
                    .HasForeignKey(d => d.TechnicalValueId)
                    .HasConstraintName("FK_MajorIndices_TechnicalValues");
            });

            modelBuilder.Entity<MarketProducts>(entity =>
            {
                entity.HasOne(d => d.Market)
                    .WithMany(p => p.MarketProducts)
                    .HasForeignKey(d => d.MarketId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MarketProducts_Markets");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.MarketProducts)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MarketProducts_Products");
            });

            modelBuilder.Entity<Markets>(entity =>
            {
                entity.HasKey(e => e.MarketId);

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Designation)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasKey(e => e.ProductId);

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.TechnicalValue)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.TechnicalValueId)
                    .HasConstraintName("FK_Products_TechnicalValues");
            });

            modelBuilder.Entity<TechnicalValues>(entity =>
            {
                entity.HasKey(e => e.TechnicalValueId);

                entity.Property(e => e.Change).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.ChangePerc).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.High).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.Last).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.Low).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Prf1Month).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.Prf1Week).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.Prf1Years).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.Prf3Years).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.PrfDaily).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.PrfYtd)
                    .HasColumnName("PrfYTD")
                    .HasColumnType("decimal(18, 4)");
            });

            modelBuilder.Entity<UserExchangeTaxes>(entity =>
            {
                entity.HasKey(e => e.UserExchangeTaxId);

                entity.HasOne(d => d.ExchangeTaxe)
                    .WithMany(p => p.UserExchangeTaxes)
                    .HasForeignKey(d => d.ExchangeTaxeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserExchangeTaxes_ExchangeTaxes");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserExchangeTaxes)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserIndiceTaxes_Users");
            });

            modelBuilder.Entity<UserOperationHistories>(entity =>
            {
                entity.HasKey(e => e.UserOperationId);

                entity.Property(e => e.ConversionValue).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.UserOperationHistories)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserOperationHistories_Products");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserOperationHistories)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserOperationHistories_Users");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.UserId).ValueGeneratedOnAdd();

                entity.Property(e => e.CreatedBy).IsRequired();

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Email).IsRequired();

                entity.Property(e => e.FirstName).IsRequired();

                entity.Property(e => e.LastName).IsRequired();

                entity.Property(e => e.ModifiedBy).IsRequired();

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.Password).IsRequired();

                entity.Property(e => e.Username).IsRequired();

                entity.HasOne(d => d.User)
                    .WithOne(p => p.Users)
                    .HasForeignKey<Users>(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Users_Wallets");
            });

            modelBuilder.Entity<WalletDeposits>(entity =>
            {
                entity.HasKey(e => e.WalletDepositId);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Wallet)
                    .WithMany(p => p.WalletDeposits)
                    .HasForeignKey(d => d.WalletId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WalletDeposits_Wallets");
            });

            modelBuilder.Entity<Wallets>(entity =>
            {
                entity.HasKey(e => e.WalletId);

                entity.Property(e => e.WalletId).ValueGeneratedOnAdd();

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Wallet)
                    .WithOne(p => p.Wallets)
                    .HasForeignKey<Wallets>(d => d.WalletId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Wallets_Currencies");
            });
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<User>()
        //        .HasKey(t => new { t.Id })
        //        .ForSqlServerIsClustered();

        //    modelBuilder.Entity<UserOperationHistory>()
        //        .HasKey(t => new { t.Id });

        //    modelBuilder.Entity<UserOperationHistory>()
        //        .HasOne(pt => pt.User)
        //        .WithMany(p => p.UserOperationHistories)
        //        .HasForeignKey(x => x.UserId);

        //    modelBuilder.Entity<UserOperationHistory>()
        //        .HasOne(pt => pt.Product)
        //        .WithMany(t => t.UserOperationHistories)
        //        .HasForeignKey(x => x.ProductId);

        //    //modelBuilder.Entity<Wallet>()
        //    //    .HasOne(x => x.Currency)
        //    //    .WithOne(x => x.Wallet);

        //    modelBuilder.Entity<Wallet>()
        //        .HasMany(x => x.WalletDeposits)
        //        .WithOne()
        //        .HasForeignKey(x => x.Id);

        //}

        //public DbSet<User> Users { get; set; }
        //public DbSet<Product> Products { get; set; }
        //public DbSet<UserOperationHistory> UserOperationHistories { get; set; }
        //public DbSet<Wallet> Wallets { get; set; }
        //public DbSet<WalletDeposit> WalletDeposits { get; set; }
        //public DbSet<Currency> Currencies { get; set; }
        //public DbSet<Market> Markets { get; set; }
        //public DbSet<Exchange> Exchanges { get; set; }

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