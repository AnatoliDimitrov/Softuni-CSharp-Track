using Claudi.Core.ViewModels.ContactsViewModel;
using System.Net;
using System.Net.Mail;

namespace Claudi.Core.HomeServices
{
    public class SHEmailSender : ISHEmailSender
    {
        public async Task Send(EmailContactViewModel model)
        {
            var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
            var message = new MailMessage();
            message.To.Add(new MailAddress("info@cludi.bg"));  // replace with valid value 
            message.From = new MailAddress("info@cludi.bg");  // replace with valid value
            message.Subject = "Works";
            message.Body = string.Format(body, model.From, model.To, model.Message);
            message.IsBodyHtml = true;

            using (var smtp = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = "",  // replace with valid value
                    Password = ""  // replace with valid value
                };
                smtp.Credentials = credential;
                smtp.Host = "claudi.bg";
                smtp.Port = 25;
                smtp.EnableSsl = true;
                await smtp.SendMailAsync(message);
                //return RedirectToAction("Sent");
            }
        }
    }
}
