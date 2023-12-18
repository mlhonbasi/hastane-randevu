namespace web_proje.Models
{
    public class Hastane
    {
        public int HastaneId { get; set; }
        public string HastaneAd { get; set; }
        public List<Polikinlik> Polikinlikler { get; set; }
    }
}
