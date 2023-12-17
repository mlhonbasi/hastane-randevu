namespace web_proje.Models
{
    public class Doktor
    {
        public string DoktorAdi { get; set; }
        public string DoktorSoyadi { get; set; }
        public string AnaBilimDali { get; set; }
        public string Polikinlik { get; set; }

        public class CalismaSaatleri
        {
            public DayOfWeek Gun { get; set; }
            public TimeSpan Baslangic { get; set; }
            public TimeSpan Bitis { get; set; }
        }
    }
}