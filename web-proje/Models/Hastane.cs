namespace web_proje.Models
{
    public class Hastane
    {
        public int HastaneId { get; set; }
        public string HastaneAdi { get; set; }
        public List<Polikinlik> Polikinlikler { get; set; }
    }
}
