namespace LimburgseWolvenApp.Migrations
{
    using LimburgseWolvenApp.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LimburgseWolvenApp.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            SetSqlGenerator("MySql.Data.MySqlClient", new MySql.Data.Entity.MySqlMigrationSqlGenerator());
        }

        protected override void Seed(LimburgseWolvenApp.Models.ApplicationDbContext context)
        {
            var reservaties = new List<Reservatie>();
            var groepen = new List<Groep>();
            var personen = new List<Persoon>();
            var dorpen = new List<Dorp>();
            Random rnd = new Random();
            int i = 1;
            while (i < 73)
            {
                var res = new Reservatie();
                reservaties.Add(res);
                int aantalInReservatie = rnd.Next(1, 8);
                var groep1 = new Groep(res);
                groepen.Add(groep1);
                Groep groep2 = null;
                if (aantalInReservatie > 5)
                {
                    groep2 = new Groep(res);
                    groepen.Add(groep2);
                }
                for (int j = 1; j <= aantalInReservatie; j++)
                {
                    if (aantalInReservatie > 5 && j > aantalInReservatie / 2)
                    {
                        personen.Add(new Persoon(res, groep2, "naam" + j, "naam" + j + "@domein.com"));
                    }
                    else
                    {
                        personen.Add(new Persoon(res, groep1, "naam" + j, "naam" + j + "@domein.com"));
                    }
                    i++;
                } // j
            } // i

            reservaties.ForEach(s => context.Reservaties.Add(s));
            groepen.ForEach(g => context.Groepen.Add(g));
            personen.ForEach(p => context.Personen.Add(p));
            context.SaveChanges();
        }
    }
}
