namespace web_proje.Models
{
    public class Doktor
    {
        public int DoktorId {  get; set; }
        public string DoktorAdi { get; set; }
        public string DoktorSoyadi { get; set; }
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