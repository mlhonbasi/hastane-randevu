using Microsoft.AspNetCore.Mvc;

namespace web_proje.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
