using Microsoft.AspNetCore.Mvc;

namespace web_proje.Controllers
{
    public class KullaniciController : Controller
    {
        public IActionResult Giris()
        {
            return View();
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
