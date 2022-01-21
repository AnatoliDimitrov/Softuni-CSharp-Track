namespace BasicWebServer.Server.Routing
{
    using BasicWebServer.Server.Common;
    using BasicWebServer.Server.HTTP;
    using BasicWebServer.Server.HTTP.Enumerations;
    using BasicWebServer.Server.Responses;

    public class RoutingTable : IRoutingTable
    {
        private readonly Dictionary<Method, Dictionary<string, Response>> routes = new Dictionary<Method, Dictionary<string, Response>>();

        public RoutingTable()
        {
           this.routes.Add(Method.get, new());
           this.routes.Add(Method.post, new());
           this.routes.Add(Method.put, new());
           this.routes.Add(Method.delete, new());
        }

        public IRoutingTable Map(string url, Method method, Response response)
        {
            if (method == Method.get) return this.MapGet(url, response);
            else if (method == Method.post) return this.MapPost(url, response);
            else throw new InvalidOperationException($"Method '{method}' is not suported");
        }

        public IRoutingTable MapGet(string url, Response response)
        {
            Guard.AgainstNull(url, nameof(url));
            Guard.AgainstNull(response, nameof(response));

            routes[Method.get].Add(url, response);

            return this;
        }

        public IRoutingTable MapPost(string url, Response response)
        {
            Guard.AgainstNull(url, nameof(url));
            Guard.AgainstNull(response, nameof(response));

            routes[Method.post].Add(url, response);

            return this;
        }

        public Response MatchRequest(Request request)
        {
            var method = request.Method;
            var url = request.Url;

            if (!this.routes.ContainsKey(method) || !this.routes[method].ContainsKey(url))
            {
                return new NotFoundResponse(StatusCode.NotFound);
            }

            return this.routes[method][url];
        }
    }
}
