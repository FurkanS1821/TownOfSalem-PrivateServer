using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using TownOfSalem_Logic.Properties;
using TownOfSalem_Logic.UserData;
using MessageType = TownOfSalem_Networking.Client.MessageType;

namespace TownOfSalem_Logic
{
    class Program
    {
        public const int PORT = 3600;
        public const int BUILD_ID = 10655;

        public static readonly object PlayersLock = new object();
        public static List<Player> AllPlayers = new List<Player>();

        public static readonly object PendingConnectionsLock = new object();
        public static List<INetworkService> PendingConnections = new List<INetworkService>();

        public static readonly object LobbiesLock = new object();
        public static List<PartyLobby> LiveLobbies = new List<PartyLobby>();

        public static readonly object GamesLock = new object();
        public static List<Game> LiveGames = new List<Game>();

        public static void Main()
        {
            Console.Title = "Town of Salem Private Server";
            Console.Write("Setting up server... ");

            var server = new TcpListener(IPAddress.Any, PORT);
            server.Start();
            PlayerManager.LoadAndResetAllData();

            Console.WriteLine("done.");
            Task.Run(() => PollAllClients());

            while (true)
            {
                var client = server.AcceptTcpClient();
                Console.WriteLine("A connection was established.");
                Task.Run(() => ProcessConnection(client));
            }
        }

        [CanBeNull]
        public static Player GetPlayer(INetworkService service)
        {
            lock (PlayersLock)
            {
                return AllPlayers.FirstOrDefault(x => x.Client == service);
            }
        }

        private static void PollAllClients()
        {
            while (true)
            {
                try
                {
                    lock (PlayersLock)
                    {
                        foreach (var player in AllPlayers)
                        {
                            player.Client?.Poll();
                        }
                    }

                    lock (PendingConnectionsLock)
                    {
                        foreach (var connection in PendingConnections)
                        {
                            connection.Poll();
                        }
                    }
                }
                catch (InvalidOperationException)
                {
                }
            }
        }

        private static void ProcessConnection(TcpClient client)
        {
            var networkService = new TOSNetworkService(client.Client);
            RegisterEverythingForService(networkService);

            lock (PendingConnectionsLock)
            {
                PendingConnections.Add(networkService);
            }

            networkService.OnDisconnected += delegate { GetPlayer(networkService).Client = null; };
        }

        private static void RegisterEverythingForService(TOSNetworkService service)
        {
            service.RegisterCallback(MessageType.RequestLoadHomepage, PacketHandler.HandleRequestLoadHomePage);
            service.RegisterCallback(MessageType.SendAccountSetting, PacketHandler.HandleSendAccountSetting);
            service.RegisterCallback(MessageType.JoinGame, PacketHandler.HandleJoinGame);
            service.RegisterCallback(MessageType.PartyCreate, PacketHandler.HandlePartyCreate);
            service.RegisterCallback(MessageType.PartyLeave, PacketHandler.HandlePartyLeave);
            service.RegisterCallback(MessageType.HostSetPartyConfig, PacketHandler.HandleHostSetPartyConfig);
            service.RegisterCallback(MessageType.PartyInvite, PacketHandler.HandlePartyInvite);
            service.RegisterCallback(MessageType.PartyResponse, PacketHandler.HandlePartyResponse);
            service.RegisterCallback(MessageType.PartyChangeHost, PacketHandler.HandlePartyChangeHost);
            service.RegisterCallback(MessageType.PartyGiveInvitePrivileges, PacketHandler.HandlePartyGiveInvitePrivileges);
            service.RegisterCallback(MessageType.PartyKick, PacketHandler.HandlePartyKick);
            service.RegisterCallback(MessageType.PartyMessage, PacketHandler.HandlePartyMessage);
        }
    }
}