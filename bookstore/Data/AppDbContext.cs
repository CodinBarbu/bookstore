using bookstore.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;

namespace bookstore.Data
{
    public class AppDbContext: System.Data.Entity.DbContext
    {
        public AppDbContext()
        {

        }

        /*public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }*/

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Autor_Carte>().HasKey(am => new
            {
                am.AutorId,
                am.CarteId
            });

            modelBuilder.Entity<Autor_Carte>().HasOptional(m => m.Carte).WithMany(am => am.Autori_Carti).HasForeignKey(m => m.CarteId);
            modelBuilder.Entity<Autor_Carte>().HasOptional(m => m.Autor).WithMany(am => am.Autori_Carti).HasForeignKey(m => m.AutorId);
            base.OnModelCreating(modelBuilder);
        }

       /* protected override void OnModelCreating(ModelBuilder modelBuilder)
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
       */
        public System.Data.Entity.DbSet<Autor> Autori { get; set; }
        public System.Data.Entity.DbSet<Carte> Carti { get; set; }
        public System.Data.Entity.DbSet<Autor_Carte> Autori_Carti { get; set; }
        public System.Data.Entity.DbSet<Editura> Edituri { get; set; }

    }
}
