using System;
using System.Collections.Generic;

namespace HoneymoonShop.Models
{
    public class Pak
    {
        public int PakId { get; set; }
        public int Artikelnummer { get; set; }
        public String Merk { get; set; }
        public int MinPrijs { get; set; }
        public int MaxPrijs { get; set; }
        public String Omschrijving { get; set; }
        public String Model { get; set; }

        public List<PakAfspraak> KledingAfspraken { get; set; }
        public List<PakAccessoire> PakAccessoires { get; set; }
    }
}
