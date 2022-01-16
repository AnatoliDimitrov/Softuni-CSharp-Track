namespace BasicWebServer.Server
{
    using BasicWebServer.Server.Common;
    using BasicWebServer.Server.HTTP;
    using BasicWebServer.Server.Routing;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;

    public class HttpServer
    {
        private readonly IPAddress ipAddress;
        private readonly int port;
        private readonly TcpListener serverListener;
        private readonly RoutingTable routingTable;

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

        public void Start()
        {
            serverListener.Start();
            Console.WriteLine($"Server listens on port {port}");

            while (true)
            {
                var connection = serverListener.AcceptTcpClient();

                NetworkStream networkStream = connection.GetStream();

                var content = "Hello from server!";

                var requestText = this.ReadRequest(networkStream);

                var request = Request.Parse(requestText);

                var response = this.routingTable.MatchRequest(request);

                WriteResponse(networkStream, response);
                connection.Close();
            }
        }

        private void WriteResponse(NetworkStream networkStream, Response response)
        {
            var contentLength = Encoding.UTF8.GetByteCount(response.Body);
        }

        private string ReadRequest(NetworkStream stream) 
        {
            var bufferLength = 1024;
            var buffer = new byte[bufferLength];
            var requestSB = new StringBuilder();
            var totalBytes = 0;

            do
            {
                var bytesRead = stream.Read(buffer, 0, bufferLength);
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
