namespace BasicWebServer.Server.HTTP
{
    using BasicWebServer.Server.HTTP.Enumerations;

    public class Request
    {
        public Method Method { get; private set; }

        public string Url { get; private set; }

        public HeaderCollection Headers { get; private set; }

        public string Body { get; private set; }

        public static Request Parse(string request)
        {
            var lines = request.Split("\r\n", StringSplitOptions.RemoveEmptyEntries);
            var firstLine = lines[0].Split(" ");

            var method = ParseMethod(firstLine[0]);
            var url = firstLine[1];

            var headers = ParseHeaders(lines.Skip(1));

            var body = string.Join("\r\n", lines.Skip(headers.Count + 2).ToArray());

            return new Request()
            {
                Method = method,
                Url = url,
                Body = body,
                Headers = headers,
            };
        }

        private static Method ParseMethod(string stringMethod)
        {
            try
            {
                return Method.Parse<Method>(stringMethod);
            }
            catch (Exception)
            {
                throw new InvalidOperationException($"Method '{stringMethod}' is not supported");
            }
        }

        private static HeaderCollection ParseHeaders(IEnumerable<string> headerLines) 
        {
            var headers = new HeaderCollection();
            foreach (var line in headerLines)
            {
                if (line == "")
                {
                    break;
                }

                var parts = line.Split(':', 2);
                if (parts.Length != 2) throw new InvalidOperationException("Request is not valid");
                var name = parts[0];
                var value = parts[1].Trim();

                headers.Add(name, value);
            }

            return headers;
        }
    }
}
