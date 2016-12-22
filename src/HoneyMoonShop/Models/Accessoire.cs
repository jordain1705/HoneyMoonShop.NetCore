﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HoneymoonShop.Models
{
    public class Accessoire
    {
        public int AccessoireId { get; set; }
        public int AccessoireCode { get; set; }
        public String Categorie { get; set; }
        public String Merk { get; set; }
        public String Geslacht { get; set; }
        public String LinkNaarWebshop { get; set; }

        public List<PakAccessoire> PakAccessoires { get; set; }
        public List<JurkAccessoire> JurkAccessoires { get; set; }
        public List<Afbeelding> Afbeeldingen { get; set; }
    }
}