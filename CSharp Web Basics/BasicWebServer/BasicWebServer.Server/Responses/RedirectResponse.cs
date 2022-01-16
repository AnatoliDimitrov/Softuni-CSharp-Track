namespace BasicWebServer.Server.Responses
{
    using BasicWebServer.Server.Common;
    using BasicWebServer.Server.HTTP;
    using BasicWebServer.Server.HTTP.Enumerations;

    public class RedirectResponse : Response
    {
        public RedirectResponse(string location) : base(StatusCode.Found)
        {
            this.Headers.Add(Constants.Location, location);
        }
    }
}
