namespace BasicWebServer.Server
{
    using System.Net;
    using System.Net.Sockets;
    using System.Text;

    using BasicWebServer.Server.Common;
    using BasicWebServer.Server.HTTP;
    using BasicWebServer.Server.Routing;

    public class HttpServer
    {
        private readonly IPAddress ipAddress;
        private readonly int port;
        private readonly TcpListener serverListener;
        private readonly RoutingTable routingTable = new RoutingTable();

        public HttpServer(string _ipAddress, int _port, Action<IRoutingTable> routingTableConfiguration)
        {
            this.ipAddress = IPAddress.Parse(_ipAddress);
            this.port = _port;
            this.serverListener = new TcpListener(ipAddress, port);
            routingTableConfiguration(this.routingTable);
        }

        public HttpServer(int _port, Action<IRoutingTable> routingTableConfiguration)
            : this(Constants.Ip, _port, routingTableConfiguration)
        {

        }

        public HttpServer(Action<IRoutingTable> routingTableConfiguration)
            : this(Constants.Port, routingTableConfiguration)
        {

        }

        public async Task Start()
        {
            serverListener.Start();
            Console.WriteLine($"Server listens on port {port}");

            while (true)
            {
                var connection = await serverListener.AcceptTcpClientAsync();

                _ = Task.Run(async () =>
                {

                    NetworkStream networkStream = connection.GetStream();

                    var requestText = await this.ReadRequestAsync(networkStream);

                    var request = Request.Parse(requestText);

                    var response = this.routingTable.MatchRequest(request);

                    if (response.PreRenderAction != null) response.PreRenderAction(request, response);

                    AddSession(request, response);

                    await WriteResponseAsync(networkStream, response);
                    connection.Close();
                });
            }
        }

        private void AddSession(Request request, Response response)
        {
            var sessionExists = request.Session.ContainsKey(Session.SessionCurrentDateKey);

            if (!sessionExists)
            {
                request.Session[Session.SessionCurrentDateKey] = DateTime.Now.ToString();
                response.Cookies.Add(Session.SessionCookieName, request.Session.Id);
            }
        }

        private async Task WriteResponseAsync(NetworkStream networkStream, Response response)
        {
            await networkStream.WriteAsync(Encoding.UTF8.GetBytes(response.ToString()));
        }

        private async Task<string> ReadRequestAsync(NetworkStream stream)
        {
            var bufferLength = Constants.BufferLength;
            var buffer = new byte[bufferLength];
            var requestSB = new StringBuilder();
            var totalBytes = 0;

            do
            {
                var bytesRead = await stream.ReadAsync(buffer, 0, bufferLength);
                requestSB.Append(Encoding.UTF8.GetString(buffer, 0, bytesRead));

                totalBytes += bytesRead;

                if (totalBytes > 10 * 1024)
                {
                    throw new InvalidOperationException("Request is too large.");
                }

                if (!stream.DataAvailable)
                    System.Threading.Thread.Sleep(1);

            } while (stream.DataAvailable);

            return requestSB.ToString();
        }
    }
}
