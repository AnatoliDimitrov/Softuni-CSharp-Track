namespace BasicWebServer.Server.Responses
{
    using System.Text;

    using Common;
    using HTTP;
    using HTTP.Enumerations;

    public abstract class ContentResponse : Response
    {
        protected ContentResponse(string content, string contentType, Action<Request, Response> preRenderAction = null) : base(StatusCode.OK)
        {
            Guard.AgainstNull(content, nameof(content));
            Guard.AgainstNull(contentType, nameof(contentType));

            this.Headers.Add(Constants.ContentType, contentType);
            this.Body = content;
        }

        public override string ToString()
        {
            if (!string.IsNullOrWhiteSpace(this.Body))
            {
                var length = Encoding.UTF8.GetByteCount(this.Body);
                this.Headers.Add(Constants.ContentLength, length.ToString());
            }

            return base.ToString();
        }
    }
}
