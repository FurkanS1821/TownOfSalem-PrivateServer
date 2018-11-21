using System;

namespace TownOfSalem_Networking.Server
{
    public class HostClickedAddMessage : BaseMessage
    {
        public readonly int RoleId;

        public HostClickedAddMessage(byte[] data) : base(data)
        {
            try
            {
                RoleId = data[1] - 1;
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
