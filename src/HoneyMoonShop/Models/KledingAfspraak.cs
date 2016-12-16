using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HoneymoonShop.Models
{
    public class KledingAfspraak
    {
        public int Id { get; set; }
        public Afspraak Afspraak { get; set; }
        public int Artikelnummer { get; set; }
        public Kleding Kleding { get; set; }

    }
}
