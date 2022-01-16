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
           this.routes.Add(Method.Get, new());
           this.routes.Add(Method.Post, new());
           this.routes.Add(Method.Put, new());
           this.routes.Add(Method.Delete, new());
        }

        public IRoutingTable Map(string url, Method method, Response response)
        {
            if (method == Method.Get) return this.MapGet(url, response);
            else if (method == Method.Post) return this.MapPost(url, response);
            else throw new InvalidOperationException($"Method '{method}' is not suported");
        }

        public IRoutingTable MapGet(string url, Response response)
        {
            Guard.AgainstNull(url, nameof(url));
            Guard.AgainstNull(response, nameof(response));

            routes[Method.Get].Add(url, response);

            return this;
        }

        public IRoutingTable MapPost(string url, Response response)
        {
            Guard.AgainstNull(url, nameof(url));
            Guard.AgainstNull(response, nameof(response));

            routes[Method.Post].Add(url, response);

            return this;
        }

        public Response MatchRequest(Request request)
        {
            var method = request.Method;
            var url = request.Url;

            if (!this.routes.ContainsKey(method) || this.routes[method].ContainsKey(url))
            {
                return new NotFoundResponse(StatusCode.NotFound);
            }

            return this.routes[method][url];
        }
    }
}
