using System;
using System.Collections.Generic;

namespace TownOfSalem_Networking.Server
{
    public class AfterGameScreenUserInfoMessage : BaseMessage
    {
        public readonly Dictionary<int, EndGamePartyMemberStatus> UserState =
            new Dictionary<int, EndGamePartyMemberStatus>();

        public AfterGameScreenUserInfoMessage(byte[] data) : base(data)
        {
            try
            {
                var index = 1;
                while (index < data.Length)
                {
                    UserState.Add(data[index] - 1, (EndGamePartyMemberStatus) data[index + 2]);
                    index += 4;
                }
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
