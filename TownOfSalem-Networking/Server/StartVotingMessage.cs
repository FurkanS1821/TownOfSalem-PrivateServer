using System;

namespace TownOfSalem_Networking.Server
{
    public class StartVotingMessage : BaseMessage
    {
        public readonly int TimeRemainingSeconds;

        public StartVotingMessage(byte[] data) : base(data)
        {
            try
            {
                TimeRemainingSeconds = Convert.ToByte(data[1]);
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
