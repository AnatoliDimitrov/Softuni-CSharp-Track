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
        private const string FileName = "content.txt";
        private const string LoginForm = @"<form action='/Login' method='POST'>
   Username: <input type='text' name='Username'/>
   Password: <input type='text' name='Password'/>
   <input type='submit' value ='Log In' /> 
</form>";
        private const string Username = "user";
        private const string Password = "user123";

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
                //.MapGet<HomeController>("/Session", c => c.Session())
                //.MapGet<HomeController>("/Login", new HtmlResponse(LoginForm))
                //.MapPost<HomeController>("/Login", new HtmlResponse("", LoginAction))
                //.MapGet<HomeController>("/Logout", new HtmlResponse("", LogoutAction))
                //.MapGet<HomeController>("/UserProfile", new HtmlResponse("", GetUserDataAction))
                ).Start();
        }

        private static void GetUserDataAction(Request request, Response response)
        {
            if (request.Session.ContainsKey(Session.SessionUserKey))
            {
                response.Body = "";
                response.Body = $"<h3>Currently logged-in user is with username '{Username}'</h3>";
            }
            else
            {
                response.Body = "";
                response.Body = $"<h3>You should first log in - <a href='/Login'>Login</a></h3>";
            }
        }

        private static void LogoutAction(Request request, Response response)
        {
            request.Session.Clear();

            response.Body = "";
            response.Body = "<h3>Logged out successfully!</h3>";
        }

        private static void LoginAction(Request request, Response response)
        {
            request.Session.Clear();

            var bodyText = "";

            var usernameMatches = request.Form["Username"] == Username;
            var passwordMatches = request.Form["Password"] == Password;

            if (usernameMatches && passwordMatches)
            {
                request.Session[Session.SessionUserKey] = "MyUserId";
                response.Cookies.Add(Session.SessionCookieName, request.Session.Id);

                bodyText = "<h3>Logged successfully!</h3>";
            }
            else
            {
                bodyText = LoginForm;
            }

            response.Body = "";
            response.Body = bodyText;
        }

        private static void DisplaySessionInfoAction(Request request, Response response)
        {
            var sessionExists = request.Session.ContainsKey(Session.SessionCurrentDateKey);

            var bodyText = "";

            if (sessionExists)
            {
                var currentDate = request.Session[Session.SessionCurrentDateKey];
                bodyText = $"Stored date: {currentDate}";
            }
            else
            {
                bodyText = "Current date stored!";
            }

            response.Body = "";
            response.Body = bodyText;
        }

        private static void AddCookiesAction( Request request, Response response)
        {
            var requestHasCookies = request.Cookies.Any(c => c.Name != Session.SessionCookieName);
            var body = "";

            if (requestHasCookies)
            {
                var cookieText = new StringBuilder();

                cookieText.AppendLine("<h1>Cookies<h1>");

                cookieText.AppendLine("<table border='1'><tr><th>Name</th><th>Value</th></tr>");

                foreach (var cookie in request.Cookies)
                {
                    cookieText.Append("<tr>");
                    cookieText.Append($"<th>{HttpUtility.HtmlEncode(cookie.Name)}</th>");
                    cookieText.Append($"<th>{HttpUtility.HtmlEncode(cookie.Value)}</th>");
                    cookieText.Append("</tr>");
                }
                cookieText.Append("</table>");
                body = cookieText.ToString();
            }
            else
            {
                body = "<h1>Cookies Set!</h1>";
            }

            if (!requestHasCookies)
            {
                response.Cookies.Add("My-Cookie", "My-Value");
                response.Cookies.Add("My-Second-Cookie", "My-Second-Value");
            }

            response.Body = body;
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
