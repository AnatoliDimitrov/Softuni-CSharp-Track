namespace BasicWebServer.Server.Responses
{
    using BasicWebServer.Server.HTTP;
    using BasicWebServer.Server.HTTP.Enumerations;

    public class BadRequestResponse : Response
    {
        public BadRequestResponse(StatusCode statusCode) : base(statusCode)
        {
        }
    }
}
