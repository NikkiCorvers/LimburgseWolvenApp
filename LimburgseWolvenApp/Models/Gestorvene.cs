using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LimburgseWolvenApp.Models
{
    public class Gestorvene
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int GestorveneID { get; set; }
        public int TellerNachten { get; set; }

        public virtual Bewoner Bewoner { get; set; }
    }
}