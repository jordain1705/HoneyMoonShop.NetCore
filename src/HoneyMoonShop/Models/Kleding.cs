using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace HoneymoonShop.Models
{
    public class Kleding
    {
        [Key]
        public int Artikelnummer { get; set; }
        public String Merk { get; set; }
        public int Prijs { get; set; }
        public String Omschrijving { get; set; }

        //public int? Id { get; set; } //can be null
        //[ForeignKey("Id")]
        //public virtual Afspraak Afspraak { get; set; }

        //public virtual ICollection<Afspraak> Afspraken { get; set; }
        //public virtual ICollection<Pak> Pakken { get; set; }
        public virtual ICollection<Jurk> Jurken { get; set; }
        //public virtual ICollection<KledingKleur> KledingKleuren { get; set; }
        //public virtual ICollection<Accessoire> Accessoires { get; set; }
    }
}
