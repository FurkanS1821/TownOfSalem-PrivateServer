using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace TownOfSalem_Logic
{
    class Program
    {
        public const int PORT = 3600;
        public static void Main()
        {
            var server = new TcpListener(IPAddress.Any, PORT);
            server.Start();

            while (true)
            {
                var client = server.AcceptTcpClient();
                Task.Run(() => ProcessConnection(client));
            }
        }

        private static void ProcessConnection(TcpClient client)
        {

        }
    }
}
