using System;

namespace TownOfSalem_Networking.Server
{
    public class UserStatisticsMessage : BaseMessage
    {
        public UserStatistics Statistics;

        public UserStatisticsMessage(byte[] data) : base(data)
        {
            try
            {
                var strArray = BytesToString(data, 1).Split('*');
                Statistics = new UserStatistics
                {
                    GamesPlayed = int.Parse(strArray[0]),
                    GamesWon = int.Parse(strArray[1]),
                    GamesDrawn = int.Parse(strArray[2]),
                    GamesDisconnected = int.Parse(strArray[3]),
                    FriendsReferred = int.Parse(strArray[4])
                };

                Statistics.GamesLost = Statistics.GamesPlayed - (Statistics.GamesWon + Statistics.GamesDrawn);
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
