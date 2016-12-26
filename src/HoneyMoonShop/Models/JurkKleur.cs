namespace HoneymoonShop.Models
{
    public class JurkKleur
    {
        public int KleurId { get; set; }
        public int JurkId { get; set; }

      
        public Jurk Jurk { get; set; }
        public Kleur Kleur { get; set; }
    }
}
