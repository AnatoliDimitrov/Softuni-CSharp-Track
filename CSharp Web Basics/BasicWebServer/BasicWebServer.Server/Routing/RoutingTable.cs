namespace BasicWebServer.Server.Routing
{
    using Common;
    using HTTP;
    using HTTP.Enumerations;
    using Responses;

    public class RoutingTable : IRoutingTable
    {
        private readonly Dictionary<Method, Dictionary<string, Func<Request, Response>>> routes = new();

        public RoutingTable()
        {
            this.routes.Add(Method.get, new());
            this.routes.Add(Method.post, new());
            this.routes.Add(Method.put, new());
            this.routes.Add(Method.delete, new());
        }

        public IRoutingTable Map(Method method, string path, Func<Request, Response> responseFunction)
        {
            Guard.AgainstNull(path, nameof(path));
            Guard.AgainstNull(responseFunction, nameof(responseFunction));

            this.routes[method][path.ToLower()] = responseFunction;

            return this;
        }

        public IRoutingTable MapGet(string path, Func<Request, Response> responseFunction)
        => this.Map(Method.get, path, responseFunction);

        public IRoutingTable MapPost(string path, Func<Request, Response> responseFunction)
        => Map(Method.post, path, responseFunction);

        public Response MatchRequest(Request request)
        {
            var method = request.Method;
            var url = request.Url.ToLower();

            if (!this.routes.ContainsKey(method) || !this.routes[method].ContainsKey(url))
            {
                return new NotFoundResponse();
            }

            return this.routes[method][url.ToLower()](request);
        }
    }
}
