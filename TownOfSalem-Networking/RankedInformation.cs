namespace TownOfSalem_Networking
{
    public class RankedInformation
    {
        public int SeasonRating = -1;
        public int PreviousSeasonRating = -1;
        public int PreviousSeasonHigh = -1;
        public const int PRACTICE_GAMES_REQUIRED = 10;
        public const int TOTAL_GAMES_REQUIRED = 50;
        public int GameMode;
        public int PracticeGamesPlayed;
        public int CareerWin;
        public int CareerLoss;
        public int CareerDraw;
        public int CareerLeaves;
        public int CareerHighRating;
        public int SeasonNumber;
        public bool IsOffseason;
        public int PlacementGamesRequired;
        public int SeasonWins;
        public int SeasonLosses;
        public int SeasonDraws;
        public int SeasonLeaves;
        public int SeasonHighRating;

        public int RankedGamesPlayed()
        {
            return SeasonWins + SeasonLosses + SeasonDraws;
        }

        public bool InPlacementMatches()
        {
            return RankedGamesPlayed() < PlacementGamesRequired;
        }

        public bool FinishedPlacementMatchesThisGame()
        {
            return RankedGamesPlayed() == PlacementGamesRequired;
        }

        public bool IsRankedPlayQualified(uint totalGamesPlayed)
        {
            return totalGamesPlayed >= 50U && PracticeGamesPlayed >= 10;
        }
    }
}
