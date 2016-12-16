using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HoneymoonShop.Models
{
    public class AccessoireAfbeeldingen
    {
        public String SourceLocation { get; set; }
        public String AccessoireAfbeelding { get; set; }
        public int AccessoireId { get; set; }
        public Accessoire Accessoire { get; set; }
    }
}
