namespace BasicWebServer
{
    using System;

    using BasicWebServer.Server;
    using BasicWebServer.Server.HTTP;
    using BasicWebServer.Server.Responses;

    public class Startup
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

        public static async Task Main()
        {
            await DownloadSitesAsTextFileAsync(FileName, new string[] { "https://judge.softuni.org/", "https://softuni.org/" });

            var server = new HttpServer(r => r
                .MapGet("/", new TextResponse("Hello from server."))
                .MapGet("/HTML", new HtmlResponse(HtmlForm))
                .MapGet("/Redirect", new RedirectResponse("http://claudi.bg"))
                .MapPost("/HTML", new TextResponse("", Startup.AddFormDataAction))
                .MapGet("/Content", new HtmlResponse(DownLoadForm))
                .MapPost("/Content", new TextFileResponse(FileName))
                );
            await server.Start();
        }

        private static async Task DownloadSitesAsTextFileAsync(string fileName, string[] urls)
        {
            var downloads = new List<Task<string>>();

            foreach (var url in urls)
            {
                downloads.Add(DownloadWebSiteContent(url));
            }

            var responses = await  Task.WhenAll(downloads);

            var responsesString = string.Join(Environment.NewLine, responses);

            await File.WriteAllTextAsync(FileName, responsesString);
        }

        private static async Task<string> DownloadWebSiteContent(string url)
        {
            using var client = new HttpClient();
            var response = await client.GetAsync(url);
            var html = await response.Content.ReadAsStringAsync();
            return html.Substring(0, 2000);
        }

        private static void AddFormDataAction(Request request, Response response)
        {
            response.Body = "";

            foreach (var item in request.Form)
            {
                response.Body += $"{item.Key} - {item.Value}";
                response.Body += Environment.NewLine;
            }
        }
    }
}
