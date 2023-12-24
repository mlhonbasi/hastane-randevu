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
            return View();
        }
        public IActionResult PolikinlikGoster()
        {
            return View();
        }
        public IActionResult DoktorGoster()
        {
            return View();
        }
        public IActionResult KullaniciGoster()
        {
            return View();
        }
        public IActionResult RandevuGoster()
        {
            return View();
        }
    }
}
