using LimburgseWolvenApp.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using MySql.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity.Migrations.History;

namespace LimburgseWolvenApp.DAL
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class WolvenContext : DbContext
    {
        public WolvenContext() : base("WolvenContext") 
        {
            DbConfiguration.SetConfiguration(new MySql.Data.Entity.MySqlEFConfiguration());
        }

        public DbSet<Bewoner> Bewoners { get; set; }
        public DbSet<Dorp> Dorpen { get; set; }
        public DbSet<Gestorvene> Gestorvenen { get; set; }
        public DbSet<Groep> Groepen { get; set; }
        public DbSet<Persoon> Personen { get; set; }
        public DbSet<Reservatie> Reservaties { get; set; }
        public DbSet<Rol> Rollen { get; set; }
        public DbSet<Zwerver> Zwervers { get; set; }
        //public DbSet<DorpSpelleider> DorpSpelleiders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<HistoryRow>().Property(h => h.MigrationId).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<HistoryRow>().Property(h => h.ContextKey).HasMaxLength(200).IsRequired();

            #region Fix asp.net identity 2.0 tables under MySQL
            // Explanations: primary keys can easily get too long for MySQL's
            // (InnoDB's) stupid 767 bytes limit.
            // With the two following lines we rewrite the generation to keep
            // those columns "short" enough
            modelBuilder.Entity<IdentityRole>()
                .Property(c => c.Name)
                .HasMaxLength(256)
                .IsRequired();

            // We have to declare the table name here, otherwise IdentityUser
            // will be created
            modelBuilder.Entity<IdentityUser>()
                .ToTable("AspNetUsers")
                .Property(c => c.UserName)
                .HasMaxLength(256)
                .IsRequired();
            #endregion

            modelBuilder.Entity<Bewoner>().HasOptional(b => b.Rol);
            //modelBuilder.Entity<DorpSpelleider>().HasOptional(d => d.Dorp);
            //modelBuilder.Entity<DorpSpelleider>().HasRequired(d => d.Spelleider);
        }
    }
}