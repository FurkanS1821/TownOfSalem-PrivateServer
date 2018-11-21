using System;

namespace TownOfSalem_Networking.Server
{
    public class UserVotedMessage : BaseMessage
    {
        public readonly int SourcePosition;
        public readonly int TargetPosition;
        public readonly int VoteCount;

        public UserVotedMessage(byte[] data) : base(data)
        {
            try
            {
                SourcePosition = data[1] - 1;
                TargetPosition = data[2] - 1;
                VoteCount = data[3];
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
