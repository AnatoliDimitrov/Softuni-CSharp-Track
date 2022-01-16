namespace BasicWebServer.Server.HTTP
{
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

        public HeaderCollection Headers { get; } = new HeaderCollection();

        public string Body { get; set; }
    }
}
