namespace BasicWebServer.Server.Responses
{
    using BasicWebServer.Server.Common;

    internal class HtmlResponse : ContentResponse
    {
        public HtmlResponse(string content) : base(content, Constants.Html)
        {
        }
    }
}
