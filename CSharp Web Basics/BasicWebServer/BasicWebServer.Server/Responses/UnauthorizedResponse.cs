namespace BasicWebServer.Server.Responses
{
    using HTTP;
    using HTTP.Enumerations;

    internal class UnauthorizedResponse : Response
    {
        public UnauthorizedResponse() : base(StatusCode.Unauthorized)
        {
        }
    }
}
