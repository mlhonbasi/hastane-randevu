using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace web_proje.Models
{
    public class Randevu
    {
        [Display(Name ="Randevu No")]
        public int RandevuId { get; set; }

        public int HastaneId { get; set; }
        public Hastane Hastane { get; set; }
        public int PolikinlikId { get; set; }
        public Polikinlik Polikinlik { get; set; }
        public DateTime RandevuTarihi { get; set; }
        public int DoktorId { get; set; }
        public Doktor Doktor { get; set; }
        public int? KullaniciId { get; set; }
        public Kullanici? Kullanici { get; set; }

    }
}
