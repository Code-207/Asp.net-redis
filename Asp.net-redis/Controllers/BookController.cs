using Microsoft.AspNetCore.Mvc;

namespace Asp.net_redis.Controllers
{
    public class BookController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }

}
