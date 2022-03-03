using Microsoft.AspNetCore.Mvc;

namespace Claudi.Web.Controllers
{
    public class ColorsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Horizontal()
        {
            return View("Multiple");
        }
    }
}
