using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LimburgseWolvenApp.Models
{
    public class Bewoner
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int BewonerId { get; set; }
        public virtual Persoon Persoon { get; set; }
        public virtual Rol Rol { get; set; }
        public virtual Dorp Dorp { get; set; }
    }
}