using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Linq;
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
        }

        public override void SendMessage(Server.BaseMessage msg)
        {
            var data = msg.Serialize();

            if (data.Count(x => x == 0) > 1)
            {
                Console.WriteLine($"Packet {msg.MessageId} has 0x0 in it.");
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
                    Console.WriteLine($"WARNING: Packet {msg.MessageId} has 0x0 in it. " +
                                      "This may cause bugs in the client.");
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
