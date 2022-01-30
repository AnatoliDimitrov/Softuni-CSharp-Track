namespace BasicWebServer.Server.Responses
{
    using Common;
    using HTTP;

    public class TextResponse : ContentResponse
    {
        public TextResponse(string content, Action<Request, Response> preRenderAction = null) : base(content, Constants.PlainText, preRenderAction)
        {
        }
    }
}
