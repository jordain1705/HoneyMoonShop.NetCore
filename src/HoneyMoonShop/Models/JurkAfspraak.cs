using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HoneymoonShop.Models
{
    public class JurkAfspraak
    {
        public int Id { get; set; }
        public Afspraak Afspraak { get; set; }
        public int JurkId { get; set; }
        public Jurk Jurk { get; set; }
    }
}
