using System;
using System.Collections.Generic;

namespace TownOfSalem_Networking.Server
{
    public class JesterCompletedGoalMessage : BaseMessage
    {
        public readonly List<int> GuiltyVotePositions = new List<int>();

        public JesterCompletedGoalMessage(byte[] data) : base(data)
        {
            try
            {
                for (var index = 1; index < data.Length; ++index) GuiltyVotePositions.Add(data[index] - 1);
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
