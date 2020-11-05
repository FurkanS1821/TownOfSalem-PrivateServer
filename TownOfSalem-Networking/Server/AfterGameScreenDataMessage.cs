using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TownOfSalem_Networking.Enums;
using TownOfSalem_Networking.Structs;

namespace TownOfSalem_Networking.Server
{
    public class AfterGameScreenDataMessage : BaseMessage
    {
        public readonly List<EndGamePartyMemberInfo> PlayerList;
        public readonly int EndGameTimeSeconds;
        public readonly int GameMode;
        public readonly int WinningGroup;
        public readonly EndGameResult GameResult;
        public readonly int EloChange;
        public readonly int MeritPointsAwarded;

        public AfterGameScreenDataMessage(List<EndGamePartyMemberInfo> playerList, int endGameTimeSeconds, int gameMode,
            int winningGroup, EndGameResult gameResult, int eloChange, int meritPointsAwarded)
            : base(MessageType.AfterGameScreenData)
        {
            PlayerList = playerList;
            EndGameTimeSeconds = endGameTimeSeconds;
            GameMode = gameMode;
            WinningGroup = winningGroup;
            GameResult = gameResult;
            EloChange = eloChange;
            MeritPointsAwarded = meritPointsAwarded;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write(Encoding.UTF8.GetBytes(EndGameTimeSeconds.ToString()));
            writer.Write(',');
            writer.Write((byte)GameMode);
            writer.Write((byte)WinningGroup);
            writer.Write((byte)(GameResult == EndGameResult.Win ? 2 : 1));
            writer.Write((byte)(EloChange + 1)); // this will be multiplied by -1 client side if game is lost
            writer.Write((byte)(MeritPointsAwarded + 1));

            var packetContents = new List<string>();
            foreach (var player in PlayerList)
            {
                var data = $"({player.OriginalName},{player.AccountName},{(char)(byte)(player.Position + 1)},";
                var roles = player.Roles.Select(x => (char)(byte)(x + 1));
                data += string.Join(",", roles) + ")";
                packetContents.Add(data);
            }

            writer.Write(Encoding.UTF8.GetBytes(string.Join(",", packetContents)));
        }
    }
}