using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HoneymoonShop.Models
{
    public class PakAccessoire
    {
        public int AccessoireId { get; set; }
        public Afspraak Accessoire { get; set; }
        public int PakId { get; set; }
        public Pak Pak { get; set; }
    }
}
