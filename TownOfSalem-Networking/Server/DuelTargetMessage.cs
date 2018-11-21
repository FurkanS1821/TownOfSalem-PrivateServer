using System;

namespace TownOfSalem_Networking.Server
{
    public class DuelTargetMessage : BaseMessage
    {
        public readonly int Position;

        public DuelTargetMessage(byte[] data) : base(data)
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
