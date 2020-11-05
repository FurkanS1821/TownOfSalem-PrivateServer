namespace TownOfSalem_Networking.Structs
{
    public class UserAccountFlags
    {
        public bool IsRestricted = true;
        public const int WEB_PREMIUM = 1;
        public const int COVEN = 2;
        public const int STEAM = 3;
        public const int MOBILE_PREMIUM = 5;
        public const int IS_RESTRICTED = 7;
        public bool IsOnSteam;
        public bool OwnsSteam;
        public bool OwnsCoven;
        public bool OwnsWebPremium;
        public bool OwnsMobilePremium;
        public bool IsTrial;
        public bool WasTrial;
    }
}
