using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HoneymoonShop.Models
{
    public class Pak
    {
        [Key]
        public int Artikelnummer { get; set; }
        public String Model { get; set; }

        [ForeignKey("Artikelnummer")]
        public Kleding Kleding { get; set; }
    }
}
