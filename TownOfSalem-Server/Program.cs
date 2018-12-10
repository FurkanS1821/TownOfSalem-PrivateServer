using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using MessageType = TownOfSalem_Networking.Client.MessageType;

namespace TownOfSalem_Logic
{
    class Program
    {
        public const int PORT = 3600;
        public const int BUILD_ID = 10655;

        public static object ClientsLock = new object();
        public static List<TOSNetworkService> AllConnectedClients = new List<TOSNetworkService>();

        public static void Main()
        {
            Console.Title = "Town of Salem Private Server";
            Console.Write("Setting up server... ");

            var server = new TcpListener(IPAddress.Any, PORT);
            server.Start();

            Console.WriteLine("done.");
            Task.Run(() => PollAllClients());

            while (true)
            {
                var client = server.AcceptTcpClient();
                Console.WriteLine("A connection was established.");
                Task.Run(() => ProcessConnection(client));
            }
        }

        private static void PollAllClients()
        {
            while (true)
            {
                lock (ClientsLock)
                {
                    foreach (var client in AllConnectedClients)
                    {
                        client.Poll();
                    }
                }
            }
        }

        private static void ProcessConnection(TcpClient client)
        {
            var networkService = new TOSNetworkService(client.Client);
            RegisterEverythingForService(networkService);
            lock (ClientsLock)
            {
                AllConnectedClients.Add(networkService);
            }

            networkService.OnDisconnected += delegate
            {
                lock (ClientsLock)
                {
                    AllConnectedClients.Remove(networkService);
                }
            };
        }

        private static void RegisterEverythingForService(TOSNetworkService service)
        {
            service.RegisterCallback(MessageType.RequestLoadHomepage, PacketHandler.HandleRequestLoadHomePage);
            service.RegisterCallback(MessageType.SendAccountSetting, PacketHandler.HandleSendAccountSetting);
        }
    }
}
