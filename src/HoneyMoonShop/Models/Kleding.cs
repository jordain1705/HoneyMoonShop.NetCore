using System;
using System.Collections.Generic;

namespace HoneymoonShop.Models
{
    public class Kleding
    {
        public int KledingId { get; set; }
        public int Artikelnummer { get; set; }
        public String Merk { get; set; }
        public int MinPrijs { get; set; }
        public int MaxPrijs { get; set; }
        public String Omschrijving { get; set; }

        public List<KledingAfspraak> KledingAfspraken { get; set; }
        public List<KledingAccessoire> KledingAccessoires { get; set; }
        public List<KledingAfbeeldingen> KledingAfbeeldingen { get; set; }
        public List<KledingKleuren> KledingKleuren { get; set; }
    }
}
