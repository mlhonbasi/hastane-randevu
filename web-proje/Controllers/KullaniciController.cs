using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
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
            if (User.Identity!.IsAuthenticated)
            {
                return RedirectToAction("Index", "Kullanici");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Giris(GirisViewModel girisViewModel)
        {
            if (ModelState.IsValid)
            {
                var kullanici = dbKullaniciContext.Kullanicilar.FirstOrDefault(k => k.KullaniciEmail == girisViewModel.Email && k.KullaniciSifre == girisViewModel.Sifre);

                if (kullanici != null)
                {
                    var kullaniciClaims = new List<Claim>();

                    kullaniciClaims.Add(new Claim(ClaimTypes.NameIdentifier, kullanici.KullaniciId.ToString()));
                    kullaniciClaims.Add(new Claim(ClaimTypes.GivenName, kullanici.KullaniciAdi ?? ""));

                    if (kullanici.KullaniciEmail == "G221210350@ogr.sakarya.edu.tr"){
                        kullaniciClaims.Add(new Claim(ClaimTypes.Role, "admin"));
                    }
                    else
                    {
                        kullaniciClaims.Add(new Claim(ClaimTypes.Role, "kullanici"));
                    }
                    var claimsIdentity = new ClaimsIdentity(kullaniciClaims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var authProperties = new AuthenticationProperties
                    {
                        IsPersistent = true
                    };
                    await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity),
                        authProperties);

                    var kullaniciRoles = kullaniciClaims
                    .Where(c => c.Type == ClaimTypes.Role)
                    .Select(c => c.Value)
                    .ToList();

                    if (kullaniciRoles.Contains("admin"))
                    {
                        return RedirectToAction("Index", "Admin");
                    }
                    else if(kullaniciRoles.Contains("kullanici"))
                    {
                        TempData["kullaniciAdi"] = kullanici.KullaniciAdi;
                        return RedirectToAction("HosgeldinSayfasi", "Kullanici");
                    }                 
                }
                else{
                    ModelState.AddModelError("", "Kullanıcı adı veya şifre yanlış");
                }              
            }
            return View(girisViewModel);
        } 
 
        public async Task<IActionResult> Cikis()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Giris");
        }
        public IActionResult Kayit()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Kayit([Bind("KullaniciAdi, KullaniciSoyadi, KullaniciEmail, KullaniciSifre")]Kullanici yeniKullanici)
        {
            if(ModelState.IsValid)
            {     
                if(yeniKullanici.KullaniciEmail=="G221210350@ogr.sakarya.edu.tr" && 
                    yeniKullanici.KullaniciSifre == "sau")
                {
                    yeniKullanici.isAdmin = true;
                }          
                dbKullaniciContext.Add(yeniKullanici);
                await dbKullaniciContext.SaveChangesAsync();

                return RedirectToAction("Giris");
            }
            else
            {
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

        public IActionResult HosgeldinSayfasi()
        {           
            return View();
        }

    }
}
