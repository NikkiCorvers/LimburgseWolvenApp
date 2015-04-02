using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace LimburgseWolvenApp.Models
{
    public class Rol
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int RolID { get; set; }
        public String Naam { get; set; }
        public int Punten { get; set; }
        public int Prioriteit { get; set; }
        public String Beschrijving { get; set; }
    }
}
