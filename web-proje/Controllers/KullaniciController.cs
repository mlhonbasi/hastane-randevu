using Microsoft.AspNetCore.Mvc;
using web_proje.Models;

namespace web_proje.Controllers
{
    public class KullaniciController : Controller
    {
        
        public IActionResult Giris(Kullanici kullanici)
        {
            if(ModelState.IsValid) 
            {

            }
            return View(kullanici);
        }

        public IActionResult Kayit()
        {
            return View();
        }

        public IActionResult ProfilGoster()
        {
            return View();
        }
    }
}
