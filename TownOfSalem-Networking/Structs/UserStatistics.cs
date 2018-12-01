namespace TownOfSalem_Networking.Structs
{
    public struct UserStatistics
    {
        public int GamesPlayed;
        public int GamesWon;
        public int GamesLost => GamesPlayed - (GamesWon + GamesDrawn);
        public int GamesDrawn;
        public int GamesDisconnected;
        public int FriendsReferred;
    }
}
