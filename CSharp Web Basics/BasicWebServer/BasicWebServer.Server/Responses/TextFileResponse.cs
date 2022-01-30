namespace BasicWebServer.Server.Responses
{
    using Common;
    using HTTP;
    using HTTP.Enumerations;

    public class TextFileResponse : Response
    {
        public TextFileResponse(string fileName) : base(StatusCode.OK)
        {
            this.FileName = fileName;
            this.Headers.Add(Constants.ContentType, Constants.PlainText);
        }

        public string FileName { get; set; }

        public override string ToString()
        {
            if (File.Exists(this.FileName))
            {
                this.Body = File.ReadAllTextAsync(this.FileName).Result;

                this.Headers.Add(Constants.ContentLength, new FileInfo(this.FileName).Length.ToString());
                this.Headers.Add(Constants.ContentDisposition, $"attachment; filname=\"{this.FileName}\"");
            }

            return base.ToString();
        }
    }
}
