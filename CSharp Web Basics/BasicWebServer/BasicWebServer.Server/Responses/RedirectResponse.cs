namespace BasicWebServer.Server.Responses
{
    using Common;
    using HTTP;
    using HTTP.Enumerations;

    public class RedirectResponse : Response
    {
        public RedirectResponse(string location) : base(StatusCode.Found)
        {
            this.Headers.Add(Constants.Location, location);
        }
    }
}
