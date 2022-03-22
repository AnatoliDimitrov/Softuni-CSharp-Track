namespace Claudi.Web.Controllers
{
    using System.Diagnostics;
    using Claudi.Core.HomeServices;
    using Claudi.Core.ViewModels;
    using Claudi.Core.ViewModels.ContactsViewModel;
    using Claudi.Infrastructure.Common;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISHEmailSender _sender;
        private readonly IConfiguration _configoration;

        public HomeController(ILogger<HomeController> logger, ISHEmailSender _emailSender, IConfiguration configoration)
        {
            this._logger = logger;
            this._sender = _emailSender;
            this._configoration = configoration;
        }

        public IActionResult Index()
        {
            return this.View();
        }
        public IActionResult Contact(string sent)
        {
            ViewBag.Message = sent;
            ViewBag.Phone = _configoration["Contacts:Phone"];
            ViewBag.DisplayPhone = _configoration["Contacts:DisplayPhone"];
            ViewBag.Email = _configoration[""];
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Contact(EmailContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _sender.Send(model);

                    return this.RedirectToAction("Contact", new { sent = Constants.SUCCESS });
                }
                catch (Exception)
                {
                    return this.RedirectToAction("Contact", new { sent = Constants.FAILD });
                }
            }

            return this.View();
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}