using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LimburgseWolvenApp.Models
{
    public class Groep
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int GroepID { get; set; }

        public virtual Reservatie Reservatie { get; set; }
        public virtual ICollection<Persoon> Personen { get; set; }

        public Groep(Reservatie res)
        {
            Reservatie = res;
        }
    }
}