namespace BasicWebServer
{
    using System;
    using System.Text;
    using System.Web;

    using Server;
    using Server.HTTP;
    using Server.Controllers;

    public class Startup
    {
        public static async Task Main()
        {
            await new HttpServer(r => r
                .MapGet<HomeController>("/", c => c.Index())
                .MapGet<HomeController>("/HTML", c => c.Html())
                .MapGet<HomeController>("/Redirect", c => c.Redirect())
                .MapPost<HomeController>("/HTML", c => c.HtmlFormPost())
                .MapGet<HomeController>("/Content", c => c.Content())
                .MapPost<HomeController>("/Content", c => c.DownloadContent())
                .MapGet<HomeController>("/Cookies", c => c.Cookies())
                .MapGet<HomeController>("/Session", c => c.Session())
                .MapGet<UserController>("/Login", c => c.Login())
                .MapPost<UserController>("/Login", c => c.LoginUser())
                .MapGet<UserController>("/Logout", c => c.Logout())
                .MapGet<UserController>("/UserProfile", c => c.GetUserDataAction())
                ).Start();
        }
    }
}
