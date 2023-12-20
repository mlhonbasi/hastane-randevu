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
        [StringLength(16, MinimumLength =8,ErrorMessage ="Şifreniz 8-16 karakter uzunluğunda olmalıdır.")]
        public string KullaniciSifre { get; set; }
        
    }
}
