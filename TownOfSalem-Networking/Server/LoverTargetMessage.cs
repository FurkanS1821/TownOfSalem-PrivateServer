using System;

namespace TownOfSalem_Networking.Server
{
    public class LoverTargetMessage : BaseMessage
    {
        public readonly int Position;

        public LoverTargetMessage(byte[] data) : base(data)
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
