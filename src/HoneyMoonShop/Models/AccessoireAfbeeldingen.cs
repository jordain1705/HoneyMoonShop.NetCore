using System;

namespace HoneymoonShop.Models
{
    public class AccessoireAfbeeldingen
    {
        public int AccessoireAfbeeldingenId{get;set;}
        public String SourceLocation { get; set; }
        public String AccessoireAfbeeldingId { get; set; }
        public int AccessoireId { get; set; }
        public Accessoire Accessoire { get; set; }
    }
}
