using Microsoft.AspNetCore.Mvc;

namespace WebApplication5.Controllers
{
    public class NewsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
