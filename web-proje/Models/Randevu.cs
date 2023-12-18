using System.Reflection.Metadata;

namespace web_proje.Models
{
    public class Randevu
    {
        public int RandevuId { get; set; }

        public DateTime RandevuTarihi { get; set; }
        public int DoktorId { get; set; }
        public Doktor Doktor { get; set; }
        public int KullaniciId { get; set; }
        public Kullanici Kullanici { get; set; }

    }
}
