using Microsoft.DotNet.Tools.Test;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Xunit;
using Xunit.Abstractions;

namespace HoneymoonShop.Models
{
    public class Afspraak
    { 
        public int AfspraakId { get; set; }

        public String Voornaam { get; set; }

        [Required
        (ErrorMessage = "Zorg dat u uw achternaam invult.")]
        public String Achternaam { get; set; }
        public String EmailAdres { get; set; }
        public String SoortAfspraak { get; set; }
        public int TelefoonNummer { get; set; }
        public DateTime Trouwdatum { get; set; }
        public DateTime DatumTijd { get; set; }

        public List<JurkAfspraak> JurkAfspraken { get; set; }
        public List<PakAfspraak> PakAfspraken { get; set; }

        //todo: why an extra relationship?
        public List<JurkAccessoire> JurkAccessoires { get; set; }
        public List<PakAccessoire> PakAccessoires { get; set; }

    }
}
