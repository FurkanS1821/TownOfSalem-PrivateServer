using System;

namespace TownOfSalem_Networking.Server
{
    public class RivalTargetMessage : BaseMessage
    {
        public readonly int Position;

        public RivalTargetMessage(byte[] data) : base(data)
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
