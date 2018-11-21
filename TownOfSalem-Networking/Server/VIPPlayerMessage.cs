using System;

namespace TownOfSalem_Networking.Server
{
    public class VIPPlayerMessage : BaseMessage
    {
        public readonly int Position;

        public VIPPlayerMessage(byte[] data) : base(data)
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
