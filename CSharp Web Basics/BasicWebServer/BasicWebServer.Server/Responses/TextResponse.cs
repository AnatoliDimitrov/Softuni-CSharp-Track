namespace BasicWebServer.Server.Responses
{
    using BasicWebServer.Server.Common;

    internal class TextResponse : ContentResponse
    {
        public TextResponse(string content) : base(content, Constants.PlainText)
        {
        }
    }
}
