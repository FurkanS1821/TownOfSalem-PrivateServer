using System;

namespace TownOfSalem_Networking.Server
{
    public class PlaugeSpreadMessage : BaseMessage
    {
        public readonly int Position;

        public PlaugeSpreadMessage(byte[] data) : base(data)
        {
            try
            {
                Position = data[1] - 1;
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
