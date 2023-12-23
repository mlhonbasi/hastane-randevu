using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace web_proje.Models
{
    public class Kullanici
    {
        public int KullaniciId { get; set; }
        [Required(ErrorMessage = "Kullanıcı adı boş geçilemez.")]
        [Display(Name = "Ad")]
        public string KullaniciAdi { get; set; }
        [Required(ErrorMessage = "Kullanıcı soyadı boş geçilemez.")]
        [Display(Name = "Soyad")]
        public string KullaniciSoyadi { get; set; }
        [Required(ErrorMessage = "Kullanici E-Mail boş geçilemez.")]
        [EmailAddress(ErrorMessage ="Geçerli bir E-Mail giriniz.")]
        [Display(Name = "E-Mail")]
        public string KullaniciEmail { get; set; }

        [Required(ErrorMessage = "Şifre boş geçilemez.")]
        [Display(Name = "Şifre")]
        [MaxLength(16,ErrorMessage ="Şifreniz maksimum 16 karakter uzunluğunda olmalı.")]
        public string KullaniciSifre { get; set; }

        public bool isAdmin = false;

        public List<Randevu>? Randevulari { get; set; }
        
    }
}
