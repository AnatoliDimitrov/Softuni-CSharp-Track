namespace BasicWebServer.Server.Responses
{
    using BasicWebServer.Server.Common;

    public class HtmlResponse : ContentResponse
    {
        public HtmlResponse(string content) : base(content, Constants.Html)
        {
        }
    }
}
