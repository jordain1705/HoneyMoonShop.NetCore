using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HoneymoonShop.Models
{
    public class KledingAccessoire
    {
        public int Artikelnummer { get; set; }
        public Kleding Kleding { get; set; }

        public int AccessoireId { get; set; }
        public Accessoire Accessoire { get; set; }
    }
}
