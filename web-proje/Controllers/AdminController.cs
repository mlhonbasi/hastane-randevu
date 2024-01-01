using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using web_proje.Models;

namespace web_proje.Controllers
{
    [Authorize(Roles ="admin")]
    public class AdminController : Controller
    {
        private HastaneContext HastaneContext;
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult HastaneGoster()
        {
            return RedirectToAction("Index", "Hastane");
        }
        public IActionResult PolikinlikGoster()
        {
            return RedirectToAction("Index", "Polikinlik");
        }
        public IActionResult DoktorGoster()
        {
            return RedirectToAction("Index", "Doktor");
        }
        public IActionResult KullaniciGoster()
        {
            return RedirectToAction("Index", "Kullanici");
        }
        public IActionResult RandevuGoster()
        {
            return RedirectToAction("Index", "Randevu");
        }
    }
}
