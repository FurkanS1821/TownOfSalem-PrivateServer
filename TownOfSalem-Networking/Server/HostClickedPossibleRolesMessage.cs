using System;

namespace TownOfSalem_Networking.Server
{
    public class HostClickedPossibleRolesMessage : BaseMessage
    {
        public readonly int Selected;

        public HostClickedPossibleRolesMessage(byte[] data) : base(data)
        {
            try
            {
                Selected = data[1];
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
