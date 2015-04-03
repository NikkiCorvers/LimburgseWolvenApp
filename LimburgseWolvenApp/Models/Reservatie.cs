using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LimburgseWolvenApp.Models
{
    public class Reservatie
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ResID { get; set; }

        public virtual ICollection<Groep> Groepen { get; set; }
        public virtual ICollection<Persoon> Personen { get; set; }
    }
}