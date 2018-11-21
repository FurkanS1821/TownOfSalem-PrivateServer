using System;

namespace TownOfSalem_Networking.Server
{
    public class VotedRepickHostMessage : BaseMessage
    {
        public readonly int VotesNeeded;

        public VotedRepickHostMessage(byte[] data) : base(data)
        {
            try
            {
                VotesNeeded = data[1] - 1;
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
