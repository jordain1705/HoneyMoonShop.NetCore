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
