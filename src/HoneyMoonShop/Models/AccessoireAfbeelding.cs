using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HoneymoonShop.Models
{
    public class AccessoireAfbeelding
    {
        [Key]
        public String Afbeelding { get; set; }

        [ForeignKey("Artikelnummer")]
        public Accessoire Accessoire { get; set; }
    }
}
