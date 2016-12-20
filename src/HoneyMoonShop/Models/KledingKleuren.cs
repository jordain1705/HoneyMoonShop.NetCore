using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HoneymoonShop.Models
{
    public class KledingKleuren
    {
        public int KledingKleurenId { get; set; }
        public String KledingKleur { get; set; }
        public String Hexacode { get; set; }
        public int KledingId { get; set; }
        public Kleding Kleding { get; set; }
    }
}
