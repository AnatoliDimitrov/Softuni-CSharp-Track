namespace Claudi.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class CalculatorsController : Controller
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}
