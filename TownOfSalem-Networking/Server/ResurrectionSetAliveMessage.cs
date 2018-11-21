using System;

namespace TownOfSalem_Networking.Server
{
    public class ResurrectionSetAliveMessage : BaseMessage
    {
        public readonly int Position;

        public ResurrectionSetAliveMessage(byte[] data) : base(data)
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
