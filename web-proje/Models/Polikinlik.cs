namespace web_proje.Models
{
    public class Polikinlik
    {
        public int PolikinlikId { get; set; }
        public string PolikinlikAdi { get; set; }
        public int HastaneId { get; set; }
        public Hastane Hastane { get; set; }
        public List<Doktor> Doktorlar { get; set; }

    }
}
