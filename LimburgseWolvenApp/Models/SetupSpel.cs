using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LimburgseWolvenApp.Models
{
    public class SetupSpel
    {
        public void setupRondes()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var aantalDeelnemers = context.Personen.Count();
        }
    }
}