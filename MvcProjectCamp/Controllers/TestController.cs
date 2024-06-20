using Microsoft.AspNetCore.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult Test2()
        {
            return View();
        }
    }
}
