namespace TownOfSalem_Networking.Structs
{
    public class ModeratorMessageInfo
    {
        public string Username = string.Empty;
        public string Message = string.Empty;
        public int MessageId;
        public bool IsDeveloperModeOnly;
        public bool IsSuccess;
        public int AccountId;
        public int TownPoints;
        public int Elo;
        public int Suspensions;
        public int UserLevel;
        public int SteamId;
        public bool IsOn;
    }
}
