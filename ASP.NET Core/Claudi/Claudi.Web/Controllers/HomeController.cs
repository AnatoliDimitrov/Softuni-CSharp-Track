namespace Claudi.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;

    using System.Diagnostics;

    using Core.HomeServices;
    using Core.ViewModels;
    using Core.ViewModels.ContactsViewModel;

    using Infrastructure.Common;

    public class HomeController : Controller
    {
        private readonly ISHEmailSender _sender;
        private readonly IConfiguration _configoration;

        public HomeController(ISHEmailSender _emailSender, IConfiguration configoration)
        {
            this._sender = _emailSender;
            this._configoration = configoration;
        }

        public async Task<IActionResult> Index()
        {
            return this.View();
        }
        public IActionResult Contact(string sent)
        {
            ViewBag.Message = sent;
            ViewBag.Phone = _configoration["Contacts:Phone"];
            ViewBag.DisplayPhone = _configoration["Contacts:DisplayPhone"];
            ViewBag.Email = _configoration["Contacts:Email"];
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

        public IActionResult Cookies()
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