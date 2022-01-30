namespace BasicWebServer.Server.Responses
{
    using Common;
    using HTTP;

    public class HtmlResponse : ContentResponse
    {
        public HtmlResponse(string content, Action<Request, Response> preRenderAction = null) 
            : base(content, Constants.Html, preRenderAction)
        {
        }
    }
}
