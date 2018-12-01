using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TownOfSalem_Networking.Enums;

namespace TownOfSalem_Networking.Server
{
    public class AfterGameScreenUserInfoMessage : BaseMessage
    {
        public readonly Dictionary<int, EndGamePartyMemberStatus> UserStates;

        public AfterGameScreenUserInfoMessage(Dictionary<int, EndGamePartyMemberStatus> userStates)
            : base(MessageType.AfterGameScreenUserInfo)
        {
            UserStates = userStates;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            for (var i = 0; i < UserStates.Count; i++)
            {
                var userState = UserStates.ElementAt(i);
                writer.Write((byte)(userState.Key + 1));
                writer.Write(',');
                writer.Write((byte)userState.Value);

                if (i < UserStates.Count - 1)
                {
                    writer.Write(Encoding.UTF8.GetBytes("**"));
                }
            }
        }
    }
}
