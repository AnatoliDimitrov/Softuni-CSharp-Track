namespace BasicWebServer.Server.Responses
{
    using HTTP;
    using HTTP.Enumerations;

    public class BadRequestResponse : Response
    {
        public BadRequestResponse() : base(StatusCode.BadRequest)
        {
        }
    }
}
