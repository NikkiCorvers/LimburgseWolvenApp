using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using LimburgseWolvenApp.Models;

namespace LimburgseWolvenApp.DAL
{
    public class WolvenInitializer : System.Data.Entity.DropCreateDatabaseAlways<WolvenContext>
    {
        protected override void Seed(WolvenContext context)
        {
            var reservaties = new List<Reservatie>();
            var groepen = new List<Groep>();
            var personen = new List<Persoon>();
            var dorpen = new List<Dorp>();
            int i = 1;
            while (i < 73)
            {
                var res = new Reservatie();
                reservaties.Add(res);
                Random rnd = new Random();
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