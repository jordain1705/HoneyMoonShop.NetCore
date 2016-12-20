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

        public List<PakAfspraak> PakAfspraken { get; set; }
        public List<PakAccessoire> PakAccessoires { get; set; }
        public List<Afbeelding> Afbeeldingen { get; set; }
        public List<PakKleur> PakKleuren { get; set; }
    }
}
