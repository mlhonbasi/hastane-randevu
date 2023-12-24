using System.ComponentModel.DataAnnotations;

namespace web_proje.Models
{
    public class Polikinlik
    {
        [Display(Name = "Polikinlik No")]
        public int PolikinlikId { get; set; }
        [Display(Name = "Polikinlik")]
        public string PolikinlikAdi { get; set; }
        public int HastaneId { get; set; }
        public Hastane Hastane { get; set; }
        public List<Doktor> Doktorlar { get; set; }

    }
}
