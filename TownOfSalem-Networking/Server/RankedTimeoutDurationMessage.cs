using System;

namespace TownOfSalem_Networking.Server
{
    public class RankedTimeoutDurationMessage : BaseMessage
    {
        public readonly int Duration;

        public RankedTimeoutDurationMessage(byte[] data) : base(data)
        {
            try
            {
                Duration = int.Parse(BytesToString(data, 1));
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
