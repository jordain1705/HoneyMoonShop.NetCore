using System;

namespace HoneymoonShop.Models
{
    public class Afbeelding
    {
        public String AfbeeldingId { get; set; }
        public int Artikelnummer { get; set; }
        public String SourcePath { get; set; }

        public Jurk Jurk { get; set; }
        public Pak Pak { get; set; }
        public Accessoire Accessoire { get; set; }
    }
}
