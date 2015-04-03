using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace LimburgseWolvenApp.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser
    // class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        static ApplicationDbContext()
        {
            Database.SetInitializer(new MySqlInitializer());
        }

        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<Bewoner> Bewoners { get; set; }
        public DbSet<Dorp> Dorpen { get; set; }
        public DbSet<Gestorvene> Gestorvenen { get; set; }
        public DbSet<Groep> Groepen { get; set; }
        public DbSet<Persoon> Personen { get; set; }
        public DbSet<Reservatie> Reservaties { get; set; }
        public DbSet<Rol> Rollen { get; set; }
        public DbSet<Zwerver> Zwervers { get; set; }
        public DbSet<UserDorp> UserDorpen { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<UserDorp>().HasOptional(u => u.Dorp);
            modelBuilder.Entity<UserDorp>().HasRequired(u => u.Spelleider);
            modelBuilder.Entity<Bewoner>().HasOptional(b => b.Rol);

            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
        }
    }
}