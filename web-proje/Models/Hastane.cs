using System.ComponentModel.DataAnnotations;

namespace web_proje.Models
{
    public class Hastane
    {
        [Display(Name = "Hastane No")]
        public int HastaneId { get; set; }
        [Display(Name ="Hastane")]
        public string HastaneAdi { get; set; }
        public List<Polikinlik> Polikinlikler { get; set; }
        public List<Randevu> Randevular { get; set; }
    }
}
