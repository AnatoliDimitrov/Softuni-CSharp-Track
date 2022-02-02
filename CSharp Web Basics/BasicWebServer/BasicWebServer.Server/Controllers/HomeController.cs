namespace BasicWebServer.Server.Controllers
{
    using BasicWebServer.Server.HTTP;
    using System.Text;
    using System.Web;

    public class HomeController : Controller
    {
        private const string HtmlForm = @"<form action='/HTML' method='POST'>
    Name: <input type='text' name='Name' />
    Age: <input type='number' name='Age' />
    <input type='submit' value='Save' />
</form>";
        private const string DownLoadForm = @"<form action='/Content' method='POST'>
   <input type='submit' value ='Download Sites Content' /> 
</form>";
        private const string FileName = "content.txt";

        public HomeController(Request request) : base(request)
        {

        }

        public Response Index() => Text("Hello from server!");

        public Response Redirect() => Redirect("https://softuni.bg");

        public Response Html() => Html(HtmlForm);

        public Response HtmlFormPost()
        {
            var data = "";

            foreach (var (key, value) in Request.Form)
            {
                data += $"{key} - {value}" + Environment.NewLine;
            }

            return Text(data);
        }

        public Response Content() => Html(DownLoadForm);

        public Response DownloadContent()
        {
            DownloadSitesAsTextFileAsync(FileName, new string[] { "http://claudi.bg" }).Wait();

           return File(FileName);
        }

        public Response Cookies()
        {
            if(Request.Cookies.Any(c => c.Name != HTTP.Session.SessionCookieName))
            {
                var cookieText = new StringBuilder();
                cookieText.AppendLine("<h1>Cookies</h1>");
                cookieText.Append("<table border='1'><tr><th>Name</th><th>Value</th></tr>");

                foreach (var cookie in Request.Cookies)
                {
                    cookieText.Append("<tr>");
                    cookieText.Append($"<td>{HttpUtility.UrlEncode(cookie.Name)}</td>");
                    cookieText.Append($"<td>{HttpUtility.UrlEncode(cookie.Value)}</td>");
                    cookieText.Append("</tr>");
                }

                cookieText.Append("</table>");
                return Html(cookieText.ToString());
            }

            var cookies = new CookieCollection();
            cookies.Add("My-Cookie", "My-Value");
            cookies.Add("My-Second-Cookie", "My-Second-Value");

            return Html("<h1>Cookies Set!</h1>", cookies);
        }

        public Response Session()
        {
            string currentDateKey = "CurrentDate";
            var sessionExists = Request.Session.ContainsKey(currentDateKey);

            if (sessionExists)
            {
                var currentDate = Request.Session[currentDateKey];

                return Text($"Stored date: {currentDate}");
            }

            return Text("Current date stored!");
        }

        private static async Task DownloadSitesAsTextFileAsync(string fileName, string[] urls)
        {
            var downloads = new List<Task<string>>();

            foreach (var url in urls)
            {
                downloads.Add(DownloadWebSiteContent(url));
            }

            var responses = await Task.WhenAll(downloads);

            var responsesString = string.Join(Environment.NewLine, responses);

            await System.IO.File.WriteAllTextAsync(FileName, responsesString);
        }

        private static async Task<string> DownloadWebSiteContent(string url)
        {
            using var client = new HttpClient();
            var response = await client.GetAsync(url);
            var html = await response.Content.ReadAsStringAsync();
            return html.Substring(0, 2000);
        }
    }
}
