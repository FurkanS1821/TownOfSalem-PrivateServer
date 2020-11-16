using System;
using System.Collections.Generic;
using System.Linq;
using BCrypt.Net;
using TownOfSalem_Logic.UserData;
using TownOfSalem_Networking;
using TownOfSalem_Networking.Client.Global;
using TownOfSalem_Networking.Client.Home;
using TownOfSalem_Networking.Client.Login;
using TownOfSalem_Networking.Enums;
using TownOfSalem_Networking.Server;
using TownOfSalem_Networking.Structs;
using Client = TownOfSalem_Networking.Client;

namespace TownOfSalem_Logic
{
    public static class PacketHandler
    {
        public static void HandleRegisterAccount(INetworkService service, Client.BaseMessage message)
        {
            void Reply(RegistrationStatus reason)
            {
                var reply = new RegistrationResultMessage(reason);
                service.SendMessage(reply);
            }

            var packet = ((RegisterAccountMessage)message).Data;

            if (!Program.REGISTRATION_ENABLED)
            {
                Reply(RegistrationStatus.RegistrationDisabled);
                return;
            }

            var username = packet.Username.Trim();

            if (string.IsNullOrWhiteSpace(username) || username.Length < 3 || username.Length > 20)
            {
                Reply(RegistrationStatus.InvalidUsername);
                return;
            }

            var referer = packet.Referer.Trim();

            if (!string.IsNullOrWhiteSpace(referer) && PlayerManager.FindUser(referer) == null)
            {
                Reply(RegistrationStatus.InvalidReferAFriend);
                return;
            }

            var password = packet.Password;

            if (!StringUtils.IsPasswordValidFormat(password))
            {
                Reply(RegistrationStatus.InvalidPassword);
                return;
            }

            // well, using facebook and steam API to authenticate users are cool
            // but it is also hard so let's not do that right now

            if (PlayerManager.FindUser(packet.Username) != null)
            {
                Reply(RegistrationStatus.UsernameTaken);
                return;
            }

            try
            {
                var player = PlayerManager.CreateUser(username, BCrypt.Net.BCrypt.EnhancedHashPassword(password, HashType.SHA512));
                Reply(RegistrationStatus.Success);
                LogPlayerIn(player, service);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception in HandleRegisterUser with type {e.GetType().Name}: {e.Message}");
                Reply(RegistrationStatus.Failed);
            }
        }

        public static void HandleLogin(INetworkService service, Client.BaseMessage message)
        {
            void Disconnect(DisconnectMessage.DisconnectReason reason)
            {
                var disconnect = new DisconnectMessage(reason);
                service.SendMessage(disconnect);
            }
            var data = ((LoginMessage)message).Data;

            if (data.BuildId != Program.BUILD_ID)
            {
                Disconnect(DisconnectMessage.DisconnectReason.OldVersion);
                return;
            }

            var player = PlayerManager.FindUser(data.Username);
            var password = player?.Data.PasswordBcrypt;

            if (player == null || string.IsNullOrEmpty(password) || !Crypto.VerifyPassword(password, data.Password))
            {
                Disconnect(DisconnectMessage.DisconnectReason.InvalidUsernameOrPassword);
                return;
            }
            
            LogPlayerIn(player, service);
        }

        public static void LogPlayerIn(Player player, INetworkService service)
        {
            player.Client = service;
            player.LastAction = DateTime.Now; // so that we don't log in as AFK
            lock (Program.PendingConnectionsLock)
            {
                Program.PendingConnections.Remove(service);
            }

            var homePage = new LoadHomePageMessage(false);

            var messagesToSend = new List<BaseMessage>();

            messagesToSend.Add(new UserStatisticsMessage(player.Data.UserStatistics));

            messagesToSend.Add(new SettingsInformationMessage(player.Data.UserSettings));

            messagesToSend.Add(new SelectionSettingsMessage(player.Data.UserSelections));

            messagesToSend.Add(new UserInformationMessage(
                player.Data.UserName,
                player.Data.TownPoints,
                player.Data.MeritPoints,
                player.Data.UserId
            ));

            messagesToSend.Add(new CurrencyMultiplierMessage(
                player.Data.TownPointsMultiplier,
                player.Data.MeritPointsMultiplier
            ));

            messagesToSend.Add(new ActiveSpecialEventsMessage(new List<SpecialEvent>()));

            messagesToSend.Add(new LastBonusWinTimeMessage(player.Data.LastBonusWinTime));

            if (player.Data.EarnedAchievements.Any())
            {
                messagesToSend.Add(new EarnedAchievementsMessage(player.Data.EarnedAchievements.ToList()));
            }

            if (player.Data.PurchasedCharacters.Any())
            {
                messagesToSend.Add(new PurchasedCharactersMessage(player.Data.PurchasedCharacters.ToList()));
            }

            if (player.Data.PurchasedHouses.Any())
            {
                messagesToSend.Add(new PurchasedHousesMessage(player.Data.PurchasedHouses.ToList()));
            }

            if (player.Data.PurchasedBackgrounds.Any())
            {
                messagesToSend.Add(new PurchasedBackgroundsMessage(player.Data.PurchasedBackgrounds.ToList()));
            }

            if (player.Data.PurchasedPets.Any())
            {
                messagesToSend.Add(new PurchasedPetsMessage(player.Data.PurchasedPets.ToList()));
            }

            if (player.Data.PurchasedLobbyIcons.Any())
            {
                messagesToSend.Add(new PurchasedLobbyIconsMessage(player.Data.PurchasedLobbyIcons.ToList()));
            }

            if (player.Data.PurchasedDeathAnimations.Any())
            {
                messagesToSend.Add(new PurchasedDeathAnimationsMessage(player.Data.PurchasedDeathAnimations.ToList()));
            }

            if (player.Data.PurchasedScrolls.Any())
            {
                messagesToSend.Add(new PurchasedScrollsMessage(player.Data.PurchasedScrolls));
            }

            if (player.Data.TutorialStatus.Any())
            {
                messagesToSend.Add(new TutorialStatusMessage(player.Data.TutorialStatus.ToList()));
            }

            messagesToSend.Add(new ActiveGameModesMessage(new List<int> { 1, 2, 3, 4, 6, 7, 8, 9, 10, 11, 12, 13, 14, 18, 19 }));

            messagesToSend.Add(new ServerFlagsMessage(new List<bool> { true }));

            messagesToSend.Add(new AccountFlagsMessage(player.Data.UserAccountFlags));

            messagesToSend.Add(new RankedInfoUpdateMessage(player.Data.RankedInformation));

            // todo
            messagesToSend.Add(new CauldronStatusMessage(new List<int> {1, 2, 3, 4, 5, 6}, new List<ProductItem>(), 1,
                4, 7, false, 45311));

            var friendList = new List<Friend>();
            foreach (var friendData in player.FriendList)
            {
                var friend = new Friend(friendData.Data.UserName, friendData.Data.UserId,
                    friendData.Status, friendData.Data.UserAccountFlags.OwnsCoven);
                friendList.Add(friend);
            }

            messagesToSend.Add(new FriendListMessage(friendList));

            service.SendMessage(homePage);

            service.SendMultipleMessages(messagesToSend.ToArray());

            NotifyAllFriendsOfStatusUpdate(player);
        }

        public static void HandleSendAccountSetting(INetworkService service, Client.BaseMessage message)
        {
            var data = (AccountSettingMessage)message;
            var player = Program.GetPlayer(service);
            var settingType = data.SettingType;
            var settingValue = data.SettingValue;

            var property = typeof(UserSettings).GetField(settingType.ToString());

            if (property == null)
            {
                return;
            }

            property.SetValue(player.Data.UserSettings, settingValue);
        }

        public static void NotifyAllFriendsOfStatusUpdate(Player player)
        {
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
    }
}
