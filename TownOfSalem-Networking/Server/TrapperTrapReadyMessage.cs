using System;

namespace TownOfSalem_Networking.Server
{
    public class TrapperTrapReadyMessage : BaseMessage
    {
        public readonly TrapStatus Status;

        public TrapperTrapReadyMessage(byte[] data) : base(data)
        {
            try
            {
                Status = (TrapStatus)data[1];
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
