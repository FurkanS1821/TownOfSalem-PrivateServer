using System.IO;
using System.Text;

namespace TownOfSalem_Networking.Server
{
    public class HowManyPlayersAndGamesMessage : BaseMessage
    {
        public readonly int PlayerCount;
        public readonly int GameCount;

        public HowManyPlayersAndGamesMessage(int playerCount, int gameCount) : base(MessageType.HowManyPlayersAndGames)
        {
            PlayerCount = playerCount;
            GameCount = gameCount;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write(Encoding.UTF8.GetBytes(PlayerCount.ToString()));
            writer.Write('*');
            writer.Write(Encoding.UTF8.GetBytes(GameCount.ToString()));
        }
    }
}
