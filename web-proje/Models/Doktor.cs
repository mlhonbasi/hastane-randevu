using System.ComponentModel.DataAnnotations;

namespace web_proje.Models
{
    public class Doktor
    {
        [Display(Name ="Doktor No")]
        public int DoktorId {  get; set; }
        [Display(Name = "Doktor Adı")]
        public string DoktorAdi { get; set; }
        [Display(Name = "Doktor Soyadı")]
        public string DoktorSoyadi { get; set; }
        [Display(Name = "Ana Bilim Dalı")]
        public string AnaBilimDali { get; set; }
        public int PolikinlikId { get; set; }
        public Polikinlik Polikinlik { get; set; }

        public List<Randevu> Randevular { get; set; }
        public class CalismaSaatleri
        {
            public DayOfWeek Gun { get; set; }
            public TimeSpan Baslangic { get; set; }
            public TimeSpan Bitis { get; set; }

            public List<CalismaSaatleri> DoktorCalismaSaatleri { get; set; }
        }
    }
}