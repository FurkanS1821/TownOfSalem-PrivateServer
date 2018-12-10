using System.Collections.Generic;
using System.IO;
using System.Text;
using TownOfSalem_Networking.Enums;
using TownOfSalem_Networking.Structs;

namespace TownOfSalem_Networking.Server
{
    public class AfterGameScreenDataMessage : BaseMessage
    {
        public readonly List<EndGamePartyMemberInfo> PlayerList = new List<EndGamePartyMemberInfo>();
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
            writer.Write((byte)(EloChange + 1));
            writer.Write((byte)(MeritPointsAwarded + 1));

            for (var i = 0; i < PlayerList.Count; i++)
            {
                var partyMemberInfo = PlayerList[i];
                writer.Write('(');
                writer.Write(Encoding.UTF8.GetBytes(partyMemberInfo.OriginalName));
                writer.Write(',');
                writer.Write(Encoding.UTF8.GetBytes(partyMemberInfo.AccountName));
                writer.Write(',');
                writer.Write((byte)(partyMemberInfo.Position + 1));
                writer.Write(',');

                for (var j = 0; j < partyMemberInfo.Roles.Count; j++)
                {
                    writer.Write((byte)(partyMemberInfo.Roles[i] + 1));

                    if (j < partyMemberInfo.Roles.Count - 1)
                    {
                        writer.Write(',');
                    }
                }

                writer.Write(')');

                if (i < PlayerList.Count - 1)
                {
                    writer.Write(',');
                }
            }
        }
    }
}
