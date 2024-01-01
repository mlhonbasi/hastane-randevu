using System.ComponentModel.DataAnnotations;

namespace web_proje.Models
{
    public class GirisViewModel
    {
        [Required(ErrorMessage = "Kullanici E-Mail boş geçilemez.")]
        [EmailAddress(ErrorMessage = "Geçerli bir E-Mail giriniz.")]
        [Display(Name = "E-Mail")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Şifre boş geçilemez.")]
        [Display(Name = "Şifre")]
        [MaxLength(16, ErrorMessage = "Şifreniz maksimum 16 karakter uzunluğunda olmalı.")]
        [DataType(DataType.Password)]
        public string Sifre { get; set; }
    }
}