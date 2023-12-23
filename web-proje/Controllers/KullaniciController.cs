using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using web_proje.Models;

namespace web_proje.Controllers
{
    public class KullaniciController : Controller
    {
        private readonly HastaneContext dbKullaniciContext;
        public KullaniciController(HastaneContext context)
        {
            dbKullaniciContext = context;
        }
        public IActionResult Giris()
        {      
            return View();
        }

        public IActionResult GirisYapildi(Kullanici girisKullanici)
        {
            var kullanici = dbKullaniciContext.Kullanicilar.FirstOrDefault(k => k.KullaniciEmail == girisKullanici.KullaniciEmail && k.KullaniciSifre == girisKullanici.KullaniciSifre);
            if(kullanici != null) {
                if (ModelState.IsValid) {
                    return View(kullanici);
                }
            }
            else{
                ModelState.AddModelError("", "E-Mail veya şifre hatalı.");
                return View(Giris);
            }

            
        }
        public IActionResult Kayit()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Kayit([Bind("KullaniciAdi, KullaniciSoyadi, KullaniciEmail, KullaniciSifre")]Kullanici yeniKullanici)
        {
            if(ModelState.IsValid)
            {               
                dbKullaniciContext.Add(yeniKullanici);
                dbKullaniciContext.SaveChanges();

                return RedirectToAction("Giris");
            }
            else{
                return View();
            }
            
           
        }

        public IActionResult ProfilGoster()
        {
            var kullaniciBilgisi = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if(!string.IsNullOrEmpty(kullaniciBilgisi))
            {
                var kullanici = dbKullaniciContext.Kullanicilar.FirstOrDefault(k => k.KullaniciId == int.Parse(kullaniciBilgisi));
                if (kullanici != null)
                {
                    return View("ProfilGoster", kullanici);
                }
            }
            return RedirectToAction("Hata");
        }

    }
}
