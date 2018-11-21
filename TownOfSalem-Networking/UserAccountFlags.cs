namespace TownOfSalem_Networking
{
    public class UserAccountFlags
    {
        public bool IsRestricted = true;
        public const int OWNS_WEB_PREMIUM = 1;
        public const int OWNS_COVEN = 2;
        public const int OWNS_STEAM = 3;
        public const int OWNS_MOBILE_PREMIUM = 5;
        public const int IS_RESTRICTED = 7;
        public bool OwnsSteam;
        public bool OwnsCoven;
        public bool OwnsWebPremium;
        public bool OwnsMobilePremium;
    }
}
