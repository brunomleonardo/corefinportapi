﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication1.Models
{
    public partial class FinPortDbContext : DbContext
    {
        public virtual DbSet<Currencies> Currencies { get; set; }
        public virtual DbSet<ExchangeProducts> ExchangeProducts { get; set; }
        public virtual DbSet<Exchanges> Exchanges { get; set; }
        public virtual DbSet<ExchangeTaxes> ExchangeTaxes { get; set; }
        public virtual DbSet<MajorIndices> MajorIndices { get; set; }
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
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-FM8TQPH\SQLEXPRESS;Initial Catalog=FinPortDb;Integrated Security=True");
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
            });

            modelBuilder.Entity<Markets>(entity =>
            {
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
    }
}