using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TownOfSalem_Logic.UserData;
using TownOfSalem_Networking;
using TownOfSalem_Networking.Client.Friend;
using TownOfSalem_Networking.Client.Home;
using TownOfSalem_Networking.Client.Lobby;
using TownOfSalem_Networking.Client.Login;
using TownOfSalem_Networking.Enums;
using TownOfSalem_Networking.Server;
using TownOfSalem_Networking.Structs;
using Client = TownOfSalem_Networking.Client;

namespace TownOfSalem_Logic
{
    public static class PacketHandler
    {
        public static void HandleRequestLoadHomePage(INetworkService service, Client.BaseMessage message)
        {
            var data = (RequestLoadHomePage)message;

            if (data.BuildId != Program.BUILD_ID)
            {
                var disconnect = new DisconnectMessage(DisconnectMessage.DisconnectReason.OldVersion);
                service.SendMessage(disconnect);
                return;
            }

            var player = PlayerManager.FindUser(data.Username);
            var password = player?.Data.PasswordMd5;

            if (player == null || password == null || !Crypto.VerifyPassword(password, data.PasswordEncrypted))
            {
                var disconnect = new DisconnectMessage(DisconnectMessage.DisconnectReason.InvalidUsernameOrPassword);
                service.SendMessage(disconnect);
                return;
            }

            player.Client = service;
            lock (Program.PendingConnectionsLock)
            {
                Program.PendingConnections.Remove(service);
            }

            var homePage = new LoadHomePageMessage(false);

            var userStats = new UserStatisticsMessage(player.Data.UserStatistics);

            var settingsInfo = new SettingsInformationMessage(player.Data.UserSettings);

            var selectionSettings = new SelectionSettingsMessage(player.Data.UserSelections);

            var userInformation = new UserInformationMessage(
                player.Data.UserName,
                player.Data.TownPoints,
                player.Data.MeritPoints
            );

            var currencyMultiplier = new CurrencyMultiplierMessage(
                player.Data.TownPointsMultiplier,
                player.Data.MeritPointsMultiplier
            );

            var activeSpecialEvents = new ActiveSpecialEventsMessage(new List<SpecialEvent>());

            var lastBonusWinTime = new LastBonusWinTimeMessage(player.Data.LastBonusWinTime);

            var earnedAchievements = new EarnedAchievementsMessage(player.Data.EarnedAchievements);

            var purchasedCharacters = new PurchasedCharactersMessage(player.Data.PurchasedCharacters);

            var purchasedHouses = new PurchasedHousesMessage(player.Data.PurchasedHouses);

            var purchasedBackgrounds = new PurchasedBackgroundsMessage(player.Data.PurchasedBackgrounds);

            var purchasedPets = new PurchasedPetsMessage(player.Data.PurchasedPets);

            var purchasedLobbyIcons = new PurchasedLobbyIconsMessage(player.Data.PurchasedLobbyIcons);

            var purchasedDeathAnimations = new PurchasedDeathAnimationsMessage(player.Data.PurchasedDeathAnimations);

            var purchasedScrolls = new PurchasedScrollsMessage(player.Data.PurchasedScrolls);

            var tutorialStatus = new TutorialStatusMessage(player.Data.TutorialStatus);

            var activeGameModes = new ActiveGameModesMessage(new[] {1, 2, 3, 4, 6, 7, 8, 9, 10, 11, 12, 13, 14, 18, 19});

            var serverFlags = new ServerFlagsMessage(true);

            var accountFlags = new AccountFlagsMessage(player.Data.UserAccountFlags);

            var rankedInfo = new RankedInfoUpdateMessage(player.Data.RankedInformation);

            // todo
            var cauldronStatus = new CauldronStatusMessage(new List<int> {1, 2, 3, 4, 5, 6}, new List<ProductItem>(), 1,
                4, 7, false, 45311);

            var friendList = new List<Friend>();
            foreach (var friendData in player.FriendList)
            {
                var friend = new Friend
                {
                    AccountId = friendData.Data.UserId,
                    OwnsCoven = friendData.Data.UserAccountFlags.OwnsCoven,
                    Status = friendData.Status,
                    UserName = friendData.Data.UserName
                };
                friendList.Add(friend);
            }

            var friendListPacket = new FriendListMessage(friendList);

            service.SendMessage(homePage);

            service.SendMultipleMessages(userStats, settingsInfo, selectionSettings, userInformation,
                currencyMultiplier, activeSpecialEvents, lastBonusWinTime, earnedAchievements, purchasedCharacters,
                purchasedHouses, purchasedBackgrounds, purchasedPets, purchasedLobbyIcons, purchasedDeathAnimations,
                purchasedScrolls, tutorialStatus, activeGameModes, serverFlags, accountFlags, rankedInfo,
                cauldronStatus, friendListPacket);

            NotifyAllFriendsOfStatusUpdate(service);
        }

        public static void HandleSendAccountSetting(INetworkService service, Client.BaseMessage message)
        {
            var data = (AccountSettingMessage)message;
            var player = Program.GetPlayer(service);

            switch (data.SettingType)
            {
                case UserSettings.Type.ChatFilterEnabled:
                case UserSettings.Type.SoundEffectsMuted:
                case UserSettings.Type.MusicMuted:
                case UserSettings.Type.HideCustomizationsEnabled:
                case UserSettings.Type.ClassicSkinsOnlyEnabled:
                case UserSettings.Type.HidePetsEnabled:
                    typeof(UserSettings).GetProperty(data.SettingType.ToString())?.SetValue(
                        player.Data.UserSettings, data.SettingValue == 2
                    );
                    break;
                case UserSettings.Type.DisplaySteamPopup:
                    break;
                case UserSettings.Type.SoundEffectsVolume:
                case UserSettings.Type.MusicVolume:
                    typeof(UserSettings).GetProperty(data.SettingType.ToString())?.SetValue(
                        player.Data.UserSettings, data.SettingValue / 100f
                    );
                    break;
                case UserSettings.Type.UILanguage:
                case UserSettings.Type.QueueLanguage:
                case UserSettings.Type.TutorialBehavior:
                    typeof(UserSettings).GetProperty(data.SettingType.ToString())?.SetValue(
                        player.Data.UserSettings, data.SettingValue
                    );
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public static void HandleJoinGame(INetworkService service, Client.BaseMessage message)
        {
            var data = (JoinGameMessage)message;
            var player = Program.GetPlayer(service);

            if (player.CurrentPartyLobby != null)
            {
                // todo: solo start logic
                NotifyAllFriendsOfStatusUpdate(service);
                return;
            }

            var brand = ((GameMode)data.GameMode).ToString().StartsWith("Coven") ? GameBrand.Coven : GameBrand.Normal;
            player.CurrentPartyLobby.SetGameMode(brand, (GameMode)data.GameMode);
            player.CurrentPartyLobby.StartGame();
            NotifyAllFriendsOfStatusUpdate(service);
        }

        public static void HandlePartyCreate(INetworkService service, Client.BaseMessage message)
        {
            var data = (PartyCreateMessage)message;
            var player = Program.GetPlayer(service);

            lock (Program.LobbiesLock)
            {
                var gameMode = data.GameBrand == (int)GameBrand.Coven ? GameMode.CovenClassic : GameMode.Classic;
                var lobby = new PartyLobby((GameBrand)data.GameBrand, gameMode, player);
                Program.LiveLobbies.Add(lobby);
                player.CurrentPartyLobby = lobby;
            }

            NotifyAllFriendsOfStatusUpdate(service);
        }

        public static void HandlePartyLeave(INetworkService service, Client.BaseMessage message)
        {
            var player = Program.GetPlayer(service);

            player.CurrentPartyLobby?.LeaveLobby(player);
            NotifyAllFriendsOfStatusUpdate(service);
        }

        private static void NotifyAllFriendsOfStatusUpdate(INetworkService service)
        {
            var player = Program.GetPlayer(service);

            foreach (var friend in player.FriendList)
            {
                if (friend.Client == null)
                {
                    continue;
                }

                var packet = new FriendUpdateMessage(
                    player.Data.UserId,
                    player.Status,
                    player.Data.UserAccountFlags.OwnsCoven
                );

                friend.Client.SendMessage(packet);
            }
        }

        public static void HandleHostSetPartyConfig(INetworkService service, Client.BaseMessage message)
        {
            var data = (HostSetPartyConfig)message;
            var player = Program.GetPlayer(service);

            player.CurrentPartyLobby?.SetGameMode((GameBrand)data.Brand, (GameMode)data.GameMode);
        }

        public static void HandlePartyInvite(INetworkService service, Client.BaseMessage message)
        {
            var data = (PartyInviteMessage)message;
            var player = Program.GetPlayer(service);

            player.CurrentPartyLobby?.InviteUser(player, data.Username);
        }

        public static void HandlePartyResponse(INetworkService service, Client.BaseMessage message)
        {
            var data = (PartyResponseMessage)message;
            var player = Program.GetPlayer(service);

            PartyLobby lobby;
            PendingPartyInviteStatusMessage update;
            lock (Program.LobbiesLock)
            {
                lobby = Program.LiveLobbies.Find(x => x.Id == data.PartyId);
            }

            PartyMemberInviteStatus inviteStatus;

            switch (data.Response)
            {
                case PartyResponse.Deny:
                    inviteStatus = PartyMemberInviteStatus.Denied;
                    break;
                case PartyResponse.Accept:
                    inviteStatus = PartyMemberInviteStatus.Accepted;
                    break;
                case PartyResponse.Loading:
                    inviteStatus = PartyMemberInviteStatus.Loading;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            lobby.Invites[player] = inviteStatus;
            update = new PendingPartyInviteStatusMessage(lobby.Invites[player], player.Data.UserName);
            foreach (var member in lobby.ConnectedPlayers)
            {
                member.Client?.SendMessage(update);
            }

            if (inviteStatus == PartyMemberInviteStatus.Accepted)
            {
                lobby.JoinPlayer(player);
            }
        }

        public static void HandlePartyChangeHost(INetworkService service, Client.BaseMessage message)
        {
            var data = (PartyChangeHostMessage)message;
            var player = Program.GetPlayer(service);

            if (!player.IsPartyHost)
            {
                return;
            }

            var playerToTransferHost = PlayerManager.FindUser(data.Username);
            player.CurrentPartyLobby.TransferHost(player, playerToTransferHost);
        }

        public static void HandlePartyGiveInvitePrivileges(INetworkService service, Client.BaseMessage message)
        {
            var data = (PartyGiveInvitePrivilegesMessage)message;
            var player = Program.GetPlayer(service);

            if (!player.IsPartyHost)
            {
                return;
            }

            var playerToGivePrivileges = PlayerManager.FindUser(data.Username);
            player.CurrentPartyLobby.GiveInvitePrivileges(playerToGivePrivileges);
        }

        public static void HandlePartyKick(INetworkService service, Client.BaseMessage message)
        {
            var data = (PartyKickMessage)message;
            var player = Program.GetPlayer(service);

            if (!player.IsPartyHost)
            {
                return;
            }

            var playerToKick = PlayerManager.FindUser(data.Username);
            player.CurrentPartyLobby.KickPlayer(playerToKick);
        }

        public static void HandlePartyMessage(INetworkService service, Client.BaseMessage message)
        {
            var data = (PartyMessage)message;
            var player = Program.GetPlayer(service);

            player.CurrentPartyLobby.SendChatMessage(player, data.Message);
        }
    }
}
