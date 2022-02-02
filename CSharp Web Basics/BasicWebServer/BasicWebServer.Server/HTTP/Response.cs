namespace BasicWebServer.Server.HTTP
{
    using System.Text;

    using BasicWebServer.Server.Common;
    using BasicWebServer.Server.HTTP.Enumerations;

    public class Response
    {
        public Response(StatusCode statusCode)
        {
            this.StatusCode = statusCode;

            this.Headers.Add(Constants.Server, "My Web Server");
            this.Headers.Add(Constants.Date, $"{DateTime.UtcNow}");
        }

        public StatusCode StatusCode { get; init; }

        public HeaderCollection Headers { get; } = new();

        public CookieCollection Cookies { get; } = new();

        public string Body { get; set; }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine($"HTTP/1.1 {(int)this.StatusCode} {this.StatusCode}");

            foreach (var header in this.Headers)
            {
                result.AppendLine(header.ToString());
            }

            foreach (var cookie in this.Cookies)
            {
                result.AppendLine($"{Constants.SetCookie}: {cookie}");
            }

            result.AppendLine();

            if (!string.IsNullOrWhiteSpace(this.Body))
            {
                result.AppendLine(this.Body);
            }

            return result.ToString();
        }
    }
}
