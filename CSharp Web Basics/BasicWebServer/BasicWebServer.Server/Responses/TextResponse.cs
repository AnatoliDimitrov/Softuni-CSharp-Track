namespace BasicWebServer.Server.Responses
{
    using Common;
    using HTTP;

    public class TextResponse : ContentResponse
    {
        public TextResponse(string content)
            : base(content, Constants.PlainText)
        {
        }
    }
}
