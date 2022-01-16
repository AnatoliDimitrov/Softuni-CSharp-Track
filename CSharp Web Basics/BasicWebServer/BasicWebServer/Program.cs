namespace BasicWebServer
{
    using BasicWebServer.Server;
    using BasicWebServer.Server.Common;

    public class Program
    {
        static void Main()
        {
            var port = Constants.Port;

            var serverListener = new HttpServer("127.0.0.1", port);
            serverListener.Start();
        }
    }
}
