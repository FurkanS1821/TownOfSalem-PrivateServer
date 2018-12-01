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
            writer.Write(Encoding.UTF8.GetBytes(Statistics.GamesPlayed.ToString()));
            writer.Write('*');
            writer.Write(Encoding.UTF8.GetBytes(Statistics.GamesWon.ToString()));
            writer.Write('*');
            writer.Write(Encoding.UTF8.GetBytes(Statistics.GamesDrawn.ToString()));
            writer.Write('*');
            writer.Write(Encoding.UTF8.GetBytes(Statistics.GamesDisconnected.ToString()));
            writer.Write('*');
            writer.Write(Encoding.UTF8.GetBytes(Statistics.FriendsReferred.ToString()));
        }
    }
}
