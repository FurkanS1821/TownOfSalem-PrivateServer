using System;

namespace TownOfSalem_Networking.Server
{
    public class GhoulRottedMessage : BaseMessage
    {
        public readonly int Position;

        public GhoulRottedMessage(byte[] data) : base(data)
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
