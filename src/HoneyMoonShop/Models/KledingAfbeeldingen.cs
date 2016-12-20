using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HoneymoonShop.Models
{
    public class KledingAfbeeldingen
    {
        public String SourceLocation { get; set; }
        public int KledingAfbeeldingId { get; set; }
        public int KledingId { get; set; }
        public Kleding Kleding { get; set; }
    }
}
