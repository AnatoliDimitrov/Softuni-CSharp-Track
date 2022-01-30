namespace BasicWebServer.Server.Routing
{
    using HTTP;
    using HTTP.Enumerations;

    public interface IRoutingTable
    {
        IRoutingTable Map(Method method, string path, Func<Request, Response> responseFunction);

        IRoutingTable MapGet(string url, Func<Request, Response> responseFunction);

        IRoutingTable MapPost(string url, Func<Request, Response> responseFunction);
    }
}
