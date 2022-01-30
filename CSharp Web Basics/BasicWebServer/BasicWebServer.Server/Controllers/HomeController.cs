namespace BasicWebServer.Server.Controllers
{
    using BasicWebServer.Server.HTTP;

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
