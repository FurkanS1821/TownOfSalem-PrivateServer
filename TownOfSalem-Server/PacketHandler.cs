using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TownOfSalem_Logic.UserData;
using TownOfSalem_Networking;
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
        public static void HandleRequestLoadHomePage(INetworkService service, Client.BaseMessage message)
        {
            var data = (RequestLoadHomePage)message;

            if (data.BuildId != Program.BUILD_ID)
            {
                var disconnect = new DisconnectMessage(DisconnectMessage.DisconnectReason.OldVersion);
                service.SendMessage(disconnect);
                return;
            }

            var userData = PlayerManager.GetUserData(data.Username);
            var password = userData?.PasswordMd5;

            if (userData == null || password == null || !Crypto.VerifyPassword(password, data.PasswordEncrypted))
            {
                var disconnect = new DisconnectMessage(DisconnectMessage.DisconnectReason.InvalidUsernameOrPassword);
                service.SendMessage(disconnect);
                return;
            }

            var homePage = new LoadHomePageMessage(false);
            service.UserData = userData;

            var userStats = new UserStatisticsMessage(userData.UserStatistics);

            var settingsInfo = new SettingsInformationMessage(userData.UserSettings);

            var selectionSettings = new SelectionSettingsMessage(userData.UserSelections);

            var userInformation = new UserInformationMessage(
                userData.UserName,
                userData.TownPoints,
                userData.MeritPoints
            );

            var currencyMultiplier = new CurrencyMultiplierMessage(
                userData.TownPointsMultiplier,
                userData.MeritPointsMultiplier
            );

            var activeSpecialEvents = new ActiveSpecialEventsMessage(new List<SpecialEvent>());

            var lastBonusWinTime = new LastBonusWinTimeMessage(userData.LastBonusWinTime);

            var earnedAchievements = new EarnedAchievementsMessage(userData.EarnedAchievements);

            var purchasedCharacters = new PurchasedCharactersMessage(userData.PurchasedCharacters);

            var purchasedHouses = new PurchasedHousesMessage(userData.PurchasedHouses);

            var purchasedBackgrounds = new PurchasedBackgroundsMessage(userData.PurchasedBackgrounds);

            var purchasedPets = new PurchasedPetsMessage(userData.PurchasedPets);

            var friendIds = userData.FriendIds;
            var friendList = new List<Friend>();
            foreach (var friendId in friendIds)
            {
                var friendData = PlayerManager.GetUserData(friendId);
                if (friendData == null) // ?
                {
                    continue;
                }

                var friendClient = Program.AllConnectedClients.FirstOrDefault(x => x.UserData.UserId == friendData.UserId);
                var friend = new Friend
                {
                    AccountId = friendData.UserId,
                    OwnsCoven = friendData.UserAccountFlags.OwnsCoven,
                    Status = friendClient?.Status ?? ActivityStatus.Offline,
                    UserName = friendData.UserName
                };
                friendList.Add(friend);
            }

            var friendListPacket = new FriendListMessage(friendList);

            var purchasedLobbyIcons = new PurchasedLobbyIconsMessage(userData.PurchasedLobbyIcons);

            var purchasedDeathAnimations = new PurchasedDeathAnimationsMessage(userData.PurchasedDeathAnimations);

            var purchasedScrolls = new PurchasedScrollsMessage(userData.PurchasedScrolls);

            var tutorialStatus = new TutorialStatusMessage(userData.TutorialStatus);

            var activeGameModes = new ActiveGameModesMessage(new[] {1, 2, 3, 4, 6, 7, 8, 9, 10, 11, 12, 13, 14, 18, 19});

            var serverFlags = new ServerFlagsMessage(true);

            var accountFlags = new AccountFlagsMessage(userData.UserAccountFlags);

            var rankedInfo = new RankedInfoUpdateMessage(userData.RankedInformation);

            service.SendMessage(homePage);

            service.SendMultipleMessages(userStats, settingsInfo, selectionSettings, userInformation,
                currencyMultiplier, activeSpecialEvents, lastBonusWinTime, earnedAchievements, purchasedCharacters,
                purchasedHouses, purchasedBackgrounds, purchasedPets, friendListPacket, purchasedLobbyIcons,
                purchasedDeathAnimations, purchasedScrolls, tutorialStatus, activeGameModes, serverFlags, accountFlags,
                rankedInfo);
            Thread.Sleep(1000);
            service.SendMessage(new ReturnToHomeMessage());
        }

        public static void HandleSendAccountSetting(INetworkService service, Client.BaseMessage message)
        {
            var data = (AccountSettingMessage)message;

            // excuse me?
            var cauldronStatus = new CauldronStatusMessage(new List<int> {1, 2, 3, 4, 5, 6}, new List<ProductItem>(), 1,
                4, 7, false, 45311);
            service.SendMessage(cauldronStatus);
        }
    }
}
