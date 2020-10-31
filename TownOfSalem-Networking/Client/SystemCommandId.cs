using System.Runtime.InteropServices;

namespace TownOfSalem_Networking.Client
{
    [StructLayout(LayoutKind.Sequential, Size = 1)]
    public struct SystemCommandId
    {
        public static int AllMessage = 1;
        public static int GameMessage = 2;
        public static int Ban = 3;
        public static int Identify = 4;
        public static int Restart = 5;
        public static int CancelRestart = 6;
        public static int GrantPoints = 7;
        public static int Suspend = 8;
        public static int ReloadXML = 9;
        public static int Whisper = 10;
        public static int UnBan = 11;
        public static int AccountInfo = 12;
        public static int GrantAchievement = 13;
        public static int DevLogin = 14;
        public static int RequestPromotion = 15;
        public static int ResetAccount = 16;
        public static int GrantCharacter = 17;
        public static int GrantBackground = 18;
        public static int GrantDeathAnimation = 19;
        public static int GrantHouse = 20;
        public static int GrantLobbyIcon = 21;
        public static int GrantPack = 22;
        public static int GrantPet = 23;
        public static int GrantScroll = 24;
        public static int TutorialProgress = 25;
        public static int ReloadPromotionXML = 26;
        public static int GrantPromotion = 27;
        public static int SetRole = 28;
        public static int GrantAccountItem = 29;
        public static int ForceNameChange = 30;
        public static int GrantMerits = 31;
        public static int SetFreeCurrencyMultiplier = 32;
        public static int GrantReferAFriend = 33;
        public static int ReloadCaches = 34;
        public static int ResetCauldronCooldown = 35;
        public static int ToggleTestPurchases = 36;
        public static int ToggleServerFlag = 37;
        public static int ToggleUserCoven = 38;
        public static int ToggleUserWebPremium = 38;
        public static int ToggleUserMobilePremium = 38;
        public static int UnlinkSteam = 39;
        public static int UnlinkCoven = 40;
        public static int GrantCoven = 41;
        public static int GrantWebPremium = 42;
        public static int KickUser = 43;
        public static int GrantMobilePremium = 44;
        public static int IpBan = 45;
        public static int GrantUnrestricted = 46;
    }
}