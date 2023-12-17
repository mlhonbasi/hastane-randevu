using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace web_proje.Models
{
    public class Kullanici
    {
        private int KullaniciID { get; set; }
        [Required(ErrorMessage = "Kullanıcı adı boş geçilemez.")]
        [Display(Name = "Ad")]
        public string KullaniciAdi { get; set; }
        [Required(ErrorMessage = "Kullanıcı soyadı boş geçilemez.")]
        [Display(Name = "Soyad")]
        public string KullaniciSoyadi { get; set; }
        [Required(ErrorMessage = "Kullanici E-Mail boş geçilemez.")]
        [EmailAddress(ErrorMessage ="Geçerli bir E-Mail giriniz.")]
        [Display(Name = "E-Mail")]
        public MailAddress KullaniciEmail { get; set; }

        [Required(ErrorMessage = "Şifre boş geçilemez.")]
        [Display(Name = "Şifre")]
        public string KullaniciSifre { get; set; }

    }
}
