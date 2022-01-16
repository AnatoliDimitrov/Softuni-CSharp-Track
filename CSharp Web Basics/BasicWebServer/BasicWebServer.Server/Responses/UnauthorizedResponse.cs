namespace BasicWebServer.Server.Responses
{
    using BasicWebServer.Server.HTTP;
    using BasicWebServer.Server.HTTP.Enumerations;

    internal class UnauthorizedResponse : Response
    {
        public UnauthorizedResponse(StatusCode statusCode) : base(statusCode)
        {
        }
    }
}
