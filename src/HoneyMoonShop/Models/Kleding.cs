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
        public int Artikelnummer { get; set; }
        public String Merk { get; set; }
        public int Prijs { get; set; }
        public String Omschrijving { get; set; }

        public List<KledingAfspraak> KledingAfspraken { get; set; }
        public List<KledingAccessoire> KledingAccessoires { get; set; }
        public List<KledingAfbeeldingen> KledingAfbeeldingen { get; set; }
        public List<KledingKleuren> KledingKleuren { get; set; }
    }
}
