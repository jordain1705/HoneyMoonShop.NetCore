using System;
using System.Collections.Generic;

namespace HoneymoonShop.Models
{
    public class Jurk
    {
        public int JurkId { get; set; }
        public int Artikelnummer { get; set; }
        public String Merk { get; set; }
        public int MinPrijs { get; set; }
        public int MaxPrijs { get; set; }
        public String Omschrijving { get; set; }
        public String Stijl { get; set; }
        public String Neklijn { get; set; }
        public String Silhouette { get; set; }
        public int NieuweCollectie { get; set; }

        public List<JurkAfspraak> JurkAfspraken { get; set; }
        public List<JurkAccessoire> JurkAccessoires { get; set; }
        public List<Afbeelding> Afbeeldingen { get; set; }
        public List<JurkKleur> JurkKleuren { get; set; }
    }
}
