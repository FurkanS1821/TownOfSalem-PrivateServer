using System.Collections.Generic;
using System.IO;
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
            foreach (var userState in UserStates)
            {
                writer.Write((byte)(userState.Key + 1));
                writer.Write(',');
                writer.Write((byte)userState.Value);
                writer.Write(';');
            }
        }
    }
}