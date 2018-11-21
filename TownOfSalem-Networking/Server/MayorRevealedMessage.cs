using System;

namespace TownOfSalem_Networking.Server
{
    public class MayorRevealedMessage : BaseMessage
    {
        public readonly int Position;

        public MayorRevealedMessage(byte[] data) : base(data)
        {
            try
            {
                Position = Convert.ToInt32(data[1]) - 1;
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
