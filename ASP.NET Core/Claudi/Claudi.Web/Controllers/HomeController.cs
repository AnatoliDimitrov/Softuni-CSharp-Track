namespace Claudi.Web.Controllers
{
    using System.Diagnostics;
    using Claudi.Core.HomeServices;
    using Claudi.Core.ViewModels;
    using Claudi.Core.ViewModels.ContactsViewModel;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISHEmailSender sender;

        public HomeController(ILogger<HomeController> logger, ISHEmailSender _emailSender)
        {
            _logger = logger;
            sender = _emailSender;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Contact(EmailContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                await sender.Send(model);
            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}