using System;

namespace TownOfSalem_Networking.Server
{
    public class UserChangedVoteMessage : BaseMessage
    {
        public readonly int SourcePosition;
        public readonly int TargetPosition;
        public readonly int PreviousTargetPosition;
        public readonly int VoteCount;

        public UserChangedVoteMessage(byte[] data) : base(data)
        {
            try
            {
                SourcePosition = Convert.ToInt32(data[1]) - 1;
                TargetPosition = Convert.ToInt32(data[2]) - 1;
                PreviousTargetPosition = Convert.ToInt32(data[3]) - 1;
                VoteCount = Convert.ToInt32(data[4]);
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
