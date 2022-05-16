﻿using bookstore.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace bookstore.Data
{
    public class AppDbContext: IdentityDbContext<ApplicationUser>
    {
        public AppDbContext()
        {

        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Autor_Carte>().HasKey(am => new
            {
                am.AutorId,
                am.CarteId
            });

            modelBuilder.Entity<Autor_Carte>().HasOne(m => m.Carte).WithMany(am => am.Autori_Carti).HasForeignKey(m => m.CarteId);
            modelBuilder.Entity<Autor_Carte>().HasOne(m => m.Autor).WithMany(am => am.Autori_Carti).HasForeignKey(m => m.AutorId);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Autor> Autori { get; set; }
        public DbSet<Carte> Carti { get; set; }
        public DbSet<Autor_Carte> Autori_Carti { get; set; }
        public DbSet<Editura> Edituri { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }


    }
}