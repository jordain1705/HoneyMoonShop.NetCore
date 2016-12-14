using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HoneymoonShop.Models
{
    public class KledingKleur
    {
        [Key]
        public String Kleur { get; set; }
        [Key]
        public int Artikelnummer { get; set; }
        [ForeignKey("Artikelnummer")]
        public virtual Kleding Kleding { get; set; }
    }
}
