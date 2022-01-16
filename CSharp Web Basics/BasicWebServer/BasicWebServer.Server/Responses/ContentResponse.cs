namespace BasicWebServer.Server.Responses
{
    using BasicWebServer.Server.Common;
    using BasicWebServer.Server.HTTP;
    using BasicWebServer.Server.HTTP.Enumerations;

    public abstract class ContentResponse : Response
    {
        protected ContentResponse(string content, string contentType) : base(StatusCode.OK)
        {
            Guard.AgainstNull(content, nameof(content));
            Guard.AgainstNull(contentType, nameof(contentType));

            this.Headers.Add(Constants.ContentType, contentType);
            this.Body = content;
        }
    }
}
