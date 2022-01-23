namespace BasicWebServer.Server.Responses
{
    using BasicWebServer.Server.Common;
    using BasicWebServer.Server.HTTP;

    public class HtmlResponse : ContentResponse
    {
        public HtmlResponse(string content, Action<Request, Response> preRenderAction = null) 
            : base(content, Constants.Html, preRenderAction)
        {
        }
    }
}
