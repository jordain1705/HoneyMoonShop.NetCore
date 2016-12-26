namespace HoneymoonShop.Models
{
    public class PakKleur
    {
        public int KleurId { get; set; }
        public int PakId { get; set; }

        public Pak Pak { get; set; }
        public Kleur Kleur { get; set; }
    }
}
