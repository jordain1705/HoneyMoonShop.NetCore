using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace HoneymoonShop.Models
{
    public class Afspraak
    {
        [Key]
        public int Id { get; set; }
        public String Voornaam { get; set; }
        public String Achternaam { get; set; }
        public EmailAddressAttribute EmailAdres { get; set; }
        public String SoortAfspraak { get; set; }
        public int TelefoonNummer { get; set; }
        public DateTime Trouwdatum { get; set; }
        public DateTime DatumTijd { get; set; }

        public int Artikelnummer { get; set; }
        [ForeignKey("Artikelnummer")]
        public Kleding Kleding { get; set; }
    }
}
