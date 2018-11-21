using System;

namespace TownOfSalem_Networking.Server
{
    public class UserCanceledVoteMessage : BaseMessage
    {
        public readonly int SourcePosition;
        public readonly int TargetPosition;
        public readonly int VoteCount;

        public UserCanceledVoteMessage(byte[] data) : base(data)
        {
            try
            {
                SourcePosition = Convert.ToInt32(data[1]) - 1;
                TargetPosition = Convert.ToInt32(data[2]) - 1;
                VoteCount = Convert.ToInt32(data[3]);
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
