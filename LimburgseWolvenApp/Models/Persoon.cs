using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LimburgseWolvenApp.Models
{
    public class Persoon
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int PersoonID { get; set; }
        public string Naam { get; set; }
        public string Emailadres { get; set; }

        public virtual Reservatie Reservatie { get; set; }
        public virtual Groep Groep { get; set; }

        public Persoon(Reservatie res, Groep groep, string naam, string emailadres)
        {
            Reservatie = res;
            Groep = groep;
            Naam = naam;
            Emailadres = emailadres;
        }
    }
}