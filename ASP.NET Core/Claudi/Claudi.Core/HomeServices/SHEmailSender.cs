namespace Claudi.Core.HomeServices
{
    using System.Net;
    using System.Net.Mail;

    using Microsoft.Extensions.Configuration;

    using ViewModels.ContactsViewModel;

    public class SHEmailSender : ISHEmailSender
    {
        private readonly IConfiguration _configuration;
        public SHEmailSender(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public async Task Send(EmailContactViewModel model)
        {
            var body = $"<p>Email From: {model.From}</p><p>{model.Message}</p>";
            var message = new MailMessage();
            message.To.Add(new MailAddress(_configuration["Contacts:Email"]));
            message.From = new MailAddress(model.From);
            message.Subject = model.Subject;
            message.Body = string.Format(body, model.From, _configuration["Contact:Email"], model.Message);
            message.IsBodyHtml = true;

            //using (var smtp = new SmtpClient())
            //{
            //    var credential = new NetworkCredential
            //    {
            //        UserName = _configuration["Username"],
            //        Password = _configuration["Password"],
            //    };
            //    smtp.Credentials = credential;
            //    smtp.Host = _configuration["Host"];
            //    smtp.Port = int.Parse(_configuration["Port"]);
            //    smtp.EnableSsl = false;
            //    await smtp.SendMailAsync(message);
            //}

            using (var smtp = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = "info@claudi.bg",
                    Password = "Anatoli8406041726",
                };
                smtp.Credentials = credential;
                smtp.Host = "flora.superhosting.bg";
                smtp.Port = 25;
                smtp.EnableSsl = false;
                await smtp.SendMailAsync(message);
            }
        }
    }
}
