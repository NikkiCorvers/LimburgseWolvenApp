using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LimburgseWolvenApp.Models
{
    public class Dorp
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int DorpID { get; set; }
        public string Naam { get; set; }

        public virtual ICollection<Rol> Rollen { get; set; }
    }
}