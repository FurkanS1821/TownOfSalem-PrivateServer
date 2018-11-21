using System;

namespace TownOfSalem_Networking.Server
{
    public class DisconnectMessage : BaseMessage
    {
        public readonly int Reason;

        public DisconnectMessage(byte[] data) : base(data)
        {
            try
            {
                Reason = data[1] - 1;
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
