using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HoneymoonShop.Models
{
    public class KledingAfbeelding
    {
        public String SourceLocation { get; set; }
        public String Artikelnummer { get; set; }
        public Kleding Kleding { get; set; }
    }
}
