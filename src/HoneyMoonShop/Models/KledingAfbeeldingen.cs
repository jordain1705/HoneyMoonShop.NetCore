using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HoneymoonShop.Models
{
    public class KledingAfbeeldingen
    {
        public String SourceLocation { get; set; }
        public String KledingAfbeelding { get; set; }
        public int Artikelnummer { get; set; }
        public Kleding Kleding { get; set; }
    }
}
