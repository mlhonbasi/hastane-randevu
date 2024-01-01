using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace web_proje.Models
{
    public class CalismaSaati
    {
        [Key]
        public int CalismaSaatId { get; set; }
        public DateTime secilenTarih  { get; set; }
        public TimeSpan Baslangic { get; set; } = new TimeSpan(9, 0, 0);
        public TimeSpan Bitis { get; set; }= new TimeSpan(12, 0, 0);


    }
}
