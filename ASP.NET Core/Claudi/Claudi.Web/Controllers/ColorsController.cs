using Claudi.Web.Data;
using Microsoft.AspNetCore.Mvc;

namespace Claudi.Web.Controllers
{
    public class ColorsController : Controller
    {
        private readonly ApplicationDbContext context;
        public ColorsController(ApplicationDbContext _context)
        {
            this.context = _context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Horizontal()
        {
            var catalogues = context.ProductColors
                .Where(p => p.Name == "horizontal")
                .OrderBy(p => p.CssClass)
                .ToList();

            return View("Multiple", catalogues);
        }
    }
}
