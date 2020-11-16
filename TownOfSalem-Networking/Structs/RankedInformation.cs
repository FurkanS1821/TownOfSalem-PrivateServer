namespace TownOfSalem_Networking.Structs
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
        public int CareerWins;
        public int CareerLosses;
        public int CareerDraws;
        public int CareerLeaves;
        public int CareerHighRating;
        public int SeasonNumber;
        public bool IsOffSeason;
        public int PlacementGamesRequired;
        public int SeasonWins;
        public int SeasonLosses;
        public int SeasonDraws;
        public int SeasonLeaves;
        public int SeasonHighRating;

        public int RankedGamesSeasonPlayed()
        {
            return SeasonWins + SeasonLosses + SeasonDraws;
        }

        public int RankedGamesCareerPlayed()
        {
            return CareerWins + CareerLosses + CareerDraws;
        }

        public bool InPlacementMatches()
        {
            return RankedGamesSeasonPlayed() < PlacementGamesRequired;
        }

        public bool FinishedPlacementMatchesThisGame()
        {
            return RankedGamesSeasonPlayed() == PlacementGamesRequired;
        }

        public bool IsRankedPlayQualified(uint totalGamesPlayed)
        {
            return totalGamesPlayed >= TOTAL_GAMES_REQUIRED && PracticeGamesPlayed >= PRACTICE_GAMES_REQUIRED;
        }
    }
}
