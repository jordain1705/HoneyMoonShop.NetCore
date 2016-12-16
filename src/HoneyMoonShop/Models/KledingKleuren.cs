using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HoneymoonShop.Models
{
    public class KledingKleuren
    {
        public String KledingKleur { get; set; }
        public int Artikelnummer { get; set; }
        public Kleding Kleding { get; set; }
    }
}
