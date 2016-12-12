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

        public int Id { get; set; }
        [ForeignKey("Id")]
        public Afspraak Afspraak { get; set; }

        public ICollection<Afspraak> Afspraken { get; set; }
        public ICollection<Pak> Pakken { get; set; }
        public ICollection<Jurk> Jurken { get; set; }
        public ICollection<KledingAfbeelding> KledingAfbeeldingen { get; set; }
        public ICollection<KledingKleur> KledingKleuren { get; set; }

    }
}
