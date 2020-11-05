using System.IO;
using System.Text;
using TownOfSalem_Networking.Structs;

namespace TownOfSalem_Networking.Server
{
    public class UserStatisticsMessage : BaseMessage
    {
        public UserStatistics Statistics;

        public UserStatisticsMessage(UserStatistics statistics) : base(MessageType.UserStatistics)
        {
            Statistics = statistics;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            var data = $"{Statistics.GamesPlayed}*{Statistics.GamesWon}*{Statistics.GamesDrawn}*";
            data += $"{Statistics.GamesDisconnected}*{Statistics.FriendsReferred}";

            writer.Write(Encoding.UTF8.GetBytes(data));
        }
    }
}