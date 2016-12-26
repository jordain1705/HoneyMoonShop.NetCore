namespace HoneymoonShop.Models
{
    public class JurkAccessoire
    {
        public int AccessoireId { get; set; }
        public Afspraak Accessoire { get; set; }
        public int JurkId { get; set; }
        public Jurk Jurk { get; set; }
    }
}
