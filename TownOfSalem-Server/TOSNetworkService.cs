using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Linq;
using System.Text;
using TownOfSalem_Networking.Client.Friend;
using TownOfSalem_Networking.Client.Game;
using TownOfSalem_Networking.Client.Global;
using TownOfSalem_Networking.Client.Home;
using TownOfSalem_Networking.Client.Lobby;
using TownOfSalem_Networking.Client.Login;
using Client = TownOfSalem_Networking.Client;
using Server = TownOfSalem_Networking.Server;

namespace TownOfSalem_Logic
{
    public class TOSNetworkService : INetworkService
    {
        private List<Client.BaseMessage> _receivedMessages = new List<Client.BaseMessage>();

        private Dictionary<Client.MessageType, Type> _serverMessages = new Dictionary<Client.MessageType, Type>
        {
            [Client.MessageType.FBLogin] = typeof(LoginFacebookMessage),
            [Client.MessageType.RequestLoadHomepage] = typeof(RequestLoadHomePage),
            [Client.MessageType.ChatMessage] = typeof(ChatMessage),
            [Client.MessageType.CatalogList] = typeof(CatalogListMessage),
            [Client.MessageType.PossibleRoles] = typeof(PossibleRolesMessage),
            [Client.MessageType.AddRole] = typeof(AddRoleMessage),
            [Client.MessageType.RemoveRole] = typeof(RemoveRoleMessage),
            [Client.MessageType.PrivateMessage] = typeof(PrivateMessage),
            [Client.MessageType.LobbyStartGame] = typeof(StartGameMessage),
            [Client.MessageType.VoteTarget] = typeof(VoteTargetMessage),
            [Client.MessageType.NightTarget] = typeof(NightTargetMessage),
            [Client.MessageType.NightTargetSecond] = typeof(NightTargetSecondMessage),
            [Client.MessageType.VoteGuilty] = typeof(VoteGuiltyMessage),
            [Client.MessageType.VoteInnocent] = typeof(VoteInnocentMessage),
            [Client.MessageType.DayTarget] = typeof(DayTargetMessage),
            [Client.MessageType.SendLastWill] = typeof(SendLastWillMessage),
            [Client.MessageType.SendDeathNote] = typeof(SendDeathNoteMessage),
            [Client.MessageType.MafiaTarget] = typeof(MafiaTargetMessage),
            [Client.MessageType.SendCustomizationSettings] = typeof(SendCustomizationSettingsMessage),
            [Client.MessageType.RequestName] = typeof(RequestNameMessage),
            [Client.MessageType.SendReport] = typeof(SendReportMessage),
            [Client.MessageType.Repick] = typeof(RepickMessage),
            [Client.MessageType.SystemCommand] = typeof(SystemCommandMessage),
            [Client.MessageType.FriendAdd] = typeof(FriendAddMessage),
            [Client.MessageType.FriendConfirm] = typeof(FriendConfirmMessage),
            [Client.MessageType.FriendRemove] = typeof(FriendRemoveMessage),
            [Client.MessageType.FriendDecline] = typeof(FriendDeclineMessage),
            [Client.MessageType.FriendMessage] = typeof(FriendMessage),
            [Client.MessageType.JoinGame] = typeof(JoinGameMessage),
            [Client.MessageType.PartyCreate] = typeof(PartyCreateMessage),
            [Client.MessageType.PartyInvite] = typeof(PartyInviteMessage),
            [Client.MessageType.PartyResponse] = typeof(PartyResponseMessage),
            [Client.MessageType.PartyLeave] = typeof(PartyLeave),
            [Client.MessageType.PartyStart] = typeof(PartyStartMessage),
            [Client.MessageType.PartyMessage] = typeof(PartyMessage),
            [Client.MessageType.SendAccountSetting] = typeof(AccountSettingMessage),
            [Client.MessageType.AwayFromKeyboard] = typeof(AFKMessage),
            [Client.MessageType.ReturnHome] = typeof(ReturnHomeMessage),
            [Client.MessageType.RedeemCode] = typeof(RedeemCodeMessage),
            [Client.MessageType.FBAchievementShare] = typeof(FBAchievementShareMessage),
            [Client.MessageType.FBWinShare] = typeof(FBWinShareMessage),
            [Client.MessageType.PartyChangeHost] = typeof(PartyChangeHostMessage),
            [Client.MessageType.PartyKick] = typeof(PartyKickMessage),
            [Client.MessageType.PartyGiveInvitePrivileges] = typeof(PartyGiveInvitePrivilegesMessage),
            [Client.MessageType.SteamOrder] = typeof(SteamOrder),
            [Client.MessageType.SteamApprove] = typeof(SteamApproveMessage),
            [Client.MessageType.SteamCreateAccount] = typeof(SteamCreateAccountMessage),
            [Client.MessageType.FBCreateAccount] = typeof(FBCreateAccountMessage),
            [Client.MessageType.SteamLinkAccount] = typeof(SteamLinkAccount),
            [Client.MessageType.RequestRankedGame] = typeof(RequestRankedGameMessage),
            [Client.MessageType.RankedQueueLeave] = typeof(RankedQueueLeaveMessage),
            [Client.MessageType.RankedQueueAccept] = typeof(RankedQueueAcceptMessage),
            [Client.MessageType.LeaveGame] = typeof(LeaveGameMessage),
            [Client.MessageType.SendForgedWill] = typeof(SendForgedWillMessage),
            [Client.MessageType.RequestPlayerStatistics] = typeof(RequestPlayerStatisticsMessage),
            [Client.MessageType.PurchasePromotion] = typeof(PurchasePromotionMessage),
            [Client.MessageType.TutorialProgress] = typeof(TutorialProgressMessage),
            [Client.MessageType.CheckUsername] = typeof(CheckUsernameMessage),
            [Client.MessageType.NameChange] = typeof(NameChangeMessage),
            [Client.MessageType.PurchaseProduct] = typeof(PurchaseProductMessage),
            [Client.MessageType.RequestCauldronStatus] = typeof(RequestCauldronStatusMessage),
            [Client.MessageType.CauldronComplete] = typeof(CauldronCompleteMessage),
            [Client.MessageType.TauntTarget] = typeof(TauntTargetMessage),
            [Client.MessageType.PirateDuelSelection] = typeof(PirateDuelSelectionMessage),
            [Client.MessageType.PotionChosen] = typeof(PotionChosenMessage),
            [Client.MessageType.HostSetPartyConfig] = typeof(HostSetPartyConfig),
            [Client.MessageType.HypnotistChoice] = typeof(HypnotistChoiceMessage),
            [Client.MessageType.JailorDeathNote] = typeof(SendJailorDeathNoteMessage),
            [Client.MessageType.RegisterAccount] = typeof(RegisterAccountMessage),
            [Client.MessageType.Login] = typeof(LoginMessage),
            [Client.MessageType.CaptchaAnswer] = typeof(CaptchaAnswerMessage),
            [Client.MessageType.Ping] = typeof(PingMessage)
        };

        private ISocketService _socketService;

        public TOSNetworkService(Socket socket)
        {
            _socketService = new TCPSocketService(socket);

            foreach (var key in _serverMessages.Keys)
            {
                OnMessage.Add(key, (service, message) => { });
            }

            _socketService.OnMessageReceived += ProcessMessages;
            _socketService.OnConnected += RaiseOnConnected;
            _socketService.OnConnectionFailed += RaiseOnConnectionFailed;
            _socketService.OnDisconnected += RaiseOnDisconnected;
        }

        public override void Connect()
        {

        }

        public override void Disconnect()
        {
            _socketService.Disconnect();
        }

        public override void Poll()
        {
            _socketService.Poll();
        }

        public void ProcessMessages(byte[] data)
        {
            var test = Encoding.UTF8.GetString(data);
            if (test.Equals("<policy-file-request/>"))
            {
                _socketService.Send(new byte[]
                {
                    0x3C, 0x3F, 0x78, 0x6D, 0x6C, 0x20, 0x76, 0x65, 0x72, 0x73, 0x69, 0x6F, 0x6E, 0x3D, 0x22, 0x31,
                    0x2E, 0x30, 0x22, 0x3F, 0x3E, 0x0A, 0x3C, 0x21, 0x44, 0x4F, 0x43, 0x54, 0x59, 0x50, 0x45, 0x20,
                    0x63, 0x72, 0x6F, 0x73, 0x73, 0x2D, 0x64, 0x6F, 0x6D, 0x61, 0x69, 0x6E, 0x2D, 0x70, 0x6F, 0x6C,
                    0x69, 0x63, 0x79, 0x20, 0x53, 0x59, 0x53, 0x54, 0x45, 0x4D, 0x20, 0x22, 0x68, 0x74, 0x74, 0x70,
                    0x3A, 0x2F, 0x2F, 0x77, 0x77, 0x77, 0x2E, 0x61, 0x64, 0x6F, 0x62, 0x65, 0x2E, 0x63, 0x6F, 0x6D,
                    0x2F, 0x78, 0x6D, 0x6C, 0x2F, 0x64, 0x74, 0x64, 0x73, 0x2F, 0x63, 0x72, 0x6F, 0x73, 0x73, 0x2D,
                    0x64, 0x6F, 0x6D, 0x61, 0x69, 0x6E, 0x2D, 0x70, 0x6F, 0x6C, 0x69, 0x63, 0x79, 0x2E, 0x64, 0x74,
                    0x64, 0x22, 0x3E, 0x0A, 0x3C, 0x63, 0x72, 0x6F, 0x73, 0x73, 0x2D, 0x64, 0x6F, 0x6D, 0x61, 0x69,
                    0x6E, 0x2D, 0x70, 0x6F, 0x6C, 0x69, 0x63, 0x79, 0x3E, 0x0A, 0x3C, 0x61, 0x6C, 0x6C, 0x6F, 0x77,
                    0x2D, 0x61, 0x63, 0x63, 0x65, 0x73, 0x73, 0x2D, 0x66, 0x72, 0x6F, 0x6D, 0x20, 0x64, 0x6F, 0x6D,
                    0x61, 0x69, 0x6E, 0x3D, 0x22, 0x2A, 0x22, 0x20, 0x74, 0x6F, 0x2D, 0x70, 0x6F, 0x72, 0x74, 0x73,
                    0x3D, 0x22, 0x33, 0x36, 0x30, 0x30, 0x2C, 0x33, 0x36, 0x30, 0x31, 0x22, 0x2F, 0x3E, 0x0A, 0x3C,
                    0x2F, 0x63, 0x72, 0x6F, 0x73, 0x73, 0x2D, 0x64, 0x6F, 0x6D, 0x61, 0x69, 0x6E, 0x2D, 0x70, 0x6F,
                    0x6C, 0x69, 0x63, 0x79, 0x3E, 0x0A, 0x00
                });
                return;
            }

            var key = (Client.MessageType)data[0];

            Console.WriteLine($"Requested: {key}");

            if (OnMessage.ContainsKey(key))
            {
                try
                {
                    var instance = (Client.BaseMessage)Activator.CreateInstance(_serverMessages[key], data);
                    OnMessage[key](this, instance);
                    OnAnyMessage(instance);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e);
                }
            }

            Program.GetPlayer(this).LastAction = DateTime.Now;
        }

        public override void SendMessage(Server.BaseMessage msg)
        {
            var data = msg.Serialize();

            if (data.Count(x => x == 0) > 1)
            {
                Console.WriteLine($"WARNING: Packet {msg.MessageId} has 0x0 in it.");
            }

            _socketService.Send(data);
        }

        public override void SendMultipleMessages(params Server.BaseMessage[] msgs)
        {
            var data = new List<byte>();

            foreach (var msg in msgs)
            {
                var msgBytes = msg.Serialize();

                if (msgBytes.Count(x => x == 0) > 1)
                {
                    Console.WriteLine($"WARNING: Packet {msg.MessageId} has 0x0 in it.");
                }

                data.AddRange(msgBytes);
            }

            _socketService.Send(data.ToArray());
        }

        public override List<Client.BaseMessage> GetReceivedMessages()
        {
            return _receivedMessages;
        }
    }
}
