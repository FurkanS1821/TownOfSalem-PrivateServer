using System;
using System.Collections.Generic;
using System.Text;

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

        public AfterGameScreenDataMessage(byte[] data) : base(data)
        {
            try
            {
                var num1 = Array.IndexOf<byte>(data, 44);
                EndGameTimeSeconds = int.Parse(Encoding.UTF8.GetString(data, 1, num1 - 1));
                GameMode = Convert.ToInt32(data[num1 + 1]);
                WinningGroup = Convert.ToInt32(data[num1 + 2]);
                GameResult = Convert.ToInt32(data[num1 + 3]) < 2 ? EndGameResult.Loss : EndGameResult.Win;
                EloChange = Convert.ToInt32(data[num1 + 4]) - 1;
                MeritPointsAwarded = Convert.ToInt32(data[num1 + 5]) - 1;
                var num2 = Array.IndexOf<byte>(data, 40);
                var str1 = Encoding.ASCII.GetString(data, num2 + 1, data.Length - num2 - 2);
                var separator = new[] {"),("};
                foreach (var str2 in str1.Split(separator, StringSplitOptions.None))
                {
                    var chArray = new[] {','};
                    var strArray = str2.Split(chArray);
                    var gamePartyMemberInfo = new EndGamePartyMemberInfo(
                        strArray[0],
                        strArray[1],
                        strArray[2].ToCharArray()[0] - 1,
                        EndGamePartyMemberStatus.Default
                    );

                    for (var i = 3; i < strArray.Length; ++i)
                    {
                        gamePartyMemberInfo.Roles.Add(strArray[i].ToCharArray()[0] - 1);
                    }

                    PlayerList.Add(gamePartyMemberInfo);
                }
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
