using LimburgseWolvenApp.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using MySql.Data.Entity;

namespace LimburgseWolvenApp.DAL
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class WolvenContext : DbContext
    {
        public WolvenContext() : base("WolvenContext") { }

        public DbSet<Bewoner> Bewoners { get; set; }
        public DbSet<Dorp> Dorpen { get; set; }
        public DbSet<Gestorvene> Gestorvenen { get; set; }
        public DbSet<Groep> Groepen { get; set; }
        public DbSet<Persoon> Personen { get; set; }
        public DbSet<Reservatie> Reservaties { get; set; }
        public DbSet<Rol> Rollen { get; set; }
        public DbSet<Zwerver> Zwervers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<User>().HasOptional(u => u.Dorp);
            modelBuilder.Entity<Bewoner>().HasOptional(b => b.Rol);
        }
    }
}