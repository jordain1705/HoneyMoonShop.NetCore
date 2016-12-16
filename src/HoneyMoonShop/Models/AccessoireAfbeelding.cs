using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HoneymoonShop.Models
{
    public class AccessoireAfbeelding
    {
        public String SourceLocation { get; set; }
        public String AccessoireId { get; set; }
        public Accessoire Accessoire { get; set; }
    }
}
