namespace BasicWebServer.Server.Responses
{
    using HTTP;
    using HTTP.Enumerations;

    internal class NotFoundResponse : Response
    {
        public NotFoundResponse() : base(StatusCode.NotFound)
        {
        }
    }
}
