using Microsoft.AspNetCore.Mvc;
using fantasy_shop.Models;

namespace fantasy_shop.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
