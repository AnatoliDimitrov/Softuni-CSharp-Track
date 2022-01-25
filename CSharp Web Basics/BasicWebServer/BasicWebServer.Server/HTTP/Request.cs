namespace BasicWebServer.Server.HTTP
{
    using BasicWebServer.Server.Common;
    using BasicWebServer.Server.HTTP.Enumerations;
    using System.Web;

    public class Request
    {
        private static Dictionary<string, Session> Sessions = new(); 

        public Method Method { get; private set; }

        public string Url { get; private set; }

        public HeaderCollection Headers { get; private set; }

        public CookieCollection Cookies { get; private set; }

        public string Body { get; private set; }

        public Session Session { get; set; }

        public IReadOnlyDictionary<string, string> Form { get; private set; }

        public static Request Parse(string request)
        {
            var lines = request.Split("\r\n");
            var firstLine = lines[0].Split(" ");

            var method = ParseMethod(firstLine[0]);
            var url = firstLine[1];

            var headers = ParseHeaders(lines.Skip(1));

            var cookies = ParseCookies(headers);

            var session = GetSession(cookies);

            var body = string.Join("\r\n", lines.Skip(headers.Count + 2).ToArray());

            var form = ParseForm(headers, body);

            return new Request()
            {
                Method = method,
                Url = url,
                Body = body,
                Headers = headers,
                Cookies = cookies,
                Session = session,
                Form = form,
            };
        }

        private static Session GetSession(CookieCollection cookies)
        {
            var sessionId = cookies.Contains(Session.SessionCookieName) ? cookies[Session.SessionCookieName] : Guid.NewGuid().ToString();

            if (!Sessions.ContainsKey(sessionId))
            {
                Sessions[sessionId] = new Session(sessionId);
            }

            return Sessions[sessionId];
        }

        private static CookieCollection ParseCookies(HeaderCollection headers)
        {
            var cookies = new CookieCollection();

            if (headers.contains(Constants.Cookie))
            {
                var cookieHeader = headers[Constants.Cookie];

                var allCookies = cookieHeader.Split(';');

                foreach (var cookieText in allCookies)
                {
                    var cookieParts = cookieText.Split('=');

                    cookies.Add(cookieParts[0].Trim(), cookieParts[1].Trim());
                }
            }

            return cookies;
        }

        private static Dictionary<string, string> ParseForm(HeaderCollection headers, string body)
        {
            var formCollection = new Dictionary<string, string>();

            if (headers.contains(Constants.ContentType) && headers[Constants.ContentType] == Constants.FormUrlEncoded)
            {
               var parsedResult = ParseFormData(body);

                foreach (var item in parsedResult)
                {
                    formCollection[item.Key] = item.Value;
                }
            }

            return formCollection;
        }

        private static Dictionary<string, string> ParseFormData(string bodyLines)
        {
            return HttpUtility.UrlDecode(bodyLines)
                .Split('&')
                .Select(p => p.Split('='))
                .Where(p => p.Length == 2)
                .ToDictionary(x => x[0], y=> y[1], StringComparer.InvariantCultureIgnoreCase);
        }

        private static Method ParseMethod(string stringMethod)
        {
            try
            {
                return Method.Parse<Method>(stringMethod.ToLower());
            }
            catch (Exception)
            {
                throw new InvalidOperationException($"Method '{stringMethod}' is not supported");
            }
        }

        private static HeaderCollection ParseHeaders(IEnumerable<string> headerLines) 
        {
            var headers = new HeaderCollection();
            foreach (var line in headerLines)
            {
                if (line == "")
                {
                    break;
                }

                var parts = line.Split(':', 2);
                if (parts.Length != 2) throw new InvalidOperationException("Request is not valid");
                var name = parts[0];
                var value = parts[1].Trim();

                headers.Add(name, value);
            }

            return headers;
        }
    }
}
