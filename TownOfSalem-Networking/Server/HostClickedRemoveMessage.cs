using System;

namespace TownOfSalem_Networking.Server
{
    public class HostClickedRemoveMessage : BaseMessage
    {
        public readonly int Index;

        public HostClickedRemoveMessage(byte[] data) : base(data)
        {
            try
            {
                Index = data[1] - 1;
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
