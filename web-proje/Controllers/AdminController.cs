using Microsoft.AspNetCore.Mvc;
using web_proje.Models;

namespace web_proje.Controllers
{
    
    public class AdminController : Controller
    {
        private HastaneContext HastaneContext;
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult HastaneGoster()
        {
            return RedirectToAction("Index","HastaneController");
        }
        public IActionResult PolikinlikGoster()
        {
            return RedirectToAction("Index", "PolikinlikController");
        }
        public IActionResult DoktorGoster()
        {
            return RedirectToAction("Index", "DoktorController");
        }
        public IActionResult KullaniciGoster()
        {
            return RedirectToAction("Index", "KullaniciController");
        }
        public IActionResult RandevuGoster()
        {
            return RedirectToAction("Index", "RandevuController");
        }
    }
}
