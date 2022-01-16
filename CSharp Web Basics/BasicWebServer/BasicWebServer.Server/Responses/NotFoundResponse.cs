namespace BasicWebServer.Server.Responses
{
    using BasicWebServer.Server.HTTP;
    using BasicWebServer.Server.HTTP.Enumerations;

    internal class NotFoundResponse : Response
    {
        public NotFoundResponse(StatusCode statusCode) : base(statusCode)
        {
        }
    }
}
