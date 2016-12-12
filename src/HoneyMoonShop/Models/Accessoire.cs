using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HoneymoonShop.Models
{
    public class Accessoire
    {
        [Key]
        public int Artikelnummer { get; set; }
        public String Categorie { get; set; }
        public String Merk { get; set; }
        public String Geslacht { get; set; }
        public String LinkNaarWebshop { get; set; }
        
        public String KledingArtikelnummer { get; set; }
        [ForeignKey("KledingArtikelnummer")]
        public Kleding Kleding { get; set; }

        public ICollection<AccessoireAfbeelding> AccessoireAfbeeldingen { get; set; }
    }
}
