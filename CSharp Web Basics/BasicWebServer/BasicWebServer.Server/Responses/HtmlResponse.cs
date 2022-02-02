namespace BasicWebServer.Server.Responses
{
    using Common;
    using HTTP;

    public class HtmlResponse : ContentResponse
    {
        public HtmlResponse(string content) 
            : base(content, Constants.Html)
        {
        }
    }
}
