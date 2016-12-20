using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HoneymoonShop.Models
{
    public class PakAfspraak
    {
        public int Id { get; set; }
        public Afspraak Afspraak { get; set; }
        public int PakId { get; set; }
        public Pak Pak { get; set; }
    }
}
